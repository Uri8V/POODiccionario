using POODiccionario.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POODiccionario.Windows
{
    public partial class frmBorrarPorCodigo : Form
    {
        public frmBorrarPorCodigo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Pais pais;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if(pais == null)
                {
                    pais = new Pais("","","","");
                }
                pais.Codigo = txtCodigo.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorProvider1.SetError(txtCodigo, "Se debe ingresar un código");
                valido = false;
            }

            return valido;
        }
    }
    
}
