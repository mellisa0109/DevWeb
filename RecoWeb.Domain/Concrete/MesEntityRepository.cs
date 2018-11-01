using System;
using System.Collections.Generic;
using System.Linq;
using RecoWeb.Domain.Abstract;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace RecoWeb.Domain.Concrete
{
    public class MesEntityRepository : IMesEntityRepository
    {
        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecowebdbEntities"].ConnectionString);
            // Properly initialize your connection here.
            return connection;
        }

        /// <summary>
        /// IList를 반환한다(반환시 List는 DapperRow로 반환되며 반환된 DapperRow를 해당 POCO Class로 Cast 해줘야 사용이 가능하다.)
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<T> CallProcudureToReturnList<T>(string procedureName, DynamicParameters parameters)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var values = connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();

                    return values;
                }
            }
            catch(Exception ex)
            {
                IList<T> error = new List<T>();
                error.Add((T)Convert.ChangeType(ex.Message.ToString(), typeof(T)));
                return error;
            }
        }

        public int CallProcudureToReturnMessage(string procedureName, DynamicParameters parameters)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var values = connection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();

                    return values;
                }
            }
            catch(Exception ex)
            {
                return 9;
            }
        }
    }
}
