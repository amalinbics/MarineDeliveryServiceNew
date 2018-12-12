using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utlity;

namespace DataAccess
{
   public interface IDataHandler
    {
        string ConnectionStringName { get; set; }
        CommandType CommandType { get; set; }
        void AddParameter<T>(string name, T value);
        Result Fetch<T,U>(U cmd);
        Result Fetch<T>(T cmd);
        Result Update<T>(T cmd);
        Task<Result> FetchMany<T>(T cmd);
        Result FetchScalar<T>(T cmd);
    }
}
