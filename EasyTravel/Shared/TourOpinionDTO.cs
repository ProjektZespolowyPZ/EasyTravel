using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class TourOpinionDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime OpinionDateTime { get; set; }
    }
}
