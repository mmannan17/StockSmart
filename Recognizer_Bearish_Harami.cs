﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365
{
    internal class Recognizer_Bearish_Harami : Recognizer
    {
        //Inherit Constructor
        public Recognizer_Bearish_Harami() : base("Bearish Harami", 2)
        {
        }

        //Abstract Method
        public override bool Recognize(List<SmartCandlestick> scsList, int index)
        {
            //Returnt the existing value or calculate new value
            SmartCandlestick scs = scsList[index];
            if (scs.Dictionary_Pattern.TryGetValue(Pattern_Name, out bool value))
            {
                return value;
            }
            else
            {
                //if out of bounds return false else continue
                int offset = Pattern_Length / 2;
                if (index < offset)
                {
                    scs.Dictionary_Pattern.Add(Pattern_Name, false);
                    return false;
                }
                else
                {
                    SmartCandlestick prev = scsList[index - offset];
                    bool bearish = (prev.open < prev.close) & (scs.close < scs.open);
                    bool harami = (scs.topPrice < prev.topPrice) & (scs.bottomPrice > prev.bottomPrice);
                    bool bearish_harami = bearish & harami;
                    scs.Dictionary_Pattern.Add(Pattern_Name, bearish_harami);
                    return bearish_harami;
                }
            }
        }
    }
}
