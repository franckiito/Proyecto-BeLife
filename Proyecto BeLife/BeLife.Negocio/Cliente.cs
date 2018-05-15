using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Cliente
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        public Cliente()
        {
            Init();
        }

        private void Init()
        {
            Rut = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            FechaDeNacimiento = DateTime.Today;
            Sexo = new Sexo();
            EstadoCivil = new EstadoCivil();
        }

        public void Create()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public Cliente Read(string rut)
        {
            Cliente cliente = new Cliente();

            using (BeLifeEntity bbdd = new BeLifeEntity())
            {

                var resultadoQuery = (from c in bbdd.Cliente
                                     where c.Rut == rut
                                     select c).FirstOrDefault();

                if (resultadoQuery != null)
                {

                    cliente.Rut = resultadoQuery.Rut;
                    cliente.Nombres = resultadoQuery.Nombres;
                    cliente.Apellidos = resultadoQuery.Apellidos;
                    cliente.FechaDeNacimiento = resultadoQuery.FechaNacimiento;

                    Sexo sexo = new Sexo();
                    cliente.Sexo = sexo.Read(resultadoQuery.IdSexo);

                    EstadoCivil estado = new EstadoCivil();
                    cliente.EstadoCivil = estado.Read(resultadoQuery.IdEstado);

                }
                else cliente = null;
            }

            return cliente;
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public List<Cliente> ReadAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (BeLifeEntity bbdd = new BeLifeEntity())
            {

                var resultadoQuery = from c in bbdd.Cliente
                                     select c;

                foreach (var x in resultadoQuery)
                {
                    Cliente cliente = new Cliente();
                    cliente.Rut = x.Rut;
                    cliente.Nombres = x.Nombres;
                    cliente.Apellidos = x.Apellidos;
                    cliente.FechaDeNacimiento = x.FechaNacimiento;

                    Sexo sexo = new Sexo();
                    cliente.Sexo = sexo.Read(x.IdSexo);

                    EstadoCivil estado = new EstadoCivil();
                    cliente.EstadoCivil = estado.Read(x.IdEstado);

                    clientes.Add(cliente);

                }
            }

            return clientes;
        }

        public List<Cliente> ReadAllBySexo(int idSexo)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (BeLifeEntity bbdd = new BeLifeEntity())
            {

                var resultadoQuery = from c in bbdd.Cliente
                                        where c.IdSexo == idSexo
                                     select c;

                foreach (var x in resultadoQuery)
                {
                    Cliente cliente = new Cliente();
                    cliente.Rut = x.Rut;
                    cliente.Nombres = x.Nombres;
                    cliente.Apellidos = x.Apellidos;
                    cliente.FechaDeNacimiento = x.FechaNacimiento;

                    Sexo sexo = new Sexo();
                    cliente.Sexo = sexo.Read(x.IdSexo);

                    EstadoCivil estado = new EstadoCivil();
                    cliente.EstadoCivil = estado.Read(x.IdEstado);

                    clientes.Add(cliente);

                }
            }

            return clientes;
        }

        public List<Cliente> ReadAllByEstadoCivil(int idEstado)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (BeLifeEntity bbdd = new BeLifeEntity())
            {

                var resultadoQuery = from c in bbdd.Cliente
                                     where c.IdEstado == idEstado
                                     select c;

                foreach (var x in resultadoQuery)
                {
                    Cliente cliente = new Cliente();
                    cliente.Rut = x.Rut;
                    cliente.Nombres = x.Nombres;
                    cliente.Apellidos = x.Apellidos;
                    cliente.FechaDeNacimiento = x.FechaNacimiento;

                    Sexo sexo = new Sexo();
                    cliente.Sexo = sexo.Read(x.IdSexo);

                    EstadoCivil estado = new EstadoCivil();
                    cliente.EstadoCivil = estado.Read(x.IdEstado);

                    clientes.Add(cliente);

                }
            }

            return clientes;
        }

    }
}
