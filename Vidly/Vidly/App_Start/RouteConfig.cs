using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /**
             * el orden del routeo importa
             * se debe ir del mas especifico al mas generico
             * ya que si entra primero el generico, no se va a ejecutar el especifico
             * 
             */
            /**
             * el mangtener un archivo de ruteo con sus magicstrings no es lo mas recomendable
             * por lo que se deben usar routeo por ATRIBUTOS
             * se debe activar con el metodo routes.MapMvcAttributeRoute()
             * y se agrega el atributo al action en el que se quiere usar
             * [Route("cadena/hacia/action/{parametro:limite:otrolimiteoconstrain}")]
             * **/


            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "Movies/Released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" }
            //    , new { year = @"\d{4}", month = @"\d{2}" });
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
