#pragma checksum "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86145cf24caefcf1b2bff46c7be8c50a8b19f3dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Details.cshtml", typeof(AspNetCore.Views_Users_Details))]
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
#line 1 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\_ViewImports.cshtml"
using CallScheduler;

#line default
#line hidden
#line 2 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\_ViewImports.cshtml"
using CallScheduler.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86145cf24caefcf1b2bff46c7be8c50a8b19f3dd", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"022342d3dceb960d97de97251f131ea87ea006fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-pageSize", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(19, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var imageUrl = (string.IsNullOrEmpty(Model.ImageName) || Model.ImageName == "Invalid image file") ? "person1.jpg" : Model.ImageName;

#line default
#line hidden
            BeginContext(202, 358, true);
            WriteLiteral(@"
<div class=""light-skin fixed-navbar sidebar-scroll"">
    <div id=""wrapper"">
        <div class=""content content-boxed"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""hpanel blog-article-box hgreen"">
                        <div class=""panel-heading"">
                            <h4>Username: ");
            EndContext();
            BeginContext(561, 14, false);
#line 15 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                     Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(575, 219, true);
            WriteLiteral(" </h4>\r\n                        </div>\r\n                        <div class=\"panel-body \">\r\n                            <p>\r\n                                <a class=\"pull-left\">\r\n                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 794, "\"", 817, 2);
            WriteAttributeValue("", 800, "/images/", 800, 8, true);
#line 20 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
WriteAttributeValue("", 808, imageUrl, 808, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(818, 261, true);
            WriteLiteral(@" alt=""profile-picture"" style=""width:265px;height:235px;"">
                                </a>
                            </p>
                            <p>
                                <span>
                                    <b>First Name: </b>  ");
            EndContext();
            BeginContext(1080, 15, false);
#line 25 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                                    Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1095, 180, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                                <span>\r\n                                    <b>Other Name: </b>  ");
            EndContext();
            BeginContext(1276, 15, false);
#line 29 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                                    Write(Model.OtherName);

#line default
#line hidden
            EndContext();
            BeginContext(1291, 179, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                                <span>\r\n                                    <b>Last Name: </b>  ");
            EndContext();
            BeginContext(1471, 14, false);
#line 33 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                                   Write(Model.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1485, 175, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                                <span>\r\n                                    <b>Email: </b>  ");
            EndContext();
            BeginContext(1661, 11, false);
#line 37 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                               Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1672, 175, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                                <span>\r\n                                    <b>Phone: </b>  ");
            EndContext();
            BeginContext(1848, 17, false);
#line 41 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                               Write(Model.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1865, 174, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                                <span>\r\n                                    <b>Role: </b>  ");
            EndContext();
            BeginContext(2040, 14, false);
#line 45 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Details.cshtml"
                                              Write(Model.RoleName);

#line default
#line hidden
            EndContext();
            BeginContext(2054, 237, true);
            WriteLiteral("\r\n                                </span>\r\n                                <br />\r\n                            </p>\r\n                            <br />\r\n                        </div>\r\n                        <div class=\"panel-footer\">\r\n");
            EndContext();
            BeginContext(2494, 82, true);
            WriteLiteral("                            <div align=\"center\">\r\n                                ");
            EndContext();
            BeginContext(2576, 175, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86145cf24caefcf1b2bff46c7be8c50a8b19f3dd10902", async() => {
                BeginContext(2743, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageSize"] = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2751, 180, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomUser> Html { get; private set; }
    }
}
#pragma warning restore 1591