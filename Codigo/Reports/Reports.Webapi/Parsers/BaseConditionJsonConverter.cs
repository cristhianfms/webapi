using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Reports.Webapi.Models;


namespace Reports.Webapi.Parsers
{
    public class BaseConditionJsonConverter : JsonCreationConverter<BaseConditionModel>
    {
        protected override BaseConditionModel Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException("jObject");
            }
            if (jObject["StudentId"] != null)
            {
                return new StudentModel();
            }
            if (jObject["TeacherId"] != null)
            {
                return new TeacherModel();
            }
            return new UserModel();
        }
    }
}
