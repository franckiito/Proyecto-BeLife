using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeLife.Negocio
{
    public class Plan
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double PrimaBase { get; set; }
        public string PolizaActual { get; set; }

        public Plan()
        {
            Init();
        }

        private void Init()
        {
            Id = string.Empty;
            Nombre = string.Empty;
            PrimaBase = 0;
            PolizaActual = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Plan algun registro que su IdPlan sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">string Id del Plan</param>
        /// <returns>Plan plan</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Plan pla = bbdd.Plan.Where(x => x.Id == this.Id).FirstOrDefault();
                if (pla != null)
                {
                    CommonBC.Syncronize(pla, this);
                    return true;
                }
                else
                {
                    throw new Exception("El Plan no existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer Plan. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Plan.
        /// </summary>
        /// <returns>List<Plan></returns>
        public List<Plan> ReadAll()
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                List<Entity.Plan> listaDatos = bbdd.Plan.ToList<Entity.Plan>();
                List<Plan> list = SyncList(listaDatos);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Leer Todos los planes. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Sexo></returns>
        private List<Plan> SyncList(List<Entity.Plan> listaDatos)
        {
            try
            {
                List<Plan> list = new List<Plan>();

                foreach (var x in listaDatos)
                {
                    Plan plan = new Plan();
                    CommonBC.Syncronize(x, plan);
                    list.Add(plan);

                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Sincronizar listas. " + ex.Message);
            }
        }

    }
}
