﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public int AreaId { get; set; }        
        public string Rotulo { get; set; }        
        public string Nome { get; set; }
    }
}