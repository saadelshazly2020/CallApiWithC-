﻿using System.Collections.Generic;

namespace NT.Integration.Medicus.Entities
{
    internal class Panel
    {
        public string panel_name { get; set; }
        public string panel_comment { get; set; }
        public List<Biomarker> biomarkers { get; set; }
        
    }
}