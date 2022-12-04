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

namespace EasyTravel.Application.Tours.Queries.GetSearchedTours
{
    public class GetSearchedToursQueryHandler : IRequestHandler<GetSearchedToursQuery, ToursVm>
    {
        public async Task<ToursVm> Handle(GetSearchedToursQuery request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Filter_tours]";
            ToursVm tours = new ToursVm();
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@search_word", SqlDbType.NVarChar).Value = request.SearchedWord;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        while (sqlDataReader.Read())
                        {
                            TourDTO tour = new TourDTO();
                            tour.Id = sqlDataReader.GetInt32("Id");
                            tour.UserName = sqlDataReader.GetString("UserName");
                            tour.Surname = sqlDataReader.GetString("Surname");
                            tour.ProfilePicture = sqlDataReader.GetString("Profile_picture");
                            tour.MainPhoto = sqlDataReader.GetString("Main_photo");
                            tour.TourName = sqlDataReader.GetString("TourName");

                            tours.Tours.Add(tour);
                        }
                    }

                }
                await sqlConnection.CloseAsync();

            }

            return tours;
        }
    }
}
