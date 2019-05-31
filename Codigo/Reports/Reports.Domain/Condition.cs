using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public enum Operator { EQ, LT, GT, LE, GE };

    public class Condition : BaseCondition
    {
        public Guid? ValueIzqId { get; set; }
        public virtual Value ValueIzq { get; set; }

        public Guid? ValueDerId { get; set; }
        public virtual Value ValueDer { get; set; }

        public Operator ConditionOperator {get;set;}
        public override bool IsValid()
        {
            return ValueIzq != null && ValueDer != null 
                && ValueDer.IsValid() && ValueIzq.IsValid();
        }
        public override bool Eval(string areaConnectionStr)
        {
            if(ConditionOperator == Operator.EQ)
            {
                return ValueIzq.Equal(ValueDer, areaConnectionStr);
            }
            else if (ConditionOperator == Operator.LT)
            {
                return ValueIzq.LessThan(ValueDer, areaConnectionStr);

            }
            else if (ConditionOperator == Operator.GT)
            {
                return ValueIzq.GreaterThan(ValueDer, areaConnectionStr);
            }
            else if (ConditionOperator == Operator.LE)
            {
                return ValueIzq.LessEqualThan(ValueDer, areaConnectionStr);
            }
            else if (ConditionOperator == Operator.GE)
            {
                return ValueIzq.GreaterEqualThan(ValueDer, areaConnectionStr);
            }
            return false;
        }
        public override string GetResult(string areaConnectionStr)
        {
            if (ConditionOperator == Operator.EQ)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " == " + strDer;
            }
            else if (ConditionOperator == Operator.LT)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " < " + strDer;
            }
            else if (ConditionOperator == Operator.GT)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " > " + strDer;
            }
            else if (ConditionOperator == Operator.LE)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " <= " + strDer;
            }
            else if (ConditionOperator == Operator.GE)
            {
                string strIzq = this.ValueIzq.GetResult(areaConnectionStr);
                string strDer = this.ValueDer.GetResult(areaConnectionStr);
                return strIzq + " >= " + strDer;
            }
            return "";
        }


    }
}
