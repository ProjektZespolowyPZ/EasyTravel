using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.UpdateLoginDate
{
    public class UpdateLoginDateCommandHandler : IRequestHandler<UpdateLoginDateCommand>
    {
        public async Task<Unit> Handle(UpdateLoginDateCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Update_login]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = request.Email;
                    sqlCommand.Parameters.Add("@last_login_date", SqlDbType.DateTime).Value = request.RecentLogin;

                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();

            }

            return Unit.Value;
        }
    }
}
