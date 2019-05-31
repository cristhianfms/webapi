using System;
using System.Collections.Generic;
using System.Text;
using Reports.DBConnections;
using System.Data;

namespace Reports.Domain
{
    public class SQLValue : Value
    {
        public string Query { get; set; }

        public override object Eval(string areaConnectionStr)
        {
            try
            {
                IDBConnectionExcecuter DBConn = new DBConnectionExcecuter();
                DBConn.SetConnectionString(areaConnectionStr);
                DBConn.SetQuerySQL(Query);
                DataSet dset = DBConn.GetResult();

                return dset.Tables[0].Rows[0][0];
            }
            catch (DBConnectionException e)
            {
                throw new DomainException("Error in sql excecution", e);
            }
        }
        public override bool IsValid()
        {
            return Query != null && Query != "";
        }
        public override string GetResult(string areaConnectionStr)
        {
            object result = Eval(areaConnectionStr);
            return "(" + result.ToString() + ")";
        }
        public override bool Equal(Value aValue, string areaConnectionStr)
        {
            try
            {
                 return IntEqual(aValue, areaConnectionStr);
            }catch
            {
                try { 
                    return BoolEqual(aValue, areaConnectionStr);
                }
                catch
                {
                    try
                    {
                        return StringEqual(aValue, areaConnectionStr);
                    }
                    catch (Exception e)
                    {
                        throw new DomainException("Values types can not be compare", e);
                    }
                }
            }
        }
        public override bool GreaterThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                return IntGreater(aValue, areaConnectionStr);
            }
            catch
            {
                try
                {
                    return BoolGreater(aValue, areaConnectionStr);
                }
                catch
                {
                    try
                    {
                        return StringGreater(aValue, areaConnectionStr);
                    }
                    catch (Exception e)
                    {
                        throw new DomainException("Values types can not be compare", e);
                    }
                }
            }
        }
        public override bool LessThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                return IntLess(aValue, areaConnectionStr);
            }
            catch
            {
                try
                {
                    return BoolLess(aValue, areaConnectionStr);
                }
                catch
                {
                    try
                    {
                        return StringLess(aValue, areaConnectionStr);
                    }
                    catch (Exception e)
                    {
                        throw new DomainException("Values types can not be compare", e);
                    }
                }
            }
        }
        public override bool GreaterEqualThan(Value aValue, string areaConnectionStr)
        {

            try
            {
                return IntGreaterEqual(aValue, areaConnectionStr);
            }
            catch
            {
                try
                {
                    return BoolGreaterEqual(aValue, areaConnectionStr);
                }
                catch
                {
                    try
                    {
                        return StringGreaterEqual(aValue, areaConnectionStr);
                    }
                    catch (Exception e)
                    {
                        throw new DomainException("Values types can not be compare", e);
                    }
                }
            }
        }
        public override bool LessEqualThan(Value aValue, string areaConnectionStr)
        {
            try
            {
                return IntLessEqual(aValue, areaConnectionStr);
            }
            catch
            {
                try
                {
                    return BoolLessEqual(aValue, areaConnectionStr);
                }
                catch
                {
                    try
                    {
                        return StringLessEqual(aValue, areaConnectionStr);
                    }
                    catch (Exception e)
                    {
                        throw new DomainException("Values types can not be compare", e);
                    }
                }
            }
        }
            

        private bool IntEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((int)queryResult) == (int)aValue.Eval(areaConnectionStr);
        }
        private bool BoolEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((bool)queryResult) == (bool)aValue.Eval(areaConnectionStr);
        }
        private bool StringEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((string)queryResult) == (string)aValue.Eval(areaConnectionStr);
        }


        private bool IntGreater(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((int)queryResult) > (int)aValue.Eval(areaConnectionStr);
        }
        private bool BoolGreater(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            bool bool1 = ((bool)queryResult);
            bool bool2 = (bool)aValue.Eval(areaConnectionStr);
            return bool1.CompareTo(bool2) > 0;
        }
        private bool StringGreater(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            string string1 = (string)queryResult;
            string string2 = (string)aValue.Eval(areaConnectionStr);
            return string1.CompareTo(string2) > 0;
        }


        private bool IntLess(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((int)queryResult) < (int)aValue.Eval(areaConnectionStr);
        }
        private bool BoolLess(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            bool bool1 = ((bool)queryResult);
            bool bool2 = (bool)aValue.Eval(areaConnectionStr);
            return bool1.CompareTo(bool2) < 0;
        }
        private bool StringLess(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            string string1 = (string)queryResult;
            string string2 = (string)aValue.Eval(areaConnectionStr);
            return string1.CompareTo(string2) < 0;
        }


        private bool IntGreaterEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((int)queryResult) >= (int)aValue.Eval(areaConnectionStr);
        }
        private bool BoolGreaterEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            bool bool1 = ((bool)queryResult);
            bool bool2 = (bool)aValue.Eval(areaConnectionStr);
            return bool1.CompareTo(bool2) >= 0;
        }
        private bool StringGreaterEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            string string1 = (string)queryResult;
            string string2 = (string)aValue.Eval(areaConnectionStr);
            return string1.CompareTo(string2) >= 0;
        }


        private bool IntLessEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            return ((int)queryResult) <= (int)aValue.Eval(areaConnectionStr);
        }
        private bool BoolLessEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            bool bool1 = ((bool)queryResult);
            bool bool2 = (bool)aValue.Eval(areaConnectionStr);
            return bool1.CompareTo(bool2) <= 0;
        }
        private bool StringLessEqual(Value aValue, string areaConnectionStr)
        {
            object queryResult = Eval(areaConnectionStr);
            string string1 = (string)queryResult;
            string string2 = (string)aValue.Eval(areaConnectionStr);
            return string1.CompareTo(string2) <= 0;
        }


    }
}
