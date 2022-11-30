using EasyTravel.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.AddOpinionToTour
{
    public class AddOpinionToTourCommandHandler : IRequestHandler<AddOpinionToTourCommand>
    {
        private ICurrentUserService _userService;
        public AddOpinionToTourCommandHandler(ICurrentUserService userService)
        {
            _userService = userService;
        }
        public async Task<Unit> Handle(AddOpinionToTourCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Create_opinion]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@rating", SqlDbType.Int).Value = request.Rating;
                    sqlCommand.Parameters.Add("@comment", SqlDbType.NVarChar).Value = request.Comment;
                    sqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime).Value = request.DateTimeAddingOpinion;
                    sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = request.IdTour;
                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = _userService.Email;

                    sqlCommand.ExecuteNonQuery();
                }
                await sqlConnection.CloseAsync();

            }

            return Unit.Value;
        }
    }
}
