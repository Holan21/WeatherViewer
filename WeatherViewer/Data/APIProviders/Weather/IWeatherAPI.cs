using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Data.APIProviders.Weather
{
    internal interface IWeatherAPI
    {
        public Task<Models.API.Weather> sendReqest(Models.API.Location location); 
    }
}
