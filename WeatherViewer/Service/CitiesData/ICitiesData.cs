﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Service.CitiesData
{
    internal interface ICitiesData
    {
        List<string> getCitys(string coutnry);
    }
}