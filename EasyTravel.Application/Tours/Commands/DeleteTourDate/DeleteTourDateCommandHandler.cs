using EasyTravel.Application.Tours.Commands.DeleteTour;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.DeleteTourDate
{
    public class DeleteTourDateCommandHandler : IRequestHandler<DeleteTourDateCommand>
    {
        public async Task<Unit> Handle(DeleteTourDateCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Delete_tour_date]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id_tour_date", SqlDbType.Int).Value = request.Id;

                    sqlCommand.ExecuteNonQuery();
                }
                await sqlConnection.CloseAsync();

            }

            return Unit.Value;
        }
    }
}
