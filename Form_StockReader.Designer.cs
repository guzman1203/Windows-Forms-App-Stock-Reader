namespace COP4365_Stock_Reader_2024
{
    partial class Form_StockReader
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_period = new System.Windows.Forms.Label();
            this.button_dnload_stock_data = new System.Windows.Forms.Button();
            this.chart_candlestick_data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_period_month = new System.Windows.Forms.Button();
            this.button_period_week = new System.Windows.Forms.Button();
            this.button_period_day = new System.Windows.Forms.Button();
            this.label_startdate = new System.Windows.Forms.Label();
            this.label_enddate = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_select_stock = new System.Windows.Forms.Button();
            this.openFileDialog_select_stockfile = new System.Windows.Forms.OpenFileDialog();
            this.label_placeholder_symbol = new System.Windows.Forms.Label();
            this.button_update_chart = new System.Windows.Forms.Button();
            this.button_add_stockfiles = new System.Windows.Forms.Button();
            this.comboBox_CSpatterns = new System.Windows.Forms.ComboBox();
            this.label_cs_pattern_select = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlestick_data)).BeginInit();
            this.SuspendLayout();
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Location = new System.Drawing.Point(18, 510);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(40, 13);
            this.label_period.TabIndex = 4;
            this.label_period.Text = "Period:";
            this.label_period.Visible = false;
            // 
            // button_dnload_stock_data
            // 
            this.button_dnload_stock_data.Location = new System.Drawing.Point(21, 400);
            this.button_dnload_stock_data.Name = "button_dnload_stock_data";
            this.button_dnload_stock_data.Size = new System.Drawing.Size(130, 72);
            this.button_dnload_stock_data.TabIndex = 5;
            this.button_dnload_stock_data.Text = "Download Latest Stock Data";
            this.button_dnload_stock_data.UseVisualStyleBackColor = true;
            this.button_dnload_stock_data.Visible = false;
            this.button_dnload_stock_data.Click += new System.EventHandler(this.button_dnload_stock_data_Click);
            // 
            // chart_candlestick_data
            // 
            chartArea1.AlignWithChartArea = "ChartArea_Volume";
            chartArea1.Name = "ChartArea_CandleSticks";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_candlestick_data.ChartAreas.Add(chartArea1);
            this.chart_candlestick_data.ChartAreas.Add(chartArea2);
            this.chart_candlestick_data.Location = new System.Drawing.Point(483, 27);
            this.chart_candlestick_data.Name = "chart_candlestick_data";
            series1.ChartArea = "ChartArea_CandleSticks";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_HLOC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "high,low,open,close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            this.chart_candlestick_data.Series.Add(series1);
            this.chart_candlestick_data.Series.Add(series2);
            this.chart_candlestick_data.Size = new System.Drawing.Size(1254, 584);
            this.chart_candlestick_data.TabIndex = 6;
            this.chart_candlestick_data.Text = "chart_candlestick_data";
            // 
            // button_period_month
            // 
            this.button_period_month.Location = new System.Drawing.Point(63, 505);
            this.button_period_month.Name = "button_period_month";
            this.button_period_month.Size = new System.Drawing.Size(75, 23);
            this.button_period_month.TabIndex = 8;
            this.button_period_month.Text = "Month";
            this.button_period_month.UseVisualStyleBackColor = true;
            this.button_period_month.Visible = false;
            this.button_period_month.Click += new System.EventHandler(this.button_period_month_Click);
            // 
            // button_period_week
            // 
            this.button_period_week.Location = new System.Drawing.Point(145, 505);
            this.button_period_week.Name = "button_period_week";
            this.button_period_week.Size = new System.Drawing.Size(75, 23);
            this.button_period_week.TabIndex = 9;
            this.button_period_week.Text = "Week";
            this.button_period_week.UseVisualStyleBackColor = true;
            this.button_period_week.Visible = false;
            this.button_period_week.Click += new System.EventHandler(this.button_period_week_Click);
            // 
            // button_period_day
            // 
            this.button_period_day.Location = new System.Drawing.Point(225, 505);
            this.button_period_day.Name = "button_period_day";
            this.button_period_day.Size = new System.Drawing.Size(75, 23);
            this.button_period_day.TabIndex = 10;
            this.button_period_day.Text = "Day";
            this.button_period_day.UseVisualStyleBackColor = true;
            this.button_period_day.Visible = false;
            this.button_period_day.Click += new System.EventHandler(this.button_period_day_Click);
            // 
            // label_startdate
            // 
            this.label_startdate.AutoSize = true;
            this.label_startdate.Location = new System.Drawing.Point(19, 193);
            this.label_startdate.Name = "label_startdate";
            this.label_startdate.Size = new System.Drawing.Size(58, 13);
            this.label_startdate.TabIndex = 11;
            this.label_startdate.Text = "Start Date:";
            // 
            // label_enddate
            // 
            this.label_enddate.AutoSize = true;
            this.label_enddate.Location = new System.Drawing.Point(19, 228);
            this.label_enddate.Name = "label_enddate";
            this.label_enddate.Size = new System.Drawing.Size(55, 13);
            this.label_enddate.TabIndex = 12;
            this.label_enddate.Text = "End Date:";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(83, 184);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(218, 20);
            this.dateTimePicker_start.TabIndex = 13;
            this.dateTimePicker_start.Value = new System.DateTime(2023, 12, 1, 12, 56, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(83, 223);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(218, 20);
            this.dateTimePicker_end.TabIndex = 14;
            this.dateTimePicker_end.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // button_select_stock
            // 
            this.button_select_stock.Location = new System.Drawing.Point(21, 310);
            this.button_select_stock.Name = "button_select_stock";
            this.button_select_stock.Size = new System.Drawing.Size(130, 72);
            this.button_select_stock.TabIndex = 15;
            this.button_select_stock.Text = "Select Stock File";
            this.button_select_stock.UseVisualStyleBackColor = true;
            this.button_select_stock.Click += new System.EventHandler(this.button_select_stock_Click);
            // 
            // openFileDialog_select_stockfile
            // 
            this.openFileDialog_select_stockfile.Filter = "All files|*.*|All CSV Files|*.csv|Month|*-Month.csv|Week|*-Week.csv|Day|*-Day.csv" +
    "";
            this.openFileDialog_select_stockfile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_select_stockfile_FileOk);
            // 
            // label_placeholder_symbol
            // 
            this.label_placeholder_symbol.AutoSize = true;
            this.label_placeholder_symbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_placeholder_symbol.Location = new System.Drawing.Point(19, 22);
            this.label_placeholder_symbol.Name = "label_placeholder_symbol";
            this.label_placeholder_symbol.Size = new System.Drawing.Size(100, 13);
            this.label_placeholder_symbol.TabIndex = 16;
            this.label_placeholder_symbol.Text = "Symbol Placeholder";
            this.label_placeholder_symbol.Visible = false;
            this.label_placeholder_symbol.TextChanged += new System.EventHandler(this.label_placeholder_symbol_TextChanged);
            this.label_placeholder_symbol.Click += new System.EventHandler(this.label_placeholder_symbol_Click);
            // 
            // button_update_chart
            // 
            this.button_update_chart.Location = new System.Drawing.Point(171, 310);
            this.button_update_chart.Name = "button_update_chart";
            this.button_update_chart.Size = new System.Drawing.Size(130, 72);
            this.button_update_chart.TabIndex = 19;
            this.button_update_chart.Text = "Update Chart";
            this.button_update_chart.UseVisualStyleBackColor = true;
            this.button_update_chart.Click += new System.EventHandler(this.button_update_chart_Click);
            // 
            // button_add_stockfiles
            // 
            this.button_add_stockfiles.Location = new System.Drawing.Point(171, 400);
            this.button_add_stockfiles.Name = "button_add_stockfiles";
            this.button_add_stockfiles.Size = new System.Drawing.Size(130, 72);
            this.button_add_stockfiles.TabIndex = 20;
            this.button_add_stockfiles.Text = "Add Stocks to Database";
            this.button_add_stockfiles.UseVisualStyleBackColor = true;
            this.button_add_stockfiles.Visible = false;
            this.button_add_stockfiles.Click += new System.EventHandler(this.button_add_stockfiles_Click);
            // 
            // comboBox_CSpatterns
            // 
            this.comboBox_CSpatterns.FormattingEnabled = true;
            this.comboBox_CSpatterns.Location = new System.Drawing.Point(127, 266);
            this.comboBox_CSpatterns.Name = "comboBox_CSpatterns";
            this.comboBox_CSpatterns.Size = new System.Drawing.Size(129, 21);
            this.comboBox_CSpatterns.TabIndex = 21;
            this.comboBox_CSpatterns.Text = "Candle Stick Patterns";
            this.comboBox_CSpatterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_CSpatterns_SelectedIndexChanged);
            // 
            // label_cs_pattern_select
            // 
            this.label_cs_pattern_select.AutoSize = true;
            this.label_cs_pattern_select.Location = new System.Drawing.Point(19, 269);
            this.label_cs_pattern_select.Name = "label_cs_pattern_select";
            this.label_cs_pattern_select.Size = new System.Drawing.Size(102, 13);
            this.label_cs_pattern_select.TabIndex = 22;
            this.label_cs_pattern_select.Text = "Candlestick Pattern:";
            // 
            // Form_StockReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 623);
            this.Controls.Add(this.label_cs_pattern_select);
            this.Controls.Add(this.comboBox_CSpatterns);
            this.Controls.Add(this.button_add_stockfiles);
            this.Controls.Add(this.button_update_chart);
            this.Controls.Add(this.label_placeholder_symbol);
            this.Controls.Add(this.button_select_stock);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label_enddate);
            this.Controls.Add(this.label_startdate);
            this.Controls.Add(this.button_period_day);
            this.Controls.Add(this.button_period_week);
            this.Controls.Add(this.button_period_month);
            this.Controls.Add(this.chart_candlestick_data);
            this.Controls.Add(this.button_dnload_stock_data);
            this.Controls.Add(this.label_period);
            this.Name = "Form_StockReader";
            this.Text = "Control Window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_StockReader_FormClosed);
            this.Load += new System.EventHandler(this.Form_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlestick_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_period;
        private System.Windows.Forms.Button button_dnload_stock_data;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candlestick_data;
        private System.Windows.Forms.Button button_period_month;
        private System.Windows.Forms.Button button_period_week;
        private System.Windows.Forms.Button button_period_day;
        private System.Windows.Forms.Label label_startdate;
        private System.Windows.Forms.Label label_enddate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Button button_select_stock;
        private System.Windows.Forms.OpenFileDialog openFileDialog_select_stockfile;
        private System.Windows.Forms.Label label_placeholder_symbol;
        private System.Windows.Forms.Button button_update_chart;
        private System.Windows.Forms.Button button_add_stockfiles;
        private System.Windows.Forms.ComboBox comboBox_CSpatterns;
        private System.Windows.Forms.Label label_cs_pattern_select;
    }
}

