using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Constants
{
    public class ErrorMessages
    {
        public static string ProductNotFound =>  "Product can´t be found";
        public static string ProductsNotFound => "Products can´t be found";

        public static string ProductNotNull => "Product input can´t be empty";
        public static string IdCantBeZero => "Id can´t be empty or zero";

        public static string ProductAdded => "Product has been added";

        public static string ProductDeleted => "Product has been deleted";

        public static string CategoriesNotFound => "Categories can´t be found";

        public static string CategoryNotFound => "Category can´t be found";
    }
}
