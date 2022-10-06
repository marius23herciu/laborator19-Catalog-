using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laborator19_Catalog_.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime DateTime { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
