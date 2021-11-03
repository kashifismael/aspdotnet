using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Domain
{
    public abstract class DatabaseEntity
    {

        protected string _id;

        protected DatabaseEntity()
        {
        }

        protected DatabaseEntity(string id)
        {
            Id = id;
        }

        public string Id { get => this._id; set => this._id = value; }


    }
}
