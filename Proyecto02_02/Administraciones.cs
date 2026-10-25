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


	}
}
