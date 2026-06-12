using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PracticaDatagridview
{
    public partial class Form1 : Form
    {
        private readonly List<int> indicesResultados = new List<int>();

        public Form1()
        {
            InitializeComponent();

            btnBuscar.Clear();
            btnAgregar.Click += btnAgregar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnPromedio.Click += btnPromedio_Click;
            btnFiltrar.Click += btnFiltrar_Click;
            lblBuscar.Click += btnBuscar_Click;
        }

        private bool ValidarEntrada(out string nombre, out int edad)
        {
            nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre no puede quedar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edad = 0;
                return false;
            }

            if (!int.TryParse(txtEdad.Text.Trim(), out edad) || edad < 0)
            {
                MessageBox.Show("Ingrese una edad valida (numero entero >= 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada(out var nombre, out var edad))
                return;

            dgvPersonas.Rows.Add(nombre, edad);
            txtNombre.Clear();
            txtEdad.Clear();
            txtNombre.Focus();
            BuscarPersonas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvPersonas.SelectedRows)
            {
                if (!fila.IsNewRow)
                    dgvPersonas.Rows.Remove(fila);
            }

            BuscarPersonas();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            int suma = 0;
            int cantidad = 0;

            foreach (DataGridViewRow fila in dgvPersonas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (int.TryParse(Convert.ToString(fila.Cells["Edades"].Value), out int edad))
                {
                    suma += edad;
                    cantidad++;
                }
            }

            if (cantidad > 0)
            {
                double promedio = (double)suma / cantidad;
                MessageBox.Show($"El promedio de edades es: {promedio:F2}", "Promedio");
            }
            else
            {
                MessageBox.Show("No hay datos para calcular el promedio.", "Promedio");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            lstMayores.Items.Clear();

            foreach (DataGridViewRow fila in dgvPersonas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (!int.TryParse(Convert.ToString(fila.Cells["Edades"].Value), out int edad))
                    continue;

                string nombre = Convert.ToString(fila.Cells["Nombres"].Value) ?? string.Empty;

                if (edad >= 18)
                    lstMayores.Items.Add($"{nombre} ({edad})");
            }

            if (lstMayores.Items.Count == 0)
                lstMayores.Items.Add("No hay mayores de edad.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPersonas();
        }

        private void BuscarPersonas()
        {
            lstResultados.Items.Clear();
            indicesResultados.Clear();

            string nombreBuscado = btnBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreBuscado))
            {
                dgvPersonas.ClearSelection();
                return;
            }

            foreach (DataGridViewRow fila in dgvPersonas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string nombre = Convert.ToString(fila.Cells["Nombres"].Value) ?? string.Empty;

                if (nombre.IndexOf(nombreBuscado, StringComparison.OrdinalIgnoreCase) < 0)
                    continue;

                string edad = Convert.ToString(fila.Cells["Edades"].Value) ?? string.Empty;
                lstResultados.Items.Add($"{nombre} ({edad})");
                indicesResultados.Add(fila.Index);
            }

            if (indicesResultados.Count > 0)
            {
                dgvPersonas.ClearSelection();
                dgvPersonas.Rows[indicesResultados[0]].Selected = true;
                dgvPersonas.CurrentCell = dgvPersonas.Rows[indicesResultados[0]].Cells[0];
            }
        }

        private void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResultados.SelectedIndex < 0 || lstResultados.SelectedIndex >= indicesResultados.Count)
                return;

            int filaIndex = indicesResultados[lstResultados.SelectedIndex];
            dgvPersonas.ClearSelection();
            dgvPersonas.Rows[filaIndex].Selected = true;
            dgvPersonas.CurrentCell = dgvPersonas.Rows[filaIndex].Cells[0];
        }
    }
}

