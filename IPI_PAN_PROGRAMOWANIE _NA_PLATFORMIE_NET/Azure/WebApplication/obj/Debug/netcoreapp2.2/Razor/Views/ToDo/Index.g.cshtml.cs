#pragma checksum "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee39ccbda8956e289148a73deb9650e4e5403762"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ToDo_Index), @"mvc.1.0.view", @"/Views/ToDo/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ToDo/Index.cshtml", typeof(AspNetCore.Views_ToDo_Index))]
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
#line 1 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#line 2 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#line 2 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
using Humanizer;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee39ccbda8956e289148a73deb9650e4e5403762", @"/Views/ToDo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_ToDo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TodoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkDone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
  
    ViewData["Title"] = "Manage your todo list";

#line default
#line hidden
            BeginContext(101, 79, true);
            WriteLiteral("\r\n<div class=\"panel panel-default todo-panel\">\r\n    <div class=\"panel-heading\">");
            EndContext();
            BeginContext(181, 17, false);
#line 9 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(198, 219, true);
            WriteLiteral("</div>\r\n\r\n    <table class=\"table table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <td>&#x2714;</td>\r\n                <td>Item</td>\r\n                <td>Due</td>\r\n            </tr>\r\n        </thead>\r\n\r\n");
            EndContext();
#line 20 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
         foreach (var item in Model.Items)
        {

#line default
#line hidden
            BeginContext(472, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(532, 246, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee39ccbda8956e289148a73deb9650e4e54037625727", async() => {
                BeginContext(574, 157, true);
                WriteLiteral("\r\n                        <input type=\"checkbox\" class=\"done-checkbox\" onchange=\"this.form.submit()\">\r\n                        <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 731, "\"", 747, 1);
#line 26 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
WriteAttributeValue("", 739, item.Id, 739, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(748, 23, true);
                WriteLiteral(">\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(778, 45, true);
            WriteLiteral("\r\n                </td>\r\n                <td>");
            EndContext();
            BeginContext(824, 10, false);
#line 29 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
               Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(834, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(862, 21, false);
#line 30 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
               Write(item.DueAt.Humanize());

#line default
#line hidden
            EndContext();
            BeginContext(883, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 32 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(920, 80, true);
            WriteLiteral("    </table>\r\n\r\n    <div class=\"panel-footer add-item-form\">\r\n        \r\n        ");
            EndContext();
            BeginContext(1001, 67, false);
#line 37 "C:\Users\luc\Documents\GitHub\luc-repository\IPI_PAN_PROGRAMOWANIE _NA_PLATFORMIE_NET\Azure\WebApplication\Views\ToDo\Index.cshtml"
   Write(await Html.PartialAsync("_AddItemPartial", new TodoItemViewModel()));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 22, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TodoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591