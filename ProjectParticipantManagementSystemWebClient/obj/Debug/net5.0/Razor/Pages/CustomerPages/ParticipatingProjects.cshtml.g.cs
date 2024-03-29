#pragma checksum "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e867aa4d677ee06baf08ee6546c5bab0a04c479f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.Pages_CustomerPages_ParticipatingProjects), @"mvc.1.0.razor-page", @"/Pages/CustomerPages/ParticipatingProjects.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e867aa4d677ee06baf08ee6546c5bab0a04c479f", @"/Pages/CustomerPages/ParticipatingProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aef98ce31f4597078a210abda72c0e1ad1356442", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_CustomerPages_ParticipatingProjects : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
  
    ViewData["Title"] = "Participating Projects";
    Layout = "_CustomerLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Participating Projects</h1>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Company Project
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Project Role
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 26 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
         foreach (var item in Model.ParticipatingProjects)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompanyProject.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 38 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
                 if (item.ProjectRole == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        Project Manager\r\n                    </td>\r\n");
#nullable restore
#line 43 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        Project Member\r\n                    </td>\r\n");
#nullable restore
#line 49 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
               Write(Html.DisplayFor(modelItem => item.Employee.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\lennovo\source\repos\PhanThiToQuyen_SE150351_A02\ProjectParticipantManagementSystemWebClient\Pages\CustomerPages\ParticipatingProjects.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ParticipatingProjectsModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ParticipatingProjectsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ParticipatingProjectsModel>)PageContext?.ViewData;
        public ProjectParticipantManagementSystemWebClient.Pages.CustomerPages.ParticipatingProjectsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
