using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDLNC.SQL
{
    public class Player
    {
        public int Id { get; set; }

        public int Player_api_id { get; set; }

        public int Player_fifa_api_id { get; set; }

        public string Player_name { get; set; }

        public string Birthday { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }
    }
}
