#pragma checksum "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b559bc4ffef664eaaa8fa015ea1bf32e81f9d3de"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorWAClient.Pages.Items
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient;

#line default
#line hidden
#line 7 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\_Imports.razor"
using BlazorWAClient.Shared;

#line default
#line hidden
#line 3 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
using BlazorWAClient.Pages.Items;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/item-detail/{Id}")]
    public class Item_detail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddMarkupContent(2, " \r\n    ");
            __builder.OpenElement(3, "p");
            __builder.AddContent(4, "The Id is ");
            __builder.AddContent(5, 
#line 7 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                  Id

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
#line 8 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
     if(item == null){

#line default
#line hidden
            __builder.AddContent(7, "        ");
            __builder.AddMarkupContent(8, "<p>Loading....</p>\r\n");
#line 10 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
    }
    else
    {

#line default
#line hidden
            __builder.AddContent(9, "        ");
            __builder.OpenElement(10, "p");
            __builder.AddContent(11, "The response is ");
            __builder.AddContent(12, 
#line 13 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                            item

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "p");
            __builder.AddContent(15, 
#line 14 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
            item.Title

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenElement(17, "p");
            __builder.AddContent(18, 
#line 15 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
            item.Description

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.OpenElement(20, "p");
            __builder.AddContent(21, 
#line 16 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
            item.Price

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n        ");
            __builder.OpenElement(23, "p");
            __builder.AddContent(24, "# of images ");
            __builder.AddContent(25, 
#line 17 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                        item.Images.Count

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n");
            __builder.AddMarkupContent(27, "        \r\n        ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "id", "carouselExampleSlidesOnly");
            __builder.AddAttribute(30, "class", "carousel slide");
            __builder.AddAttribute(31, "data-ride", "carousel");
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "carousel-inner");
            __builder.AddMarkupContent(35, "\r\n");
#line 22 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                 for (int i = 0; i < item.Images.Count; i++)
                {
                    var img = item.Images[i];
                    var itemClass = i == 0 ? "carousel-item active" : "carousel-item";

#line default
#line hidden
            __builder.AddContent(36, "                    ");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", 
#line 26 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                                 itemClass

#line default
#line hidden
            );
            __builder.AddMarkupContent(39, "\r\n                        ");
            __builder.OpenElement(40, "img");
            __builder.AddAttribute(41, "src", 
#line 27 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                                    $"https://localhost:5001/api/{img.Path}"

#line default
#line hidden
            );
            __builder.AddAttribute(42, "alt", "img.FileName");
            __builder.AddAttribute(43, "class", "d-block");
            __builder.AddAttribute(44, "width", "150");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n");
#line 29 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                }

#line default
#line hidden
            __builder.AddContent(47, "            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n");
            __builder.AddContent(50, "        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(51);
            __builder.AddAttribute(52, "href", 
#line 33 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
                           $"/item-form/{item.Id}"

#line default
#line hidden
            );
            __builder.AddAttribute(53, "class", "btn btn-primary");
            __builder.AddAttribute(54, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(55, "Edit");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(56, "\r\n");
#line 34 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
    }

#line default
#line hidden
            __builder.AddMarkupContent(57, "    \r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 38 "C:\Users\marcus.stockton\OneDrive\Documents\Angular Projects\AngularShoppingSite\BlazorWAClient\Pages\Items\Item-detail.razor"
      
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
