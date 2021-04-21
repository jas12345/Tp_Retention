using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Retention.Helpers
{
    public static class HtmlHelperExtension
    {
        //public static string Button(this HtmlHelper helper, String name, String value, String type = "submit", String id = "", String extra = "", String controlador = null)
        //{
        //    HttpContext httpContext = HttpContext.Current;
        //    List<AccionViewModel> lExceptions = new List<AccionViewModel>();


        //    RouteData routeData = helper.ViewContext.RouteData;
        //    string controller = (controlador == null) ? routeData.GetRequiredString("controller") : controlador;

        //    string salida = "";

        //    lExceptions.Add(new AccionViewModel { cNombre = "Cancelar" });
        //    lExceptions.Add(new AccionViewModel { cNombre = "Cargar" });
        //    lExceptions.Add(new AccionViewModel { cNombre = "Cerrar" });
        //    lExceptions.Add(new AccionViewModel { cNombre = "Button" });
        //    //lExceptions.Add(new AccionViewModel { cNombre = "cancelar", cNombreModulo = "autentificacion" });

        //    string input = string.Format("<input type='{4}' name='{0}' value='{1}' id='{2}'  {3}/>", name, value, id, extra, type);

        //    if (lExceptions.Any(p => p.cNombre.ToLower() == name.ToLower()))
        //    {
        //        salida = input;
        //    }
        //    else
        //    {
        //        UsuarioSesion usuarioSesion = ((UsuarioSesion)httpContext.Session["_Usuario"]);
        //        if (usuarioSesion == null)
        //        {
        //            return salida;
        //        }

        //        var usuarioPermisos = usuarioSesion.lPermisos;
        //        if (usuarioPermisos.Any(p => p.cNombreModulo.ToLower() == controller.ToLower() && p.cNombre.ToLower() == name.ToLower()))
        //        {
        //            salida = input;
        //        }
        //    }
        //    return salida;
        //}

        //public static StringBuilder Icon(this HtmlHelper helper, String name, String etiqueta, String id, String extra, String accion = "", String controlador = null)
        //{
        //    StringBuilder output = new StringBuilder();
        //    String accion_btn = "";
        //    HttpContext httpContext = HttpContext.Current;

        //    UsuarioSesion usuarioSesion = ((UsuarioSesion)httpContext.Session["_Usuario"]);

        //    if (usuarioSesion == null)
        //    {
        //        return output;
        //    }

        //    var usuarioPermisos = usuarioSesion.lPermisos;

        //    switch (name.ToLower())
        //    {
        //        case "editar":
        //            accion_btn = "pencil";
        //            break;
        //        case "eliminar":
        //            accion_btn = "trash";
        //            break;
        //        case "regenerar":
        //            accion_btn = "arrowrefresh-1-e";
        //            break;
        //        case "enviar":
        //            accion_btn = "mail-closed";
        //            break;
        //        case "resetear":
        //            accion_btn = "transferthick-e-w";
        //            break;
        //        case "habilitar":
        //            accion_btn = "circle-check";
        //            break;
        //        case "deshabilitar":
        //            accion_btn = "circle-close";
        //            break;
        //        case "bloquear":
        //            accion_btn = "locked";
        //            break;
        //        case "desbloquear":
        //            accion_btn = "unlocked";
        //            break;
        //        case "articulos":
        //            accion_btn = "cart";
        //            break;
        //        case "ordenar":
        //            accion_btn = "triangle-2-n-s";
        //            break;
        //        case "campos":
        //            accion_btn = "newwin";
        //            break;
        //        case "extras":
        //            accion_btn = "plusthick";
        //            break;
        //        case "cobrarnegativo":
        //            accion_btn = "circle-check";
        //            break;
        //        case "cobrarafirmativo":
        //            accion_btn = "circle-close";
        //            break;
        //        case "fullTrue":
        //            accion_btn = "pencil";
        //            break;
        //        case "fullFalse":
        //            accion_btn = "pencil";
        //            break;
        //    }

        //    RouteData routeData = helper.ViewContext.RouteData;
        //    string controller = (controlador == null) ? routeData.GetRequiredString("controller") : controlador;

        //    if (usuarioPermisos.Any(p => p.cNombreModulo.ToLower() == controller.ToLower() && p.cNombre.ToLower() == accion.ToLower()))
        //    {
        //        if (name.ToLower() == "cobrarnegativo")
        //        {

        //            output.Append("<a class='fg-button ui-state-default-habilitar fg-button-icon-solo ui-corner-all' href='#' " + extra + "><span class='ui-icon-habilitar ui-icon-habilitar-" + accion_btn + " " + name + "'" + " title='" + LanguageHelper.NormalTag(etiqueta) + "'></span></a>");

        //        }
        //        else
        //        {
        //            output.Append("<a class='fg-button ui-state-default fg-button-icon-solo ui-corner-all' href='#' " + extra + "><span class='ui-icon ui-icon-" + accion_btn + " " + name + "'" + " title='" + LanguageHelper.NormalTag(etiqueta) + "'></span></a>");
        //        }
        //    }
        //    return output;
        //}

        //public static Boolean TienePermiso(this HtmlHelper helper, String name, String controlador = null)
        //{
        //    HttpContext httpContext = HttpContext.Current;
        //    UsuarioSesion usuarioSesion = ((UsuarioSesion)httpContext.Session["_Usuario"]);

        //    if (usuarioSesion == null)
        //    {
        //        return false;
        //    }

        //    var usuarioPermisos = usuarioSesion.lPermisos;
        //    Boolean ret = false;


        //    RouteData routeData = helper.ViewContext.RouteData;
        //    string controller = (controlador == null) ? routeData.GetRequiredString("controller") : controlador;

        //    if (usuarioPermisos.Any(p => p.cNombreModulo.ToLower() == controller.ToLower() && p.cNombre.ToLower() == name.ToLower()))
        //    {
        //        ret = true;
        //    }

        //    return ret;
        //}
    }
}
