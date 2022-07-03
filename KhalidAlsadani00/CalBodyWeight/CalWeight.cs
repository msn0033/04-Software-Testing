using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalBodyWeight
{
    public class CalWeight
    {
        public int Height { get; set; }
        public string Sex { get; set; }

        public double GetBodyWeight()
        {
            switch (Sex)
            {
                case "m":
                    return (Height - 100) - ((Height - 150) / 4);
                case "w":
                    return (Height - 100) - ((Height - 150) / 2);
                default:
                    return 0;
            }
        }
    }
}