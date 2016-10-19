namespace CSDLNC
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noSQLUserControl1 = new CSDLNC.NoSQLUserControl();
            this.sqlUserControl1 = new CSDLNC.SQLUserControl();
            this.SuspendLayout();
            // 
            // noSQLUserControl1
            // 
            this.noSQLUserControl1.AutoSize = true;
            this.noSQLUserControl1.Location = new System.Drawing.Point(593, 12);
            this.noSQLUserControl1.Name = "noSQLUserControl1";
            this.noSQLUserControl1.Size = new System.Drawing.Size(586, 548);
            this.noSQLUserControl1.TabIndex = 1;
            // 
            // sqlUserControl1
            // 
            this.sqlUserControl1.AutoSize = true;
            this.sqlUserControl1.Location = new System.Drawing.Point(-8, 12);
            this.sqlUserControl1.Name = "sqlUserControl1";
            this.sqlUserControl1.Size = new System.Drawing.Size(595, 548);
            this.sqlUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 566);
            this.Controls.Add(this.noSQLUserControl1);
            this.Controls.Add(this.sqlUserControl1);
            this.Name = "Form1";
            this.Text = "Compare SQL and NoSQL - Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SQLUserControl sqlUserControl1;
        private NoSQLUserControl noSQLUserControl1;
    }
}

