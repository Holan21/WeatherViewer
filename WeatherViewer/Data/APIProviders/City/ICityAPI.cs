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
        public Task<List<object>> sendReqest(string coutnry);
    }
}
