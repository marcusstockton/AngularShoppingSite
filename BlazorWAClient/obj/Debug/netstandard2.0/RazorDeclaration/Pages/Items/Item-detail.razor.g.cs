#pragma checksum "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b559bc4ffef664eaaa8fa015ea1bf32e81f9d3de"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWAClient.Pages.Items
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient;

#line default
#line hidden
#line 7 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient.Shared;

#line default
#line hidden
#line 3 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
using BlazorWAClient.Pages.Items;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/item-detail/{Id}")]
    public class Item_detail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 38 "c:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
      
    [Parameter]
    public string Id { get; set; }
    ItemModel item;

    protected override async Task OnInitializedAsync()
    {
        item = await Http.GetJsonAsync<ItemModel>($"https://localhost:5001/api/Items/{Id}");
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
