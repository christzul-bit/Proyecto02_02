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
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                    texto.Pausa();
                } while (opcion != 11);
            }
            void MenuClientes()
            {
                Cliente cliente;
                int opcionCliente, tipoCliente, telefono;
                string nombreCliente, correoElectronico, numTelefono;

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
                                Console.WriteLine("No se han registrado clientes.");
                            }else
                            {
                                //codigo de busqueda
                            }
                            texto.Pausa();
                            break;
                        case 3:
                            if (admin.Clientes.Count == 0)
                            {
                                Console.WriteLine("No se han registrado clientes.");
                            }
                            else
                            {
                                foreach(Cliente i in admin.Clientes)
                                {
                                    i.MostrarInfo();
                                    Console.WriteLine();
                                }
                            }
                            texto.Pausa();
                            break;
                        case 4: break;
                        default: fallo.OpcionInvalida(); break;
                    }
                } while (opcionCliente != 4);
            }
            MenuPrincipal();

        }
    }
}
