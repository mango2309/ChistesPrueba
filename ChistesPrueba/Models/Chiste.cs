using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChistesPrueba.Models
{
    public class Chiste
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Texto { get; set; }

    }
}
