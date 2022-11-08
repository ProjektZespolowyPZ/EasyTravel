using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.UpdateAvatar
{
    public class UpdateAvatarCommandHandler : IRequestHandler<UpdateAvatarCommand>
    {
        public async Task<Unit> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Update_avatar]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = request.Id;
                    sqlCommand.Parameters.Add("@profile_picture", SqlDbType.NVarChar).Value = request.Avatar;

                    sqlCommand.ExecuteNonQuery();
                }
                await sqlConnection.CloseAsync();

            }

            return Unit.Value;
        }
    }
}
