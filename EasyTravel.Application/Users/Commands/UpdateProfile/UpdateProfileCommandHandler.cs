using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Update_user]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = request.Id;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = request.Name;
                    sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar).Value = request.Surname;
                    sqlCommand.Parameters.Add("@profile_picture", SqlDbType.NVarChar).Value = request.ProfilePicture;
                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = request.Email;
                    sqlCommand.Parameters.Add("@phone_number", SqlDbType.NVarChar).Value = request.PhoneNumber;

                    sqlCommand.ExecuteNonQuery();
                }
                await sqlConnection.CloseAsync();

            }
            return Unit.Value;
        }
    }
}
