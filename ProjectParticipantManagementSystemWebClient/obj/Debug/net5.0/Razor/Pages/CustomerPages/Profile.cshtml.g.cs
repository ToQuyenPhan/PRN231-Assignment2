#pragma checksum "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef9ae1d6fb3c44563e2070de99ff179c13a3bccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.Pages_CustomerPages_Profile), @"mvc.1.0.razor-page", @"/Pages/CustomerPages/Profile.cshtml")]
namespace ProjectParticipantManagementSystemWebClient.Pages.CustomerPages
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
#line 1 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\_ViewImports.cshtml"
using ProjectParticipantManagementSystemWebClient;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef9ae1d6fb3c44563e2070de99ff179c13a3bccc", @"/Pages/CustomerPages/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aef98ce31f4597078a210abda72c0e1ad1356442", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_CustomerPages_Profile : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "_CustomerLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Profile</h1>\r\n<div>\r\n    <h4>Employee</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Email Address\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Skills));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Skills));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Department));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Department.DepartmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef9ae1d6fb3c44563e2070de99ff179c13a3bccc9807", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\Profile.cshtml"
                                  WriteLiteral(Model.Employee.EmployeeID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ProfileModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ProfileModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ProfileModel>)PageContext?.ViewData;
        public ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ProfileModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
