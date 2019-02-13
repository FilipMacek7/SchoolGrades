using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class Znamka
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        [MaxLength(1)]
        public int znamka { get; set; }
        [MaxLength(3)]
        public int Vaha { get; set; }
    }
}
