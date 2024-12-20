using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Stock_Reader_2024
{
    public partial class Form_Control : Form
    {
        // list of stock reader forms
        public List<Form_StockReader> list_stockreaderFroms = new List<Form_StockReader>();

        public Form_Control()
        {
            InitializeComponent();
        }

        private void Form_Control_Load(object sender, EventArgs e)
        {

        }
        
        
        /// <summary>
        /// Event handler for the button selectfiles click. Opens the open file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_selectfiles_Click(object sender, EventArgs e)
        {
            openFileDialog_selectfiles.ShowDialog();
        }

        /// <summary>
        /// Event handler for the open file diaglog FileOK event. Loads selected files into stock reader forms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_selectfiles_FileOk(object sender, CancelEventArgs e)
        {
            create_stockreaders(ref list_stockreaderFroms, openFileDialog_selectfiles);
            load_stockreaders(list_stockreaderFroms, dateTimePicker_startdate.Value, dateTimePicker_enddate.Value);
        }
        
        /// <summary>
        /// Stores and extracts the information from the selected file(s) into a(the) stock reader form(s). Stores stock reader forms 
        /// </summary>
        /// <param name="list_StockReaders">list of </param>
        /// <param name="sr_files"></param>
        private void create_stockreaders(ref List<Form_StockReader> list_StockReaders, OpenFileDialog sr_files)
        {
            foreach (string fileName in sr_files.FileNames)
            {
                // initalize and populate a new stock reader form
                Form_StockReader sr = new Form_StockReader();
                sr.readCandlestickDataFromFile(fileName);
                // add new form to stock reader form list
                list_StockReaders.Add(sr);
                // subscribe to the FormClosedEvent of the display form
                sr.FormClosedEvent += Form_StockReader_FormClosedEvent;
            }
        }
        /// <summary>
        /// Loads the Stock Readers forms in a list. Information loaded will be between the start and end date.
        /// </summary>
        /// <param name="list_StockReaders">list of stock reader forms</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        private void load_stockreaders(List<Form_StockReader> list_StockReaders, DateTime start, DateTime end)
        {
            foreach (Form_StockReader form_sr in list_StockReaders)
            {
                // set the new dates
                form_sr.set_startDate(start);
                form_sr.set_endDate(end);
                // update the charts data
                form_sr.update_displays();
                // display the chart
                form_sr.Show();
            }
        }
        /// <summary>
        /// Event handler for the FormClosedEvent of stock reader forms. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_StockReader_FormClosedEvent(object sender, EventArgs e)
        {
            var closedForm = (Form_StockReader)sender;

            // Remove the closed form from the list
            list_stockreaderFroms.Remove(closedForm);
        }

        private void button_updatefroms_Click(object sender, EventArgs e)
        {
            load_stockreaders(list_stockreaderFroms, dateTimePicker_startdate.Value, dateTimePicker_enddate.Value);
        }

        /// <summary>
        /// Event handler for the button load stock readers click. Loads the forms selected. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_loadStockReaders_Click(object sender, EventArgs e)
        {

        }
    }
}
