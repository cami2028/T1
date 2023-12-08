using System.Security.Cryptography.X509Certificates;

namespace _13553_Curso_T1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BasedeDatos basedeDatos = new BasedeDatos();
        int retiro = 0, deposito = 0;

        
        //Metodo para limpiar las cajas de texto
        public void limpiarTXT()
        {
            txtcod1.Text = "";
            txtNom1.Text = "";
            txtDni1.Text = "";
            txtDirec1.Text = "";
            txtDistri1.Text = "";
            cboDescrip1.Text = "";
            txtNum_Cuenta1.Text = "";
            cboTip_Cuenta1.Text = "";
            cboTip_Operacion1.Text = "";
            cboMoneda1.Text = "";
            txtImporte1.Text = "";
            txtSaldoActual.Text = "";

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            if (txtIngrese_NumCuenta.TextLength != 14) //num de cuenta no tenga mas digitos de los 14 permitidos

            { MessageBox.Show("N° de Cuenta no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                var respuesta2 = MessageBox.Show("¿Está seguro del dato a buscar?", "Confirmar operación"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta2 == DialogResult.Yes)
                {


                    MessageBox.Show("Datos Encontrado", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    double numcuentab = Convert.ToDouble(txtIngrese_NumCuenta.Text);
                   
                    basedeDatos.cBuscarNodo(dgvBusquedaLista, numcuentab);
                    txtNom2.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    txtDirec2.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    txtDistri2.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                    txtNumCuenta2.Text = dgvMovimientos.CurrentRow.Cells[0].Value.ToString();
                    txtTipCuenta2.Text = dgvCuenta.CurrentRow.Cells[1].Value.ToString();
                    txtTipMoneda2.Text = dgvCuenta.CurrentRow.Cells[2].Value.ToString();
                    txtSaldoActual2.Text = dgvMovimientos.CurrentRow.Cells[3].Value.ToString();

                    switch (cboTip_Operacion1.SelectedIndex)
                    {
                        case 0:
                            deposito++;
                            break;
                        case 1:
                            retiro++;
                            break;
                    }


                    txtNumDepositos.Text = deposito.ToString();
                    txtNumReetiros.Text = retiro.ToString();
        
                  
                    cboTip_Operacion1.Text = "";
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {  // Se limpiara todos los datos que figuren en las cajas de texto de la ventana Datos Generales
            if (MessageBox.Show("¿Esta Seguro?", "Responda", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtIngrese_NumCuenta.Text = "";
                txtNom2.Text = "";
                txtDirec2.Text = "";
                txtDistri2.Text = "";
                txtNumCuenta2.Text = "";
                txtTipCuenta2.Text = "";
                txtTipMoneda2.Text = "";
                txtSaldoActual2.Text = "";
                txtIngrese_NumCuenta.Focus();
                dgvBusquedaLista.Rows.Clear();
            }
            else
            {
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

       private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            var Brespuesta = MessageBox.Show("¿Seguro que desea reiniciar la aplicación?", "Confirmación",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Brespuesta == DialogResult.Yes)
            {
          
                Application.Restart();
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Variable para Saldo Contable
            double SaldoContable = 0; 

            //Se crea avisos para evitar ingresar datos errados en las cajas de textos.

            if (txtcod1.Text == "" && txtNom1.Text == "" && txtDni1.Text == "" && txtDirec1.Text == "" && txtDistri1.Text == "" && cboDescrip1.Text == "" && txtNum_Cuenta1.Text == "" && cboTip_Cuenta1.Text == ""
                && cboTip_Operacion1.Text == "" && cboMoneda1.Text == "")
            {
                MessageBox.Show("NO SE HA REGISTRADO NINGUN DATO!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtcod1.Text == "") { MessageBox.Show("Falta el codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (txtNom1.Text == "") { MessageBox.Show("Falta el nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (txtDni1.TextLength != 8) { MessageBox.Show("DNI no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (txtDirec1.Text == "") { MessageBox.Show("Falta la direccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (txtDistri1.Text == "") { MessageBox.Show("Falta la direccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (cboDescrip1.Text != "Ingreso Efectivo" && cboDescrip1.Text != "Pago con Cheque" && cboDescrip1.Text != "Abono Visanet" && cboDescrip1.Text != "Abono Mastercard" && cboDescrip1.Text != "Retiro Cajero")
            { MessageBox.Show("Descripcion no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (txtNum_Cuenta1.TextLength != 14) { MessageBox.Show("N° de Cuenta no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (cboTip_Cuenta1.Text != "Cuenta Corriente" && cboTip_Cuenta1.Text != "Cuenta Sueldo" && cboTip_Cuenta1.Text != "Cuenta Ahorros")
            { MessageBox.Show("Tipo de Cuenta no Valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (cboTip_Operacion1.Text != "D" && cboTip_Operacion1.Text != "R") { MessageBox.Show("Tipo de Operación no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (txtSaldoActual.Text == "") { MessageBox.Show("Falta Saldo Actual"); }
            else if (cboMoneda1.Text != "Soles" && cboMoneda1.Text != "Dólares") { MessageBox.Show("Moneda no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (double.Parse(txtImporte1.Text) > 5000)
    
            {
                
                MessageBox.Show("La transaccion excede de los limites, se puede retirar o depositar como maximo 5000 por dia", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var respuesta = MessageBox.Show("¿Está seguro de los datos ingresados?", "Confirmar oepracion"
                      , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (cboTip_Operacion1.Text == "D")
                        SaldoContable = (Convert.ToDouble(txtSaldoActual.Text) + Convert.ToDouble(txtImporte1.Text));
                    else 
                    SaldoContable = (Convert.ToDouble(txtSaldoActual.Text) - Convert.ToDouble(txtImporte1.Text));

                    MessageBox.Show("Datos registrados", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Capturar los datos del formulario
                    basedeDatos.Ingresar(int.Parse(txtcod1.Text), txtNom1.Text, int.Parse(txtDni1.Text), DateTime.Parse(dateTimePicker1.Text), txtDirec1.Text,
                       txtDistri1.Text, cboDescrip1.Text, Convert.ToDouble(txtNum_Cuenta1.Text), cboTip_Cuenta1.Text, cboTip_Operacion1.Text, cboMoneda1.Text, Convert.ToDouble(txtImporte1.Text),Convert.ToDouble(txtSaldoActual.Text), SaldoContable);
                    //Mostramos los datos del formulario de la lista enlazada
                    basedeDatos.MostrarClientes(dgvClientes, null);
                    basedeDatos.MostrarCuentas(dgvCuenta, null);
                    basedeDatos.MostrarMovimientos(dgvMovimientos, null);
                    //Limpiar las cajas de texto
                    limpiarTXT();
                }

            }
        
        }
    }
}