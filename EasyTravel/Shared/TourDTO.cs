using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class TourDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string ProfilePicture { get; set; }
        public string MainPhoto { get; set; }
        public string TourName { get; set; }
    }
}
