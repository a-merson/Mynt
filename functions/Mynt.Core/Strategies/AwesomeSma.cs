﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mynt.Core.Indicators;
using Mynt.Core.Interfaces;
using Mynt.Core.Models;

namespace Mynt.Core.Strategies
{
    public class AwesomeSma : ITradingStrategy
    {
        public string Name => "Awesome SMA";

        public List<Candle> Candles { get; set; }

        public AwesomeSma()
        {
            this.Candles = new List<Candle>();
        }

        public List<int> Prepare()
        {
            var result = new List<int>();

            var ao = Candles.AwesomeOscillator();
            var smaShort = Candles.Sma(20);
            var smaLong = Candles.Sma(40);

            for (int i = 0; i < Candles.Count; i++)
            {
                if (i == 0)
                    result.Add(0);
                else if ((ao[i] > 0 && ao[i - 1] < 0 && smaShort[i] > smaLong[i]) ||
                    (ao[i] > 0 && smaShort[i] > smaLong[i] && smaShort[i - 1] < smaLong[i - 1]))
                    result.Add(1);
                else
                    result.Add(0);
            }

            return result;
        }
    }
}
