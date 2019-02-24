using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    [Table("Znamky")]
    public class Znamka
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        [MaxLength(1)]
        public int znamka { get; set; }
        [MaxLength(3)]
        public int Vaha { get; set; }
        [ForeignKey(typeof(Predmet))]
        public int PredmetID { get; set; }
    }
}
