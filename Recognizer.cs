using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COP4365_Stock_Reader_2024;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal abstract class Recognizer
    {
        public string patternName;
        public int patternLength;

        public Recognizer(string pN, int pL)
        {
            this.patternName = pN;
            this.patternLength = pL;
        }
        public abstract bool Recognize(List<Smart_CandleStick> lscs, int index);

        public void recognizeAll(List<Smart_CandleStick> lscs)
        {
            for (int i = 0; i < lscs.Count(); i++)
            {
                if (!lscs[i].patterns.TryGetValue(this.patternName, out bool isFound))
                {
                    lscs[i].patterns[this.patternName] = Recognize(lscs, i);
                }
            }
        }
    }
    /*    
    internal class Recognizer_ : Recognizer
    {
        public Recognizer_() : base("", 1) {}

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            //current cs
            Smart_CandleStick currentCS = lscs[currentIndex];
            //if close > open than the current cs is bullish
            return currentCS.close > currentCS.open;
        }
    }
    */

    internal class Recognizer_Bullish : Recognizer
    {
        public Recognizer_Bullish() : base("Bullish", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                //current cs
                Smart_CandleStick currentCS = lscs[currentIndex];
                //if cs's close > cs's open than the current cs is bullish
                return currentCS.close > currentCS.open;
            }
            return false;
        }
    }

    internal class Recognizer_Bearish : Recognizer
    {
        public Recognizer_Bearish() : base("Bearish", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                //current cs
                Smart_CandleStick currentCS = lscs[currentIndex];
                //if cs's close < cs's open than the current cs is bearish
                return currentCS.close < currentCS.open;
            }
            return false;
        }
    }

    internal class Recognizer_Hammer : Recognizer
    {
        public Recognizer_Hammer() : base("Hammer", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                return isHammer(lscs[currentIndex]);
            }
            return false;
        }

        // Hammmer
        // body between 10% to 40% of range
        // upper tail 1% or less of range
        // lower tail > body range
        private bool isHammer(Smart_CandleStick cs)
        {
            double gn_p = 0.05;

            double mx_br = 0.4 * cs.range;
            double mn_br = 0.1 * cs.range;

            bool isHammer = true;
            if (!(cs.bodyRange >= mn_br && cs.bodyRange <= mx_br)) { isHammer = false; } // bodyrange
            if (!(cs.upperTail <= gn_p * cs.range)) { isHammer = false; } // upper tail
            if (!(cs.lowerTail > cs.bodyRange)) { isHammer = false; } // lower tail
            return isHammer;
        }
    }

    internal class Recognizer_InvHammer : Recognizer
    {
        public Recognizer_InvHammer() : base("Inverse Hammer", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                return isInvHammer(lscs[currentIndex]);
            }
            return false;
        }
        // Inverse hammer
        // body between 10% to 40% of range
        // bottom tail 20% or less of range
        // upper tail > body range
        private bool isInvHammer(Smart_CandleStick cs)
        {
            double gn_p = 0.05;

            bool isHammer = true;
            double mx_br = 0.4 * cs.range;
            double mn_br = 0.1 * cs.range;

            if (!(cs.bodyRange >= mn_br && cs.bodyRange <= mx_br)) { isHammer = false; } // body range range
            if (!(cs.upperTail > cs.bodyRange)) { isHammer = false; } // upper tail is greater than lower tail
            if (!(cs.lowerTail <= gn_p * cs.range)) { isHammer = false; } // lower tail is small or missing
            return isHammer;
        }

    }

    internal class Recognizer_HangingMan : Recognizer
    {
        public Recognizer_HangingMan() : base("Hangingman", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Hanging man
            // isBearish
            // lowerTail >= 2*bodyRange
            // upperTail 5% or less of range

            bool isHangingman = false;
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                isHangingman = true;
                double gn_p = 0.05;
                Recognizer_Bearish recBearish = new Recognizer_Bearish();
                Smart_CandleStick currentCS = lscs[currentIndex];

                if (!recBearish.Recognize(lscs, currentIndex)) { isHangingman = false; } // cs is bearish
                else if (!(currentCS.lowerTail >= 2 * currentCS.bodyRange)) { isHangingman = false; } // lower tail is twice as big as body range
                else if (!(currentCS.upperTail <= gn_p * currentCS.range)) { isHangingman = false; } // upper tail is small or missing
            }

            return isHangingman;
        }
    }

    internal class Recognizer_Doji : Recognizer
    {
        public Recognizer_Doji() : base("Doji", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                return isDoji(lscs[currentIndex]);
            }
            return false;
        }

        // Doji
        // top price ~= bottom price
        private bool isDoji(Smart_CandleStick cs)
        {
            double gn_p = 0.05;
            bool isDoji = true;

            if (!((cs.bodyRange) <= gn_p)) { isDoji = false; }

            return isDoji;
        }

    }

    internal class Recognizer_DragonflyDoji : Recognizer
    {
        public Recognizer_DragonflyDoji() : base("Dragonfly Doji", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Doji Dragonfly
            // is a Doji
            // lower tail >= 2/3 range 
            bool isDragonflyDoji = false;
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                isDragonflyDoji = true;
                Recognizer_Doji recDoji = new Recognizer_Doji();
                Smart_CandleStick cs = lscs[currentIndex];

                if (!recDoji.Recognize(lscs, currentIndex)) { isDragonflyDoji = false; }
                else if (!(cs.lowerTail >= ((2.0 / 3.0) * cs.range))) { isDragonflyDoji = false; }
                //else if (!(cs.upperTail <= ((1/3) * cs.range))) { isDragonflyDoji = false; }
            }

            return isDragonflyDoji;
        }
    }

    internal class Recognizer_Gravestone : Recognizer
    {
        public Recognizer_Gravestone() : base("Gravestone Doji", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            // Doji Gravestone
            // is a Doji
            // upper tail >= 2/3 range

            bool isGravestoneDoji = false;
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                isGravestoneDoji = true;
                Recognizer_Doji recDoji = new Recognizer_Doji();
                Smart_CandleStick cs = lscs[currentIndex];

                if (!recDoji.Recognize(lscs, currentIndex)) { isGravestoneDoji = false; }
                else if (!(cs.upperTail >= ((2.0 / 3.0) * cs.range))) { isGravestoneDoji = false; }
                //else if (!(cs.lowerTail <= ((1/3) * cs.range))) { isGravestoneDoji = false; }
            }
            return isGravestoneDoji;
        }
    }

    internal class Recognizer_Marubozu : Recognizer
    {
        public Recognizer_Marubozu() : base("Marubozu", 1) { }

        public override bool Recognize(List<Smart_CandleStick> lscs, int currentIndex)
        {
            if (currentIndex >= patternLength - 1 && currentIndex < lscs.Count()) //cs cannot be not the first or second candlestick in the list
            {
                return isMarubozu(lscs[currentIndex]);
            }
            return false;
        }

        // Marubozu "shaved head"
        // bodyrange >= 90% of range
        private bool isMarubozu(Smart_CandleStick scs)
        {
            double gn_p = 0.05;
            bool isMarubozu = true;

            if (!(scs.lowerTail <= gn_p * scs.range)) { isMarubozu = false; }
            else if (!(scs.upperTail <= gn_p * scs.range)) { isMarubozu = false; }

            return isMarubozu;
        }
    }


}

