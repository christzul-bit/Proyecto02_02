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
            Recibido, EnEspera, Asignada, EnDiagnostico, EnReparacion, ListaParaEntregar, Entregado, Cancelado
        }
		private tipoEstado estado;

		public tipoEstado Estado
		{
			get { return estado; }
			set { estado = value; }
		}
        private Stack<tipoEstado> historialEstados;
        public Stack<tipoEstado> HistorialEstados
        {
            get { return historialEstados; }
            set { historialEstados = value; }
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
        public bool ActualizarEstado(tipoEstado nuevoEstado)
        {
            if (estado == tipoEstado.Entregado || estado == tipoEstado.Cancelado)
            {
                return false;
            }
            historialEstados.Push(estado);
            estado = nuevoEstado;
            return true;
        }
        public bool DeshacerEstado()
        {
            if (estado == tipoEstado.Entregado || estado == tipoEstado.Cancelado)
            {
                return false;
            }
            if (historialEstados.Count > 0)
            {
                estado = historialEstados.Pop();
                return true;
            }
            return false;
        }
        public void MostrarInfo()
		{
            Console.WriteLine($"Codigo de solicitud: {ID} \n" +
				$"Cliente asociado: {Propietario.Nombre} (Id: {Propietario.ID}) \n" +
				$"Equipo en presentado: {Dispositivo.Marca}, {Dispositivo.Modelo} (Id: {Dispositivo.ID})\n" +
				$"Descripcion del problema: {Descripcion}\n" +
				$"Fecha de entrada: {FechaEntrada} \n" +
				$"Fecha limite de entrega: {FechaLimite} \n" +
				$"Prioridad: {(Prioridad ? "Urgente" : "Normal")} \n" +
				$"Estado Actual: {Estado} \n" +
				$"Técnico Asignado: {(TecnicoAsignado != null ? TecnicoAsignado.Nombre : "Sin asignar")} \n" +
				$"Diagnóstico: {(string.IsNullOrEmpty(Diagnostico) ? "Pendiente" : Diagnostico)}\n" +
				$"Costo Total: Q{Total:F2}");
		}
		public double CalcularTotal(double reparacion, double repuestos)
		{
			return reparacion + repuestos;
		}
		//metodo para actualizar estado. pendiente
		public Solicitud(string id, Cliente porpietario, Equipo dispositivo, string descripcion, DateTime entrada, DateTime fin, bool prioridad)
		{
			ID = id;
			Propietario = porpietario;
			Dispositivo = dispositivo;
			Descripcion = descripcion;
			FechaEntrada = entrada;
			FechaLimite = fin;
			Prioridad = prioridad;
			Estado = tipoEstado.Recibido;
            historialEstados = new Stack<tipoEstado>();
            TecnicoAsignado = null;
			Diagnostico = "";
			CostoReparacion = 0;
			CostoRepuesto = 0;
			Total = 0;
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
		private List<string> idClientes;

		public List<string> IdClientes
		{
			get { return idClientes; }
			set { idClientes = value; }
		}
		private List<string> idTecnicos;

		public List<string> IdTecnicos
		{
			get { return idTecnicos; }
			set { idTecnicos = value; }
		}

		private List<string> idEquipos;

		public List<string> IdEquipos
		{
			get { return idEquipos; }
			set { idEquipos = value; }
		}

		private List<string> idSolicitudes;

		public List<string> IdSolicitudes
		{
			get { return idSolicitudes; }
			set { idSolicitudes = value; }
		}
		private List<string> idRepuestos;

		public List<string> IdRepuestos
		{
			get { return idRepuestos; }
			set { idRepuestos = value; }
		}
        private List<Cliente> clientes;

		public List<Cliente> Clientes
		{
			get { return clientes; }
			set { clientes = value; }
		}
		private List<Equipo> equipos;

		public List<Equipo> Equipos
		{
			get { return equipos; }
			set { equipos = value; }
		}
		private List<Repuesto> repuestos;

		public List<Repuesto> Repuestos
		{
			get { return repuestos; }
			set { repuestos = value; }
		}



		private Random rand;

        public void RegistrarSolicitud(Cliente cli, Equipo eq, string desc, bool esUrgente)
        {
            Solicitud nuevaSol = new Solicitud(GenerarId("SLC"), cli, eq, desc, DateTime.Now, DateTime.Now.AddDays(7), esUrgente);
            nuevaSol.ActualizarEstado(Solicitud.tipoEstado.EnEspera);

            if (esUrgente)
            {
                Urgentes.Enqueue(nuevaSol);
            }
            else
            {
                Espera.Enqueue(nuevaSol);
            }
        }
        public bool AsignarTecnico(Solicitud sol, Tecnico tec)
		{
            if (!tec.Disponibilidad || tec.TrabajosActivos >= tec.LimiteTrabajos)
            {
                return false;
            }

            if (tec.Especialidad != Tecnico.especial.Multitarea)
            {
                string tipoEq = sol.Dispositivo.GetType().Name;
                if (!tec.Especialidad.ToString().Equals(tipoEq, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            sol.TecnicoAsignado = tec;
            tec.TrabajosActivos++;
            sol.ActualizarEstado(Solicitud.tipoEstado.Asignada);
            return true;
        }
		public Solicitud SiguienteSolicitud()
		{
            if (Urgentes.Count > 0)
            {
                return Urgentes.Dequeue();
            }
            else if (Solicitudes.Count > 0)
            {
                return Solicitudes.Dequeue();
            }
            return null;
        }
		public string GenerarId(string inicio)
		{
			string idrand;
			int numeros = rand.Next(10000, 100000);
			if(inicio == "CLT")
			{
				idrand = inicio + numeros;
				foreach(string i in idClientes)
				{
					if (i.Equals(idrand))
					{
						GenerarId(inicio);
					}
				}
				idClientes.Add(idrand);
				return idrand;
			}
            else if (inicio == "TEC")
            {
                idrand = inicio + numeros;
                foreach (string i in idTecnicos)
                {
                    if (i.Equals(idrand))
                    {
                        GenerarId(inicio);
                    }
                }
                idTecnicos.Add(idrand);
                return idrand;
            }
            else if (inicio == "DIS")
            {
                idrand = inicio + numeros;
                foreach (string i in idEquipos)
                {
                    if (i.Equals(idrand))
                    {
                        GenerarId(inicio);
                    }
                }
                idEquipos.Add(idrand);
                return idrand;
            }
            else if (inicio == "SLC")
            {
                idrand = inicio + numeros;
                foreach (string i in idSolicitudes)
                {
                    if (i.Equals(idrand))
                    {
                        GenerarId(inicio);
                    }
                }
                idSolicitudes.Add(idrand);
                return idrand;
            }
            else
			{
                idrand = inicio + numeros;
                foreach (string i in idRepuestos)
                {
                    if (i.Equals(idrand))
                    {
                        GenerarId(inicio);
                    }
                }
                idRepuestos.Add(idrand);
                return idrand;
            }
        }
		public void BusquedaId(string id)
		{
			bool encontrado = false;
            if (id.StartsWith("CLT"))
            {
                foreach (Cliente i in clientes)
				{
					if(id == i.ID)
					{
                        Console.WriteLine("Cliente encontrado: ");
						i.MostrarInfo();
						encontrado = true;
					}
				}
				if(encontrado == false)
				{
                    Console.WriteLine("No existe un cliente con ese ID");
				}
            }
            else if (id.StartsWith("TEC"))
            {
                foreach(Tecnico i in tecnicos)

                {
                    if (id == i.ID)
                    {
                        Console.WriteLine("Tecnico encontrado: ");
                        i.MostrarInfo();
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("No existe un tecnico con ese ID");
                }
            }
            else if (id.StartsWith("DIS"))
            {
                foreach(Equipo i in equipos)

                {
                    if (id == i.ID)
                    {
                        Console.WriteLine("Equipo encontrado: ");
                        i.MostrarInfo();
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("No existe un equipo con ese ID");
                }
            }
            else if (id.StartsWith("SLC"))
            {
                foreach(Solicitud i in solicitudes)

                {
                    if (id == i.ID)
                    {
                        Console.WriteLine("Solicitud encontrada: ");
                        i.MostrarInfo();
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    foreach (Solicitud i in Urgentes)

                    {
                        if (id == i.ID)
                        {
                            Console.WriteLine("Solicitud encontrada: ");
                            i.MostrarInfo();
                            encontrado = true;
                        }
                    }
					if(encontrado == false)
					{
                        foreach (Solicitud i in Espera)

                        {
                            if (id == i.ID)
                            {
                                Console.WriteLine("Solicitud encontrada: ");
                                i.MostrarInfo();
                                encontrado = true;
                            }
                        }
						if (!encontrado)
						{
                            Console.WriteLine("No existen solicitudes con ese ID");
						}
                    }

                }
            }
            else
            {
                foreach (Repuesto i in Repuestos)

                {
                    if (id == i.ID)
                    {
                        Console.WriteLine("Repuesto encontrado: ");
                        i.MostrarInfo();
                        encontrado = true;
                    }
                }
				if (!encontrado)
				{
                    Console.WriteLine("No existen repuestos con ese ID");
				}
            }
        }
        public bool ExisteNumeroSerie(string serie)
        {
            foreach (Equipo i in equipos)
            {
                if (i.Serie.Equals(serie, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public Administracion()
		{
			Tecnicos = new List<Tecnico>();
			Solicitudes = new Queue<Solicitud>();
			Urgentes = new Queue<Solicitud>();
			Espera = new Queue<Solicitud>();
			IdClientes = new List<string>();
			IdEquipos = new List<string>();
			IdTecnicos = new List<string>();
			IdRepuestos = new List<string>();
			IdSolicitudes = new List<string>();
			Clientes = new List<Cliente>();
			Repuestos = new List<Repuesto>();
			Equipos = new List<Equipo>();
			rand = new Random();
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
