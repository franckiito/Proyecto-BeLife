using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Tarificador
    {
        /// <summary>
        /// Composicion de Cliente. Un tarificador tiene un cliente.
        /// </summary>
        public Cliente Cliente = new Cliente();

        public Tarificador()
        {
            Init();
        }

        private void Init()
        {
            Cliente = new Cliente();
        }

        public double CalcularRecargo()
        {
            double prima = 0;
            int edad = CalcularEdad(Cliente.FechaNacimiento, DateTime.Now);

            try
            {
                if (edad >= 18 && edad <= 25)
                {
                    prima += 3.6;
                }
                if (edad >= 26 && edad <= 45)
                {
                    prima += 2.4;
                }
                if (edad > 45)
                {
                    prima += 6.0;
                }
                //sexo 1 = hombre
                if (Cliente.Sexo.Id == 1)
                {
                    prima += 2.4;
                }
                else
                {
                    prima += 1.2;
                }
                //Soltero
                if (Cliente.EstadoCivil.Id == 1)
                {
                    prima += 4.8;
                }
                else
                {
                    //Casado
                    if (Cliente.EstadoCivil.Id == 2)
                    {
                        prima += 2.4;
                    }
                    else
                    {
                        prima += 3.6;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

            return prima;
        }

        public int CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }
    }
}
