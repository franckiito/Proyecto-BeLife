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
        public DateTime FechaNacimiento { get; set; }
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
            FechaNacimiento = DateTime.Today;
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

            try
            {
                if (!Read())
                {

                    BeLifeEntity bbdd = new BeLifeEntity();
                    Entity.Cliente cli = new Entity.Cliente();

                    //Sincroniza datos y guarda los cambios
                    CommonBC.Syncronize(this, cli);
                    CommonBC.Syncronize(this.Sexo, cli.Sexo);
                    cli.IdSexo = this.Sexo.Id;
                    CommonBC.Syncronize(this.EstadoCivil, cli.EstadoCivil);
                    cli.IdEstado = this.EstadoCivil.Id;
                    bbdd.Cliente.Add(cli);
                    bbdd.SaveChanges();
                    crea = true;

                }
                else
                {
                    throw new Exception("El cliente ya existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error. " + ex.Message);
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
                    throw new Exception("El cliente ya existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error. " + ex.Message);
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

                Sexo sexo = new Sexo();
                sexo.Id = x.IdSexo;
                if (sexo.Read())
                {
                    cliente.Sexo = sexo;
                }
                else
                {
                    throw new Exception("Error al leer el sexo.");
                }

                EstadoCivil estado = new EstadoCivil();
                estado.Id = x.IdEstado;
                if (estado.Read())
                {
                    cliente.EstadoCivil = estado;
                }
                else
                {
                    throw new Exception("Error al leer el sexo.");
                }

                list.Add(cliente);

            }

            return list;
        }



        public List<Cliente> ReadAllBySexo(int id)
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Sexo.Id == id).ToList<Entity.Cliente>();
            List<Cliente> list = SyncList(listaC);
            return list;

        }

        public List<Cliente> ReadAllByEstadoCivil(int id)
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.EstadoCivil.Id == id).ToList<Entity.Cliente>();
            List<Cliente> list = SyncList(listaC);
            return list;
        }

    }
}
