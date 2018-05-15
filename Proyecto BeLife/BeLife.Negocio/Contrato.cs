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

        public void Create()
        {

        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

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

        public void ReadAllByNumeroContrato()
        {

        }

        public void ReadAllByRut()
        {

        }

        public void ReadAllByPoliza()
        {

        }

    }
}
