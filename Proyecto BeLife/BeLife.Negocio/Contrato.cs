using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class Contrato
    {
        public string NumeroContrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public Cliente Titular { get; set; }
        public Plan PlanAsociado { get; set; }
        public string Poliza { get; set; } 
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia{ get; set; }
        public bool EstaVigente { get; set; }
        public bool ConDeclaracionDeSalud { get; set; }
        public double PrimaAnual { get; set; }
        public double PrimaMensual { get; set; }
        public string Observaciones { get; set; }

        public Contrato()
        {
            Init();
        }

        private void Init()
        {
            NumeroContrato = string.Empty;
            Creacion = DateTime.Today;
            Termino = DateTime.Today;
            Titular = new Cliente();
            PlanAsociado = new Plan();
            Poliza = string.Empty;
            InicioVigencia = DateTime.Today;
            FinVigencia = DateTime.Today;
            EstaVigente = false;
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
            BeLifeEntity bbdd = new BeLifeEntity();
            if (!this.Read())
            {
                try
                {
                    //sincronizacion de los datos, desde negocio a BD
                    Entity.Contrato con = new Entity.Contrato();
                    CommonBC.Syncronize(this, con);
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
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                //busca en la BD el contrato por numero
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.NumeroContrato).FirstOrDefault();
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

        public bool Update()
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                //trae el contrato con el mismo numero de contrato
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.NumeroContrato).FirstOrDefault();
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

        public bool Delete()
        {
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                //trae el contrato con el mismo numero de contrato de la clase
                Entity.Contrato con = bbdd.Contrato.Where(x => x.Numero == this.NumeroContrato).FirstOrDefault();
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
        /// Retorna todos los registros de la tabla Sexo.
        /// </summary>
        /// <returns>List<Sexo></returns>
        public List<Contrato> ReadAll()
        {
            List<Contrato> contrato = new List<Contrato>();
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Contrato> listaDatos = bbdd.Contrato.ToList<Entity.Contrato>();
            List<Contrato> list = SyncList(listaDatos);            
            return list;
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Sexo></returns>
        private List<Contrato> SyncList(List<Entity.Contrato> listaDatos)
        {
            List<Contrato> list = new List<Contrato>();

            foreach (var x in listaDatos)
            {
                Contrato contrato = new Contrato();
                CommonBC.Syncronize(x, contrato);
                list.Add(contrato);

            }

            return list;
        }

        public List<Contrato> ReadAllByNumeroContrato(string num)
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x=> x.Numero == num).ToList<Entity.Contrato>();
            List<Contrato> list = SyncList(listaDatos);
            return list;
        }

        public List<Contrato> ReadAllByRut(string rut)
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x=> x.RutCliente == rut).ToList<Entity.Contrato>();
            List<Contrato> list = SyncList(listaDatos);
            return list;
        }

        public List<Contrato> ReadAllByPoliza(string pol)
        {
            
            BeLifeEntity bbdd = new BeLifeEntity();
            List<Entity.Contrato> listaDatos = bbdd.Contrato.Where(x => x.Plan.PolizaActual == pol).ToList<Entity.Contrato>();
            List<Contrato> list = SyncList(listaDatos);
            return list;
        }

    }
}
