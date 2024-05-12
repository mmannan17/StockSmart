﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365
{
    internal class Recognizer_Bearish : Recognizer
    {
        //Inherit Constructor
        public Recognizer_Bearish() : base("Bearish", 1)
        {
        }

        //Abstract Method
        public override bool Recognize(List<SmartCandlestick> scsList, int index)
        {
            //Return the existing value or calculate new value
            SmartCandlestick scs = scsList[index];
            if (scs.Dictionary_Pattern.TryGetValue(Pattern_Name, out bool value))
            {
                return value;
            }
            else
            {
                bool bearish = scs.open > scs.close;
                scs.Dictionary_Pattern.Add(Pattern_Name, bearish);
                return bearish;
            }
        }
    }
}
