using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniContests.DAL.Repositories
{
    public class PicturesRepository : GenericRepository<Picture>
    {
        public PicturesRepository(SoftuniContestsEntities context)
            : base(context)
        {

        }
    }
}
