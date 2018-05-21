using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Validaciones
    {

        /// <summary>
        /// Retorna True si el rut es valido y no es nulo.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool ValidaRut(string rut)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(rut))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Rut.");
                }
                if (!ValidaRutChileno(rut))
                {
                    valida = false;
                    throw new Exception("Debe ingresar un Rut Valido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception("Valida Rut: " + ex.Message);
            }
        }

        //Rut Chileno Valido
        public bool ValidaRutChileno(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return validacion;
        }

        /// <summary>
        /// Retorna true si el Nombre es valido.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ValidaNombre(string nombre)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(nombre))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar nombres.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true si el Apellido es valido.
        /// </summary>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public bool ValidaApellido(string apellido)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(apellido))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar apellido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna True cuando una fecha es mayor de edad y no es nula.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool ValidaFechaNacimiento(DateTime fecha)
        {
            try
            {
                bool valida = true;

                if (fecha == null)
                {
                    valida = false;
                    throw new Exception("Debe Ingresar fecha.");
                }
                if (ValidaEdad(fecha) < 18)
                {
                    valida = false;
                    throw new Exception("Debe ser mayor de edad.");
                }
                

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna la edad, de una fecha ingresada por parametro.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private int ValidaEdad(DateTime fecha)
        {
            try
            {
                int age = DateTime.Now.Year - fecha.Year;
                if (DateTime.Now.Month < fecha.Month || (DateTime.Now.Month == fecha.Month && DateTime.Now.Day < fecha.Day))
                    age--;
                return age;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true cuando se ha seleccionado un combobox.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ValidaComboBoxEstado(int index)
        {
            try
            {
                bool valida = true;

                if (index < 0)
                {
                    valida = false;
                    throw new Exception("Debe seleccionar un item del combobox Estado.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true cuando se ha seleccionado un combobox.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ValidaComboBoxSexo(int index)
        {
            try
            {
                bool valida = true;

                if (index < 0)
                {
                    valida = false;
                    throw new Exception("Debe seleccionar un item del combobox Sexo.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
