using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02_02
{
    internal class Excepciones
    {
        private Decorar texto;

        public Decorar Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public void IntFalse()
        {
            Texto.MensajeError("Ingrese su respuesta unicamente en numeros");
        }
        public void OpcionInvalida()
        {
            Texto.MensajeError("Ha ingresado una opcion invalida, ingrese unicamente datos dentro del rango establecido por el menu");
        }
        public void DatoVacio()
        {
            Texto.MensajeError("No puedes dejar este dato vacio, por favor ingresa la informacion requerida");
        }
        public void DatoFueraRando()
        {
            Texto.MensajeError("El dato que has ingresado no posee los caracteres requeridos.");
        }
        public Excepciones()
        {
            Texto = new Decorar();
        }
    }
}
