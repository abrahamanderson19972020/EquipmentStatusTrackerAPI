using DataAccess.Abstract;
using DataAccess.DatabaseContexts;
using Entities.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGpsPositionDal : EfEntityRepositoryDal<GpsPosition>, IGpsPositionDal
    {
        public EfGpsPositionDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<GpsPosition>> logger)
            : base(context, logger)
        {
        }
    }
}
