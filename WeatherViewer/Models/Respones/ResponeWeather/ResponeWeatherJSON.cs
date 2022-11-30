using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Models.Respones.ResponeWeather
{
    internal class ResponeWeatherJSON
    {
        // TODO: Указать правильный тип данных

        public object coord { get; set; } = new();
        public object weather { get; set; } = new();
        public object @base { get; set; } = new(); // TODO: Убрать!
        public object main { get; set; } = new();
        public object visibility { get; set; } = new();
        public object wind { get; set; } = new();
        public object clouds { get; set; } = new();
        public object rain { get; set; } = new();
        public object snow { get; set; } = new();
        public object dt { get; set; } = new();
        public object sys { get; set; } = new();
        public object timezone { get; set; } = new();
        public object id { get; set; } = new();
        public object name { get; set; } = new();
        public object cod { get; set; } = new();
    }
}