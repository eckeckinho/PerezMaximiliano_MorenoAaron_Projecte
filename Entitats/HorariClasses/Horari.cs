using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.HorariClasses
{
    public class Horari
    {
        public int id { get; set; }
        public int restaurantid { get; set; }
        public int dia { get; set; }
        public TimeSpan hora_inici { get; set; }
        public TimeSpan hora_final { get; set; }
        public override string ToString() { return $"{hora_inici:hh\\:mm} - {hora_final:hh\\:mm}"; }
    }
}
