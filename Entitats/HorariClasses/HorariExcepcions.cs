using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.HorariClasses
{
    public class HorariExcepcions
    {
        public int id { get; set; }
        public DateTime data_inici { get; set; }
        public DateTime data_final { get; set; }
        public int restaurantid { get; set; }
    }
}
