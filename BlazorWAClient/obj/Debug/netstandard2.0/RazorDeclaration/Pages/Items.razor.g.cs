#pragma checksum "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e3a1f0042075411298263229bdb040799cf363e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWAClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient;

#line default
#line hidden
#line 7 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/items")]
    public class Items : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 26 "C:\Users\MarcusS\Dropbox\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items.razor"
       
    Item[] response;
    protected override async Task OnInitializedAsync()
    {
        response = await Http.GetJsonAsync<Item[]>("https://localhost:5001/api/Items");
    }

    public class Image{
        public string Path{get;set;}
        public string FileName{get;set;}
        public string Type{get;set;}
    }

    public class Item{
        public string Id {get;set;}
        public string Name {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public decimal Price{get;set;}
        public Image[] Images{get;set;}
    }
    

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
