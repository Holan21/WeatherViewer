using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Models.Respones.ResponesLocation
{
    internal class ResponeLocationJSON
    {
        public bool error { get; set; } = true;
        public string msg { get; set; } = string.Empty;
        public string getMsg() { return msg; }
        public bool getError() { return error; }
        public API.Location data { get; set; } = new API.Location();
        public API.Location getData() { return data; }

    }
}
