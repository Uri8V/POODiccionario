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
    public partial class frmDiccionario : Form
    {
        public frmDiccionario()
        {
            InitializeComponent();
        }
        private Paises diccionarioPaises = new Paises();
     
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDiccionario_Load(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var item in diccionarioPaises.GetPaises())
            {
                DataGridViewRow r = CrearCeldas();
                SetearFila(r, item);
                AgregarCelda(r);
            }

            MostrarTotal();
        }

        private void MostrarTotal()
        {
           txtCantidadPaises.Text = diccionarioPaises.GetCountPaises().ToString();
        }

        private void AgregarCelda(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, KeyValuePair<string, Pais> item)
        {
            r.Cells[colCodigo.Index].Value = item.Value.Codigo;
            r.Cells[colPais.Index].Value = item.Value.Nombre;
            r.Cells[colContinente.Index].Value=item.Value.Continente;
            r.Cells[colPoblacion.Index].Value=item.Value.Poblacion;

            r.Tag = item.Value;
        }

        private DataGridViewRow CrearCeldas()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            frmFiltro frm = new frmFiltro();
            frm.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais paisEliminado = r.Tag as Pais;
            frmBorrarPorCodigo frm = new frmBorrarPorCodigo();
            frm.ShowDialog();
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Pais con el codigo {paisEliminado.Codigo}?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            if (diccionarioPaises.EliminarPaisPorCodigo(paisEliminado.Codigo))
            {
                diccionarioPaises.EliminarPaisPorCodigo(paisEliminado.Codigo);
                dgvDatos.Rows.Remove(r);
                txtCantidadPaises.Text = diccionarioPaises.GetCountPaises().ToString();
                MessageBox.Show("Pais eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPais frm= new frmAgregarPais();
            DialogResult dr= frm.ShowDialog(this);
            if(dr == DialogResult.No)
            {
                return;
            }
            var NuevoPais = frm.GetPaisNuevo();
            if (NuevoPais == null) { return; }
            /*Tengo que ver si no existe en el objeto paises
             * si no es así lo agrego y  lo muestro
             * caso contrario mensaje de error*/
            if (diccionarioPaises + NuevoPais)
            {
                DataGridViewRow r = CrearCeldas();
                KeyValuePair<string, Pais> registro = new KeyValuePair<string, Pais>(NuevoPais.Codigo, NuevoPais);
                SetearFila(r, registro);
                AgregarCelda(r);
                MostrarTotal();

            }
            else
            {
                MessageBox.Show("Ya existe!!!");
            }
        }
    }
}
