using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Services
{
    public interface ICrudService<T>
    {
        public List<T> GetAll();

        public T getOneById(string id);

        public T create(T t);

        public T update(T t);

        public bool delete(string id);
    }
}
