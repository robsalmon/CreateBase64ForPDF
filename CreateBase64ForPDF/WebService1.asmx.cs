using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using IronPdf;


namespace CreateBase64ForPDF
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string CreateBase64ForPDF()
        {
            string htmlDoc = "<h2>Test</h2>";
            string binaryDoc = StringToBinary(htmlDoc);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(binaryDoc);
            var base64String = Convert.ToBase64String(plainTextBytes);

            return base64String;
        }

public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        [WebMethod]
        public string CreatePDFBase64FromHTML()
        {
            string htmlDoc = "<h2>Test</h2>";
            
            var renderer = new IronPdf.HtmlToPdf();

            var pdf = renderer.RenderHtmlAsPdf(htmlDoc);

            byte[] binaryPDF = pdf.BinaryData;

            string base64String = Convert.ToBase64String(binaryPDF);

            return base64String;
        }
    }


}
