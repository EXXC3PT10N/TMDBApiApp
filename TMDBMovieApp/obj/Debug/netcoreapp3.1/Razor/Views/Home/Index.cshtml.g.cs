#pragma checksum "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fffc7ab791b758923be24443583b0f74fcc1778a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\_ViewImports.cshtml"
using TMDBMovieApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\_ViewImports.cshtml"
using TMDBMovieApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fffc7ab791b758923be24443583b0f74fcc1778a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d93eb71fb05bdab38542562154d8802df330900", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TrendingResults>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 10 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml"
             for (var i = 0; i < Model.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col\">\r\n                    <div><img");
            BeginWriteAttribute("src", " src=\"", 268, "\"", 327, 2);
            WriteAttributeValue("", 274, "https://image.tmdb.org/t/p/w185/", 274, 32, true);
#nullable restore
#line 13 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 306, Model[i].poster_path, 306, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n                    <h5 class=\"text-center\">");
#nullable restore
#line 14 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml"
                                       Write(Model[i].title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n                </div>\r\n");
#nullable restore
#line 17 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\Home\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TrendingResults>> Html { get; private set; }
    }
}
#pragma warning restore 1591