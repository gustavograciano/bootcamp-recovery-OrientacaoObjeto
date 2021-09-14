using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoOO
{
    class ValidationUtil<T>
    {
        public bool isValid(T data)
        {
            var result = false;

            if(data is string && data != null)
            {
                Console.WriteLine("String valida");
                result = true;
            }else if (data is int && data != null)
            {
                Console.WriteLine("Int valido");
                result = true;
            }
            else if (data is bool && data != null)
            {
                Console.WriteLine("Bool valido");
                result = true;
            }

            return result;
        }
    }
}
