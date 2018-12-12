using System.Collections.Generic;
using Utlity;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace MarineDeliveryServiceNew
{
    public static class ServiceUtility
    {
        public static List<T> EncodeObjects<T>(List<T> listValue)
        {
            var inputType = typeof(T);

            var inputProperties = inputType.GetProperties();
            foreach (var listItem in listValue)
            {
                foreach (var prop in inputProperties)
                {
                    string name = prop.Name;
                    if (prop.PropertyType.FullName.Contains("System.String"))
                    {
                        if (inputType.GetProperty(name).GetValue(listItem) != null)
                        {
                            var value = inputType.GetProperty(name).GetValue(listItem);
                            inputType.GetProperty(name).SetValue(listItem, value.ToString().EncodeString());
                        }
                    }
                    //else if (prop.PropertyType.FullName.Contains("System.Byte[]"))
                    //{
                    //    if (inputType.GetProperty(name).GetValue(listItem) != null)
                    //    {
                    //        var imgValue = inputType.GetProperty(name).GetValue(listItem);
                    //        inputType.GetProperty(name).SetValue(listItem, Encoding.UTF8.GetString((byte[])imgValue));
                    //    }
                    //}
                }
            }
            return listValue;
        }



        public static string ToJsonString<T>(T jsonValue)
        {
            var jsonSerialiser = new JavaScriptSerializer() { MaxJsonLength = 999999999 };
            string jsonIgnoreNullValues = JsonConvert.SerializeObject(jsonValue, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return jsonIgnoreNullValues;
        }


        //private void Update<T>(string dbName, T parameter, string sp)
        //{
        //    try
        //    {
        //        _dataHandler.ConnectionStringName = dbName;
        //        _dataHandler.AddParameter<string>("JsonValue", ToJsonString<T>(parameter));
        //        var Marineresult = _dataHandler.FetchMany(sp);
        //        var result = ((ProcResult)Marineresult.Source);
        //        if (result.StatusNew.ToLower() != Common.Status.success.ToString())
        //        {
        //            _logging.WriteErrorLog(string.Format("{0} - {1}", sp, result.Reason));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logging.WriteErrorLog(sp + " " + ex.Message);
        //    }


        //}


    }
}
