using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public static class DTOConverter
    {
        public static BaseConditionModel ConvertToConditionModel(BaseCondition baseCondition)
        {
            if(baseCondition is AndCondition)
            {
                return new AndConditionModel(baseCondition);
            }
            if(baseCondition is OrCondition)
            {
                return  new OrConditionModel(baseCondition);
            }
            if(baseCondition is Condition)
            {
                return  new ConditionModel(baseCondition);
            }
            return  new BaseConditionModel(baseCondition);
        }


        public static ValueModel ConvertToValueModel(Value value)
        {
            if(value is IntValue)
            {
                return  new IntValueModel(value);
            }
            if (value is StringValue)
            {
                return new StringValueModel(value);
            }
            if (value is SQLValue)
            {
                return new SQLValueModel(value);
            }
            return new ValueModel(value);
        }
    }
}
