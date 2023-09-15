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
    public partial class frmFiltro : Form
    {
        public frmFiltro()
        {
            InitializeComponent();
        }
        Paises diccionarioPaises = new Paises();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var lista = diccionarioPaises.GetRegiones();
            comboContinentes.DataSource = lista;
            comboContinentes.SelectedIndex = 0;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
          
        }

        private void comboContinentes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
