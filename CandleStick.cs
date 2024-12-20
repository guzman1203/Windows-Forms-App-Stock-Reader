using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Stock_Reader_2024
{
    internal class CandleStick
    {
        // Constant static properties
        public static readonly string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";
        private static readonly char[] input_delimiters = { ',' };
        private static readonly char[] name_delimiters = { '-', '.' };

        // Class Properties 
        public string ticker { get; set; }
        public string period { get; set; }
        public DateTime date { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }

        //
        // Constructors
        //
        public CandleStick()
        {
            // Assign default candlestick's properties
            ticker = "";
            period = "";
            date = DateTime.Now;
            open = 0;
            high = 0;
            low = 0;
            close = 0;
            volume = 0;
        }
        public CandleStick(string cvs_input, string cvs_filename)
        {
            // Split the cvs filename into 3 values: Ticker, Period, file extention
            string[] cs_filename = cvs_filename.Split(name_delimiters);

            // Split the cvs input string into 7 values: Date,Open,High,Low,Close,Adj Close,Volume
            string[] cs_values = (cvs_input.Split(input_delimiters));

            // Confirm the splits occured correctly
            if (cs_values.Length != 7 && cs_filename.Length != 3)
            {
                throw new ArgumentException("Invalid cvs file");
            }

            // Assign the candlestick's properties
            ticker = cs_filename[0];
            period = cs_filename[1];
            date   = DateTime.Parse(cs_values[0]);
            open   = Convert.ToDouble(cs_values[1]);
            high   = Convert.ToDouble(cs_values[2]);
            low    = Convert.ToDouble(cs_values[3]);
            close  = Convert.ToDouble(cs_values[4]);
            volume = Convert.ToDouble(cs_values[6]);
        }
    }
}
