using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.DeleteTourTag
{
    public class DeleteTourTagCommandHandler : IRequestHandler<DeleteTourTagCommand>
    {
        public async Task<Unit> Handle(DeleteTourTagCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Delete_tour_tag]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id_tag", SqlDbType.Int).Value = request.Id;

                    sqlCommand.ExecuteNonQuery();
                }
                await sqlConnection.CloseAsync();

            }

            return Unit.Value;
        }
    }
}
