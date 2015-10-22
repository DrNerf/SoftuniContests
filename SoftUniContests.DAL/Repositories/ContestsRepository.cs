using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniContests.DAL.Repositories
{
    public class ContestsRepository : GenericRepository<Contest>
    {
        public ContestsRepository(SoftuniContestsEntities context) 
            : base(context)
        {

        }
    }
}
