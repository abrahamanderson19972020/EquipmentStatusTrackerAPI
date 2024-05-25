using Business.ResponseModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<IDataResult<List<T>>> BusinessGetAllAsync();
        Task<IDataResult<T>> BusinessGetByIdAsync(int id);
        Task<IResult> BusinessAddAsync(T entity);
        Task<IResult> BusinessUpdateAsync(T entity);
        Task<IResult> BusinessDeleteAsync(T entity);
    }
}
