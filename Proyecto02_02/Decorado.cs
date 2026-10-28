using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Decorar
    {
        public void Titulo(string texto, ConsoleColor colorFondo)
        {
            Console.Clear();
            Console.ResetColor();
            int ancho = 100;
            Console.BackgroundColor = colorFondo;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', ancho));
            int espacios = (ancho - texto.Length) / 2;
            Console.WriteLine(new string(' ', espacios) + texto + new string(' ', espacios));
            Console.WriteLine(new string('=', ancho));
            Console.ResetColor();
            Console.WriteLine();
        }

        public void OpcionMenu(string numero, string texto, ConsoleColor colorTex)
        {
            Console.ForegroundColor = colorTex;
            Console.Write("  [" + numero + "] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public void MensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ CORRECTO:  " + mensaje);
            Console.ResetColor();
        }

        public void MensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ✘ ERROR:  " + mensaje);
            Console.ResetColor();
        }

        public void Pausa()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione cualquier tecla para continuar....................");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
