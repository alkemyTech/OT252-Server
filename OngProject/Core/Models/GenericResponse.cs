using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class GenericResponse
    {
        public string Message { get; set; }
        public object Entity { get; set; }
    }
}
