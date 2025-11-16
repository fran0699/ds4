using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double numero1 = Convert.ToDouble(TextBox1.Text);
            double numero2 = Convert.ToDouble(TextBox2.Text);

            double resultado = numero1 + numero2;

            Label2.Text = resultado.ToString();

        }
    }
}