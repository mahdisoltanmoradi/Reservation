#pragma checksum "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75f9eb39e7e8036a856f60aa006c8231cf9a2312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CourseGroupComponent_CourseGroup), @"mvc.1.0.view", @"/Views/Shared/Components/CourseGroupComponent/CourseGroup.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CourseGroupComponent/CourseGroup.cshtml", typeof(AspNetCore.Views_Shared_Components_CourseGroupComponent_CourseGroup))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75f9eb39e7e8036a856f60aa006c8231cf9a2312", @"/Views/Shared/Components/CourseGroupComponent/CourseGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CourseGroupComponent_CourseGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Practies.DataLayer.Entities.Course.CourseGroup>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 168, true);
            WriteLiteral("<div class=\"main-menu\">\r\n    <div class=\"container\">\r\n        <nav>\r\n            <span class=\"responsive-sign\"><i class=\"zmdi zmdi-menu\"></i></span>\r\n            <ul>\r\n");
            EndContext();
#line 7 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                 foreach (var group in Model.Where(g => g.ParentId == null))
                {

#line default
#line hidden
            BeginContext(333, 62, true);
            WriteLiteral("                    <li>\r\n                        <a href=\"\"> ");
            EndContext();
            BeginContext(396, 16, false);
#line 10 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                               Write(group.GroupTitle);

#line default
#line hidden
            EndContext();
            BeginContext(412, 7, true);
            WriteLiteral(" </a>\r\n");
            EndContext();
#line 11 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                         if (Model.Any(g => g.ParentId == group.GroupId))
                        {

#line default
#line hidden
            BeginContext(521, 34, true);
            WriteLiteral("                            <ul>\r\n");
            EndContext();
#line 14 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                 foreach (var sub in Model.Where(g => g.ParentId == group.GroupId))
                                {

#line default
#line hidden
            BeginContext(691, 52, true);
            WriteLiteral("                                    <li><a href=\"\"> ");
            EndContext();
            BeginContext(744, 14, false);
#line 16 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                               Write(sub.GroupTitle);

#line default
#line hidden
            EndContext();
            BeginContext(758, 12, true);
            WriteLiteral(" </a></li>\r\n");
            EndContext();
#line 17 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                }

#line default
#line hidden
            BeginContext(805, 35, true);
            WriteLiteral("                            </ul>\r\n");
            EndContext();
#line 19 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                        }

#line default
#line hidden
            BeginContext(867, 27, true);
            WriteLiteral("                    </li>\r\n");
            EndContext();
#line 21 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                }

#line default
#line hidden
            BeginContext(913, 55, true);
            WriteLiteral("\r\n            </ul>\r\n        </nav>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Practies.DataLayer.Entities.Course.CourseGroup>> Html { get; private set; }
    }
}
#pragma warning restore 1591
