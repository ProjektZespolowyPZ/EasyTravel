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

namespace EasyTravel.Application.Tours.Commands.CreateTour
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, int>
    {
        private ICurrentUserService _userService;
        public CreateTourCommandHandler(ICurrentUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME1 = "[dbo].[Create_tour]";
            const string PROCEDURE_NAME2 = "[dbo].[Create_tour_dates]";
            const string PROCEDURE_NAME3 = "[dbo].[Create_tour_photos]";
            const string PROCEDURE_NAME4 = "[dbo].[Create_tags]";
            SqlParameter idTourSQL;
            int idTour;
            
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME1, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    idTourSQL = new SqlParameter("@id_Tour", SqlDbType.Int);
                    idTourSQL.Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(idTourSQL);

                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = _userService.Email;
                    sqlCommand.Parameters.Add("@meeting_place", SqlDbType.NVarChar).Value = request.MeetingPlace;
                    sqlCommand.Parameters.Add("@end_place", SqlDbType.NVarChar).Value = request.EndPlace;
                    sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = request.Description;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = request.Name;
                    sqlCommand.Parameters.Add("@length", SqlDbType.NVarChar).Value = request.Length;
                    sqlCommand.Parameters.Add("@main_photo", SqlDbType.NVarChar).Value = request.MainPhoto;
                    sqlCommand.Parameters.Add("@map_photo", SqlDbType.NVarChar).Value = request.MapPhoto;

                    sqlCommand.ExecuteNonQuery();

                }

                idTour = Convert.ToInt32(idTourSQL.Value);

                foreach (var item in request.TourDates)
                {

                    using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME2, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                    {

                        sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = idTour;
                        sqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime).Value = item.TourDate;
                        sqlCommand.Parameters.Add("@price", SqlDbType.Float).Value = item.Price;
                        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.Password;                        
                        sqlCommand.ExecuteNonQuery();

                    }
                }

                foreach (var item in request.TourPhotos)
                {

                    using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME3, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                    {

                        sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = idTour;
                        sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = item.TourPhoto;

                        sqlCommand.ExecuteNonQuery();

                    }
                }

                foreach (var item in request.TourTags)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME4, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                    {

                        sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = idTour;
                        sqlCommand.Parameters.Add("@tag", SqlDbType.NVarChar).Value = item.Tag;

                        sqlCommand.ExecuteNonQuery();

                    }
                }
                await sqlConnection.CloseAsync();

            }
            
            return idTour;
        }
    }
}
