using System;
using System.Collections.Generic;

namespace sharpenthesaw.Models.ViewModels
{
    public class IndexViewModel
    {
        //model for our index  view
            public List<Bowlers> bowlers { get; set; }
            public PageNumberingInfo pageNumberingInfo { get; set;}
            public string TeamName { get; set; }
    }
}
