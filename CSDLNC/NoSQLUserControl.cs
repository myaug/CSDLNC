using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSDLNC.SQL;

namespace CSDLNC
{
    public partial class NoSQLUserControl : UserControl
    {
        private SQLHelper helper = new SQLHelper();

        private string numberRecordSuffix = " records";
        private string timeExecutionSuffix = " ms";

        public NoSQLUserControl()
        {
            InitializeComponent();

            bindNumberOfRecord();
        }

        public void bindNumberOfRecord()
        {
            country_lbl.Text = helper.NumberOfRecord("Country") + numberRecordSuffix;
            league_lbl.Text = helper.NumberOfRecord("League") + numberRecordSuffix;
            team_lbl.Text = helper.NumberOfRecord("Team") + numberRecordSuffix;
            match_lbl.Text = helper.NumberOfRecord("Match") + numberRecordSuffix;
            player_lbl.Text = helper.NumberOfRecord("Player") + numberRecordSuffix;
            player_stats_lbl.Text = helper.NumberOfRecord("Player_Stats") + numberRecordSuffix;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {

        }
    }
}
