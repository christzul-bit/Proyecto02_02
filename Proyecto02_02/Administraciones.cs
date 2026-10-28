using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Solicitud
    {
		private string id;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}
		private Cliente propietario;

		public Cliente Propietario
		{
			get { return propietario; }
			set { propietario = value; }
		}
		private Equipo dispositivo;

		public Equipo Dispositivo
		{
			get { return dispositivo; }
			set { dispositivo = value; }
		}
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
		private DateTime fechaEntrada;

		public DateTime FechaEntrada
		{
			get { return fechaEntrada; }
			set { fechaEntrada = value; }
		}
		private DateTime fechaLimite;

		public DateTime FechaLimite
		{
			get { return fechaLimite; }
			set { fechaLimite = value; }
		}
		private bool prioridad;

		public bool Prioridad
		{
			get { return prioridad; }
			set { prioridad = value; }
		}
		public enum tipoEstado
		{
			Espera, Revision, Reparacion, Entregado, Cancelado
		}
		private tipoEstado estado;

		public tipoEstado Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		private Tecnico tecnicoAsignado;

		public Tecnico TecnicoAsignado
		{
			get { return tecnicoAsignado; }
			set { tecnicoAsignado = value; }
		}
		private string diagnostico;

		public string Diagnostico
		{
			get { return diagnostico; }
			set { diagnostico = value; }
		}
		private List<Repuesto> repuestos;

		public List<Repuesto> Repuestos
		{
			get { return repuestos; }
			set { repuestos = value; }
		}
		private double costoReparacion;

		public double CostoReparacion
		{
			get { return costoReparacion; }
			set { costoReparacion = value; }
		}
		private double costoRepuesto;

		public double CostoRepuesto
		{
			get { return costoRepuesto; }
			set { costoRepuesto = value; }
		}
		private double total;

		public double Total
		{
			get { return total; }
			set { total = value; }
		}
		public void MostrarInfo()
		{
            Console.WriteLine($"Codigo de solicitud: {ID} \n" +
				$"Cliente asociado: {Propietario.Nombre} \n" +
				$"(Se identifica con el id: {Propietario.ID}) \n" +
				$"Equipo en presentado: {Dispositivo.Marca}, modelo {Dispositivo.Modelo} \n" +
				$"(Se identifica con el id: {Dispositivo.ID})\n" +
				$"Descripcion del problema: {Descripcion}\n" +
				$"Fecha de entrada: {FechaEntrada} \n" +
				$"Fecha limite de entrega: {FechaLimite}");
			if(Prioridad == false)
			{
                Console.WriteLine("Nivel de prioridad: Normal");
			}else { Console.WriteLine("Nible de prioridad: Alta"); }
            Console.WriteLine($"Estado de la solicitud: {Estado}\n" +
				$"Tecnico asignado: {TecnicoAsignado}\n" +
				$"Diagnostico: {Diagnostico}\n" +
				$"Repuestos utilizados ---- \n" +
				$"Costo por reparacion: {CostoReparacion} \n" +
				$"Costo por uso de repuestos: {CostoRepuesto} \n" +
				$"Costo Total: {Total}");
		}
		public double CalcularTotal(double reparacion, double repuestos)
		{
			return reparacion + repuestos;
		}
		//metodo para actualizar estado. pendiente
		public Solicitud(string id, Cliente porpietario, Equipo dispositivo, string descripcion, DateTime entrada, DateTime fin, bool prioridad, tipoEstado estado, Tecnico tecnico, string diagnostico, double costoReparacion, double costoRepuesto, double total)
		{
			ID = id;
			Propietario = porpietario;
			Dispositivo = dispositivo;
			Descripcion = descripcion;
			FechaEntrada = entrada;
			FechaLimite = fin;
			Prioridad = prioridad;
			Estado = estado;
			TecnicoAsignado = tecnico;
			Diagnostico = diagnostico;
			CostoReparacion = costoReparacion;
			CostoRepuesto = costoRepuesto;
			Total = total;
		}
	}
    internal class Administracion
    {
		private Solicitud pedido;

		public Solicitud Pedido
		{
			get { return pedido; }
			set { pedido = value; }
		}
		private List<Tecnico> tecnicos;

		public List<Tecnico> Tecnicos
		{
			get { return tecnicos; }
			set { tecnicos = value; }
		}
		private Queue<Solicitud> solicitudes;

		public Queue<Solicitud> Solicitudes
		{
			get { return solicitudes; }
			set { solicitudes = value; }
		}
		private Queue<Solicitud> urgentes;

		public Queue<Solicitud> Urgentes
		{
			get { return urgentes; }
			set { urgentes = value; }
		}
		private Queue<Solicitud> espera;

		public Queue<Solicitud> Espera
		{
			get { return espera; }
			set { espera = value; }
		}

		public Tecnico AsignarTecnico()
		{
			return tecnicos[1];
			//modificar luego
		}
		public Solicitud SiguienteSolicitud()
		{
			return solicitudes.Dequeue();
			//modificar luego
		}
		public void AdministrarSolicitud(Solicitud solicitud)
		{
			//modificar luego
		}
		public Administracion()
		{
			Tecnicos = new List<Tecnico>();
			Solicitudes = new Queue<Solicitud>();
			Urgentes = new Queue<Solicitud>();
			Espera = new Queue<Solicitud>();
		}
	}
	internal class Reportes
	{
		private List<Solicitud> completados;

		public List<Solicitud> Completados
		{
			get { return completados; }
			set { completados = value; }
		}
		private List<Repuesto> repuestos;

		public List<Repuesto> Repuestos
		{
			get { return repuestos; }
			set { repuestos = value; }
		}
		private string[,] historialSemanal;

		public string[,] HistorialSemanal
		{
			get { return historialSemanal; }
			set { historialSemanal = value; }
		}

		public void MostrarPendientes()
		{
			//modificar luego
		}

		public void MostrarSolicitudes()
		{
			//modificar luego
		}
		public void MostrarUrgentes() { }
		public void MostrarCompletados() { }
		public void MostrarTecnicosDisponibles() { }
		public void MostrarCompletadosTecnico() { }
		public void MostrarEquiposAtendidos() { }
		public void MostrarSolicitudesPorCosto() { }
		public void MostrarSolicitudesPorTiempo() { }
		public void MostrarRepuestosExistentes() { }
		public void MostrarIngresosTotales() { }
		public void MostrarHistorialSemanal() { }

		public Reportes(int filas)
		{
			Completados = new List<Solicitud>();
			HistorialSemanal = new string[7, filas];
			//ver mas detalles luego
		}
	}
}
