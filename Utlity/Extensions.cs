using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    public static class Extensions 
    {

        public static bool IsStringEmpty(this string input)
        {
            bool output = false;
            try
            {
                output = string.IsNullOrEmpty(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static int ToInteger(this string input)
        {
            int output = 0;
            try
            {
                output = Int32.Parse(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
              //  Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static float ToFloat(this string input)
        {
            float output = 0;
            try
            {
                output = float.Parse(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
              //  Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static double ToDouble(this string input)
        {
            double output = 0;
            try
            {
                output = double.Parse(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static decimal ToDecimal(this string input)
        {
            decimal output = 0;
            try
            {
                output = decimal.Parse(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
               // Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static char ToChar(this string input)
        {
            char output = ' ';
            try
            {
                output = char.Parse(input);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
               // Logger.WriteLog(ex.Message);
            }
            return output;
        }

        public static object AssignValues(this DataRow dr, object obj)
        {
            DataColumnCollection dcc = dr.Table.Columns;
            string name = string.Empty;
            // Logger.WriteLog(" AssignValues - " + obj.GetType().Name);
            obj = Activator.CreateInstance(obj.GetType());
            foreach (var item in obj.GetType().GetProperties())
            {
                name = item.Name;
                if (dcc.Contains(name))
                {
                    object propValue = null;
                    if (dr[name].GetType().FullName == "System.Byte[]")
                    {
                        propValue = System.Text.Encoding.UTF8.GetString((byte[])dr[name]);
                    }
                    else
                    {
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                        propValue = typeConverter.ConvertFromString(dr[name].ToString().Trim());
                    }
                    if (propValue == null)
                    {
                        if (item.PropertyType.FullName.Contains("System.Int32"))
                        {
                            propValue = 0;
                        }
                        else if (item.PropertyType.FullName.Contains("System.System.Double"))
                        {
                            propValue = double.Parse("0");
                        }
                        else if (item.PropertyType.FullName.Contains("System.Decimal"))
                        {
                            propValue = decimal.Parse("0");
                        }
                        else if (item.PropertyType.FullName.Contains("System.Single"))
                        {
                            propValue = Single.Parse("0");
                        }
                    }
                    item.SetValue(obj, propValue, null);
                }
            }
            return obj;
        }

        public static List<object> AssignValues(this DataTable dt, object obj)
        {
            string name = string.Empty;
            List<object> objects = new List<object>();
            //  Logger.WriteLog(" AssignValues - " + obj.GetType().Name);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DataColumnCollection dcc = dt.Columns;
                    name = string.Empty;
                    obj = Activator.CreateInstance(obj.GetType());
                    foreach (var item in obj.GetType().GetProperties())
                    {
                        name = item.Name;
                        if (dcc.Contains(name))
                        {
                            TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                            object propValue = typeConverter.ConvertFromString(dr[name].ToString());

                            if (propValue == null)
                            {
                                if (item.PropertyType.FullName.Contains("System.Int32"))
                                {
                                    propValue = 0;
                                }
                                else if (item.PropertyType.FullName.Contains("System.System.Double"))
                                {
                                    propValue = double.Parse("0");
                                }
                                else if (item.PropertyType.FullName.Contains("System.Decimal"))
                                {
                                    propValue = decimal.Parse("0");
                                }
                                else if (item.PropertyType.FullName.Contains("System.Single"))
                                {
                                    propValue = Single.Parse("0");
                                }
                            }
                            item.SetValue(obj, propValue, null);
                        }
                    }
                    objects.Add(obj);
                }
            }

            return objects;
        }

        public static string EncodeString(this string str)
        {
            if (str != null)
            {
                str = str.Trim();
                if (!str.IsStringEmpty())
                {
                    if (str.Contains("&"))
                    {
                        str = str.Replace("&", "&amp;");
                    }
                    if (str.Contains("<"))
                    {
                        str = str.Replace("<", "&lt;");
                    }
                    if (str.Contains(">"))
                    {
                        str = str.Replace(">", "&gt;");
                    }
                    if (str.Contains("\""))
                    {
                        str = str.Replace("\"", "&quot;");
                    }
                    if (str.Contains("'"))
                    {
                        str = str.Replace("'", "&#39;");
                    }
                    //if (str.Contains("'"))
                    //{
                    //    str = str.Replace("'", "''");
                    //}
                    if (str.Contains("/"))
                    {
                        str = str.Replace("/", "&#x2F;");
                    }
                }
            }
            return str;
        }

        public static string ToUTFString(this byte[] img)
        {
             return Encoding.UTF8.GetString(img);
        }


    }
}
