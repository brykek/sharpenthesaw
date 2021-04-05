using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using sharpenthesaw.Models.ViewModels;

namespace sharpenthesaw.Infrastructure
{
    [HtmlTargetElement("div", Attributes ="page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlinfo;

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlinfo = uhf;
        }

        public PageNumberingInfo PageInfo { get; set; }

        //create our own dictionary
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        //css properties
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlinfo.GetUrlHelper(ViewContext);
            //creates a div for pagination
            TagBuilder finishedTag = new TagBuilder("div");

            //for loop for each page
            for (int i =1; i <= PageInfo.NumPages; i++)
            {
                

                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;

                if (PageClassesEnabled)
                {
                    //styling when a div is selected
                    individualTag.AddCssClass(PageClass);
                    individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);
                individualTag.InnerHtml.Append(i.ToString());



                finishedTag.InnerHtml.AppendHtml(individualTag);
            }



            output.Content.AppendHtml(finishedTag.InnerHtml);
        }


    }
}
