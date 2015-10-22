using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniContests.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private SoftuniContestsEntities context = new SoftuniContestsEntities();

        private ContestsRepository contestsRepository;

        public ContestsRepository ContestsRepository
        {
            get
            {
                if (contestsRepository == null)
                {
                    contestsRepository = new ContestsRepository(context);
                }
                return contestsRepository;
            }
        }

        private PicturesRepository picturesRepository;

        public PicturesRepository PicturesRepository
        {
            get
            {
                if (picturesRepository == null)
                {
                    picturesRepository = new PicturesRepository(context);
                }
                return picturesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
