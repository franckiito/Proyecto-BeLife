using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeLife.Entity;

namespace BeLife.Negocio
{
    public class EstadoCivil
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public EstadoCivil()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla EstadoCivil algun registro que su IdEstadoCivil sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">string Id del Estado Civil</param>
        /// <returns>EstadoCivil estado</returns>
        public EstadoCivil Read(int id)
        {
            EstadoCivil estado = new EstadoCivil();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = (from e in bbdd.EstadoCivil
                                          where e.IdEstado == id
                                          select e).FirstOrDefault();

                    if (resultadoQuery != null)
                    {
                        estado.Id = resultadoQuery.IdEstado;
                        estado.Descripcion = resultadoQuery.Descripcion;
                    }
                    else estado = null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el Estado Civil con Id:{1}, {0}", ex.Message, id);
            }

            return estado;
        }

        /// <summary>
        /// Retorna todos los registros de la tabla EstadoCivil.
        /// </summary>
        /// <returns>List<EstadoCivil></returns>
        public List<EstadoCivil> ReadAll()
        {
            List<EstadoCivil> estados = new List<EstadoCivil>();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = from e in bbdd.EstadoCivil
                                         select e;
                    foreach (var x in resultadoQuery)
                    {
                        EstadoCivil estado = new EstadoCivil();
                        estado.Id = x.IdEstado;
                        estado.Descripcion = x.Descripcion;
                        estados.Add(estado);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar los Estados Civiles, {0}", ex.Message);
            }

            return estados;
        }

    }
}
