using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using COP4365_Stock_Reader_2024;
using WindowsFormsApp_COP_4365_Stock_Reader_2024;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COP4365_Stock_Reader_2024
{
    public partial class Form_StockReader : Form
    {
        // get stock data folder from parent directory
        static string stock_folder_name = "\\Stock Data";
        static string stock_folder_parent = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()).ToString();
        static string stock_folder_directory = stock_folder_parent + stock_folder_name;

        // candlesticks complete list. Lists all candlesticks from a csv file.
        List<CandleStick> cs_complete = new List<CandleStick>();
        // candlesticks display list. List all candlesticks within date range.
        BindingList<CandleStick> bindingList_cs_display = new BindingList<CandleStick>();

        // event that will be raised when the form is closed
        public event EventHandler FormClosedEvent;

        // recognizer controller
        Controller_Recognizer RecognizerManager = new Controller_Recognizer();

        // pattern name representing no pattern selected
        string no_pattern = "None";

        public Form_StockReader()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initial specifications for the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Control_Load(object sender, EventArgs e)
        {
            // Set openFileDialog_stockFolder InitialDirectory
            // openFileDialog_select_stockfile.InitialDirectory = stock_folder_directory;

            // fill the pattern combobox with current candle stick patterns
            List<string> none = new List<string>() { no_pattern };
            List<string> patterns = new List<string>(none.Concat(RecognizerManager.patternNames));
            comboBox_CSpatterns.DataSource = patterns;
        }
        /// <summary>
        /// This method does web scrapping on yahoo finance. It grabs 5Y monthly, weekly, and daily data for the stocks in the global stock ticker list
        /// </summary>
        /// <param sender="parameter1">Description of the first parameter.</param>
        /// <param EventArgs="parameter2">Description of the second parameter.</param>
        /// <returns>Description of the return value.</returns>
        
        
        private void button_dnload_stock_data_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event handler for a button click event. Calls the openFileDialog_select_stockfile to open a file explore at the "Stock Folder" directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_select_stock_Click(object sender, EventArgs e)
        {
            openFileDialog_select_stockfile.ShowDialog(); // open the file explorer and select file
            update_displays(); // update displays
        }
        /// <summary>
        /// Event handler for openfileDialog FileOK event. Updates the list of candlesticks from a new file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_select_stockfile_FileOk(object sender, CancelEventArgs e)
        {
            // Call the function update candlestick complete list with the file name chosen by the open-file-diaglog
            readCandlestickDataFromFile();
        }
        
        
        /// <summary>
        /// Function that updates the cs_complete bound list with the candlesticks of the current file chosen by the open-file-dialog.
        /// </summary>
        private void readCandlestickDataFromFile()
        {
            string filepath = openFileDialog_select_stockfile.FileName; // path of the file selected from the file explorer 
            readCandlestickDataFromFile(filepath, ref cs_complete);
        }
        /// <summary>
        /// Reads candlestick information from a csv file.
        /// </summary>
        /// <param name="filepath">file path of the cvs file</param>
        /// <param name="cs_list">reference to a list of candlesticks</param>
        /// <returns></returns>
        private void readCandlestickDataFromFile(string filepath, ref List<CandleStick> cs_list)
        {
            cs_list.Clear(); // clear the candlestick in the file list
            
            try // Handle any unexpected errors
            {
                var sr = new StreamReader(filepath); // Read the first line of the selected file
                if (sr.ReadLine() != CandleStick.referenceString) // Check if we are reading the correct file
                {
                    MessageBox.Show("Error: Incorrect File");
                }
                while (!sr.EndOfStream) // While there is still more lines to read
                {
                    // Create a new candlestick
                    CandleStick scs = new CandleStick(sr.ReadLine(), Path.GetFileName(filepath));
                    // Add candlestick to file list
                    cs_list.Add(scs);
                }
                // reverse the order of the file list
                // cs_list.Reverse();
            }
            catch (SecurityException ex)
            {
                // Display an error message
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }


        /// <summary>
        /// Event handler for button click event. Updates chart display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_update_chart_Click(object sender, EventArgs e)
        {
            update_displays(); // update the stock reader form information in the chart
        }
        /// <summary>
        /// Update chart display.
        /// </summary>
        public void update_displays()
        {
            // Check that there are candlesticks in the candlestick complete list
            if (cs_complete.Count != 0)
            {
                // filter for in-range candlesticks
                filterCandlesticks();
                // update the chart
                chartDisplayCandlesticks();
                // update the gridview
                // gridviewDisplayCandlesticks();
                // normalize chart to fit data
                normalizeChart();
                // update placeholders
                update_placeholders();
                // update selected pattern on the chart
                update_candlestick_pattern_chart_display();

            }
            else
                // Throw and error message
                MessageBox.Show("Error. No data to display");
        }
        /// <summary>
        /// Function to filter candlesticks by end and start date.
        /// </summary>
        
        
        private void filterCandlesticks()
        {
            // start and end date values
            DateTime start = dateTimePicker_start.Value;
            DateTime end = dateTimePicker_end.Value;
            // sub-list of candlesticks
            List<CandleStick> cs_sublist = new List<CandleStick>();
            // filter candlesticks by date range
            filterCandlesticks(ref cs_complete, ref cs_sublist, start, end);
            // set the global
            bindingList_cs_display.Clear();
            foreach (CandleStick cs in cs_sublist)
            {
                bindingList_cs_display.Add(cs);
            } 
        }
        /// <summary>
        /// Function to filter candlesticks by end and start date.
        /// </summary>
        /// <param name="full_list">full-list of candlesticks</param>
        /// <param name="sub_list">reference sub-list of candlesticks</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        private void filterCandlesticks(ref List<CandleStick> full_list, ref List<CandleStick> sub_list, DateTime start, DateTime end)
        {
            // clear display list
            sub_list.Clear();
            // check that dates are correct in relation to each other
            if (start > end)
            {
                // Throw and error message
                MessageBox.Show("Error. No data to display");
            }
            else
            {
                // filtering file candlesticks for candlesticks within the date range
                for (int i = 0; i < full_list.Count; i++)
                {
                    CandleStick cs = full_list[i];
                    if (cs.date.CompareTo(end) > 0)
                    {
                        // after date range. stop searching
                        break;
                    }
                    if (cs.date.CompareTo(start) < 0)
                    {
                        // before date range. continue searching
                        continue;
                    }
                    // convert cs to smart cs
                    Smart_CandleStick smart_CandleStick = new Smart_CandleStick(cs);
                    // add candlestick to sub list
                    sub_list.Add(smart_CandleStick);
                    // replace candlestick on full list with smart candlestick
                    full_list[i] = smart_CandleStick;
                }
            }
        }
        
        
        /// <summary>
        /// Function to normalize the chart to a range depending on display candlesticks max and min values.
        /// </summary>
        private void normalizeChart()
        {
            // buffer percent
            double buffer_pcnt = 0.1; // percent of range as buffer
            // candle stick list
            List<CandleStick> cs_list = new List<CandleStick>(bindingList_cs_display);
            // candle stick chart area 
            ChartArea cs_chart = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"];
            // normalize chart
            normalizeChart(buffer_pcnt, cs_list, ref cs_chart);
        }
        /// <summary>
        /// Function to normalize the chart to a range depending on display candlesticks max and min values.
        /// </summary>
        /// <param name="buffer_pcnt">percent of the range that makes the buffer</param>
        /// <param name="cs_list">input to find range</param>
        /// <param name="cs_chart">chart to normalize</param>
        private void normalizeChart(double buffer_pcnt, List<CandleStick> cs_list, ref ChartArea cs_chart)
        {
            try
            {
                double cs_max = cs_list[0].high; // maximum
                double cs_min = cs_list[0].low; // minimum 
                double cs_rng; // range

                // find the range of the candlestick values in the display list
                foreach (CandleStick cs in cs_list)
                {
                    if (cs.high > cs_max)
                        cs_max = cs.high;
                    if (cs.low < cs_min)
                        cs_min = cs.low;
                }
                // calc range
                cs_rng = cs_max - cs_min;

                // set max and min
                cs_chart.AxisY.Minimum = Math.Floor(Math.Max(cs_min - buffer_pcnt * cs_rng, 0));
                cs_chart.AxisY.Maximum = Math.Ceiling(cs_max + buffer_pcnt * cs_rng);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Handle the exception
                // For example, you could log the exception or show an error message
                Console.WriteLine("Index out of bounds exception occurred: " + ex.Message);
                // You might want to throw the exception again if you cannot recover from it
                throw;
            }
        }
        
        
        /// <summary>
        /// Function to update the display of the candlestick data on the chart.
        /// </summary>
        private void chartDisplayCandlesticks()
        {
            List<CandleStick> cs_list = new List<CandleStick>(bindingList_cs_display);
            chartDisplayCandlesticks(cs_list);
        }
        /// <summary>
        /// Function to update the display of the candlestick data on the chart.
        /// </summary>
        /// <param name="cs_list">candlestick binding list</param>
        private void chartDisplayCandlesticks(List<CandleStick> cs_list)
        {
            // convert list to binding list
            BindingList<CandleStick> cs_bind_list = new BindingList<CandleStick>(cs_list);
            // update the chart
            chart_candlestick_data.DataSource = cs_bind_list;
            // refresh the chart to display the updated data
            chart_candlestick_data.DataBind();
        }

        // Table Display
        /*      
                /// <summary>
                /// Function to update the gridview.
                /// </summary>
                private void gridviewDisplayCandlesticks()
                {
                    // update the gridview data
                    gridviewDisplayCandlesticks(cs_display);
                }
                /// <summary>
                /// Function to update the gridview.
                /// </summary>
                private void gridviewDisplayCandlesticks(BindingList<CandleStick> cs_bindingList)
                {
                    // update the gridview data
                    dataGridView_cs_properties.DataSource = cs_bindingList;
                }
        */
        /// <summary>
        /// Event handler for the data gridview row removed event. When a row is removed in the gridview by the user, update the chart to reflect the removal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_cs_properties_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // update chart display
            chartDisplayCandlesticks();
        }


        /// <summary>
        /// Update the placeholders on the stockreader form.
        /// </summary>
        private void update_placeholders()
        {
            // update ticker symbol
            string title = bindingList_cs_display[0].ticker + '-' + bindingList_cs_display[0].period;
            label_placeholder_symbol.Text = title;
            label_placeholder_symbol.Visible = true;
        }
        /// <summary>
        /// Event handler for the label text change event. Changes the label to the ticker and period of the current candlesticks being displayed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_placeholder_symbol_TextChanged(object sender, EventArgs e)
        {
            // font/size constraints
            int max_f_sz = 40;
            int max_wd = 400;
            // resize the placeholder to fit
            label_placeholder_symbol.Font = new Font(label_placeholder_symbol.Font.FontFamily, resizeLabelFont(max_f_sz, max_wd, label_placeholder_symbol));
        }
        /// <summary>
        /// Function to resizeing labels giving font and width constraints
        /// </summary>
        /// <param name="mx_font">font constraint</param>
        /// <param name="max_wd">width constraint in pixels</param>
        /// <param name="label">label struct</param>
        /// <returns>a double representing the new font size</returns>
        private float resizeLabelFont(int mx_font, int max_wd, System.Windows.Forms.Label label)
        {
            float fs = mx_font; // wanted font size

            int orig_wd = label.Width; // original wd
            float orig_fs = label.Font.Size;

            // get the measurements with new font size
            label.Font = new Font(label.Font.FontFamily, mx_font);
            int new_wd = label.Width;

            if (new_wd > max_wd) // resizing down by ratio
            {
                float ratio = orig_fs / orig_wd;
                fs = max_wd * ratio;
            }
            return fs;
        }
        
 
        /// <summary>
        /// Function to change the period of the current ticker displayed and update the chart.
        /// </summary>
        /// <param name="period">new period to change to</param>
        private void change_stockperiod(string period)
        {
            // if chart is empty display fail message
            if (bindingList_cs_display.Count == 0)
            {
                MessageBox.Show("Error: Chart not populated");
            }
            else
            {
                // retrieve stock ticker
                string ticker = bindingList_cs_display[0].ticker;
                // file directory
                string new_file_name = ticker + '-' + period + ".csv";
                string new_file_path = Path.Combine(stock_folder_directory, new_file_name);
                // replace the file list with the new files candlesticks
                List<CandleStick> cs_file = new List<CandleStick>();
                readCandlestickDataFromFile(new_file_path, ref cs_file);
                cs_complete = new List<CandleStick>(cs_file);
            }
        }
        /// <summary>
        /// Event handler for button click event. Changes the current stock to it's month period if possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_period_month_Click(object sender, EventArgs e)
        {
            // period month
            string period = "Month";
            // change stock period to month
            change_stockperiod(period);
            // mimic a click from update button
            button_update_chart_Click(sender, e);
        }
        /// <summary>
        /// Event handler for button click event. Changes the current stock to it's week period if possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_period_week_Click(object sender, EventArgs e)
        {
            // period week
            string period = "Week";
            // change stock period to month
            change_stockperiod(period);
            // mimic a click from update button
            button_update_chart_Click(sender, e);
        }
        /// <summary>
        /// Event handler for button click event. Changes the current stock to it's day period if possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_period_day_Click(object sender, EventArgs e)
        {
            // period day
            string period = "Day";
            // change stock period to month
            change_stockperiod(period);
            // mimic a click from update button
            button_update_chart_Click(sender, e);
        }
        
        
        /// <summary>
        /// Event handler for the FormClosed event. Remove itself from the control form's list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_StockReader_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Raise the FormClosedEvent when the form is closed
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
        
        
        /// <summary>
        /// Public function to set the start date
        /// </summary>
        /// <param name="newStart"></param>
        public void set_startDate(DateTime newStart)
        {
            dateTimePicker_start.Value = newStart;
        }
        /// <summary>
        /// Public function to set the end date
        /// </summary>
        /// <param name="newEnd"></param>
        public void set_endDate(DateTime newEnd)
        {
            dateTimePicker_end.Value = newEnd;
        }
        
        
        /// <summary>
        /// Public function that allows a control form to update an object from this from class's complete candlestick list
        /// </summary>
        /// <param name="filePath">File path of csv stock file</param>
        public void readCandlestickDataFromFile(string filePath)
        {
            readCandlestickDataFromFile(filePath, ref cs_complete);
        }


        private void label_placeholder_symbol_Click(object sender, EventArgs e)
        {

        }
        private void button_add_stockfiles_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Event Handler. Change the candle stick patterns being annotated 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_CSpatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_candlestick_pattern_chart_display();
        }
        /// <summary>
        /// Showcase on the chart the candlestick pattern selected by the combobox 
        /// </summary>
        private void update_candlestick_pattern_chart_display()
        {
            try
            {
                // get the selected pattern
                string pattern = comboBox_CSpatterns.SelectedValue.ToString();
                showcase_candlestick_pattern(pattern);
            }
            catch (System.NullReferenceException) {}
        }
        /// <summary>
        /// Changes the candlestick pattern being highlighted on the candlestick chart
        /// </summary>
        /// <param name="pattern"></param>
        private void showcase_candlestick_pattern(string pattern)
        {
            // check if none pattern
            if (pattern == no_pattern)
            {
                // clear the cs chart of annotations
                chart_candlestick_data.Annotations.Clear();
                // display as normal
                chartDisplayCandlesticks();
            }
            else
            {
                // clear the cs chart of annotations
                chart_candlestick_data.Annotations.Clear();

                // check each candlestick for the selected pattern
                for (int i = 0; i < bindingList_cs_display.Count; i++)
                {
                    // check if pattern is already stored in the candlestick
                    try
                    {
                        // check if smart candlestick is part of the selected pattern
                        if (((Smart_CandleStick)bindingList_cs_display[i]).patterns[pattern])
                        {
                            draw_arrowAnnotation_to_csChart(i);
                        }
                    }
                    // if pattern wasn't stored, then recognize all display candlesticks for all patterns
                    catch (KeyNotFoundException)
                    {
                        // recognize all smart candlesticks in the candlestick display
                        List<Smart_CandleStick> list_scs_display = bindingList_cs_display.Cast<Smart_CandleStick>().ToList();
                        RecognizerManager.recognize_CandlestickPatterns(list_scs_display);

                        // check if smart candlestick is part of the selected pattern
                        if (((Smart_CandleStick)bindingList_cs_display[i]).patterns[pattern])
                        {
                            draw_arrowAnnotation_to_csChart(i);
                        }
                    }
                }
            }
        }
        private void draw_arrowAnnotation_to_csChart(int index)
        {
            ChartArea chart = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"];
            DataPoint currentCS_dp = chart_candlestick_data.Series["Series_HLOC"].Points[index];
            string name = index.ToString();
            Color clr = Color.Blue;
            int chartXRange = bindingList_cs_display.Count;
            add_arrowAnnotation(chart, currentCS_dp, name, clr, chartXRange);
        }
        /// <summary>
        /// Add an arrow annotation to the chart anchored at the datapoint
        /// </summary>
        /// <param name="dp">the datapoint to anchor to</param>
        /// <param name="i">the name of the annotation</param>
        /// <param name="clr">the color of the annotation</param>
        private void add_arrowAnnotation(ChartArea chart, DataPoint dp, string i, Color clr, int chartXRange)
        {         
            // create the arrow annotation
            ArrowAnnotation arrow = new ArrowAnnotation();
            arrow.AnchorDataPoint = dp; // anchor it to the datapoint
            arrow.Name = $"arrow_{i}";
            arrow.LineColor = clr;
            arrow.ClipToChartArea = chart.Name; // ensures the line stays within the chart area

            double size = Math.Min(Math.Max(50/chartXRange, 0.1),5);

            arrow.AnchorOffsetY = -(Math.Min(size, (chart.AxisY.Maximum - dp.YValues[0]-2)));
            arrow.Height = size;
            arrow.Width = size;
            arrow.LineWidth = Math.Max(((int)(size)), 1);
            arrow.ArrowSize = Math.Max(((int)(size)), 1);

            // Add the line annotations to the chart
            chart_candlestick_data.Annotations.Add(arrow);
        }
        /// <summary>
        /// Add two line annotations to chart anchored at the datapoint
        /// </summary>
        /// <param name="dp">Datapoint to anchor to</param>
        /// <param name="i">Integer for name</param>
        private void add_doubleLineAnnotations_to_chart(DataPoint dp, string i)
        {
            double chartYRange = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisY.Maximum - chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisY.Minimum;
            double chartXRange = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisX.Maximum - chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisX.Minimum;
            double lenPercent = 0.10;

            // create the line annotation
            VerticalLineAnnotation topLA = new VerticalLineAnnotation();
            topLA.AnchorDataPoint = dp; // anchor it to the datapoint
            topLA.Name = $"tLA_{i}";
            topLA.ClipToChartArea = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].Name; // ensures the line stays within the chart area
            topLA.Y = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisY.Maximum;
            topLA.Height = lenPercent * chartYRange;

            VerticalLineAnnotation bottomLA = new VerticalLineAnnotation();
            bottomLA.AnchorDataPoint = dp;
            bottomLA.Name = $"bLA_{i}";
            bottomLA.ClipToChartArea = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].Name; // ensures the line stays within the chart area
            bottomLA.Height = 8;
            bottomLA.Y = chart_candlestick_data.ChartAreas["ChartArea_CandleSticks"].AxisY.Minimum + 1;

            if (chartXRange >= 100) { topLA.LineWidth = 1; bottomLA.LineWidth = 1; }
            else if (chartXRange >= 50) { topLA.LineWidth = 3; bottomLA.LineWidth = 3; }
            else if (chartXRange >= 25) { topLA.LineWidth = 5; bottomLA.LineWidth = 5; }
            else { topLA.LineWidth = 9; bottomLA.LineWidth = 9; }

            topLA.LineColor = Color.Red;
            bottomLA.LineColor = Color.Red;

            // Add the line annotations to the chart
            chart_candlestick_data.Annotations.Add(topLA);
            chart_candlestick_data.Annotations.Add(bottomLA);
        }
    }
}
