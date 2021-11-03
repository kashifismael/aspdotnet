using AspDotNetStarter.Database;
using AspDotNetStarter.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Services
{
    public class PlayerServiceImpl : AbstractCrudServiceImpl<Player>
    {
        public PlayerServiceImpl(ApiContext dbContext) : base(dbContext)
        {
        }
    }
}
