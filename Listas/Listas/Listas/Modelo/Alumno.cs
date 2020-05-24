using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Listas.Modelo
{
    public class Alumno
    {
        private string numControl;
        private string nombre;
        private string apellido1;
        private string apellido2;

        public string NumControl
        {
            get
            {
                return numControl;

            }
            set
            {
                numControl = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido1
        {
            get
            {
                return apellido1;

            }
            set
            {
                apellido1 = value;
            }
        }

        public string Apellido2
        {
            get
            {
                return apellido2;
            }
            set
            {
                apellido2 = value;
            }
        }

        public Alumno()
        {
            NumControl = "14460667";
            Nombre = "Daniel";
            Apellido1 = "Hernandez";
            Apellido2 = "Pizano";
        }
    }
}