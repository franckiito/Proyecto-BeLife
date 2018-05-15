using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeLife.Entity;

namespace BeLife.Negocio
{
    public class Sexo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Sexo()
        {
            Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Sexo algun registro que su IdSexo sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">string Id del Sexo</param>
        /// <returns>Sexo sexo</returns>
        public Sexo Read(int id)
        {
            Sexo sexo = new Sexo();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = (from s in bbdd.Sexo
                                          where s.IdSexo == id
                                          select s).FirstOrDefault();

                    if (resultadoQuery != null)
                    {
                        sexo.Id = resultadoQuery.IdSexo;
                        sexo.Descripcion = resultadoQuery.Descripcion;
                    }
                    else sexo = null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el Sexo ID:{1} , {0}", ex.Message, id);
            }

            return sexo;
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Sexo.
        /// </summary>
        /// <returns>List<Sexo></returns>
        public List<Sexo> ReadAll()
        {
            List<Sexo> sexos = new List<Sexo>();

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {

                    var resultadoQuery = from s in bbdd.Sexo
                                         select s;

                    foreach (var x in resultadoQuery)
                    {
                        Sexo sexo = new Sexo();
                        sexo.Id = x.IdSexo;
                        sexo.Descripcion = x.Descripcion;
                        sexos.Add(sexo);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar Sexos, {0}", ex.Message);
            }

            return sexos;
        }
    }
}
