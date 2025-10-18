using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio121
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtbVelocidad.Text, out double velocidadKmh) || velocidadKmh < 0)
            {
                MessageBox.Show("Ingrese una velocidad válida (km/h) y no negativa.",
                                "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbVelocidad.Clear();
                txtbVelocidad.Focus();
                return;
            }

            if (!double.TryParse(txtbTiempoUsado.Text, out double minutos) || minutos < 0)
            {
                MessageBox.Show("Ingrese un tiempo válido en MINUTOS y no negativo.",
                                "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbTiempoUsado.Clear();
                txtbTiempoUsado.Focus();
                return;
            }

            double tiempoHoras = minutos / 60.0;
            double distancia = velocidadKmh * tiempoHoras;
            txtbDistanciaRecorrida.Text = distancia.ToString("N2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbVelocidad.Clear();
            txtbTiempoUsado.Clear();
            txtbDistanciaRecorrida.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
