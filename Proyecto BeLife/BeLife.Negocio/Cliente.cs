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
        public Sexo Sexo = new Sexo();
        public EstadoCivil EstadoCivil = new EstadoCivil();
        public string Genero
        {
            get { return Sexo.Descripcion; }
        }
        public string Estado
        {
            get { return EstadoCivil.Descripcion; }
        }

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
                BeLifeEntities bbdd = new BeLifeEntities();
                Entity.Cliente cli = new Entity.Cliente();

                //Ve si no existe el cliente para poder crearlo.
                if (!this.Read())
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(this, cli);
                    CommonBC.Syncronize(this.Sexo, cli.Sexo);
                    cli.IdSexo = this.Sexo.Id;
                    CommonBC.Syncronize(this.EstadoCivil, cli.EstadoCivil);
                    cli.IdEstado = this.EstadoCivil.Id;

                    //Guarda los cambios
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

                throw new Exception("Error Crear Cliente. " + ex.Message);
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

            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Cliente cli = bbdd.Cliente.Where(x => x.Rut == this.Rut).FirstOrDefault();

                if (cli != null)
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(cli, this);
                    CommonBC.Syncronize(cli.Sexo, Sexo);
                    CommonBC.Syncronize(cli.EstadoCivil, EstadoCivil);

                    return true;
                }
                else
                {
                    return false;
                    throw new Exception("El Cliente Rut : " + Rut + "  no existe." );
                }
            }
            catch (Exception ex )
            {

                throw new Exception("Error Read Cliente. " + ex.Message);
            }
            

            
        }

        public bool Update()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                //Trae un cliente.
                Entity.Cliente cli = bbdd.Cliente.Where(x => x.Rut == this.Rut).FirstOrDefault();
                if (cli != null)
                {
                    //sincroniza la clase de negocio con la entidad de BD.
                    CommonBC.Syncronize(this,cli);
                    cli.IdSexo = this.Sexo.Id;
                    cli.IdEstado = this.EstadoCivil.Id;

                    //Modifica los cambios.
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("El cliente no existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Actualizar Cliente. " + ex.Message);
            }
        }

        public bool Delete()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Contrato contrato = bbdd.Contrato.Where(con => con.RutCliente == Rut).FirstOrDefault();
                if(contrato == null)
                {
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
                        throw new Exception("El cliente no existe.");
                    }
                }
                else
                {
                    throw new Exception("El cliente tiene un contrato asociado.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete Cliente. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Cliente.
        /// </summary>
        /// <returns>List<Cliente></returns>
        public List<Cliente> ReadAll()
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();

                List<Entity.Cliente> listaDatos = bbdd.Cliente.ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer los Clientes. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Cliente></returns>
        private List<Cliente> SyncList(List<Entity.Cliente> listaDatos)
        {
            List<Cliente> list = new List<Cliente>();

            try
            {
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
                        throw new Exception("Error al leer el Estado.");
                    }

                    list.Add(cliente);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Sincronizar Lista. " + ex.Message);
            }

            return list;
        }


        /// <summary>
        /// Retorna los clientes con el Sexo que sea igual al parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Cliente> ReadAllBySexo(int id)
        {

            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Sexo.Id == id).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllBySexo. " + ex.Message);
            }
            

        }

        /// <summary>
        /// Retorna los clientes con el estado civil que sea igual al parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Cliente> ReadAllByEstadoCivil(int id)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.EstadoCivil.Id == id).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna una lista de los clientes que tengan el mismo rut del parametro.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public List<Cliente> ReadAll(string rut)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Rut == rut).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna una lista de todos los clientes que tengan el mismo rut y sexo que los parametros
        /// </summary>
        /// <param name="idSexo"></param>
        /// <param name="rut"></param>
        /// <returns></returns>
        public List<Cliente> ReadAllRutSexo(string rut, int idSexo  )
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Rut == rut).ToList<Entity.Cliente>();
                listaC = listaC.Where(cli => cli.IdSexo == idSexo ).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

        //
        public List<Cliente> ReadAllRutEstado(string rut, int idEstado)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Rut == rut).ToList<Entity.Cliente>();
                listaC = listaC.Where(cli => cli.IdEstado == idEstado).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna una lista de todos los clientes que tengan el mismo Rut, Sexo y Estado que los parametros
        /// </summary>
        /// <param name="idSexo"></param>
        /// <param name="idEstado"></param>
        /// <param name="rut"></param>
        /// <returns></returns>
        public List<Cliente> ReadAll(string rut, int idSexo, int idEstado)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.Rut == rut).ToList<Entity.Cliente>();
                listaC = listaC.Where(cli => cli.IdSexo == idSexo).ToList<Entity.Cliente>();
                listaC = listaC.Where(cli => cli.IdEstado == idEstado).ToList<Entity.Cliente>();
                
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna una lista de todos los Clientes con el mismo Sexo y Estado que los parametros.
        /// </summary>
        /// <param name="idSexo"></param>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        public List<Cliente> ReadAll(int idSexo, int idEstado)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Cliente> listaC = bbdd.Cliente.Where(cli => cli.IdSexo == idSexo).ToList<Entity.Cliente>();
                listaC = listaC.Where(cli => cli.IdEstado == idEstado).ToList<Entity.Cliente>();
                List<Cliente> list = SyncList(listaC);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ReadAllByEstadoCivil. " + ex.Message);
            }
        }

    }
}
