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
    public partial class SQLUserControl : UserControl
    {
        private SQLHelper helper = new SQLHelper();

        private string numberRecordSuffix = " records";
        private string timeExecutionSuffix = " ms";

        public SQLUserControl()
        {
            InitializeComponent();
            BindNumberOfRecord();
            BindPlayerList();
            InitInsertData();
        }

        private void BindNumberOfRecord()
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
            bindingSourcePLayerList.DataSource = helper.Select();
            lbl_time.Text = helper.timeExecution + timeExecutionSuffix;
        }
        
        private void BindPlayerList()
        {
            playerList.DataSource = bindingSourcePLayerList;
        }

        private void InitInsertData()
        {
            txt_apiId.Text = "80000";
            txt_name.Text = "Ronaldo";
            txt_birthday.Text = "1990-02-29 00:00:00";
            txt_height.Text = "182880000";
            txt_weight.Text = "187";
            txt_preferred_foot.Text = "right";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Player player = new Player()
            {
                Player_api_id = int.Parse(txt_apiId.Text),
                Player_name = txt_name.Text,
                Birthday = txt_birthday.Text,
                Height = int.Parse(txt_height.Text),
                Weight = int.Parse(txt_weight.Text)
            };
            helper.Insert(player);
            lbl_time.Text = helper.timeExecution + timeExecutionSuffix;
        }
    }
}
