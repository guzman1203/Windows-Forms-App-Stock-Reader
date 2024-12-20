using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using COP4365_Stock_Reader_2024;

namespace WindowsFormsApp_COP_4365_Stock_Reader_2024
{
    internal class Controller_Recognizer
    {
        // the full list of recognizers that recognizer candlestick patterns
        public Dictionary<string, Recognizer> recognizers = get_RecognizerTypes();

        // full list of recognizer pattern names
        public List<string> patternNames = get_patternNames();


        public Controller_Recognizer() { }

        /// <summary>
        /// Recognizes all smart candlesticks in the list for every recognizer.
        /// </summary>
        /// <param name="lscs">list of smart candlesticks</param>
        public void recognize_CandlestickPatterns(List<Smart_CandleStick> lscs) 
        {
            foreach (KeyValuePair<string, Recognizer> kvp in recognizers) 
            {
                kvp.Value.recognizeAll(lscs);
            }
        }

        /// <summary>
        /// Searches the recognizer list for a recognizer with a given pattern name
        /// </summary>
        /// <param name="pattern">name of the patternname variable of the recognizer</param>
        /// <returns></returns>
        private Recognizer get_recognizer(string pattern)
        {
            try
            {
                return recognizers[pattern];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        /// <summary>
        /// Finds all recognizer types within the system and returns a dictionary of each type
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Recognizer> get_RecognizerTypes()
        {
            Dictionary<string, Recognizer> recognizers = new Dictionary<string, Recognizer>();
            Type recognizerType = typeof(Recognizer);
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type type in assembly.GetTypes())
            {
                if (recognizerType.IsAssignableFrom(type) && !type.IsAbstract && type != recognizerType)
                {
                    Recognizer rec = (Recognizer)Activator.CreateInstance(type);
                    recognizers[rec.patternName] = rec;
                }
            }

            return recognizers;
        }

        private static List<string> get_patternNames()
        {
            List<string> patterns = new List<string>();
            // add the name of the pattern to the pattern list
            foreach (var kvp in get_RecognizerTypes())
            {
                patterns.Add(kvp.Key);
            }
            // sort it alphabetically
            patterns.Sort();

            return patterns;
        }
    }
}
