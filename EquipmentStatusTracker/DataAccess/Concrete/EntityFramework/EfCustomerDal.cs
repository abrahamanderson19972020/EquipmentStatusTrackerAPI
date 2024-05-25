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
    public class EfCustomerDal : EfEntityRepositoryDal<Customer>, ICustomerDal
    {
        public EfCustomerDal(ApplicationDBContext context, ILogger<EfEntityRepositoryDal<Customer>> logger)
            : base(context, logger)
        {
        }
    }
}
