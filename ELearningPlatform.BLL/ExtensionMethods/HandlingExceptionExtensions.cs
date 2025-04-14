using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.ExtensionMethods
{
    public static class HandlingExceptionExtensions
    {
        public static void CheckForException<T>(this int id, object model)
        {
            if(model == null)
            {
                throw new Exception($"{typeof(T).Name} of {id} is not found");
            }
        }
    }
}
