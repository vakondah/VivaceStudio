using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.TagHelpers
{
    [HtmlTargetElement("my-alert-message")]
    public class AlertMessageTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var td = ViewCtx.TempData;
            if (td.ContainsKey("alert"))
            {
                output.BuildTag("h4", "bg-danger text-center text-white p-2 rounded");
                output.Content.SetContent(td["alert"].ToString());
            }
            else
            {
                output.SuppressOutput();
            }
        }

    }
}
