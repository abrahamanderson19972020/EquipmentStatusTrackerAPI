using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class SuccessMessages<T> where T : class
    {
        public static string ItemAdded = $"A new {typeof(T).Name} is added";
        public static string ItemUpdated = $"{typeof(T).Name} is updated";
        public static string ItemDeleted = $"{typeof(T).Name} is deleted";
        public static string ItemById = $"{typeof(T).Name} is returned successfully";
        public static string ItemAllListed = $"All {typeof(T).Name}s are listed";
    }
}
