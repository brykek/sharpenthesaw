using System;
using System.Collections.Generic;

namespace sharpenthesaw.Models.ViewModels
{
    public class IndexViewModel
    {
            public List<Bowlers> bowlers { get; set; }
            public PageNumberingInfo pageNumberingInfo { get; set;}
            public string TeamName { get; set; }
    }
}
