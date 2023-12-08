using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13553_Curso_T1
{
    //Clase que define las operaciones importantes de la lista enlazada simple.
    class BasedeDatos
    {

        Nodo primero;
        Nodo ultimo;

        public BasedeDatos()
        {
            primero = null;
            ultimo = null;
        }

        public void Ingresar(int num_operacion, string nombre, int dni, DateTime fecha, string direccion, string distrito, string descripcion,
                   double num_cuenta, string tip_cuenta, string tip_operacion, string tip_moneda, double importe, double SaldoActual, double SaldoContable)
        {
            Nodo nuevo = new Nodo(num_operacion, nombre, dni, fecha, direccion, distrito, descripcion, num_cuenta, tip_cuenta,
                              tip_operacion, tip_moneda, importe, SaldoActual, SaldoContable);


            if (primero == null)
            {
                primero = nuevo;
                nuevo.Siguiente = null;
                ultimo = nuevo;
            }

            else
            {
                ultimo.Siguiente = nuevo;
                nuevo.Siguiente = null;
                ultimo = nuevo;
            }
        }
   
         // EN ESTE METODO  SE BUSCARA EL NODO A BUSCAR
        public void cBuscarNodo(DataGridView dgv , double valor) 
        {   
            Nodo actual;
            actual = primero;
            bool flag = false;
            double nodoBuscado = valor;
            if (primero != null)
            {
                while (actual != null && flag == false)
                {
                    if (actual.num_operacion != nodoBuscado)
                    {
                        MessageBox.Show(valor + " Esta en la Lista", "Listas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgv.Rows.Add(actual.num_cuenta, actual.fecha, actual.descripcion, actual.num_operacion, actual.tip_operacion, actual.importe, actual.SaldoContable);
                        actual = actual.Siguiente;

                        flag = true;
                    }

                    actual = actual.Siguiente;
                }

                if (flag == false)
                    MessageBox.Show(valor + " No esta en la Lista", "Listas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La lista esta Vacía!!", "Listas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Se crea metodo para mostrar la lista enlazada de clientes
        public void MostrarClientes(DataGridView dgv, string cliente)
        {

            Nodo actual;
            actual = primero;
            dgv.Rows.Clear();

            if (primero != null)
            {
                while (actual != null)
                {
                    dgv.Rows.Add(actual.dni,actual.nombre,actual.direccion,actual.distrito);
                    actual = actual.Siguiente;
                }
              
            }
            
        }
        //Se crea metodo para mostrar la lista enlazada de las movimientos
        public void MostrarCuentas(DataGridView dgv, string cuenta)
        {

            Nodo actual;
            actual = primero;
            dgv.Rows.Clear();
            if (primero != null)
            {
                while (actual != null)
                {
                    dgv.Rows.Add(actual.num_cuenta, actual.tip_cuenta, actual.tip_moneda, actual.SaldoActual,actual.dni);
                    actual = actual.Siguiente;
                }

            }

        }

        //Se crea metodo para mostrar la lista enlazada de las cuentas
        public void MostrarMovimientos(DataGridView dgv, string movimientos)
        {

            Nodo actual;
            actual = primero;
            dgv.Rows.Clear();
            if (primero != null)
            {
                while (actual != null)
                {
                    dgv.Rows.Add(actual.num_cuenta,actual.fecha, actual.descripcion, actual.num_operacion, actual.tip_operacion,actual.importe,actual.SaldoContable);
                  actual = actual.Siguiente;
                }

            }
        
        }
 
    }
}
