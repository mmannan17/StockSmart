﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365
{
    internal class Recognizer_Doji : Recognizer
    {
        //Inherit Constructor
        public Recognizer_Doji() : base("Doji", 1)
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
                bool doji = scs.bodyRange < (scs.range * 0.03m);
                scs.Dictionary_Pattern.Add(Pattern_Name, doji);
                return doji;
            }
        }
    }
}
