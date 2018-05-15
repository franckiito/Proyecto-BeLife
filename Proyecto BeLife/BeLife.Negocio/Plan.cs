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
        public Plan Read(string id)
        {
            Plan plan = new Plan();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = (from p in bbdd.Plan
                                          where p.IdPlan == id
                                          select p).FirstOrDefault();

                    if (resultadoQuery != null)
                    {
                        plan.Id = resultadoQuery.IdPlan;
                        plan.Nombre = resultadoQuery.Nombre;
                        plan.PrimaBase = resultadoQuery.PrimaBase;
                        plan.PolizaActual = resultadoQuery.PolizaActual;
                    }
                    else plan = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el Plan ID:{1} , {0}", ex.Message, id);
            }

            return plan;
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Plan.
        /// </summary>
        /// <returns>List<Plan></returns>
        public List<Plan> ReadAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = from p in bbdd.Plan
                                         select p;

                    foreach (var x in resultadoQuery)
                    {
                        Plan plan = new Plan();
                        plan.Id = x.IdPlan;
                        plan.Nombre = x.Nombre;
                        plan.PrimaBase = x.PrimaBase;
                        plan.PolizaActual = x.PolizaActual;
                        planes.Add(plan);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar los Planes, {0}", ex.Message);
            }

            return planes;
        }

    }
}
