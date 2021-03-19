using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivadloVPF
{
    class formats
    {

        /*
         * Format numbers from Buttons
         * @string value
         */
        public string[] formatFromButton(string value)
        {
            string[] xy = value.Split('-');
            return xy;
        }
    }
}
