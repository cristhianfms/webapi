using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class BoolValue : Value
    {
        public bool Data { get; set; }

        public override object Eval(string areaConnectionStr)
        {
            return Data;
        }
        public override bool IsValid()
        {
            return Data != null;
        }
        public override string GetResult(string areaConnectionStr)
        {
            return Data.ToString();
        }
        public override bool Equal(Value aValue, string areaConnectionStr)
        {
            try
            {
                bool otherBool = (bool)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherBool) == 0;
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
                bool otherBool = (bool)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherBool) >= 0;
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
                bool otherBool = (bool)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherBool) > 0;
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
                bool otherBool = (bool)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherBool) <= 0;
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
                bool otherBool = (bool)aValue.Eval(areaConnectionStr);
                return Data.CompareTo(otherBool) < 0;
            }
            catch (Exception e)
            {
                throw new DomainException("Values types can not be compare", e);
            }
        }
    }
}
