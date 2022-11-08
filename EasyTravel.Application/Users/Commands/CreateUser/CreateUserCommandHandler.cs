using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Create_user]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = request.Email;
                    sqlCommand.Parameters.Add("@registration_date", SqlDbType.DateTime).Value = request.RegistrationDate;
                    sqlCommand.Parameters.Add("@last_login_date", SqlDbType.DateTime).Value = request.RecentLoginDate;

                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();

            }

            return Unit.Value;
        }
    }
}
