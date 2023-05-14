using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Entites;
using Services;

namespace Repository
{
    public class RatingRepository: IRatingRepository
    {
    public string _storeWebsiteContext { get; set; }
        public RatingRepository(IConfiguration configuration)
        {
            _storeWebsiteContext = configuration.GetConnectionString("School");
        }
        public async Task Rate(Rating rating)
        {
            string query = "INSERT INTO [dbo].[RATING] ([HOST] ,[METHOD],[PATH],[REFERER],[USER_AGENT],[RECORD_DATE])"
            + "VALUES(@Host, @Method, @Path, @Referer, @UserAgent,@RecordDate)";
        using (SqlConnection connection = new SqlConnection(_storeWebsiteContext))
        using(SqlCommand sqlCommand = new SqlCommand(query,connection))
            {
                sqlCommand.Parameters.Add("@Host", SqlDbType.VarChar, 50).Value = rating.Host;
                sqlCommand.Parameters.Add("@Method", SqlDbType.VarChar, 10).Value = rating.Method;
                sqlCommand.Parameters.Add("@Path", SqlDbType.VarChar, 50).Value = rating.Path;
                sqlCommand.Parameters.Add("@Referer", SqlDbType.NVarChar, 100).Value = rating.Referer;
                sqlCommand.Parameters.Add("@UserAgent", SqlDbType.NVarChar, int.MaxValue).Value = rating.UserAgent;
                sqlCommand.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = rating.RecordoDate;

                await connection.OpenAsync();
                int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
                    }

    }
}
