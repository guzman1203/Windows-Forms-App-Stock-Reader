namespace COP4365_Stock_Reader_2024
{
    partial class Form_Control
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
            this.button_selectfiles = new System.Windows.Forms.Button();
            this.openFileDialog_selectfiles = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_startdate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_enddate = new System.Windows.Forms.DateTimePicker();
            this.button_updatefroms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_selectfiles
            // 
            this.button_selectfiles.Location = new System.Drawing.Point(12, 113);
            this.button_selectfiles.Name = "button_selectfiles";
            this.button_selectfiles.Size = new System.Drawing.Size(159, 81);
            this.button_selectfiles.TabIndex = 0;
            this.button_selectfiles.Text = "Select and Load File(s)";
            this.button_selectfiles.UseVisualStyleBackColor = true;
            this.button_selectfiles.Click += new System.EventHandler(this.button_selectfiles_Click);
            // 
            // openFileDialog_selectfiles
            // 
            this.openFileDialog_selectfiles.FileName = "openFileDialog_selectfiles";
            this.openFileDialog_selectfiles.Filter = "All files|*.*|All CSV Files|*.csv|Month|*-Month.csv|Week|*-Week.csv|Day|*-Day.csv" +
    "";
            this.openFileDialog_selectfiles.Multiselect = true;
            this.openFileDialog_selectfiles.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_selectfiles_FileOk);
            // 
            // dateTimePicker_startdate
            // 
            this.dateTimePicker_startdate.Location = new System.Drawing.Point(12, 87);
            this.dateTimePicker_startdate.Name = "dateTimePicker_startdate";
            this.dateTimePicker_startdate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startdate.TabIndex = 2;
            this.dateTimePicker_startdate.Value = new System.DateTime(2022, 12, 1, 22, 30, 0, 0);
            // 
            // dateTimePicker_enddate
            // 
            this.dateTimePicker_enddate.Location = new System.Drawing.Point(261, 87);
            this.dateTimePicker_enddate.Name = "dateTimePicker_enddate";
            this.dateTimePicker_enddate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_enddate.TabIndex = 3;
            this.dateTimePicker_enddate.Value = new System.DateTime(2024, 1, 1, 22, 30, 0, 0);
            // 
            // button_updatefroms
            // 
            this.button_updatefroms.Location = new System.Drawing.Point(302, 113);
            this.button_updatefroms.Name = "button_updatefroms";
            this.button_updatefroms.Size = new System.Drawing.Size(159, 81);
            this.button_updatefroms.TabIndex = 4;
            this.button_updatefroms.Text = "Update Forms";
            this.button_updatefroms.UseVisualStyleBackColor = true;
            this.button_updatefroms.Click += new System.EventHandler(this.button_updatefroms_Click);
            // 
            // Form_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 199);
            this.Controls.Add(this.button_updatefroms);
            this.Controls.Add(this.dateTimePicker_enddate);
            this.Controls.Add(this.dateTimePicker_startdate);
            this.Controls.Add(this.button_selectfiles);
            this.Name = "Form_Control";
            this.Text = "Stock_Control";
            this.Load += new System.EventHandler(this.Form_Control_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_selectfiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog_selectfiles;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_enddate;
        private System.Windows.Forms.Button button_updatefroms;
    }
}