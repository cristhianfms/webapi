using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;


namespace Reports.Webapi.Models
{
    public class ConditionModel : Model<Condition, ConditionModel>
    {
        public string Operator { get; set; }
        public string ValueIzq { get; set; }
        public string TypeIzq { get; set; }
        public string ValueDer { get; set; }
        public string TypeDer { get; set; }

        public ConditionModel() { }

        public ConditionModel(Condition entity)
        {
            SetModel(entity);
        }

        public override Condition ToEntity()
        {
            return new Condition()
            {
                Operator = this.Operator,
                ValueIzq = ToValue(TypeIzq, ValueIzq),
                ValueDer = ToValue(TypeDer, ValueDer)
            };
        }

        private Value ToValue(string type, string value) {
            Value valueExp = new IntValue();
            if (type == "int")
            {
                return valueExp = new IntValue()
                {
                    Data = int.Parse(value)
                };
            }
            else if( type == "sql")
            {
                valueExp = new SQLValue()
                {
                    Data = value,
                };
            }
            else if(type == "str")
            {
                valueExp = new StringValue()
                {
                    Data = value
                };
            }
            return valueExp;
        }


        protected override ConditionModel SetModel(Condition entity)
        {
            this.Operator = entity.Operator;
            this.ValueIzq = entity.ValueIzq.Display();
            this.ValueDer = entity.ValueDer.Display();
            this.TypeIzq = GetValueType(entity.ValueIzq);
            this.TypeDer = GetValueType(entity.ValueDer);
            return this;
        }


        private string GetValueType(Value entity)
        {
            string type = "";
            if (entity.GetType().Name == "SQLValue" 
                || entity.GetType().Name == "SQLValueProxy")
            {
                type = "sql";
            }
            else if (entity.GetType().Name == "IntValue" ||
                entity.GetType().Name == "IntValueProxy")
            {
                type = "int";
            }
            else if (entity.GetType().Name == "StringValue" ||
                entity.GetType().Name == "StringValueProxy")
            {
                type = "str";
            }
            return type;
        }


    }

}
