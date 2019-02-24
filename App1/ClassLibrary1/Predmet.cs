using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [Table("Predmety")]
    public class Predmet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nazev { get; set; }
        [OneToMany]
        public List<Znamka> Znamky { get; set; }
    }
}
