using System;
using System.Collections.Generic;
using System.Text;
using Reports.Logger.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class LogModel : Model<Log, LogModel>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }


        public LogModel() { }

        public LogModel(Log entity)
        {
            SetModel(entity);
        }

        public override Log ToEntity()
        {
            return new Log()
            {
                Id = this.Id,
                UserName = this.UserName,
                Date = this.Date,
                Action = this.Action,
            };

        }

        protected override LogModel SetModel(Log entity)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
            this.Date = entity.Date;
            this.Action = entity.Action;
            return this;
        }
    }
}

