using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal class Recognizer_BearishHarami : Recognizer
    {
        public Recognizer_BearishHarami() : base("Bearish Harami", 2) { }

        public override bool Recognize(List<Smart_CandleStick> list_SmartCandlestick, int currentIndex)
        {
            // Futuresight Order

            //cs cannot be not the last candlestick in the list
            if (list_SmartCandlestick.Count() >= this.patternLength && currentIndex >= 0 && currentIndex < list_SmartCandlestick.Count()-1)
            {
                Smart_CandleStick candlestick_mother = list_SmartCandlestick[currentIndex]; // current candlestick
                Smart_CandleStick candlestick_child = list_SmartCandlestick[currentIndex + 1]; // next candlestick

                return ((candlestick_child.close < candlestick_child.open) && // child is bearish
                    (candlestick_mother.close > candlestick_mother.open) && // mother is bullish
                    (candlestick_child.bodyRange <= 2 * candlestick_mother.bodyRange) && // the child body range is half or less of the mother 
                    (candlestick_child.topPrice < candlestick_mother.topPrice) && // body range of child is contained in the body of mother 
                    (candlestick_child.bottomPrice > candlestick_mother.bottomPrice));
            }
            return false;
        }
    }

    internal class Recognizer_BullishHarmi : Recognizer
    {
        public Recognizer_BullishHarmi() : base("Bullish Harami", 2) { }

        public override bool Recognize(List<Smart_CandleStick> list_SmartCandlestick, int currentIndex)
        {
            // Futuresight Order

            //cs cannot be not the last candlestick in the list
            if (list_SmartCandlestick.Count() >= this.patternLength && currentIndex >= 0 && currentIndex < list_SmartCandlestick.Count()-1)
            {
                Smart_CandleStick candlestick_mother = list_SmartCandlestick[currentIndex]; // current candlestick
                Smart_CandleStick candlestick_child = list_SmartCandlestick[currentIndex + 1]; // next candlestick

                return ((candlestick_child.close > candlestick_child.open) && // child is bullish
                    (candlestick_mother.close < candlestick_mother.open) && // mother is bearish
                    (candlestick_child.bodyRange <= 2 * candlestick_mother.bodyRange) && // the child less than or equal to half of the mother 
                    (candlestick_child.topPrice < candlestick_mother.topPrice) && // body of child is contained in the body of mother 
                    (candlestick_child.bottomPrice > candlestick_mother.bottomPrice));
            }
            return false;
        }
    }
}
