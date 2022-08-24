#pragma checksum "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6da8e24df88407b3db166aa565439f67486ae441"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assignment_Assignment), @"mvc.1.0.view", @"/Views/Assignment/Assignment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\_ViewImports.cshtml"
using KNUStudySystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\_ViewImports.cshtml"
using KNUStudySystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6da8e24df88407b3db166aa565439f67486ae441", @"/Views/Assignment/Assignment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"629e3a9517734a88d8b702806bcb8ef79ecce44e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Assignment_Assignment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Assignment>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/tasks.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
  
    bool isProgressNotNullOrHigherThan100(int Progress)
    {
        if (Progress > 100 || Progress < 0)
        {
            return true;
        }
        return false;

    }
    int CalculateProgress(DateTime Deadline, DateTime Assignment_Date)
    {
        DateTime CurrentTime = DateTime.Now;
        int Progress = Convert.ToInt32((1 - ((Deadline - CurrentTime).TotalMinutes / (Deadline - Assignment_Date).TotalMinutes)) * 100);
        if (!isProgressNotNullOrHigherThan100(Progress))
            return Progress;
        else
            return 100;
    }
    string GetTimeLeft(DateTime Deadline)
    {
        DateTime CurrentTime = DateTime.Now;
        TimeSpan TimeDiff = Deadline - CurrentTime;

        if (TimeDiff.Days > 0)
        {
            return(Convert.ToString(TimeDiff.Days) + " Days left");
        }
        else if (TimeDiff.Hours > 0)
        {
            return(Convert.ToString(TimeDiff.Hours) + " Hours left");
        }
        else if (TimeDiff.Minutes > 0)
        {
            return(Convert.ToString(TimeDiff.Minutes) + " Minutes left");
        }
        else if (TimeDiff.TotalSeconds > 0)
        {
            return("Less than one minute");
        }
        return("Time passed");
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- Main-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6da8e24df88407b3db166aa565439f67486ae4415867", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 47 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"task__container-row\">\r\n");
#nullable restore
#line 49 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
     foreach(var item in Model)
    {
        CultureInfo ci = new CultureInfo("en-US");

        int Progress = CalculateProgress(item.Deadline, item.Assignment_Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"task__element\">\r\n        <h4 class = \"task__date\">");
#nullable restore
#line 55 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
                            Write(item.Assignment_Date.ToString("MMMM", ci));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
                                                                       Write(item.Assignment_Date.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 55 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
                                                                                                  Write(item.Assignment_Date.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <p class = \"task__headline set-center\">\r\n          <span>");
#nullable restore
#line 57 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
           Write(item.Assignment_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </p>\r\n        <p class = \"task__detailed set-center\">\r\n          <span>");
#nullable restore
#line 60 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
           Write(item.Assignment_Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </p>\r\n        <span class = \"task__progress\">Progress</span>\r\n        <div class=\"task__progress-bar\">\r\n          <div class=\"progress\"");
            BeginWriteAttribute("style", " style = \"", 2168, "\"", 2196, 3);
            WriteAttributeValue("", 2178, "width:", 2178, 6, true);
#nullable restore
#line 64 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
WriteAttributeValue(" ", 2184, Progress, 2185, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2194, "%;", 2194, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n          </div>\r\n        </div>\r\n        <div class=\"task__days-left\">\r\n            <div class = \"task__days-timer\">\r\n                ");
#nullable restore
#line 69 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
           Write(GetTimeLeft(item.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n      </div>\r\n");
#nullable restore
#line 73 "F:\КНУ\KnuStudySystemFiles\KNUStudySystem\KNUStudySystem\Views\Assignment\Assignment.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Assignment>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
