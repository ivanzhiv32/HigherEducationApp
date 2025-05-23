#pragma checksum "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9d8c2f2edaead7d642be20d433a3c8a6c07e16b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RegionReport_Details), @"mvc.1.0.view", @"/Views/RegionReport/Details.cshtml")]
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
#line 1 "D:\Учеба\Диплом\HigherEducationApp\Views\_ViewImports.cshtml"
using HigherEducationApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Учеба\Диплом\HigherEducationApp\Views\_ViewImports.cshtml"
using HigherEducationApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9d8c2f2edaead7d642be20d433a3c8a6c07e16b", @"/Views/RegionReport/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebccbc7ee510f41f8db04af68282ecd212d188a0", @"/Views/_ViewImports.cshtml")]
    public class Views_RegionReport_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HigherEducationApp.Models.RegionReport>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/YearReportPlot.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9d8c2f2edaead7d642be20d433a3c8a6c07e16b3800", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {

        var data = google.visualization.arrayToDataTable([
            ['Направление', 'Кол-во студентов'],
            ['Гуманитарные науки', ");
#nullable restore
#line 16 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                              Write(Model.CountAllStudents);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"],
            ['Искусство и культура', 89226],
            ['Оборона и безопасность государства, военные науки', 64],
            ['Математические и естественные науки', 172926],
            ['Инженерное дело, технологии и технические науки', 901026],
            ['Здравоохранение и медицинские науки', 335333],
            ['Сельское хозяйство и сельскохозяйственные науки', 111652],
            ['Науки об обществе', 793967],
            ['Образование и педагогические науки', 262305]
        ]);

        var options = {
            title: 'My Daily Activities',
            sliceVisibilityThreshold: .00001
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
    }
</script>

<div class=""info"" id=""res"" style=""font: normal 400 11px Tahoma;"">
    <h1>Характеристика высшего образование в РФ</h1>
    <h2>");
#nullable restore
#line 40 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
   Write(Model.YearReport.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 40 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                            Write(Model.Region.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>

    <div id=""statistic"" style=""width: 100%; position: relative; margin: 10px 0px 0px;"">
        <div class=""statistic_info"" style=""position: relative;padding: 4px 9px;font: 20px / 20px Tahoma;color: rgb(68, 85, 85);left: 0px;"" id=""statistic_info_all"">
            <span>
");
#nullable restore
#line 45 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                   for (int i = 1; i < Model.Region.Institutions.Count; i++)
                  {
                      if(Model.Region.Institutions[i].InstitutionReports == null)
                      {
                          i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                          <span class=\"val\">");
#nullable restore
#line 50 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 51 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                          break;
                      }
                  }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                 организаций высшего образования<sup style=""font:9px Calibri;"">*</sup>, в том числе:</span>

            <hr style=""border:none;border-bottom:1px solid #aaa;margin:0px 9px;"">
        </div>

        <div class=""statistic_info"" style=""position: relative;padding: 4px 9px;font: 20px / 20px Tahoma;color: rgb(68, 85, 85);left: 0px;"" id=""statistic_info_chart_kont"">
            <div style=""border-left:10px solid #88b;padding:0px 6px;margin:4px 0px;margin-left:6px;"">
                <span class=""val"" style=""font-size:15px;"">");
#nullable restore
#line 61 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                                                     Write(Model.CountAllStudents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> студентов, обучающихся по программам высшего образования\r\n            </div>\r\n            <div style=\"border-left:10px solid #c8a;padding:0px 6px;margin:4px 0px;margin-left:6px;\">\r\n                <span class=\"val\" style=\"font-size:15px;\">");
#nullable restore
#line 64 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                                                     Write(Model.CountFullTimeStudents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> студентов очной формы обучения\r\n            </div>\r\n            <div style=\"border-left:10px solid #9a8;padding:0px 6px;margin:4px 0px;margin-left:6px;\">\r\n                <span class=\"val\" style=\"font-size:15px;\">");
#nullable restore
#line 67 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
                                                     Write(Model.CountFreeFormStudents);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> студентов за счет бюджетных средств бюджетной системы РФ
            </div>
            <hr style=""border:none;border-bottom:1px solid #aaa;margin:0px 9px;"">
            <div id=""piechart"" style=""width: 100%;height: 400px;padding-top: 15px;position: relative;"" data-role=""chart""></div>
        </div>
    </div>
    <div>
");
#nullable restore
#line 74 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
         foreach (Institution institution in Model.Region.Institutions)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
             if (institution.InstitutionReports != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a>");
#nullable restore
#line 78 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
              Write(institution.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(";</a><br />\r\n");
#nullable restore
#line 79 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "D:\Учеба\Диплом\HigherEducationApp\Views\RegionReport\Details.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HigherEducationApp.Models.RegionReport> Html { get; private set; }
    }
}
#pragma warning restore 1591
