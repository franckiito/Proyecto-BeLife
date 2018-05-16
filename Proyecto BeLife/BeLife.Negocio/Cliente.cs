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

        /// <summary>
        /// Crea un registro de Cliente en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            bool crea = false;

            if (!this.Read()){
                BeLifeEntity bbdd = new BeLifeEntity();
                Entity.Cliente cli  = new Entity.Cliente();
                try
                {
                    //Sincroniza datos y guarda los cambios
                    CommonBC.Syncronize(this, cli);
                    bbdd.Cliente.Add(cli);
                    bbdd.SaveChanges();
                    crea = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR!!! " + ex.Message);

                }
            }
            else{
                throw new Exception("El cliente ya existe.");
            }

            return crea;
        }

        /// <summary>
        /// Buscar un cliente por el parametro rut en la tabla Cliente.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool Read()
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                Entity.Cliente cli = bbdd.Cliente.Where(x => x.Rut == this.Rut).FirstOrDefault();

                if (cli != null)
                {
                    CommonBC.Syncronize(cli, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            
        }

        public bool Update()
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                //trae el contrato con el mismo numero de contrato
                Entity.Cliente cli = bbdd.Cliente.Where(x => x.Rut == this.Rut).FirstOrDefault();
                if (cli != null)
                {
                    //sincroniza la clase de la aplicacion con la entidad de BD y modifica los cambios
                    CommonBC.Syncronize(this,cli);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete()
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                //trae el contrato con el mismo numero de contrato
                Entity.Cliente cli = bbdd.Cliente.Where(x => x.Rut == this.Rut).FirstOrDefault();
                if (cli != null)
                {
                    //sincroniza la clase de la aplicacion con la entidad de BD y modifica los cambios
                    bbdd.Cliente.Remove(cli);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Cliente.
        /// </summary>
        /// <returns>List<Cliente></returns>
        public List<Cliente> ReadAll()
        {
            BeLifeEntity bbdd = new BeLifeEntity();

            List<Entity.Cliente> listaDatos = bbdd.Cliente.ToList<Entity.Cliente>();
            List<Cliente> list = SyncList(listaDatos);

            return list;
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Cliente></returns>
        private List<Cliente> SyncList(List<Entity.Cliente> listaDatos)
        {
            List<Cliente> list = new List<Cliente>();

            foreach (var x in listaDatos)
            {
                Cliente cliente = new Cliente();
                CommonBC.Syncronize(x, cliente);
                list.Add(cliente);

            }

            return list;
        }



        public List<Cliente> ReadAllBySexo(int id)
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Sexo.IdSexo == id).ToList<Entity.Cliente>();
            List<Cliente> list = SyncList(listaC);
            return list;

        }

        public List<Cliente> ReadAllByEstadoCivil(int id)
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.EstadoCivil.IdEstado == id).ToList<Entity.Cliente>();
            List<Cliente> list = SyncList(listaC);
            return list;
        }


        /*

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
        */

    }
}
