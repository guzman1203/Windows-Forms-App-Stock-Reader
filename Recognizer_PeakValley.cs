using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal class Recognizer_Peak : Recognizer
    {
        public Recognizer_Peak() : base("Peak", 3) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Futuresight Order

            // index cannot be not the first or the last candlestick in the list
            if (lscs.Count() >= this.patternLength && currentIndex > 0 && currentIndex < lscs.Count() - 1 && currentIndex > 0)
            {
                Smart_CandleStick prevCS = lscs[currentIndex - 1];
                Smart_CandleStick currCS = lscs[currentIndex];
                Smart_CandleStick nextCS = lscs[currentIndex + 1];

                return (nextCS.high < currCS.high && prevCS.high < currCS.high);
            }
            return false;
        }
    }

    internal class Recognizer_Valley : Recognizer
    {
        public Recognizer_Valley() : base("Valley", 3) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            //Futuresight Order

            // index cannot be not the first or the last candlestick in the list
            if (lscs.Count() >= this.patternLength && currentIndex > 0 && currentIndex < lscs.Count() - 1)
            {
                // check if the pattern already exists on this cs
                Smart_CandleStick prevCS = lscs[currentIndex - 1];
                Smart_CandleStick currCS = lscs[currentIndex];
                Smart_CandleStick nextCS = lscs[currentIndex + 1];

                // the middle candlestick must be lower than the two besides it
                return ((nextCS.low > currCS.low) && (prevCS.low > currCS.low));
            }

            return false;
        }
    }
}
