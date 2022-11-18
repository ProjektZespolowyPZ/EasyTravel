using EasyTravel.Application.Common.Interfaces;
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

namespace EasyTravel.Application.Users.Queries.GetUserInformation
{
    public class GetUserInformationQueryHandler : IRequestHandler<GetUserInformationQuery, UserInformationVm>
    {
        private ICurrentUserService _userService;

        public GetUserInformationQueryHandler(ICurrentUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserInformationVm> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
        {
            const string PROCEDURE_NAME = "[dbo].[Display_user]";
            UserInformationVm userInformation = new UserInformationVm();
            using (SqlConnection sqlConnection = new SqlConnection(Resources.ConnectionString))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = _userService.Email;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        while (sqlDataReader.Read())
                        {
                            
                            userInformation.Id = sqlDataReader.GetInt32("Id");
                            userInformation.Name = sqlDataReader.GetString("Name");
                            userInformation.Surname = sqlDataReader.GetString("Surname");
                            userInformation.ProfilePicture = sqlDataReader.GetString("Profile_picture");
                            userInformation.Email = sqlDataReader.GetString("Contact_email");
                            userInformation.PhoneNumber = sqlDataReader.GetString("Phone_number");
                            userInformation.RegistrationDate = sqlDataReader.GetDateTime("Registration_date");
                            userInformation.LastLoginDate = sqlDataReader.GetDateTime("Last_login_date");

                        }
                    }

                }
                await sqlConnection.CloseAsync();

            }

            return userInformation;
        }
    }
}
