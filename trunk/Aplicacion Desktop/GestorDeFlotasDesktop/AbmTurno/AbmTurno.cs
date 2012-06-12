using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmTurno
{
    public partial class AbmTurno : Form
    {
        private string camposSelect = "turnoID, horaInicio, horaFin, descripcion, valorFicha, valorBandera";
        private string whereObligatorio = "isnull(anulado,'0')='0'";
        private string consultaOrderBy = "turnoID";
        private string nombreTabla = "Femig.Turnos";
        private string filtro1Value = "horaInicio";
        private string filtro2Value = "horaFin";
        private string filtro3Value = "descripcion";
        private string filtro4Value = "valorFicha";
        private string filtro5Value = "valorBandera";
        private string filtro1Text = "Hora Inicio";
        private string filtro2Text = "Hora Fin";
        private string filtro3Text = "Descripción";
        private string filtro4Text = "Valor Ficha";
        private string filtro5Text = "Valor Bandera";

        private static AbmTurno unicaInst = null;
        public static AbmTurno Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmTurno();
            }
            return unicaInst;
        }

        private AbmTurno()
        {
            InitializeComponent();
        }

        private void AbmTurno_Load(object sender, EventArgs e)
        {
            
            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgTurnos.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgTurnos.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgTurnos.Columns["turnoID"].Visible = false;
            dgTurnos.Columns[filtro1Value].HeaderText = filtro1Text;
            dgTurnos.Columns[filtro2Value].HeaderText = filtro2Text;
            dgTurnos.Columns[filtro3Value].HeaderText = filtro3Text;
            dgTurnos.Columns[filtro4Value].HeaderText = filtro4Text;
            dgTurnos.Columns[filtro5Value].HeaderText = filtro5Text;
        }

        private void inicializarFormulario()
        {
            cmbHoraInicio.Text = "00";
            cmbHoraFin.Text = "23";
            txtDescripcion.Text = "";
            txtMaxFicha.Text = "";
            txtMaxBandera.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            
                strQuery += " and horaInicio >= " + cmbHoraInicio.Text;
                strQuery += " and horaFin <= " + cmbHoraFin.Text;

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtDescripcion.Text + "%'";
            if (!string.IsNullOrEmpty(txtMaxFicha.Text))
                strQuery += " and " + filtro4Value + " <= " + txtMaxFicha.Text;
            if (!string.IsNullOrEmpty(txtMaxBandera.Text))
                strQuery += " and " + filtro5Value + " <= " + txtMaxBandera.Text;
            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgTurnos.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";

                leyendaFiltros += filtro1Text + ": " + cmbHoraInicio.Text;
                leyendaFiltros += ", " + filtro2Text + ": " + cmbHoraFin.Text;

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtDescripcion.Text;
            if (!string.IsNullOrEmpty(txtMaxFicha.Text))
                leyendaFiltros += ", " + filtro4Text + " <= " + txtMaxFicha.Text;
            if (!string.IsNullOrEmpty(txtMaxBandera.Text))
                leyendaFiltros += ", " + filtro5Text + " <= " + txtMaxBandera.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmTurno.addEditTurno frmAbmTurno = GestorDeFlotasDesktop.AbmTurno.addEditTurno.Instance();
            frmAbmTurno.modoAbm = "Nuevo";
            frmAbmTurno.tituloPantalla = "Agregar Nuevo Turno";
            if (frmAbmTurno.ShowDialog() == DialogResult.OK)
                cargarQuery();
            frmAbmTurno.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            inicializarFormulario();
            cargarQuery();
        }

        private void dgAutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmTurno.addEditTurno frmEditarAuto = GestorDeFlotasDesktop.AbmTurno.addEditTurno.Instance();
                frmEditarAuto.modoAbm = "Editar";
                frmEditarAuto.turnoID = dgTurnos.SelectedRows[0].Cells["turnoID"].Value.ToString();
                frmEditarAuto.tituloPantalla = "Editar Auto";
                if (frmEditarAuto.ShowDialog() == DialogResult.OK)
                    cargarQuery();
                frmEditarAuto.Close();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa eliminar este Turno?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter pTurnoId = new SqlParameter("@pTurnoId", SqlDbType.VarChar, 10);
                    pTurnoId.Value = dgTurnos.SelectedRows[0].Cells["turnoID"].Value.ToString();
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarTurno", pTurnoId);
                    cargarQuery();
                }

            }
        }
    }
}
