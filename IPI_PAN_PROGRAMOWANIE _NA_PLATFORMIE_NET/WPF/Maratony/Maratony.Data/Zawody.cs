using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maratony.Data
{
    public class Zawody
    {
        private static long nextId = 0;

        public Zawody()
        {
            this.ID = System.Threading.Interlocked.Increment(ref nextId);
            Biegacze = new List<Biegacz>();

        }
        public string Miejsce { get; set; }

        public DateTime Data { get; set; }

        public double Dystans { get; set; }

        public long ID { get; set; }

        public List<Biegacz> Biegacze { get; set; }
    }
}
