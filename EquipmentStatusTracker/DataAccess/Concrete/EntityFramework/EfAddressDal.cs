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
   public class EfAddressDal:EfEntityRepositoryDal<Address>,IAddressDal
    {
        public EfAddressDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<Address>> logger)
            : base(context, logger)
        {
        }
    }
}
