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
    public partial class frmAgregarPais : Form
    {
        public frmAgregarPais()
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
                if(pais is null)
                {
                    pais = new Pais();
                }
                pais.Nombre=txtNombre.Text;
                pais.Codigo= txtCodigo.Text;
                pais.Continente=txtContinente.Text;
                pais.Poblacion=txtPoblacion.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
           errorProvider1.Clear();
           bool valido = true;
           if(string.IsNullOrEmpty(txtNombre.Text) )
           {
                errorProvider1.SetError(txtNombre, "Debe ingresar un nombre");
                valido = false;
           }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorProvider1.SetError(txtCodigo, "Debe ingresar un código");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtContinente.Text))
            {
                errorProvider1.SetError(txtContinente, "Debe ingresar un continente");
                valido = false;
            }
            if(string.IsNullOrEmpty (txtPoblacion.Text))
            {
                errorProvider1.SetError(txtPoblacion, "Debe ingresar una población");
                valido = false;
            }
            return valido;
        }

        internal Pais GetPaisNuevo()
        {
            return pais;
        }
    }
}
