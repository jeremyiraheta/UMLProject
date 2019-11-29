using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMLProject.BackEnd
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
            
        public static bool checkRolByName(Tipos_Usuarios t, string rol)
        {
            return t.NOMBRE.ToLower() == rol.ToLower();
        }
        public static string createTable(string[] headers, List<string[]> rows)
        {
            string html = "";
            html += "<table>";
            html += "<thead><tr>";
            foreach (string item in headers)
            {
                html += $"<th>{item}</th>";
            }
            html += "</tr></thead><tbody>";
            foreach (string[] item in rows)
            {
                html += "<tr>";
                foreach (string subitem in item)
                {
                    html += $"<td>{subitem}</td>";
                }
                html += "</tr>";
            }
            html += "</tbody></table>";

            return html;
        }
    }
}