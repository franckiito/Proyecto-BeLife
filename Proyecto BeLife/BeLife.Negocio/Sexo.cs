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
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Sexo s = bbdd.Sexo.Where(x => x.Id == this.Id).FirstOrDefault();
                if(s != null)
                {
                    CommonBC.Syncronize(s, this);
                    return true;
                }
                else
                {
                    return false;
                    //throw new Exception("El Id : {0}, no existe." + Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer sexo." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Sexo.
        /// </summary>
        /// <returns>List<Sexo></returns>
        public List<Sexo> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.Sexo> listaDatos = bbdd.Sexo.ToList<Entity.Sexo>();
                List<Sexo> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer los sexos. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Sexo></returns>
        private List<Sexo> SyncList(List<Entity.Sexo> listaDatos)
        {
            List<Sexo> list = new List<Sexo>();

            foreach (var x in listaDatos)
            {
                Sexo sexo = new Sexo();
                CommonBC.Syncronize(x, sexo);
                list.Add(sexo);

            }

            return list;
        }
    }
}
