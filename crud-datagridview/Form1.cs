using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CrudDatagridview
{
    public partial class Form1 : Form
    {
        private List<string[]> datos = new List<string[]>();
        private const string ArchivoJson = "datos.json";

        public Form1()
        {
            InitializeComponent();
            btnEliminar.Click += btnEliminar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosDesdeArchivo();
            MostrarDatos(datos);
        }

        private void MostrarDatos(IEnumerable<string[]> origen)
        {
            dataGridView1.Rows.Clear();

            foreach (var fila in origen)
                dataGridView1.Rows.Add(fila);

            dataGridView1.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtDni.Clear();
            txtNombre.Focus();
        }

        private bool ValidarEntrada(out string[] datosFila)
        {
            datosFila = Array.Empty<string>();

            string dni = txtDni.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string edad = txtEdad.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(edad))
            {
                MessageBox.Show("Complete todos los campos antes de agregar un registro.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(edad, out int edadNumerica) || edadNumerica < 0)
            {
                MessageBox.Show("Ingrese una edad valida.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

  
            if (datos.Any(fila => fila.Length > 1 && fila[1].Equals(dni, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un registro con ese DNI.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

       
            datosFila = new[]
            {
                nombre,
                dni,
                apellido,
                edadNumerica.ToString()
            };

            return true;
        }

        private void CargarDatosDesdeArchivo()
        {
            if (!File.Exists(ArchivoJson))
                return;

            var json = File.ReadAllText(ArchivoJson);
            datos = JsonConvert.DeserializeObject<List<string[]>>(json) ?? new List<string[]>();

            for (int i = 0; i < datos.Count; i++)
            {
                var fila = datos[i];
                if (fila.Length >= 4)
                {
                    bool primerEsNumero = fila[0].All(char.IsDigit);
                    if (primerEsNumero)
                    {
                        var dni = fila[0];
                        var apellido = fila[1];
                        var nombre = fila[2];
                        var edad = fila[3];
                        datos[i] = new[] { nombre, dni, apellido, edad };
                    }
                }
            }
        }

        private void GuardarDatosEnArchivo()
        {
            var json = JsonConvert.SerializeObject(datos, Formatting.Indented);
            File.WriteAllText(ArchivoJson, json);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada(out var datosFila))
                return;

            datos.Add(datosFila);
            MostrarDatos(datos);
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string dniSeleccionado = Convert.ToString(dataGridView1.SelectedRows[0].Cells["DNI"].Value) ?? string.Empty;

            if (string.IsNullOrWhiteSpace(dniSeleccionado))
                return;

            datos.RemoveAll(fila => fila.Length > 1 && fila[1].Equals(dniSeleccionado, StringComparison.OrdinalIgnoreCase));
            txtBuscar.Clear();
            MostrarDatos(datos);
            GuardarDatosEnArchivo();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MostrarDatos(datos);
                return;
            }

            var resultados = datos
                .Where(fila => fila.Any(campo => campo.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            MostrarDatos(resultados);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarDatosEnArchivo();
        }
    }
}

