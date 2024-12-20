using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal class Recognizer_BullishEngulfing : Recognizer
    {
        public Recognizer_BullishEngulfing(): base("Bullish Engulfing", 2) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Futuresight order

            // check for enough candlesticks and index not last element in list
            if (lscs.Count() >= patternLength && 0 <= currentIndex && currentIndex < lscs.Count()-1) 
            {
                //check if the current cs engulfs the previous cs
                Smart_CandleStick ncs = lscs[currentIndex+1];
                Smart_CandleStick ccs = lscs[currentIndex];

                return ((ncs.close > ncs.open)  // next cs is bullish
                     && (ccs.close < ccs.open)  // current cs is bearish
                     && (ncs.topPrice > ccs.topPrice) // next cs topprice is higher than current cs topprice 
                     && (ncs.bottomPrice < ccs.bottomPrice)); // next cs bottomprice is lower than current cs bottomprice
            }
            return false;
        }
    }
    internal class Recognizer_BearishEngulfing : Recognizer
    {
        public Recognizer_BearishEngulfing() : base("Bearish Engulfing", 2) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Futuresight Order

            // check for enough candlesticks and index not last element in list
            if (lscs.Count() >= patternLength && 0 <= currentIndex && currentIndex < lscs.Count()-1)
            {
                //check if the current cs engulfs the previous cs
                Smart_CandleStick ncs = lscs[currentIndex+1];
                Smart_CandleStick ccs = lscs[currentIndex];

                return ((ncs.close < ncs.open)  // next cs is bearish
                     && (ccs.close > ccs.open)  // current cs is bullish
                     && (ncs.topPrice > ccs.topPrice) // next cs topprice is higher than current cs topprice 
                     && (ncs.bottomPrice < ccs.bottomPrice)); // next cs bottomprice is lower than current cs bottomprice                      
            }
            return false;
        }
    }
}
