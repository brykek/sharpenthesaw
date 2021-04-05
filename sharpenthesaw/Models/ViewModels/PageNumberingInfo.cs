using System;
namespace sharpenthesaw.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int  CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //calculate number of pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage));
    }
}
