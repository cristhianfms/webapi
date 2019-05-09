using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;


namespace Reports.Webapi.Models
{
    public class ConditionModel : Model<Condition, ConditionModel>
    {
        public string Operation { get; set; }
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
                Operation = this.Operation,
                ValueIzq = ToValueExpression(TypeIzq, ValueIzq),
                ValueDer = ToValueExpression(TypeDer, ValueDer)
            };
        }

        private ValueExpression ToValueExpression(string type, string value) {
            ValueExpression valueExp = new IntValue();
            if (type == "int")
            {
                return valueExp = new IntValue()
                {
                    Value = value
                };
            }
            else if( type == "sql")
            {
                valueExp = new SQLValue()
                {
                    Value = value,
                };
            }
            else if(type == "str")
            {
                valueExp = new StringValue()
                {
                    Value = value
                };
            }
            return valueExp;
        }


        protected override ConditionModel SetModel(Condition entity)
        {
            this.Operation = entity.Operation;
            this.ValueIzq = entity.ValueIzq.Value;
            this.ValueDer = entity.ValueDer.Value;
            this.TypeIzq = GetValueExpressionType(entity.ValueIzq);
            this.TypeDer = GetValueExpressionType(entity.ValueDer);
            return this;
        }

        private string GetValueExpressionType(ValueExpression entity)
        {
            string type = "";
            if (entity.GetType().Name == "SQLValue")
            {
                type = "sql";
            }
            else if (entity.GetType().Name == "IntValue")
            {
                type = "int";
            }
            else if (entity.GetType().Name == "StringValue")
            {
                type = "str";
            }
            return type;
        }


    }

}
