using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Text;
using eStore.ViewModels;
namespace eStore.TagHelpers
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement("catalogue", Attributes = BrandIdAttribute)]
    public class CatalogueHelper : TagHelper
    {
        private const string BrandIdAttribute = "brand";
        [HtmlAttributeName(BrandIdAttribute)]
        public string BrandId { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public CatalogueHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_session.GetObject<ProductViewModel[]>("catalogue") != null)
            {
                var innerHtml = new StringBuilder();
                ProductViewModel[] catalogue = _session.GetObject<ProductViewModel[]>("catalogue");
                innerHtml.Append("<div class=\"col-xs-12\" style=\"font-size:x-large;\"><span> Catalogue </span></div>");
                foreach (ProductViewModel prod in catalogue)
                {
                    if (prod.BrandId == Convert.ToInt32(BrandId) || Convert.ToInt32(BrandId) == 0)
                    {
                        innerHtml.Append("<div id=\"prod\" class=\"col-sm-3 col-xs-12 text-center\" style=\"border:solid; padding: 5px 0;\">");
                        innerHtml.Append("<span class=\"col-xs-12\"><img src=\"/img/products/" + prod.GraphicName + "\" style=\"height:64px; width:64px;\" /></span>");
                        innerHtml.Append("<span style=\"font -size:medium;\">" + prod.ProductName + " </span>");
                        innerHtml.Append("<div><span>For More Info.<br />Click Details</span></div>");
                        innerHtml.Append("<div><a href=\"#details_popup\" data-toggle=\"modal\" class=\"btn btn-default\" id=\"modalbtn\" data-id=\"" + prod.Id + "\">Details</a></div>");
                        innerHtml.Append("<input type=\"hidden\" id=\"descr-" + prod.Id + "\" value=\"" + prod.Description + "\" />");
                        innerHtml.Append("<input type=\"hidden\" id=\"name-" + prod.Id + "\" value=\"" + prod.ProductName + "\" />");
                        innerHtml.Append("<input type=\"hidden\" id=\"msrp-" + prod.Id + "\" value=\"" + prod.MSRP + "\" />");
                        innerHtml.Append("<input type=\"hidden\" id=\"img-" + prod.Id+ "\" value =\"" + prod.GraphicName + "\" />");
                        innerHtml.Append("<input type=\"hidden\" id=\"brand-" + prod.Id + "\" value =\"" + prod.BrandName + "\"/></div>");
                    }
                }
                output.Content.SetHtmlContent(innerHtml.ToString());
            }
        }
    }
}