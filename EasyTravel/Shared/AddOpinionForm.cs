using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class AddOpinionForm
    {
        public int Rating { get; set; } = 0;
        public string Comment { get; set; }
        public DateTime DateTimeAddingOpinion { get; set; }
        public int IdTour { get; set; }
    }
}
