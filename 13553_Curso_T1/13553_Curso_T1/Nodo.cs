using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13553_Curso_T1
{
    //Clase nodo que contiene todos los datos del nodo de la lista Enlazada Simple
    class Nodo
    {
        //Definir las propiedades del nodo de la lista
         public int num_operacion { get; set; }
         public string nombre{ get; set; }
         public int dni{ get; set; }
         public DateTime fecha { get; set; }
          public string direccion { get; set; }
         public string distrito{ get; set; }
         public string descripcion{ get; set; }
         public double num_cuenta { get; set; }
         public string tip_cuenta{ get; set; }
         public string tip_operacion { get; set; }
         public string tip_moneda{ get; set; }
         public double importe{ get; set; }
         public double SaldoActual { get; set; }
         public double SaldoContable { get; set; }

        //Definir el enlace siguiente del nodo
        private Nodo siguiente;
        internal Nodo Siguiente { get => siguiente; set => siguiente = value; }

        //Inicializar el nodo
        public Nodo(int num_operacion, string nombre, int dni, DateTime fecha, string direccion, string distrito, string descripcion,
                   double num_cuenta, string tip_cuenta, string tip_operacion, string tip_moneda, double importe, double SaldoActual, double SaldoContable)
        {
            this.num_operacion = num_operacion;
            this.nombre = nombre;
            this.dni = dni;
            this.fecha = fecha;
            this.direccion = direccion;
            this.distrito = distrito;
            this.descripcion = descripcion;
            this.num_cuenta = num_cuenta;
            this.tip_cuenta = tip_cuenta;
            this.tip_operacion = tip_operacion;
            this.tip_moneda = tip_moneda;
            this.importe = importe;
            this.SaldoActual = SaldoActual;
            this.SaldoContable = SaldoContable;

            //Enlace siguiente apunta a null
            siguiente = null;
        }

       


    }

}
