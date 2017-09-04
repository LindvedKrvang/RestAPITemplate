using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.UnitOfWork;

namespace VideoMenuDAL
{
    public interface IDalFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
