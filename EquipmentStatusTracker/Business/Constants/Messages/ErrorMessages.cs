using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class ErrorMessages<T> where T : class
    {
        public static string NoItemFound = $"No {typeof(T).Name} is found";
        public static string NoValidItem= $" {typeof(T).Name} is invalid";
        public static string NoAddedItem = $" {typeof(T).Name} is not added";
        public static string NoUpdatedItem = $" {typeof(T).Name} is not updated";
        public static string NoDeletedItem = $" {typeof(T).Name} is not deleted";
        public static string UnexpectedError = $"An error occurred while retrieving {typeof(T).Name}";
    }
}
