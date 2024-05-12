﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365
{
    internal class Recognizer_Hammer : Recognizer
    {
        //Inherit Constructor
        public Recognizer_Hammer() : base("Hammer", 1)
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
                bool hammer = ((scs.range * 0.20m) < scs.bodyRange) & (scs.bodyRange < (scs.range * 0.33m)) & (scs.lowerTail > scs.range * 0.66m);
                scs.Dictionary_Pattern.Add(Pattern_Name, hammer);
                return hammer;
            }
        }
    }
}
