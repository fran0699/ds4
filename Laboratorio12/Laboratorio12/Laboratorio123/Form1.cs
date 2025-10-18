using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double ladoA, ladoB, ladoC;

        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            validarDatos();
            double semiperimetro = (ladoA + ladoB + ladoC) / 2;
            txtbSemiperimetro.Text = semiperimetro.ToString("N2");
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            validarDatos();
            double area = (ladoA * ladoB) / 2;
            txtbArea.Text = area.ToString("N2");
        }

        private void validarDatos()
        {
            if (!Double.TryParse(txtbLadoA.Text, out ladoA) || ladoA < 0)
            {
                MessageBox.Show("Ingrese un valor válido para el lado A y no negativo.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbLadoA.Clear();
                txtbLadoA.Focus();
                return;
            }
            if (!Double.TryParse(txtbLadoB.Text, out ladoB) || ladoB < 0)
            {
                MessageBox.Show("Ingrese un valor válido para el lado B y no negativo.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbLadoB.Clear();
                txtbLadoB.Focus();
                return;
            }
            if (!Double.TryParse(txtbLadoC.Text, out ladoC) || ladoC < 0)
            {
                MessageBox.Show("Ingrese un valor válido para el lado C y no negativo.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbLadoC.Clear();
                txtbLadoC.Focus();
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbLadoA.Clear();
            txtbLadoB.Clear();
            txtbLadoC.Clear();
            txtbSemiperimetro.Clear();
            txtbArea.Clear();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
