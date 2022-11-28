using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Models.API.JSON
{
    internal class ResponeJSON
    {
        public bool error { get; set;} = true;
        public string msg { get; set; } = string.Empty;
        public object[] data { get; set; } = new string[0];

        public object[] getData() { return data; }

        public string getMsg()
        {
            return msg;
        }
    }
}
