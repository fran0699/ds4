using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                tResultado.Visible = false;
                lblError.Visible = false;
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                lblError.Text = "El campo número no puede estar vacío.";
                lblError.Visible = true;
                return;
            }

            int dimensionMatriz;

            try
            {
                dimensionMatriz = Convert.ToInt32(txtN.Text);
            }
            catch (FormatException)
            {
                lblError.Text = "El valor ingresado no es un número entero válido.";
                lblError.Visible = true;
                return;
            }

            if (dimensionMatriz <= 0)
            {
                lblError.Text = "El número debe ser mayor que 0.";
                lblError.Visible = true;
                return;
            }

            lblError.Visible = false;
            tResultado.Rows.Clear();

            //    Recorro fila por fila y columna por columna
            for (int indiceFila = 0; indiceFila < dimensionMatriz; indiceFila++)
            {
                TableRow filaTabla = new TableRow(); // Creo una nueva fila de la tabla

                for (int indiceColumna = 0; indiceColumna < dimensionMatriz; indiceColumna++)
                {
                    TableCell celda = new TableCell();

                    // En la diagonal inversa se cumple: columna == (N - 1 - fila)
                    int valorCelda = (indiceColumna == (dimensionMatriz - 1 - indiceFila)) ? 1 : 0;

                    celda.Text = valorCelda.ToString();
                    celda.HorizontalAlign = HorizontalAlign.Center;

                    filaTabla.Cells.Add(celda);
                }

                tResultado.Rows.Add(filaTabla); // Agrego la fila completa a la tabla
            }

            tResultado.Visible = true;

        }
    }
}