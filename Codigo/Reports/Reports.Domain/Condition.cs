using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    

    public class Condition : BaseCondition
    {
        public Guid? ValueIzqId { get; set; }
        public virtual Value ValueIzq { get; set; }

        public Guid? ValueDerId { get; set; }
        public virtual Value ValueDer { get; set; }

        public string Operator {get;set;}

        public override bool IsValid()
        {
            return ValueIzq != null && ValueDer != null 
                && ValueDer.IsValid() && ValueIzq.IsValid();
        }
        public override bool Eval(string areaConnectionStr)
        {
            if(Operator == ConditionType.EQ)
            {
                return ValueIzq.Equal(ValueDer, areaConnectionStr);
            }
            else if (Operator == ConditionType.LT)
            {
                return ValueIzq.LessThan(ValueDer, areaConnectionStr);

            }
            else if (Operator == ConditionType.GT)
            {
                return ValueIzq.GreaterThan(ValueDer, areaConnectionStr);
            }
            else if (Operator == ConditionType.LE)
            {
                return ValueIzq.LessEqualThan(ValueDer, areaConnectionStr);
            }
            else if (Operator == ConditionType.GE)
            {
                return ValueIzq.GreaterEqualThan(ValueDer, areaConnectionStr);
            }
            return false;
        }
        public override string GetResult(string areaConnectionStr)
        {
            if (Operator == ConditionType.EQ)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " == " + strDer;
            }
            else if (Operator == ConditionType.LT)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " < " + strDer;
            }
            else if (Operator == ConditionType.GT)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " > " + strDer;
            }
            else if (Operator == ConditionType.LE)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " <= " + strDer;
            }
            else if (Operator == ConditionType.GE)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " >= " + strDer;
            }
            return "";
        }


    }
}
