using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using COP4365_Stock_Reader_2024;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal class Smart_CandleStick : CandleStick
    {
        // class variables
        public double range { get; set; }
        public double bodyRange { get; set; }
        public double topPrice { get; set; }
        public double bottomPrice { get; set; }
        public double upperTail { get; set; }
        public double lowerTail { get; set; }

        static private readonly double gn_p = 0.075; // percent of range to be considered not existing

        // pattern properties
        public Dictionary<string, bool> patterns = new Dictionary<string, bool>();
    
        //
        // constructors
        //

        // default constructor
        public Smart_CandleStick() : base()
        {
            ticker = "";
            date = DateTime.Now;
            period = "";
            range = 0;
            bodyRange = 0;
            topPrice = 0;
            bottomPrice = 0;
            upperTail = 0;
            lowerTail = 0;
        }
        // copy constructor
        public Smart_CandleStick(CandleStick cs)
        {
            this.ticker = cs.ticker;
            this.period = cs.period;
            this.date = cs.date;
            this.high = cs.high;
            this.low = cs.low;
            this.open = cs.open;
            this.close = cs.close;
            this.volume = cs.volume;
            computeExtraProperties();
        }
        // base constructor
        public Smart_CandleStick(string cvs_input, string cvs_filename) : base(cvs_input, cvs_filename) 
        { 
            computeExtraProperties();
        }
        /// <summary>
        /// compute the extra properties of a smart candlestick
        /// </summary>
        private void computeExtraProperties()
        {
            range = this.high - this.low;
            bodyRange = Math.Abs(this.open - this.close);
            topPrice = Math.Max(this.open, this.close);
            bottomPrice = Math.Min(this.close, this.open);
            upperTail = Math.Abs(this.high - topPrice);
            lowerTail = Math.Abs(this.bottomPrice - this.low);
        }
    }
}
