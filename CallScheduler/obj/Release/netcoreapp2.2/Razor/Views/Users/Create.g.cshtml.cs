#pragma checksum "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d77d30e32cbd4e40c17f418e3add35ede22d26d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Create), @"mvc.1.0.view", @"/Views/Users/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Create.cshtml", typeof(AspNetCore.Views_Users_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d77d30e32cbd4e40c17f418e3add35ede22d26d7", @"/Views/Users/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"022342d3dceb960d97de97251f131ea87ea006fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-pageSize", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("create-user"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml"
  

    // var isAdmin = (bool)ViewData["IsAdmin"];
    var bankCode = (string)ViewData["BankCode"];

    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(147, 273, true);
            WriteLiteral(@"
<div id=""colorlib-contact"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12 text-center colorlib-heading animate-box"">
                <h2>
                    <span style=""float:left;"">Create User</span>
                    ");
            EndContext();
            BeginContext(420, 183, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d77d30e32cbd4e40c17f418e3add35ede22d26d77032", async() => {
                BeginContext(595, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageSize"] = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(603, 153, true);
            WriteLiteral("\r\n                </h2>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12 animate-box\">\r\n                ");
            EndContext();
            BeginContext(756, 3598, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d77d30e32cbd4e40c17f418e3add35ede22d26d79873", async() => {
                BeginContext(793, 1571, true);
                WriteLiteral(@"
                    <div class=""row form-group"">
                        <div class=""col-md-6"">
                            <input type=""text"" id=""Email"" name=""Email"" class=""form-control"" placeholder=""Email"">
                        </div>
                        <div class=""col-md-6"">
                            <input type=""text"" id=""Username"" name=""Username"" class=""form-control"" placeholder=""Username"">
                        </div>
                    </div>
                    <div class=""row form-group"">
                        <div class=""col-md-6"">
                            <input type=""text"" id=""FirstName"" name=""FirstName"" class=""form-control"" placeholder=""First Name"">
                        </div>
                        <div class=""col-md-6"">
                            <input type=""text"" id=""OtherName"" name=""OtherName"" class=""form-control"" placeholder=""Other Name"">
                        </div>
                    </div>
                    <div class=""row form-group"">
     ");
                WriteLiteral(@"                   <div class=""col-md-6"">
                            <input type=""text"" id=""LastName"" name=""LastName"" class=""form-control"" placeholder=""Last Name"">
                        </div>
                        <div class=""col-md-6"">
                            <input type=""text"" id=""Phone"" name=""Phone"" class=""form-control"" placeholder=""Phone"">
                        </div>
                    </div>
                    <div class=""row form-group"">
                        <div class=""col-md-6"">
                            ");
                EndContext();
                BeginContext(2365, 208, false);
#line 50 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml"
                       Write(Html.DropDownList("RoleName", (SelectList)ViewBag.Roles, "Select Role:",
                           htmlAttributes: new { @id = "RoleName", @class = "form-control new-input", @placeholder = "Select Role:" }));

#line default
#line hidden
                EndContext();
                BeginContext(2573, 418, true);
                WriteLiteral(@"
                        </div>
                        <div class=""col-md-6"">
                            <input type=""file"" id=""imageurl"" class=""form-control"">
                            <span style=""color: #f00;"">
                                * upload photo
                            </span>
                        </div>
                    </div>
                    <div class=""row form-group"">
");
                EndContext();
                BeginContext(3084, 85, true);
                WriteLiteral("                            <div class=\"col-md-12\">\r\n                                ");
                EndContext();
                BeginContext(3170, 212, false);
#line 64 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml"
                           Write(Html.DropDownList("BankCode", (SelectList)ViewBag.Banks, "Select Bank:",
                               htmlAttributes: new { @id = "BankCode", @class = "form-control new-input", @placeholder = "Select Bank:" }));

#line default
#line hidden
                EndContext();
                BeginContext(3382, 38, true);
                WriteLiteral("\r\n                            </div>\r\n");
                EndContext();
                BeginContext(3451, 155, true);
                WriteLiteral("                    </div>\r\n                    <div class=\"row form-group\">\r\n                        <div class=\"col-md-12\">\r\n                            ");
                EndContext();
                BeginContext(3607, 224, false);
#line 71 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml"
                       Write(Html.DropDownList("TeamLeadId", (SelectList)ViewBag.TeamLeads, "Select TeamLead:",
                           htmlAttributes: new { @id = "TeamLeadId", @class = "form-control new-input", @placeholder = "Select TeamLead:" }));

#line default
#line hidden
                EndContext();
                BeginContext(3831, 154, true);
                WriteLiteral("\r\n\r\n                        </div>\r\n                        <input type=\"hidden\" id=\"BankCode\" name=\"BankCode\" class=\"form-control\" placeholder=\"BankCode\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3985, "\"", 4002, 1);
#line 75 "C:\Users\AYOTUNDE IKUMAWOYI\Desktop\ARK\CallScheduler\CallScheduler\Views\Users\Create.cshtml"
WriteAttributeValue("", 3993, bankCode, 3993, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4003, 344, true);
                WriteLiteral(@">
                    </div>
                    
                    <div class=""form-group"">
                        <div align=""center"">
                            <input type=""submit"" value=""Submit"" id=""btn-enter"" class=""btn btn-primary"" style=""width:50%"">
                        </div>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4354, 60, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4431, 2447, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(document).ready(function () {
            console.log(""ready!"");
        });

        $('#create-user').submit(function (event) {
            console.log(""submit!"");
            event.preventDefault();

            var fileUpload = $(""#imageurl"").get(0);
            var files = fileUpload.files;
            var data = new FormData();
            data.append(""Email"", $(""#Email"").val());
            data.append(""Username"", $(""#Username"").val());
            data.append(""FirstName"", $(""#FirstName"").val());
            data.append(""OtherName"", $(""#OtherName"").val());
            data.append(""LastName"", $(""#LastName"").val());
            data.append(""Phone"", $(""#Phone"").val());
            data.append(""RoleName"", $(""#RoleName"").val());
            data.append(""BankCode"", $(""#BankCode"").val());
            data.append(""TeamLeadId"", $(""#TeamLeadId"").val());

            for (var i = 0; i < files.length; i++) {
                data.append(""file""");
                WriteLiteral(@", files[i]);
            }

            $.ajax({
                type: 'POST',
                url: '/api/users/create',
                contentType: false,
                processData: false,
                data: data,
                success: function (message) {

                    console.log(message);
                    var loginSuccess = message.success;
                    var loginStatus = message.status;
                    if (loginSuccess == true) {
                        $.showMessage(null, loginStatus);
                        setTimeout(function () {
                            var url = ""/api/users/1/10"";
                            window.location.href = url;
                        }, 2000);
                    } else {

                        $('#BankCode').val('');
                        $('#RoleName').val('');
                        $('#Phone').val('');
                        $('#LastName').val('');
                        $('#OtherName').val('');
       ");
                WriteLiteral(@"                 $('#FirstName').val('');
                        $('#Username').val('');
                        $('#Email').val('');

                        $.showMessage(null, loginStatus);
                    }
                },
                error: function () {
                    $.showMessage(null, loginStatus);
                }
            });
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(6881, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591