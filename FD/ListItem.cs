using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD
{
    internal class ListItem
    {
        public string DisplayText { get; set; } 
        public object Data { get; set; }  

        public override string ToString()
        {
            return DisplayText; 
        }
    }
}
