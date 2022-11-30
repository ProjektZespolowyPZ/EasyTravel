using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Queries.GetTour
{
    public class GetTourQueryHandler : IRequestHandler<GetTourQuery, TourVm>
    {
        public async Task<TourVm> Handle(GetTourQuery request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Display_tour_details]";
            TourVm tour = new TourVm();
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id_tour", SqlDbType.Int).Value = request.TourId;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        while (sqlDataReader.Read())
                        {

                            tour.Id = sqlDataReader.GetInt32("Id");
                            tour.UserName = sqlDataReader.GetString("UserName");
                            tour.Surname = sqlDataReader.GetString("Surname");
                            tour.ProfilePicture = sqlDataReader.GetString("Profile_picture");
                            tour.Email = sqlDataReader.GetString("Contact_email");
                            tour.PhoneNumber = sqlDataReader.GetString("Phone_number");
                            tour.LastLoginDate = sqlDataReader.GetDateTime("Last_login_date");
                            tour.TourName = sqlDataReader.GetString("TourName");
                            tour.Description = sqlDataReader.GetString("Description");
                            tour.MainPhoto = sqlDataReader.GetString("Main_photo");
                            tour.MapPhoto = sqlDataReader.GetString("Map_photo");
                            tour.MeetingPlace = sqlDataReader.GetString("Meeting_place");
                            tour.EndPlace = sqlDataReader.GetString("End_place");
                            tour.Length = sqlDataReader.GetString("Lenght");
                        }

                        if (sqlDataReader.NextResult())
                        {
                            while (sqlDataReader.Read())
                            {
                                TourDateDTO tourDate = new TourDateDTO();
                                tourDate.TourDate = sqlDataReader.GetDateTime("Date_time");
                                tourDate.Price = sqlDataReader.GetFloat("Price");
                                tourDate.Password = sqlDataReader.GetString("Password");

                                tour.TourDates.Add(tourDate);
                            }
                        }

                        if(sqlDataReader.NextResult())
                        {
                            while(sqlDataReader.Read())
                            {
                                TourPhotoDTO tourPhoto1 = new TourPhotoDTO();
                                tourPhoto1.TourPhoto = sqlDataReader.GetString("Photo");

                                tour.TourPhotos.Add(tourPhoto1);
                            }
                        }

                        if(sqlDataReader.NextResult())
                        {
                            int sumRating = 0;
                            while(sqlDataReader.Read())
                            {
                                TourOpinionDTO tourOpinion = new TourOpinionDTO();
                                tourOpinion.UserId = sqlDataReader.GetInt32("Id");
                                tourOpinion.UserName = sqlDataReader.GetString("Name");
                                tourOpinion.UserSurname = sqlDataReader.GetString("Surname");
                                tourOpinion.Rating = sqlDataReader.GetInt32("Rating");
                                tourOpinion.Comment = sqlDataReader.GetString("Comment");
                                tourOpinion.OpinionDateTime = sqlDataReader.GetDateTime("Date_time");

                                sumRating += tourOpinion.Rating;
                                tour.TourOpinions.Add(tourOpinion);
                            }
                            if (tour.TourOpinions.Count != 0)
                            {
                                tour.AvarageRating = Math.Round((double)sumRating / tour.TourOpinions.Count, 2);
                            }
                        }


                    }

                }
                await sqlConnection.CloseAsync();

            }

            return tour;
        }
    }
}
