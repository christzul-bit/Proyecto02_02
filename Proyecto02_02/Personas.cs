using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Persona
    {
		private string id;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public virtual void MostrarInfo()
		{
            Console.WriteLine();
		}

		public Persona(string id, string nombre)
		{
			ID = id;
			Nombre = nombre;
		}
	}
	internal class Cliente : Persona
	{
		private int telefono;

		public int Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}
		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}

		public enum tipoClientes
		{
			Persona, Empresarial, Estudiante
		}
		private tipoClientes tipo;

		public tipoClientes Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}
		private int solicitudes;

		public int Solicitudes
		{
			get { return solicitudes; }
			set { solicitudes = value; }
		}

        public override void MostrarInfo()
        {
            Console.WriteLine($"Codigo del cliente: {ID} \n" +
				$"Nombre del cliente: {Nombre} \n" +
				$"Numero telefonico: {Telefono} \n" +
				$"Correo electronico: {Correo} \n" +
				$"Tipo de cliente: {Tipo} \n" +
				$"Numero de solicitudes: {Solicitudes}");
        }
		public Cliente(string id, string name, int phone, string correo, tipoClientes tipo, int solicitud) : base(id, name)
		{
			Telefono = phone;
			Correo = correo;
			Tipo = tipo;
			Solicitudes = solicitud;
		}
	}
	internal class Tecnico : Persona
	{
		public enum especial
		{
			Computadora, Laptop, Impresora, Telefono, Multitarea
		}
		private especial especialidad;

		public especial Especialidad
		{
			get { return especialidad; }
			set { especialidad = value; }
		}
		private bool disponibilidad;

		public bool Disponibilidad
		{
			get { return disponibilidad; }
			set { disponibilidad = value; }
		}
        private int trabajosActivos;
        public int TrabajosActivos
        {
            get { return trabajosActivos; }
            set { trabajosActivos = value; }
        }
        private int serviciosFinalizados;
        public int ServiciosFinalizados
        {
            get { return serviciosFinalizados; }
            set { serviciosFinalizados = value; }
        }
        private List<double> calificacionPromedio;
        public List<double> CalificacionPromedio
        {
            get { return calificacionPromedio; }
            set { calificacionPromedio = value; }
        }
        private int limiteTrabajos;
        public int LimiteTrabajos
        {
            get { return limiteTrabajos; }
            set { limiteTrabajos = value; }
        }
		private double CalcularPromedio()
		{

            if (CalificacionPromedio == null || CalificacionPromedio.Count == 0)
            {
                return 0;
            }
            else
            {
                return CalificacionPromedio.Average();
            }
        }

        public override void MostrarInfo()
        {
			//Modificar luego
            Console.WriteLine($"Codigo del tecnico: {ID} \n" +
                $"Nombre del tecnico: {Nombre} \n" +
                $"Especialidad: {Especialidad} \n" +
                $"Disponibilidad: {(Disponibilidad ? "Disponible" : "No disponible \n")}\n" +
				$"Trabajos activos: {TrabajosActivos} / {LimiteTrabajos} \n" +
                $"Servicios finalizados: {ServiciosFinalizados} \n" +
				$"Calificación promedio: {CalcularPromedio()}");
        }
		public Tecnico(string id, string name, especial Especial, bool disponibilidad, int limite) : 
			base(id, name)
		{
			Especialidad = Especial;
			Disponibilidad = disponibilidad;
			LimiteTrabajos = limite;
			TrabajosActivos = 0;
			ServiciosFinalizados = 0;
			CalificacionPromedio = new List<double>();
		}

	}
}
