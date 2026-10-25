using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Equipo
    {
		private string id;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}
		private string serie;

		public string Serie
		{
			get { return serie; }
			set { serie = value; }
		}

		private string marca;

		public string Marca
		{
			get { return marca; }
			set { marca = value; }
		}
		private string modelo;

		public string Modelo
		{
			get { return modelo; }
			set { modelo = value; }
		}
		private Cliente propietario;

		public Cliente Propietario
		{
			get { return propietario; }
			set { propietario = value; }
		}
		private string accesorios;

		public string Accesorios
		{
			get { return accesorios; }
			set { accesorios = value; }
		}

		public virtual void MostrarInfo()
		{
            Console.WriteLine($"Id interno del producto: {ID} \n" +
				$"Numero de serie: {Serie} \n" +
				$"Marca registrada: {Marca} \n" +
				$"Modelo del equipo: {Modelo} \n" +
				$"Propietario: {Propietario.Nombre} \n" +
				$"(Con el id: {Propietario.ID})" +
				$"Accesorios entregados: {Accesorios}");
		}
		//Modificar luego
		public virtual double CalcularCosto()
		{
			return 0;
		}

		public Equipo(string id, string serie, string marca, string modelo, Cliente propietario, string accesorios)
		{
			ID = id;
			Serie = serie;
			Marca = marca;
			Modelo = modelo;
			Propietario = propietario;
			Accesorios = accesorios;
		}
	}
	internal class Computadora : Equipo
	{
		//Definir costo luego
		private double costo;

		public double Costo
		{
			get { return costo; }
			set { costo = value; }
		}
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Costo por reparacion: {Costo}");
        }
        public override double CalcularCosto()
        {
            return base.CalcularCosto();
        }
		public Computadora(string id, string serie, string marca, string modelo, Cliente propietario, string accesorio, double costo) : base(id, serie, marca, modelo, propietario, accesorio)
		{
			Costo = costo;
		}
	}
    internal class Laptop : Equipo
    {
        //Definir costo luego
        private double costo;

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Costo por reparacion: {Costo}");
        }
        public override double CalcularCosto()
        {
            return base.CalcularCosto();
        }
        public Laptop(string id, string serie, string marca, string modelo, Cliente propietario, string accesorio, double costo) : base(id, serie, marca, modelo, propietario, accesorio)
        {
            Costo = costo;
        }
    }
    internal class Impresora : Equipo
    {
        //Definir costo luego
        private double costo;

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Costo por reparacion: {Costo}");
        }
        public override double CalcularCosto()
        {
            return base.CalcularCosto();
        }
        public Impresora(string id, string serie, string marca, string modelo, Cliente propietario, string accesorio, double costo) : base(id, serie, marca, modelo, propietario, accesorio)
        {
            Costo = costo;
        }
    }
    internal class Telefono : Equipo
    {
        //Definir costo luego
        private double costo;

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Costo por reparacion: {Costo}");
        }
        public override double CalcularCosto()
        {
            return base.CalcularCosto();
        }
        public Telefono(string id, string serie, string marca, string modelo, Cliente propietario, string accesorio, double costo) : base(id, serie, marca, modelo, propietario, accesorio)
        {
            Costo = costo;
        }
    }
	internal class Repuesto
	{
		private string id;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private int existencias;

		public int Existencias
		{
			get { return existencias; }
			set { existencias = value; }
		}

		private double precio;

		public double Precio
		{
			get { return precio; }
			set { precio = value; }
		}
		public void MostrarInfo()
		{
            Console.WriteLine($"Codigo interno: {ID} \n" +
				$"Descripcion: {Descripcion}\n" +
				$"Cantidad en existencia: {Existencias} \n" +
				$"Precio por unidad: {Precio}");
		}
		public Repuesto(string id, string descripcion, int  existencias, double precio)
		{
			ID = id;
			Descripcion = descripcion;
			Existencias = existencias;
			Precio = precio;
		}
	}
}
