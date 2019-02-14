using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Predmet
    {
        public string Nazev { get; set; }
        public List<Znamka> Znamky
        {
            get
            {
                if (this.Znamky == null)
                {
                    this.Znamky = new List<Znamka>();
                }

                return this.Znamky;
            }

            set
            {
                this.Znamky = value;
            }
        }
    }
}
