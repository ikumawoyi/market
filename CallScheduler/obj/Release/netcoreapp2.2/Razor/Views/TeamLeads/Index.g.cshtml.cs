#pragma checksum "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce5ec058ec31fe2afaba46bb8a97f288f0a7bd0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TeamLeads_Index), @"mvc.1.0.view", @"/Views/TeamLeads/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TeamLeads/Index.cshtml", typeof(AspNetCore.Views_TeamLeads_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce5ec058ec31fe2afaba46bb8a97f288f0a7bd0f", @"/Views/TeamLeads/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"022342d3dceb960d97de97251f131ea87ea006fa", @"/Views/_ViewImports.cshtml")]
    public class Views_TeamLeads_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<TeamLead>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
  
    ViewData["Title"] = "TeamLeads";
    var index = (int)((Model.PageIndex - 1) * 10) + 1;
    // var firstPage = 1;
    var lastPage = ViewBag.NumberOfPages;

#line default
#line hidden
            BeginContext(205, 275, true);
            WriteLiteral(@"
<div class=""colorlib-blog"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12 text-center colorlib-heading animate-box"">
                <h2>
                    <span style=""float:left;"">Team Leads</span>
                </h2>
");
            EndContext();
#line 17 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                 if (Model.Count == 0)
                {

#line default
#line hidden
            BeginContext(539, 107, true);
            WriteLiteral("                <p style=\"color:red;\">\r\n                    No Team Lead available.\r\n                </p>\r\n");
            EndContext();
#line 22 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(665, 36, true);
            WriteLiteral("            </div>\r\n        </div>\r\n");
            EndContext();
#line 25 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
         if (Model.Count != 0)
        {

#line default
#line hidden
            BeginContext(744, 1057, true);
            WriteLiteral(@"            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""hpanel"">
                        <div class=""panel-heading"">
                            <div class=""panel-tools"">
                                <a class=""showhide""><i class=""fa fa-chevron-up""></i></a>
                                <a class=""closebox""><i class=""fa fa-times""></i></a>
                            </div>
                        </div>
                        <div class=""panel-body no-border no-shadow"">
                            <div class=""table-responsive"">
                                <table cellpadding=""1"" cellspacing=""1"" class=""table table-bordered table-striped"">
                                    <thead>
                                        <tr>
                                            <th>S/N</th>
                                            <th>Name</th>
                                        </tr>
                                    </thead>
            ");
            WriteLiteral("                        <tbody>\r\n");
            EndContext();
#line 46 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                                         foreach (var mess in Model)
                                        {

#line default
#line hidden
            BeginContext(1914, 102, true);
            WriteLiteral("                                            <tr>\r\n                                                <td>");
            EndContext();
            BeginContext(2018, 7, false);
#line 49 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                                                Write(index++);

#line default
#line hidden
            EndContext();
            BeginContext(2026, 59, true);
            WriteLiteral("</td>\r\n                                                <td>");
            EndContext();
            BeginContext(2086, 9, false);
#line 50 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                                               Write(mess.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2095, 58, true);
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
            EndContext();
#line 52 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
                                        }

#line default
#line hidden
            BeginContext(2196, 312, true);
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class=""panel-footer"">
                        </div>
                    </div>
                </div>
            </div>
");
            EndContext();
#line 62 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\TeamLeads\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2519, 22, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<TeamLead>> Html { get; private set; }
    }
}
#pragma warning restore 1591
