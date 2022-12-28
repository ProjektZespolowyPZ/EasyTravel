using EasyTravel.Application.Users.Commands.UpdateProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.EditTour
{
    public class EditTourCommandHandler : IRequestHandler<EditTourCommand>
    {
        public async Task<Unit> Handle(EditTourCommand request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Update_tour]";
            const string PROCEDURE_NAME2 = "[dbo].[Update_tour_dates]";
            const string PROCEDURE_NAME3 = "[dbo].[Update_tour_photo]";
            const string PROCEDURE_NAME4 = "[dbo].[Update_tour_tag]";
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = request.Id;
                    sqlCommand.Parameters.Add("@meeting_place", SqlDbType.NVarChar).Value = request.MeetingPlace;
                    sqlCommand.Parameters.Add("@end_place", SqlDbType.NVarChar).Value = request.EndPlace;
                    sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = request.Description;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = request.Name;
                    sqlCommand.Parameters.Add("@length", SqlDbType.NVarChar).Value = request.Length;
                    sqlCommand.Parameters.Add("@main_photo", SqlDbType.NVarChar).Value = request.MainPhoto;
                    sqlCommand.Parameters.Add("@map_photo", SqlDbType.NVarChar).Value = request.MapPhoto;

                    sqlCommand.ExecuteNonQuery();
                }

                foreach (var item in request.TourDates)
                {
                    if (item.Id != 0)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME2, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                        {

                            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = item.Id;
                            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = item.TourDate;
                            sqlCommand.Parameters.Add("@price", SqlDbType.Float).Value = item.Price;
                            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.Password;
                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("[dbo].[Create_tour_dates]", sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                        {

                            sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = request.Id;
                            sqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime).Value = item.TourDate;
                            sqlCommand.Parameters.Add("@price", SqlDbType.Float).Value = item.Price;
                            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.Password;
                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                }

                foreach (var item in request.TourPhotos)
                {
                    if(item.Id != 0)
                    using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME3, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                    {

                        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = item.Id;
                        sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = item.TourPhoto;

                        sqlCommand.ExecuteNonQuery();

                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("[dbo].[Create_tour_photos]", sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                        {

                            sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = request.Id;
                            sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = item.TourPhoto;

                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                }

                foreach (var item in request.TourTags)
                {
                    if (item.Id != 0)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME4, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                        {

                            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = item.Id;
                            sqlCommand.Parameters.Add("@tag", SqlDbType.NVarChar).Value = item.Tag;

                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("[dbo].[Create_tags]", sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                        {

                            sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = request.Id;
                            sqlCommand.Parameters.Add("@tag", SqlDbType.NVarChar).Value = item.Tag;

                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                }
                await sqlConnection.CloseAsync();

            }
            return Unit.Value;
        }
    }
}
