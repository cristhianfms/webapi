using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class StringValue : Value
    {
        public string Data { get; set; }

        public override object Eval(string areaConnectionStr)
        {
            return Data;
        }
        public override bool IsValid()
        {
            return Data != null && Data !="";
        }
        public override string GetResult(string areaConnectionStr)
        {
            return Data;
        }
        public override bool Equal(Value aValue, string areaConnectionStr)
        {
            try
            {
                string otherString = (string)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherString) == 0;
            }
            catch(Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
        public override bool GreaterEqualThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                string otherString = (string)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherString) >= 0;
            }
            catch (Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
        public override bool GreaterThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                string otherString = (string)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherString) > 0;
            }
            catch (Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
        public override bool LessEqualThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                string otherString = (string)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherString) <= 0;
            }
            catch (Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
        public override bool LessThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                string otherString = (string)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherString) < 0;
            }
            catch (Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
    }
}
