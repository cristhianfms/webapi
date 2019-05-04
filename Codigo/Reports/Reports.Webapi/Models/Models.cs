using System.Collections.Generic;
using System.Linq;

namespace Reports.Webapi.Models
{
    public abstract class Model<E, M>
        where E : class
        where M : Model<E, M>, new()
    {
        public static IEnumerable<M> ToModel(IEnumerable<E> entities)
        {
            IEnumerable<M> models = entities.Select(x => ToModel(x));
            return models;
        }

        public static M ToModel(E entity)
        {
            if (entity == null) return null;
            return new M().SetModel(entity);
        }

        public static IEnumerable<E> ToEntity(IEnumerable<M> models)
        {
            IEnumerable<E> entities = models.Select(x => ToEntity(x));
            return entities;
        }

        public static E ToEntity(M model)
        {
            if (model == null) return null;
            return model.ToEntity();
        }

        public abstract E ToEntity();

        protected abstract M SetModel(E entity);
    }
}