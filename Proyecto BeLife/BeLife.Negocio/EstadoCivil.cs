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

            BeLifeEntity bbdd = new BeLifeEntity();

            Entity.EstadoCivil e = bbdd.EstadoCivil.Where(x => x.IdEstado == id).FirstOrDefault();

            CommonBC.Syncronize(e, estado);

            return estado;
        }

        /// <summary>
        /// Retorna todos los registros de la tabla EstadoCivil.
        /// </summary>
        /// <returns>List<EstadoCivil></returns>
        public List<EstadoCivil> ReadAll()
        {
            BeLifeEntity bbdd = new BeLifeEntity();

            List<Entity.EstadoCivil> Estados = bbdd.EstadoCivil.ToList<Entity.EstadoCivil>();
            List<EstadoCivil> list = SyncList(Estados);

            return list;
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<EstadoCivil></returns>
        private List<EstadoCivil> SyncList(List<Entity.EstadoCivil> listaDatos)
        {
            List<EstadoCivil> list = new List<EstadoCivil>();

            foreach (var x in listaDatos)
            {
                EstadoCivil estadoCivil = new EstadoCivil();
                CommonBC.Syncronize(x, estadoCivil);
                list.Add(estadoCivil);

            }

            return list;
        }
    }
}
