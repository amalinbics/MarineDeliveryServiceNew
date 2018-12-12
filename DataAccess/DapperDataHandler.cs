using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utlity;
using QueryBase;
namespace DataAccess
{
    public class DapperDataHandler : IDataHandler, IDisposable
    {
        private readonly IQueryFetch queryHandler;
        private readonly ILogging logging;
        public DapperDataHandler(IQueryFetch queryHandler, ILogging logging)
        {
            this.queryHandler = queryHandler;
            this.logging = logging;
        }

        DynamicParameters parameters;
        private CommandType _cmdType = CommandType.StoredProcedure;
        public CommandType CommandType
        {
            get
            {
                return _cmdType;
            }
            set
            {
                _cmdType = value;
            }
        }

        private string _connectionName;
        public string ConnectionStringName
        {
            get
            {
                return _connectionName;
            }

            set
            {
                _connectionName = value;
            }
        }

        public void AddParameter<T>(string name, T value)
        {
            if (parameters == null)
                parameters = new DynamicParameters();
            parameters.Add("@" + name, value);
        }

        public Result Fetch<T, U>(U cmd)
        {
            Result result = new Result();
            try
            {
                var functionParameter = new DynamicParameters();
                functionParameter = parameters;
                parameters = null;

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString))
                {
                    var queryResult = db.Query<T>(queryHandler.GetQuery(cmd), functionParameter == null ? null : functionParameter, commandTimeout: 120, commandType: CommandType).ToList();
                    result.Source = queryResult;
                    result.AffectedRows = queryResult.Count();
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"Fetch - {cmd} - { ConnectionStringName } " + ex.Message);
                result.Message = ex.Message;
                result.Success = false;
                result.AffectedRows = 0;
            }
            return result;
        }

        public Result Fetch<T>(T cmd)
        {
            Result result = new Result();
            try
            {
                var functionParameter = new DynamicParameters();
                functionParameter = parameters;
                parameters = null;

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString))
                {
                    var queryResult = db.QueryMultiple(queryHandler.GetQuery(cmd), functionParameter == null ? null : functionParameter,commandType: CommandType);
                    var listResult = queryResult.Read<ProcResult>().ToList();
                    result.Source = listResult[0];
                    result.Success = true;                    
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"Fetch - {cmd} - { ConnectionStringName }  " + ex.Message);
                result.Message = ex.Message;
                result.Success = false;
                result.AffectedRows = 0;
            }
            return result;
        }


        public async Task<Result> FetchMany<T>(T cmd)
        {
            Result result = new Result();
            var functionParameter = new DynamicParameters();
            try
            {

                functionParameter = parameters;
                parameters = null;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString))
                {
                    var query = await db.QueryMultipleAsync(queryHandler.GetQuery(cmd), functionParameter == null ? null : functionParameter,commandTimeout:2 ,commandType: CommandType);
                    var listResult = query.Read<ProcResult>().ToList();
                    result.Source = listResult[0];
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"FetchMany - {cmd} - { ConnectionStringName } " + ex.Message);
                foreach (string item in functionParameter.ParameterNames)
                {
                    logging.WriteErrorLog($"FetchMany - {item} ");
                }

                result.Message = ex.Message;
                result.Success = false;
                result.AffectedRows = 0;
            }


            return result;
        }

        public Result Update<T>(T cmd)
        {
            Result result = new Result();
            try
            {
                var functionParameter = new DynamicParameters();
                functionParameter = parameters;
                parameters = null;

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString))
                {
                    var queryResult = db.Execute(queryHandler.GetQuery(cmd), functionParameter == null ? null : functionParameter, commandTimeout: 2, commandType: CommandType);
                    result.Source = queryResult;
                    result.AffectedRows = queryResult;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"Update - {cmd} - { ConnectionStringName } " + ex.Message);
                result.Success = false;
                result.AffectedRows = 0;
                result.Message = ex.Message;
            }
            return result;
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public Result FetchScalar<T>(T cmd)
        {
            Result result = new Result();
            try
            {
                var functionParameter = new DynamicParameters();
                functionParameter = parameters;
                parameters = null;

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString))
                {
                    var queryResult = db.ExecuteScalar(queryHandler.GetQuery(cmd), functionParameter == null ? null : functionParameter, commandTimeout: 2, commandType: CommandType);
                    result.Scalar = queryResult;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"Update - {cmd} - { ConnectionStringName } " + ex.Message);
                result.Success = false;
                result.AffectedRows = 0;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
