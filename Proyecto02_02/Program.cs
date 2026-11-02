using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Decorar texto = new Decorar();
            Excepciones fallo = new Excepciones();
            Administracion admin = new Administracion();
            void MenuPrincipal()
            {
                int opcion;
                do
                {
                    texto.Titulo("XELATECH SOPORTE", ConsoleColor.Blue);
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Seleciona una opcion: ");
                        texto.OpcionMenu("1.", "Gestion clientes", ConsoleColor.Cyan);
                        texto.OpcionMenu("2.", "Gestion tecnicos", ConsoleColor.Cyan);
                        texto.OpcionMenu("3.", "Gestion equipos", ConsoleColor.Cyan);
                        texto.OpcionMenu("4.", "Gestion solicitudes", ConsoleColor.Cyan);
                        texto.OpcionMenu("5.", "Gestion repuestos", ConsoleColor.Cyan);
                        texto.OpcionMenu("6.", "Atencion de colas", ConsoleColor.Cyan);
                        texto.OpcionMenu("7.", "Ordenamientos", ConsoleColor.Cyan);
                        texto.OpcionMenu("8.", "Busquedas", ConsoleColor.Cyan);
                        texto.OpcionMenu("9.", "Reportes", ConsoleColor.Cyan);
                        texto.OpcionMenu("10.", "Generar datos de prueba", ConsoleColor.Cyan);
                        texto.OpcionMenu("11.", "Salir", ConsoleColor.Red);
                        if(!int.TryParse(Console.ReadLine(), out opcion)){
                            fallo.IntFalse();
                        }else { break; }
                    }while(true);
                    switch (opcion)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuTecnicos();
                            break;
                        case 3:
                            MenuEquipos();
                            break;
                        case 4:
                            MenuSolicitudes();
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            MenuOrdenamientos();
                            break;
                        case 8:
                            MenuBusquedas();
                            break;
                        case 9:
                            MenuReportes();
                            break;
                        case 10:
                            break;
                        case 11: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                } while (opcion != 11);
            }
            void MenuClientes()
            {
                Cliente cliente;
                int opcionCliente, tipoCliente, telefono;
                string nombreCliente, correoElectronico, numTelefono, idCliente;

                do
                {
                    texto.Titulo("Gestion Clientes", ConsoleColor.DarkBlue);
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Seleccione una opcion: ");
                        texto.OpcionMenu("1.", "Registrar nuevo cliente", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Editar cliente registrado", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Mostrar lista de clientes", ConsoleColor.Blue);
                        texto.OpcionMenu("4.", "Regresar al menu principal", ConsoleColor.Red);
                        if(!int.TryParse(Console.ReadLine(), out opcionCliente))
                        {
                            fallo.IntFalse();
                        }else { break; }
                    } while (true);
                    switch(opcionCliente)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Ingrese el nombre del cliente (entre 10 a 50 caracteres): ");
                                nombreCliente = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nombreCliente))
                                {
                                    if(nombreCliente.Length < 10 || nombreCliente.Length > 50)
                                    {
                                        fallo.DatoFueraRando();
                                    }else { break; }
                                    
                                }else { fallo.DatoVacio(); }
                                
                            } while (true);
                            do
                            {
                                Console.WriteLine("Ingrese el numero de telefono del cliente (8 caracteres): ");
                                numTelefono = Console.ReadLine();
                                if (!string.IsNullOrEmpty(numTelefono))
                                {
                                    if (numTelefono.Length != 8)
                                    {
                                        fallo.DatoFueraRando();
                                    }
                                    else {
                                        if(!int.TryParse(numTelefono, out telefono))
                                        {
                                            fallo.IntFalse();
                                        }else { break; }
                                    }

                                }else { fallo.DatoVacio(); }

                            } while (true);
                            do
                            {
                                Console.WriteLine("Ingrese el correo electronico del cliente (menos de 20 caracteres): ");
                                correoElectronico = Console.ReadLine().Trim();
                                if (!string.IsNullOrEmpty(correoElectronico))
                                {
                                    if (correoElectronico.Length > 20)
                                    {
                                        fallo.DatoFueraRando();
                                    }
                                    else {
                                        if (correoElectronico.EndsWith("@gmail.com"))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            texto.MensajeError("El correo electronico debe terminar con '@gmail.com'");
                                        }
                                    }

                                }else { fallo.DatoVacio(); }
                                
                            } while (true);
                            do
                            {
                                Console.WriteLine("Seleccione el tipo de cliente: ");
                                texto.OpcionMenu("1.", "Personal", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("2.", "Empresarial", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("3.", "Estudiante", ConsoleColor.DarkYellow);
                                if(!int.TryParse(Console.ReadLine().Trim(), out tipoCliente))
                                {
                                    fallo.IntFalse();
                                }else {
                                    if(tipoCliente < 1 ||  tipoCliente > 3)
                                    {
                                        fallo.OpcionInvalida();
                                    }else { break; }
                                }                                
                            } while (true);
                            if(tipoCliente == 1)
                            {
                                cliente = new Cliente(admin.GenerarId("CLT"), nombreCliente,telefono,correoElectronico,Cliente.tipoClientes.Persona,0);
                            }else if(tipoCliente == 2)
                            {
                                cliente = new Cliente(admin.GenerarId("CLT"), nombreCliente, telefono, correoElectronico, Cliente.tipoClientes.Empresarial, 0);
                            }
                            else
                            {
                                cliente = new Cliente(admin.GenerarId("CLT"), nombreCliente, telefono, correoElectronico, Cliente.tipoClientes.Estudiante, 0);
                            }
                            admin.Clientes.Add(cliente);
                            texto.MensajeExito("Cliente registrado correctamente");
                            break;
                        case 2:
                            if(admin.Clientes.Count == 0)
                            {
                                texto.MensajeError("No se han registrado clientes.");
                            }else
                            {
                                do
                                {
                                    Console.WriteLine("Ingrese el id a buacar (ej. CLT12345): ");
                                    idCliente = Console.ReadLine();
                                    if (string.IsNullOrEmpty(idCliente))
                                    {
                                        fallo.DatoVacio();
                                    }else { 
                                        if(idCliente.Length != 8)
                                        {
                                            fallo.DatoFueraRando();
                                        }else
                                        {
                                            break;
                                        }
                                    }
                                } while (true);
                                admin.BusquedaId(idCliente);
                            }
                            break;
                        case 3:
                            if (admin.Clientes.Count == 0)
                            {
                                texto.MensajeError("No se han registrado clientes.");
                            }
                            else
                            {
                                foreach(Cliente i in admin.Clientes)
                                {
                                    i.MostrarInfo();
                                    Console.WriteLine(new string('-', 30));
                                }
                            }
                            break;
                        case 4: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opcionCliente != 4);
            }
            void MenuTecnicos()
            {
                int opcionTecnico, tipoEspecialidad;
                string nombreTecnico, idTecnico;
                do
                {
                    texto.Titulo("Gestión de Técnicos", ConsoleColor.DarkBlue);
                    do
                    {
                        Console.WriteLine("Seleccione una opción: ");
                        texto.OpcionMenu("1.", "Registrar nuevo técnico", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Buscar técnico por ID", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Mostrar lista de técnicos", ConsoleColor.Blue);
                        texto.OpcionMenu("4.", "Regresar al menú principal", ConsoleColor.Red);
                        if (!int.TryParse(Console.ReadLine(), out opcionTecnico))
                        {
                            fallo.IntFalse();
                        }
                        else { break; }
                    } while (true);

                    switch (opcionTecnico)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Ingrese el nombre del técnico (10 a 50 caracteres): ");
                                nombreTecnico = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nombreTecnico))
                                {
                                    if (nombreTecnico.Length < 10 || nombreTecnico.Length > 50)
                                        fallo.DatoFueraRando();
                                    else { break; }
                                }
                                else fallo.DatoVacio();
                            } while (true);

                            do
                            {
                                Console.WriteLine("Seleccione la especialidad: ");
                                texto.OpcionMenu("1.", "Computadora", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("2.", "Laptop", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("3.", "Impresora", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("4.", "Teléfono", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("5.", "Multitarea", ConsoleColor.DarkYellow);
                                if (!int.TryParse(Console.ReadLine(), out tipoEspecialidad) || tipoEspecialidad < 1 || tipoEspecialidad > 5)
                                {
                                    fallo.OpcionInvalida();
                                }
                                else { break; }
                            } while (true);

                            Tecnico.especial esp = (Tecnico.especial)(tipoEspecialidad - 1);
                            Tecnico nuevoTec = new Tecnico(admin.GenerarId("TEC"), nombreTecnico, esp, true, 3);
                            admin.Tecnicos.Add(nuevoTec);
                            texto.MensajeExito("Técnico registrado correctamente.");
                            break;

                        case 2:
                            if (admin.Tecnicos.Count == 0)
                            {
                                texto.MensajeError("No hay técnicos registrados.");
                            }
                            else
                            {
                                do
                                {
                                    Console.WriteLine("Ingrese el ID del técnico a buscar (ej. TEC12345): ");
                                    idTecnico = Console.ReadLine();
                                    if (string.IsNullOrEmpty(idTecnico))
                                    {
                                        fallo.DatoVacio();
                                    }
                                    else
                                    {
                                        if (idTecnico.Length != 8)
                                        {
                                            fallo.DatoFueraRando();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                } while (true);
                                admin.BusquedaId(idTecnico);
                            }
                            break;

                        case 3:
                            if (admin.Tecnicos.Count == 0)
                            {
                                texto.MensajeError("No hay técnicos registrados.");
                            }
                            else
                            {
                                foreach (Tecnico t in admin.Tecnicos)
                                {
                                    t.MostrarInfo();
                                    Console.WriteLine(new string('-', 30));
                                }
                            }
                            break;

                        case 4: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opcionTecnico != 4);
            }

            void MenuEquipos()
            {
                int opcionEquipo, tipoEquipo;
                string serie, marca, modelo, estadoFisico, accesorios, idClienteBuscado;
                Cliente propietarioAsignado = null;

                do
                {
                    texto.Titulo("Gestión de Equipos", ConsoleColor.DarkBlue);
                    do
                    {
                        Console.WriteLine("Seleccione una opción: ");
                        texto.OpcionMenu("1.", "Registrar nuevo equipo", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Mostrar lista de equipos", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Regresar al menú principal", ConsoleColor.Red);
                        if (!int.TryParse(Console.ReadLine(), out opcionEquipo))
                        {
                            fallo.IntFalse();
                        }
                        else { break; }
                    } while (true);

                    switch (opcionEquipo)
                    {
                        case 1:
                            if (admin.Clientes.Count == 0)
                            {
                                texto.MensajeError("Debe registrar al menos un cliente antes de asociar un equipo.");
                                texto.Pausa();
                                break;
                            }
                            do
                            {
                                Console.WriteLine("Ingrese el ID del cliente propietario (ej. CLT12345): ");
                                idClienteBuscado = Console.ReadLine();
                                propietarioAsignado = admin.Clientes.FirstOrDefault(c => c.ID == idClienteBuscado);
                                if (propietarioAsignado == null)
                                {
                                    texto.MensajeError("Cliente no encontrado. Intente nuevamente.");
                                }
                                else { break; }
                            } while (true);

                            do
                            {
                                Console.WriteLine("Ingrese el número de serie único del equipo: ");
                                serie = Console.ReadLine().Trim();
                                if (string.IsNullOrEmpty(serie))
                                {
                                    fallo.DatoVacio();
                                }
                                else if (admin.ExisteNumeroSerie(serie))
                                {
                                    texto.MensajeError("El número de serie ya se encuentra registrado en el sistema.");
                                }
                                else { break; }
                            } while (true);
                            do
                            {

                                Console.WriteLine("Ingrese la marca del equipo (10 caracteres maximo): ");
                                marca = Console.ReadLine().Trim();
                                if (!string.IsNullOrEmpty(marca))
                                {
                                    if (marca.Length > 10)
                                        fallo.DatoFueraRando();
                                    else { break; }
                                }
                                else {fallo.DatoVacio();}

                            } while (true);
                            do
                            {
                                Console.WriteLine("Ingrese el modelo del equipo: ");
                                modelo = Console.ReadLine();
                                if (!string.IsNullOrEmpty(modelo))
                                {
                                    if (modelo.Length > 10 || modelo.Length < 5)
                                        fallo.DatoFueraRando();
                                    else { break; }
                                }
                                else { fallo.DatoVacio(); }
                            } while (true);
                            do
                            {
                                Console.WriteLine("Ingrese el estado físico recibido (ej. Bueno, Rayado, Dañado): ");
                                estadoFisico = Console.ReadLine();
                                if (!string.IsNullOrEmpty(estadoFisico))
                                {
                                    if (estadoFisico.Length > 50 || estadoFisico.Length < 10)
                                        fallo.DatoFueraRando();
                                    else { break; }
                                }
                                else { fallo.DatoVacio(); }
                            } while (true);
                            do
                            {
                                Console.WriteLine("Ingrese accesorios entregados (ej. Cargador, Estuche): ");
                                accesorios = Console.ReadLine();
                                if (!string.IsNullOrEmpty(accesorios))
                                {
                                    if (accesorios.Length > 50 || accesorios.Length < 10)
                                        fallo.DatoFueraRando();
                                    else { break; }
                                }
                                else { fallo.DatoVacio(); }
                            } while (true);

                            do
                            {
                                Console.WriteLine("Seleccione el tipo de equipo: ");
                                texto.OpcionMenu("1.", "Computadora de Escritorio", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("2.", "Laptop", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("3.", "Impresora", ConsoleColor.DarkYellow);
                                texto.OpcionMenu("4.", "Teléfono", ConsoleColor.DarkYellow);
                                if (!int.TryParse(Console.ReadLine(), out tipoEquipo) || tipoEquipo < 1 || tipoEquipo > 4)
                                {
                                    fallo.OpcionInvalida();
                                }
                                else { break; }
                            } while (true);

                            Equipo nuevoEq = null;
                            if (tipoEquipo == 1) nuevoEq = new Computadora(admin.GenerarId("DIS"), serie, marca, modelo, propietarioAsignado, accesorios, estadoFisico, 150.0);
                            else if (tipoEquipo == 2) nuevoEq = new Laptop(admin.GenerarId("DIS"), serie, marca, modelo, propietarioAsignado, accesorios, estadoFisico,  200.0);
                            else if (tipoEquipo == 3) nuevoEq = new Impresora(admin.GenerarId("DIS"), serie, marca, modelo, propietarioAsignado, accesorios, estadoFisico, 100.0);
                            else if (tipoEquipo == 4) nuevoEq = new Telefono(admin.GenerarId("DIS"), serie, marca, modelo, propietarioAsignado, accesorios, estadoFisico, 120.0);

                            admin.Equipos.Add(nuevoEq);
                            texto.MensajeExito("Equipo registrado exitosamente.");
                            break;

                        case 2:
                            if (admin.Equipos.Count == 0)
                            {
                                texto.MensajeError("No hay equipos registrados.");
                            }
                            else
                            {
                                foreach (Equipo i in admin.Equipos)
                                {
                                    i.MostrarInfo();
                                    Console.WriteLine(new string('-', 30));
                                }
                            }
                            break;

                        case 3: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opcionEquipo != 3);
            }
            void MenuSolicitudes()
            {
                int opSol;
                string idEq, desc, idTec;
                do
                {
                    texto.Titulo("Gestión de Solicitudes y Colas", ConsoleColor.DarkBlue);
                    do
                    {
                        Console.WriteLine("Seleccione una opción: ");
                        texto.OpcionMenu("1.", "Crear nueva solicitud de servicio", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Atender siguiente solicitud (Urgentes / Normales)", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Ver historial y Deshacer último estado de solicitud", ConsoleColor.Blue);
                        texto.OpcionMenu("4.", "Regresar al menú principal", ConsoleColor.Red);

                        if (!int.TryParse(Console.ReadLine(), out opSol))
                        {
                            fallo.IntFalse();
                        }
                        else { break; }
                    } while (true);

                    switch (opSol)
                    {
                        case 1:
                            if (admin.Clientes.Count == 0 || admin.Equipos.Count == 0)
                            {
                                texto.MensajeError("Debe registrar al menos un cliente y un equipo previamente.");
                                break;
                            }
                            do
                            {
                                Console.WriteLine("Ingrese el ID del equipo para la solicitud: ");
                                idEq = Console.ReadLine();
                                if (!string.IsNullOrEmpty(idEq))
                                {
                                    if(idEq.Length != 8)
                                    {
                                        fallo.DatoFueraRando();
                                    }else { break; }
                                }
                                else { fallo.DatoVacio(); }
                            } while (true);
                            Equipo equipoBuscado = admin.Equipos.FirstOrDefault(e => e.ID == idEq);
                            if (equipoBuscado == null)
                            {
                                texto.MensajeError("Equipo no encontrado.");
                                break;
                            }

                            bool equipoOcupado = admin.Urgentes.Any(s => s.Dispositivo.ID == idEq) ||
                                                 admin.Espera.Any(s => s.Dispositivo.ID == idEq);
                            if (equipoOcupado)
                            {
                                texto.MensajeError("El equipo ya cuenta con una solicitud activa en el sistema.");
                                break;
                            }

                            do
                            {
                                Console.WriteLine("Ingrese la descripción del problema: ");
                                desc = Console.ReadLine();
                                if (!string.IsNullOrEmpty(desc))
                                {
                                    if(desc.Length < 10 ||  desc.Length > 40)
                                    {
                                        fallo.DatoFueraRando();
                                    }
                                    else { break; }
                                }else { fallo.DatoVacio(); }
                            } while (true);

                            Console.WriteLine("¿La solicitud es urgente? (1. Sí / 2. No): ");
                            int pOp = int.TryParse(Console.ReadLine(), out int valP) ? valP : 2;
                            bool esUrgente = (pOp == 1);

                            admin.RegistrarSolicitud(equipoBuscado.Propietario, equipoBuscado, desc, esUrgente);
                            texto.MensajeExito("Solicitud registrada y encolada correctamente.");
                            break;

                        case 2:
                            Solicitud solAtender = admin.SiguienteSolicitud();
                            if (solAtender == null)
                            {
                                texto.MensajeError("No hay solicitudes pendientes en las colas.");
                                break;
                            }

                            texto.Resaltar("--- Siguiente Solicitud a Atender ---",ConsoleColor.DarkCyan);
                            solAtender.MostrarInfo();

                            if (admin.Tecnicos.Count == 0)
                            {
                                texto.MensajeError("No hay técnicos registrados para asignar.");
                                break;
                            }

                            texto.Resaltar("\nTécnicos disponibles en el sistema:", ConsoleColor.DarkBlue);
                            foreach (var t in admin.Tecnicos)
                            {
                                t.MostrarInfo();
                                Console.WriteLine("-------------------");
                            }

                            do
                            {
                                Console.WriteLine("Ingrese el ID del técnico a asignar: ");
                                idTec = Console.ReadLine();
                                if (!string.IsNullOrEmpty(idTec))
                                {
                                    if(idTec.Length != 8)
                                    {
                                        fallo.DatoFueraRando();
                                    }else { break; }
                                }
                                else { fallo.DatoVacio(); }
                            } while (true);
                            Tecnico tecAsignar = admin.Tecnicos.FirstOrDefault(t => t.ID == idTec);

                            if (tecAsignar != null && admin.AsignarTecnico(solAtender, tecAsignar))
                            {
                                texto.MensajeExito("Técnico asignado exitosamente y estado actualizado.");
                            }
                            else
                            {
                                texto.MensajeError("No se pudo asignar el técnico (verifique disponibilidad, carga o especialidad).");
                                if (solAtender.Prioridad) admin.Urgentes.Enqueue(solAtender);
                                else admin.Solicitudes.Enqueue(solAtender);
                            }
                            break;

                        case 3:
                            Console.WriteLine("Ingrese el ID de la solicitud a consultar: ");
                            string idS = Console.ReadLine();
                            Solicitud solHist = admin.Urgentes.FirstOrDefault(s => s.ID == idS) ??
                                                admin.Solicitudes.FirstOrDefault(s => s.ID == idS);

                            if (solHist == null)
                            {
                                texto.MensajeError("Solicitud no encontrada en colas activas.");
                                break;
                            }

                            solHist.MostrarInfo();
                            Console.WriteLine($"\nCantidad de estados anteriores en la Pila: {solHist.HistorialEstados.Count}");
                            texto.Resaltar("¿Desea deshacer el último cambio de estado? (1. Sí / 2. No): ",ConsoleColor.Yellow);
                            if (int.TryParse(Console.ReadLine(), out int rDeshacer) && rDeshacer == 1)
                            {
                                if (solHist.DeshacerEstado())
                                {
                                    texto.MensajeExito($"Estado revertido con éxito. Nuevo estado: {solHist.Estado}");
                                }
                                else
                                {
                                    texto.MensajeError("No se pudo deshacer (pila vacía o estado finalizado/entregado).");
                                }
                            }
                            break;

                        case 4: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opSol != 4);
            }
            void MenuOrdenamientos()
            {
                int opOrd;
                do
                {
                    texto.Titulo("Módulo de Ordenamientos Manuales", ConsoleColor.DarkBlue);
                    do
                    {
                        Console.WriteLine("Seleccione el algoritmo de ordenamiento: ");
                        texto.OpcionMenu("1.", "Solicitudes por Costo Total", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Técnicos por Servicios Finalizados", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Repuestos por Existencias", ConsoleColor.Blue);
                        texto.OpcionMenu("4.", "Solicitudes por Fecha de Recepción", ConsoleColor.Blue);
                        texto.OpcionMenu("5.", "Regresar al menú principal", ConsoleColor.Red);

                        if (!int.TryParse(Console.ReadLine(), out opOrd))
                        {
                            fallo.IntFalse();
                        }else { break; }
                    } while (true);

                    var todasSolicitudes = admin.Urgentes.Concat(admin.Solicitudes).ToList();

                    switch (opOrd)
                    {
                        case 1:
                            if (todasSolicitudes.Count == 0) { texto.MensajeError("No hay solicitudes suficientes."); break; }
                            admin.SolicitudesPorCosto(todasSolicitudes);
                            texto.Resaltar("\n--- Solicitudes ordenadas por Costo ---", ConsoleColor.Blue);
                            foreach (var s in todasSolicitudes) { Console.WriteLine($"ID: {s.ID} | Costo: Q{s.Total:F2}"); }
                            break;

                        case 2:
                            if (admin.Tecnicos.Count == 0) { texto.MensajeError("No hay técnicos suficientes."); break; }
                            admin.TecnicosPorServicios(admin.Tecnicos);
                            texto.Resaltar("\n--- Técnicos ordenados por Servicios ---", ConsoleColor.Blue);
                            foreach (var t in admin.Tecnicos) { Console.WriteLine($"Técnico: {t.Nombre} | Servicios: {t.ServiciosFinalizados}"); }
                            break;

                        case 3:
                            if (admin.Repuestos.Count == 0) { texto.MensajeError("No hay repuestos suficientes."); break; }
                            admin.RepuestosPorExistencia(admin.Repuestos);
                            texto.Resaltar("\n--- Repuestos ordenados por Existencia ---", ConsoleColor.Blue);
                            foreach (var r in admin.Repuestos) { Console.WriteLine($"Repuesto: {r.Descripcion} | Existencias: {r.Existencias}"); }
                            break;

                        case 4:
                            if (todasSolicitudes.Count == 0) { texto.MensajeError("No hay solicitudes suficientes."); break; }
                            admin.SolicitudesPorFecha(todasSolicitudes, 0, todasSolicitudes.Count - 1);
                            texto.Resaltar("\n--- Solicitudes ordenadas por Fecha (Quick Sort) ---", ConsoleColor.Blue);
                            foreach (var s in todasSolicitudes) { Console.WriteLine($"ID: {s.ID} | Fecha: {s.FechaEntrada}"); }
                            break;

                        case 5: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opOrd != 5);
            }

            void MenuBusquedas()
            {
                int opBus;
                string busNombre, idSolicitud;
                do
                {
                    texto.Titulo("Módulo de Búsquedas", ConsoleColor.DarkBlue);
                    do
                    {
                        Console.WriteLine("Seleccione el tipo de búsqueda: ");
                        texto.OpcionMenu("1.", "Clientes por nombre parcial", ConsoleColor.Blue);
                        texto.OpcionMenu("2.", "Solicitud por Código ID", ConsoleColor.Blue);
                        texto.OpcionMenu("3.", "Regresar al menú principal", ConsoleColor.Red);

                        if (!int.TryParse(Console.ReadLine(), out opBus))
                        {
                            fallo.IntFalse();
                        }
                        else { break; }
                    } while (true);

                    switch (opBus)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Ingrese parte del nombre del cliente a buscar (no mayor a 50 caracteres): ");
                                busNombre = Console.ReadLine();
                                if (!string.IsNullOrEmpty(busNombre))
                                {
                                    if (busNombre.Length > 50)
                                    {
                                        fallo.DatoFueraRando();
                                    }else { break; }                                  
                                }else { fallo.DatoVacio(); }
                            } while (true);
                            admin.BusquedaCliente(busNombre);
                            break;

                        case 2:
                            var listaSol = admin.Urgentes.Concat(admin.Espera).ToList();
                            if (listaSol.Count == 0) { texto.MensajeError("No hay solicitudes."); break; }

                            do
                            {
                                Console.WriteLine("Ingrese el id a buacar (ej. CLT12345): ");
                                idSolicitud = Console.ReadLine();
                                if (string.IsNullOrEmpty(idSolicitud))
                                {
                                    fallo.DatoVacio();
                                }
                                else
                                {
                                    if (idSolicitud.Length != 8)
                                    {
                                        fallo.DatoFueraRando();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            } while (true);
                            admin.BusquedaId(idSolicitud);
                            break;

                        case 3: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                } while (opBus != 3);
            }
            void MenuReportes()
            {
                int opRep;
                Reportes repManager = new Reportes();

                do
                {
                    texto.Titulo("Módulo de Reportes y Estadísticas", ConsoleColor.DarkBlue);
                    Console.WriteLine("Seleccione un reporte a generar: ");
                    texto.OpcionMenu("1.", "Solicitudes en espera (separadas por prioridad)", ConsoleColor.Blue);
                    texto.OpcionMenu("2.", "Solicitudes activas, finalizadas y canceladas", ConsoleColor.Blue);
                    texto.OpcionMenu("3.", "Técnicos disponibles y con carga completa", ConsoleColor.Blue);
                    texto.OpcionMenu("4.", "Técnico con más servicios finalizados", ConsoleColor.Blue);
                    texto.OpcionMenu("5.", "Matriz semanal de carga de trabajo", ConsoleColor.Blue);
                    texto.OpcionMenu("6.", "Regresar al menú principal", ConsoleColor.Red);

                    if (!int.TryParse(Console.ReadLine(), out opRep))
                    {
                        fallo.IntFalse();
                        continue;
                    }

                    switch (opRep)
                    {
                        case 1:
                            texto.Resaltar("\n--- SOLICITUDES URGENTES EN ESPERA ---", ConsoleColor.DarkBlue);
                            if (admin.Urgentes.Count == 0) Console.WriteLine("No hay solicitudes urgentes pendientes.");
                            else foreach (var s in admin.Urgentes) { s.MostrarInfo(); Console.WriteLine("---"); }

                            texto.Resaltar("\n--- SOLICITUDES NORMALES EN ESPERA ---", ConsoleColor.DarkBlue);
                            if (admin.Solicitudes.Count == 0) Console.WriteLine("No hay solicitudes normales pendientes.");
                            else foreach (var s in admin.Espera) { s.MostrarInfo(); Console.WriteLine("---"); }
                            break;

                        case 3:
                            repManager.MostrarTecnicosDisponibles(admin.Tecnicos);
                            break;

                        case 4:
                            repManager.MostrarTecnicoTop(admin.Tecnicos);
                            break;

                        case 5:
                            repManager.MostrarHistorialSemanal(admin.Tecnicos);
                            break;

                        case 6: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opRep != 6);
            }

            //---------------------------
            MenuPrincipal();

        }
    }
}
