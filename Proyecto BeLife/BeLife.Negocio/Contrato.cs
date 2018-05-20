using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Contrato
    {
        public string Numero { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }

        //Relacion de composicion con la Clase Cliente.
        public Cliente Titular = new Cliente();

        public string NombreCliente
        {
            get
            {
                string _nom = Titular.Nombres + " " + Titular.Apellidos;
                return _nom;
            }
        }

        //Relacion de composicion con la Clase Plan.
        public Plan PlanAsociado = new Plan();

        public string Poliza
        {
            get
            {
                return PlanAsociado.PolizaActual;
            }
        } 
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia{ get; set; }
        public bool EstaVigente { get; set; }
        public bool ConDeclaracionDeSalud { get; set; }
        public double PrimaAnual { get; set; }
        public double PrimaMensual { get; set; }
        public string Observaciones { get; set; }

        //Relacion de dependencia: no forma parte de la clase, es utilizada para hacer alguna de sus operaciones
        public void Tarificador()
        {
            Tarificador tarificador = new Tarificador();
            tarificador.CalcularPrima();
        }

        public Contrato()
        {
            Init();
        }

        private void Init()
        {
            Numero = DateTime.Now.ToString("YYYYMMDDHHmmSS");
            Creacion = DateTime.Today;
            Termino = DateTime.Today.AddYears(1);
            Titular = new Cliente();
            PlanAsociado = new Plan();
            //Poliza = string.Empty;
            InicioVigencia = DateTime.Today;
            FinVigencia = DateTime.Today;
            EstaVigente = true;
            ConDeclaracionDeSalud = false;
            PrimaAnual = 0;
            PrimaMensual = 0;
            Observaciones = string.Empty;
        }
        /// <summary>
        /// Agrega el objeto en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //Connexion a la base de datos
            BeLifeEntities bbdd = new BeLifeEntities();
            if (!this.Read())
            {
                try
                {
                    //sincronizacion de los datos, desde negocio a BD
                    Entity.Contrato con = new Entity.Contrato();
                    CommonBC.Syncronize(this, con);
                    CommonBC.Syncronize(this.Titular, con.Cliente);
                    con.RutCliente = this.Titular.Rut;
                    CommonBC.Syncronize(this.PlanAsociado, con.Plan);
                    con.CodigoPlan = this.PlanAsociado.Id;
                    

                    //agrega el contrato a DB y guarda los cambios
                    bbdd.Contrato.Add(con);
                    bbdd.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR!!! " + ex.Message);

                }           }
            else
            {
                throw new Exception("El contrato ya existe.");

            }
            

        }
        /// <summary>
        /// Busca el contrato con el mismo numero de la clase
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                //busca en la BD el contrato por numero
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.Numero).FirstOrDefault();
                if(con != null)
                {
                    //pasa los datos desde la entidad extraidad desde la BD a la clase de la aplicacion
                    CommonBC.Syncronize(con, this);
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
        /// Actualiza el registro contrato.
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                //trae el contrato con el mismo numero de contrato
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.Numero).FirstOrDefault();
                if (con != null)
                {
                    //sincroniza la clase de la aplicacion con la entidad de BD y modifica los cambios
                    CommonBC.Syncronize(this, con);
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
        /// Elimina un registro de la tabla contrato.
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                //trae el contrato con el mismo numero de contrato de la clase
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.Numero).FirstOrDefault();
                if (con != null)
                {
                    //elimina el contrato de la BD y guarda los cambios
                    bbdd.Contrato.Remove(con);
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
        /// Retorna todos los registros de la tabla Contrato.
        /// </summary>
        /// <returns>List<Sexo></returns>
        public List<Contrato> ReadAll()
        {
            try
            {
                List<Contrato> contrato = new List<Contrato>();
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.ToList<Entity.Contrato>();


                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar todos los Contratos. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Sexo></returns>
        private List<Contrato> SyncList(List<Entity.Contrato> listaDatos)
        {
            try
            {
                List<Contrato> list = new List<Contrato>();

                foreach (var x in listaDatos)
                {
                    Contrato contrato = new Contrato();
                    CommonBC.Syncronize(x, contrato);

                    //Asigna las propiedades del cliente a Titular.
                    Cliente cliente = new Cliente();
                    cliente.Rut = x.RutCliente;
                    if (cliente.Read())
                    {
                        contrato.Titular = cliente;
                    }
                    else
                    {
                        throw new Exception("Error al leer el Cliente.");
                    }

                    //Asigna las propiedades del Plan a PlanAsociado.
                    Plan plan = new Plan();
                    plan.Id = x.CodigoPlan;
                    if (plan.Read())
                    {
                        contrato.PlanAsociado = plan;
                    }
                    else
                    {
                        throw new Exception("Error al leer el Plan.");
                    }

                    list.Add(contrato);

                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al sincronizar listas. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo numero contrato que el parametro
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByNumeroContrato(string num)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Numero == num).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByNumeroContrato. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo RutCliente que el parametro
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByRutCliente(string rut)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.RutCliente == rut).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByRut. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan la misma Poliza que el parametro
        /// </summary>
        /// <param name="pol"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByPoliza(string pol)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Plan.PolizaActual == pol).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByPoliza. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo numero de contrato, rut cliente y Poliza que los parametros
        /// </summary>
        /// <param name="num"></param>
        /// <param name="rut"></param>
        /// <param name="pol"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByAll(string num, string rut, string pol)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Numero == num).ToList<Entity.Contrato>();
                listaDatos = listaDatos.Where(x => x.RutCliente == rut).ToList<Entity.Contrato>();
                listaDatos = listaDatos.Where(x => x.Plan.PolizaActual == pol).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByAll. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo numero de contrato y rut cliente que los parametros.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="rut"></param>
        /// <param name="pol"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByNumByRut(string num, string rut)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Numero == num).ToList<Entity.Contrato>();
                listaDatos = listaDatos.Where(x => x.RutCliente == rut).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByNumByRut. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo numero de contrato y Poliza que los parametros.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="pol"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByNumByPol(string num, string pol)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Numero == num).ToList<Entity.Contrato>();
                listaDatos = listaDatos.Where(x => x.Plan.PolizaActual == pol).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByNumByPol. " + ex);
            }
        }

        /// <summary>
        /// Retorna una lista con los contratos que tengan el mismo Rut Cliente y Poliza que los parametros.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="pol"></param>
        /// <returns></returns>
        public List<Contrato> ReadAllByRutByPol(string rut, string pol)
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.RutCliente == rut).ToList<Entity.Contrato>();
                listaDatos = listaDatos.Where(x => x.Plan.PolizaActual == pol).ToList<Entity.Contrato>();
                List<Contrato> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ReadAllByRutByPol. " + ex);
            }
        }
    }
}
