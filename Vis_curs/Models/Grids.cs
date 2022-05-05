using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_curs.Models
{
    public class Grids
    {
        public Grids(string c1, string c2, string c3, string c4, string c5, string c6)
        {
            Column1 = c1;
            Column2 = c2;
            Column3 = c3;
            Column4 = c4;
            Column5 = c5;
            Column6 = c6;
        }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }

    }
}
