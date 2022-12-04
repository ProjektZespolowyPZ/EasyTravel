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

namespace EasyTravel.Application.Users.Queries.GetOtherUserInformation
{
    public class GetOtherUserInformationQueryHandler : IRequestHandler<GetOtherUserInformationQuery, UserInformationVm>
    {
        public async Task<UserInformationVm> Handle(GetOtherUserInformationQuery request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Display_other_user]";
            UserInformationVm userInformation = new UserInformationVm();
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@id_user", SqlDbType.NVarChar).Value = request.UserId;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        while (sqlDataReader.Read())
                        {

                            userInformation.Id = sqlDataReader.GetInt32("Id");
                            userInformation.Name = sqlDataReader.GetString("UserName");
                            userInformation.Surname = sqlDataReader.GetString("Surname");
                            userInformation.ProfilePicture = sqlDataReader.GetString("Profile_picture");
                            userInformation.Email = sqlDataReader.GetString("Contact_email");
                            userInformation.PhoneNumber = sqlDataReader.GetString("Phone_number");
                            userInformation.RegistrationDate = sqlDataReader.GetDateTime("Registration_date");
                            userInformation.LastLoginDate = sqlDataReader.GetDateTime("Last_login_date");

                        }

                        if (sqlDataReader.NextResult())
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

                                userInformation.UserTours.Add(tour);
                            }
                        }
                    }
                }
                await sqlConnection.CloseAsync();
            }
            return userInformation;
        }
    }
}
