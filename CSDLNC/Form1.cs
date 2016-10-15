using CSDLNC.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Test();
        }

        private void Test()
        {
            Player player = new Player()
            {
                Player_api_id = 123456,
                Player_fifa_api_id = 654321,
                Player_name = "Hoang Minh",
                Birthday = "1990-02-29 00:00:00",
                Height = 182880000,
                Weight = 250
            };
            SQLHelper helper = new SQLHelper();
            //var timeExcution = helper.Insert(player);

            var players = helper.Select();
        }
    }
}
