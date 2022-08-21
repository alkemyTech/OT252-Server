using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class GenericResponse
    {
        public bool IsSucces { get; set; } = true;
        public string DisplayMessage { get; set; }
        public object Entity { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
