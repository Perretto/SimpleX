using System.Web.Mvc;

namespace Simplex.Pizzaria.Areas.Fornecedor
{
    public class FornecedorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Fornecedor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Fornecedor_default",
                "Fornecedor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}