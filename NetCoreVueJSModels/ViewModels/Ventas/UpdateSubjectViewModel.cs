using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSModels.ViewModels.Ventas
{
    public class UpdateSubjectViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MyProperty { get; set; }
        public string Email { get; set; }
        public string SubjectType { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
