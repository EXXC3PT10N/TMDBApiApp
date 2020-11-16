#pragma checksum "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3d0a60218f9a6bbb9d8ca782e314efc6355601e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyList_index), @"mvc.1.0.view", @"/Views/MyList/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d0a60218f9a6bbb9d8ca782e314efc6355601e", @"/Views/MyList/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c25c61ceaf00d71aff7a55b4fb3196217c4e5fc", @"/Views/_ViewImports.cshtml")]
    public class Views_MyList_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
   System.Diagnostics.Debug.WriteLine("asd"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<script>\n    function getMovies(val) {\n        let numberOfItems = 6;\n\n             $.ajax({\n            type: \"POST\",\n            url: \"");
#nullable restore
#line 13 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
             Write(Url.Action("GetMovies"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: { value: val, numberOfItems: numberOfItems},
            dataType: ""json"",
                 success: function (msg) {
                     $(""#search_results"").html("""");
                     msg.forEach((item, index) => {
                         let listHTML = $(""#search_results"").html();
                         let elementHTML = `
                           <div class=""col"">
            <div class=""interactive_image"">
                    <img src=""${item.poster_path}""  class=""image""/>
                    <button class=""overlay"" onclick=""addMovie()"">
                        <div class=""text"">+</div>
                    </button>
                    <h5 class=""text-center"">${item.title}</h5>
            </div>


        </div>
`
                         listHTML += elementHTML;
                         $(""#search_results"").html(listHTML);
                         console.log(index + "". "" + item.title);
                     })

            },
            error: function (req, status, erro");
            WriteLiteral(@"r) {
                console.log(msg);
            }
        });


    }

    function addMovie() {
        alert(""button clicked!"" + this);
    }

</script>

<style>
    .interactive_image {
        position: relative;
        max-height: 510px;
        max-width: 340px;
    }

    .image {
        display: block;
        width: 100%;
        height: auto;
    }

    .overlay {
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        height: 100%;
        width: 100%;
        opacity: 0;
        transition: .5s ease;
        background-color: #008CBA;
    }

        .overlay:hover {
            opacity: 1;
        }

    .text {
        color: white;
        font-size: 20px;
        position: absolute;
        top: 50%;
        left: 50%;
        -webkit-transform: translate(-50%, -50%);
        -ms-transform: translate(-50%, -50%);
        transform: translate(-50%, -50%);
        text-align: center;
    }
</style>

<div class=""container"">
    <div class=""row");
            WriteLiteral("\">\n        <div class=\"col\">\n            <input type=\"text\" name=\"movieInput\"");
            BeginWriteAttribute("value", " value=\"", 2474, "\"", 2482, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Wyszukaj...\" oninput=\"getMovies(this.value)\" class=\"input-group-text\" />\n        </div>\n    </div>\n    <br />\n    <div class=\"row\" id=\"search_results\">\n\n    </div>\n    <div class=\"row\">\n      \n");
#nullable restore
#line 108 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
         for (var i = 0; i < Model.Count; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col\">\n            <div class=\"card\" style=\"width: 15rem;\">\n                <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 2869, "\"", 2928, 2);
            WriteAttributeValue("", 2875, "https://image.tmdb.org/t/p/w185/", 2875, 32, true);
#nullable restore
#line 112 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
WriteAttributeValue("", 2907, Model[i].poster_path, 2907, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n                <div class=\"card-body\">\n                    <h5 class=\"card-title text-center\">");
#nullable restore
#line 114 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
                                                  Write(Model[i].title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                    <div class=\"card-text\">Średnia ocen: ");
#nullable restore
#line 115 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
                                                    Write(Model[i].vote_average);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    <br />\n                    <a href=\"#\" class=\"btn btn-primary\">Go somewhere</a>\n                </div>\n               \n            </div>\n        </div>\r\n");
#nullable restore
#line 122 "H:\Visual Studio Projects\2019\TMDBMovieApp\TMDBMovieApp\Views\MyList\index.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
