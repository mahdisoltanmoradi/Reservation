#pragma checksum "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2348b622b5d63edfe55559c41f2997ae9b50abcc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_UserFactors), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/UserFactors.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/UserPanel/Views/Home/UserFactors.cshtml", typeof(AspNetCore.Areas_UserPanel_Views_Home_UserFactors))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2348b622b5d63edfe55559c41f2997ae9b50abcc", @"/Areas/UserPanel/Views/Home/UserFactors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    public class Areas_UserPanel_Views_Home_UserFactors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Practies.DataLayer.Entities.FoodPrograms.Factor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SideBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
  
    ViewData["Title"] = "UserFactors";

#line default
#line hidden
            BeginContext(116, 413, true);
            WriteLiteral(@"


<div class=""container"">
    <nav aria-label=""breadcrumb"">
        <ul class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""/"">خانه</a></li>
            <li class=""breadcrumb-item active"" aria-current=""page""> پنل کاربری </li>
        </ul>
    </nav>
</div>



<main>
    <div class=""container"">
        <div class=""user-account"">
            <div class=""row"">
                ");
            EndContext();
            BeginContext(529, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10e5aacf9977477891d334e4cc2d78c5", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(556, 1270, true);
            WriteLiteral(@"
                <div class=""col-md-9 col-sm-8 col-xs-12"">
                    <div class=""panel panel-default"">
                        <div class=""panel-heading"">
                            لیست فاکتورها
                        </div>
                        <hr />
                        <!-- /.panel-heading -->
                        <div class=""panel-body"">
                            <div class=""table-responsive"">
                                <div id=""dataTables-example_wrapper"" class=""dataTables_wrapper form-inline"" role=""grid"">

                                    <table class=""table table-striped table-bordered table-hover dataTable no-footer"" id=""dataTables-example"" aria-describedby=""dataTables-example_info"">
                                        <thead>
                                            <tr>
                                                <th>نام کاربر</th>
                                                <th>نام غذا</th>
                                            ");
            WriteLiteral("    <th>قیمت غذا</th>\r\n                                                <th>تاریخ خرید غذا</th>\r\n                                            </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n");
            EndContext();
#line 45 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                             foreach (var factor in Model)
                                            {

#line default
#line hidden
            BeginContext(1949, 110, true);
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
            EndContext();
            BeginContext(2060, 20, false);
#line 48 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                                   Write(factor.User.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2080, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(2144, 20, false);
#line 49 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                                   Write(factor.Food.FoodName);

#line default
#line hidden
            EndContext();
            BeginContext(2164, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(2228, 17, false);
#line 50 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                                   Write(factor.Food.Price);

#line default
#line hidden
            EndContext();
            BeginContext(2245, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(2309, 22, false);
#line 51 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                                   Write(factor.Food.CreateDate);

#line default
#line hidden
            EndContext();
            BeginContext(2331, 62, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
            EndContext();
#line 53 "C:\Users\Mahdi\Desktop\core تمرین\Practies_Test2\Practies_Test2\Areas\UserPanel\Views\Home\UserFactors.cshtml"
                                            }

#line default
#line hidden
            BeginContext(2440, 420, true);
            WriteLiteral(@"                                        </tbody>
                                    </table>


                                </div>
                            </div>

                        </div>
                        <!-- /.panel-body -->
                        <!-- /.panel -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>






");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Practies.DataLayer.Entities.FoodPrograms.Factor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
