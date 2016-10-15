namespace CSDLNC
{
    partial class SQLUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.country_lbl = new System.Windows.Forms.Label();
            this.league_lbl = new System.Windows.Forms.Label();
            this.team_lbl = new System.Windows.Forms.Label();
            this.match_lbl = new System.Windows.Forms.Label();
            this.player_lbl = new System.Windows.Forms.Label();
            this.player_stats_lbl = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.player_list = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.player_list)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Demo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Country:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(200, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Team:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(18, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "League:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(200, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Match:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(385, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Player:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(385, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Player_Stats:";
            // 
            // country_lbl
            // 
            this.country_lbl.AutoSize = true;
            this.country_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.country_lbl.Location = new System.Drawing.Point(88, 56);
            this.country_lbl.Name = "country_lbl";
            this.country_lbl.Size = new System.Drawing.Size(92, 16);
            this.country_lbl.TabIndex = 7;
            this.country_lbl.Text = "12000 records";
            // 
            // league_lbl
            // 
            this.league_lbl.AutoSize = true;
            this.league_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.league_lbl.Location = new System.Drawing.Point(88, 92);
            this.league_lbl.Name = "league_lbl";
            this.league_lbl.Size = new System.Drawing.Size(92, 16);
            this.league_lbl.TabIndex = 8;
            this.league_lbl.Text = "12000 records";
            // 
            // team_lbl
            // 
            this.team_lbl.AutoSize = true;
            this.team_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.team_lbl.Location = new System.Drawing.Point(258, 56);
            this.team_lbl.Name = "team_lbl";
            this.team_lbl.Size = new System.Drawing.Size(92, 16);
            this.team_lbl.TabIndex = 9;
            this.team_lbl.Text = "12000 records";
            // 
            // match_lbl
            // 
            this.match_lbl.AutoSize = true;
            this.match_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.match_lbl.Location = new System.Drawing.Point(259, 92);
            this.match_lbl.Name = "match_lbl";
            this.match_lbl.Size = new System.Drawing.Size(92, 16);
            this.match_lbl.TabIndex = 10;
            this.match_lbl.Text = "12000 records";
            // 
            // player_lbl
            // 
            this.player_lbl.AutoSize = true;
            this.player_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.player_lbl.Location = new System.Drawing.Point(448, 56);
            this.player_lbl.Name = "player_lbl";
            this.player_lbl.Size = new System.Drawing.Size(92, 16);
            this.player_lbl.TabIndex = 11;
            this.player_lbl.Text = "12000 records";
            // 
            // player_stats_lbl
            // 
            this.player_stats_lbl.AutoSize = true;
            this.player_stats_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.player_stats_lbl.Location = new System.Drawing.Point(491, 92);
            this.player_stats_lbl.Name = "player_stats_lbl";
            this.player_stats_lbl.Size = new System.Drawing.Size(92, 16);
            this.player_stats_lbl.TabIndex = 12;
            this.player_stats_lbl.Text = "12000 records";
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Select.Location = new System.Drawing.Point(21, 132);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(82, 30);
            this.btn_Select.TabIndex = 13;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_add.Location = new System.Drawing.Point(124, 132);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(146, 30);
            this.btn_add.TabIndex = 14;
            this.btn_add.Text = "Add New Player";
            this.btn_add.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_update.Location = new System.Drawing.Point(290, 132);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(82, 30);
            this.btn_update.TabIndex = 15;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(17, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Time execution:";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_time.Location = new System.Drawing.Point(140, 180);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(40, 16);
            this.lbl_time.TabIndex = 17;
            this.lbl_time.Text = "12ms";
            // 
            // player_list
            // 
            this.player_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.player_list.Location = new System.Drawing.Point(21, 216);
            this.player_list.Name = "player_list";
            this.player_list.Size = new System.Drawing.Size(535, 285);
            this.player_list.TabIndex = 18;
            // 
            // SQLUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.player_list);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.player_stats_lbl);
            this.Controls.Add(this.player_lbl);
            this.Controls.Add(this.match_lbl);
            this.Controls.Add(this.team_lbl);
            this.Controls.Add(this.league_lbl);
            this.Controls.Add(this.country_lbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SQLUserControl";
            this.Size = new System.Drawing.Size(594, 518);
            ((System.ComponentModel.ISupportInitialize)(this.player_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label country_lbl;
        private System.Windows.Forms.Label league_lbl;
        private System.Windows.Forms.Label team_lbl;
        private System.Windows.Forms.Label match_lbl;
        private System.Windows.Forms.Label player_lbl;
        private System.Windows.Forms.Label player_stats_lbl;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.DataGridView player_list;
    }
}
