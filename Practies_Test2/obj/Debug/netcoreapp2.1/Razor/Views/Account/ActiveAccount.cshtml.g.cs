#pragma checksum "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Account\ActiveAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b2e13881360a6d8da068a2de6cc67c2bdcde24c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ActiveAccount), @"mvc.1.0.view", @"/Views/Account/ActiveAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ActiveAccount.cshtml", typeof(AspNetCore.Views_Account_ActiveAccount))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b2e13881360a6d8da068a2de6cc67c2bdcde24c", @"/Views/Account/ActiveAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ActiveAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Account\ActiveAccount.cshtml"
  
    ViewData["Title"] = "فعال سازی حساب کاربری";

#line default
#line hidden
            BeginContext(59, 262, true);
            WriteLiteral(@"
<nav aria-label=""breadcrumb"">
    <ul class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/"">سینما</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">فعال سازی حساب کاربری </li>
    </ul>
</nav>
<div class=""container"">
");
            EndContext();
#line 13 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Account\ActiveAccount.cshtml"
     if (ViewBag.IsActive==true)
    {

#line default
#line hidden
            BeginContext(362, 196, true);
            WriteLiteral("        <div class=\"alert alert-info\">\r\n            <p>حساب کاربری شما با موفقیت فعال شد</p>\r\n            <p>\r\n                <a href=\"/Login\">ورود به سایت</a>\r\n            </p>\r\n        </div>\r\n");
            EndContext();
#line 21 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Account\ActiveAccount.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(582, 113, true);
            WriteLiteral("        <div class=\"alert alert-danger\">\r\n            <p>حساب کاربری با مشخصات زیر یافت نشد</p>\r\n        </div>\r\n");
            EndContext();
#line 27 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Views\Account\ActiveAccount.cshtml"
    }

#line default
#line hidden
            BeginContext(702, 8, true);
            WriteLiteral("</div>\r\n");
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
