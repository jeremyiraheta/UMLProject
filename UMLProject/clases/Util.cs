using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMLProject.clases
{
    public static class Util
    {
        public static string MensajeExito(string msg)
        {
            return "<div class=\"alert-box alert-box--success hideit\">" +
                                $"<p>{msg}</p>" +
                                "<i class=\"fa fa-times alert-box__close\" aria-hidden=\"true\"></i>" +
                            "</div>";
        }
        public static string MensajeFracaso(string msg)
        {
            return "<div class=\"alert-box alert-box--error hideit\">" +
                                $"<p>{msg}</p>" +
                                "<i class=\"fa fa-times alert-box__close\" aria-hidden=\"true\"></i></div>";
        }
            

    }
}