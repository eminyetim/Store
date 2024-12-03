using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("div",Attributes ="products")]
    public class LastesProductTagHelper : TagHelper
    {
        private readonly IServiceManager _manager; // Injection

        [HtmlAttributeName("number")] // number a göre çalışır.
        public int Number { get; set; }

        public LastesProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class","my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class","lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class","fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastes Products"); // direkt yazı.

            /* List yapısını oluştur*/
            TagBuilder unorderList = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProducts(Number,false);
            foreach (var product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href",$"/product/get{product.ProductId}");
                a.InnerHtml.AppendHtml(product.ProductName);
                li.InnerHtml.AppendHtml(a);
                unorderList.InnerHtml.AppendHtml(li);
            }
            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(unorderList);
            //Çıktı
            output.Content.AppendHtml(div);
        }
    }
}