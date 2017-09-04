using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UnitOfWork;

namespace VideoMenuDAL
{
    public class DalFacade : IDalFacade
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkMemory(new InMemoryContext());
    }
}
