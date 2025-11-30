using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio201
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbTabla.Visible = false;
        }

        double numero;
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                lbTabla.Visible = true;
                lbTabla.Items.Clear();
                lbTabla.Items.Add("El campo número no puede estar vacío.");
                return;
            }

            double numero;

            try
            {
                numero = Convert.ToDouble(txtNumero.Text);
            }
            catch (FormatException)
            {
                lbTabla.Visible = true;
                lbTabla.Items.Clear();
                lbTabla.Items.Add("Debe ingresar un número válido en el campo número.");
                return;
            }

            lbTabla.Visible = true;
            lbTabla.Items.Clear();

            for (int i = 1; i <= 25; i++)
            {
                lbTabla.Items.Add(string.Format("{0} x {1} = {2}", numero, i, numero * i));
            }
        }
    }
}