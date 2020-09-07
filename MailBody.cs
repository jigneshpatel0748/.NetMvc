using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using JigneshPractical.Model;

namespace JigneshPractical.Utilis
{
    public class MailBody
    {
        public static string SetRegistrationBody(string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<label style='ont-size: 16px; font - family: sans - serif;font - weight: 600;'>Dear " + Name + ",</label>");
            sb.Append("<label style='ont-size: 16px; font - family: sans - serif;font - weight: 600;color: #00FF00;'>Thanking you for registering.</label>");
            return Convert.ToString(sb);
        }
        public static string SetStockBody(List<TRN_Stock_List_Result> _List)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<table style='font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;border-collapse: collapse;width: 100 %;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>");
            sb.Append("<thed>");
            sb.Append("<tr>");
            sb.Append("<th style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>Sr. No</th>");
            sb.Append("<th style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>Stock Name</th>");
            sb.Append("<th style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>Qty</th>");
            sb.Append("<th style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>Rate</th>");
            sb.Append("<th style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>Value</th>");
            sb.Append("</tr>");
            sb.Append("</thed>");

            sb.Append("<tbody>");
            int i = 1, Qty = 0;
            double Rate = 0, Value = 0;
            foreach (var item in _List)
            {
                sb.Append("<tr>");
                sb.Append("<td style='border: 1px solid #ddd;'>" + i++ + "</td>");
                sb.Append("<td style='border: 1px solid #ddd;'>" + item.Stock_Name + "</td>");
                sb.Append("<td style='border: 1px solid #ddd;'>" + item.Qty + "</td>");
                sb.Append("<td style='border: 1px solid #ddd;'>" + Math.Round(item.Rate, 2) + "</td>");
                sb.Append("<td style='border: 1px solid #ddd;'>" + Math.Round(item.Value,2) + "</td>");
                sb.Append("</tr>");

                Qty += item.Qty;
                Rate += item.Rate;
                Value += item.Value;
            }
            sb.Append("<tr>");
            sb.Append("<td style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'></td>");
            sb.Append("<td style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'></td>");
            sb.Append("<td style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>" + Qty + "</td>");
            sb.Append("<td style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>" + Math.Round(Value / Qty, 2) + "</td>");
            sb.Append("<td style='border: 1px solid #ddd;padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #729673;color: white;'>" + Math.Round(Value, 2) + "</td>");
            sb.Append("</tr>");

            sb.Append("</tbody>");
            return Convert.ToString(sb);
        }
    }
}