using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ProvinceSpy
{
    public class ProvinceHistory
    {
        private readonly string provinceName;
        private readonly LinkedList<ProvinceRevision> revisions = new LinkedList<ProvinceRevision>();

        public ProvinceHistory(string provinceName)
        {
            this.provinceName = provinceName;
        }

        public string ProvinceName
        {
            get { return provinceName; }
        }

        public void Add(ProvinceRevision revision)
        {
            revisions.AddLast(revision);
        }
    }
}