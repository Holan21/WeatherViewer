using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WetherViewer.Models.API.JSON;

namespace WetherViewer.Data.APIProviders.City
{
    internal interface ICityAPI
    {
        public Task<ResponeJSON> sendReqestGetJSON(string coutnry);
    }
}
