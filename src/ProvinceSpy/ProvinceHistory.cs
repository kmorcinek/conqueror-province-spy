using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProvinceSpy
{
    public class ProvinceHistory
    {
        private readonly string provinceName;
        private readonly List<ProvinceRevision> revisions = new List<ProvinceRevision>();

        public ProvinceHistory(string provinceName)
        {
            this.provinceName = provinceName;
        }

        public string ProvinceName
        {
            get { return provinceName; }
        }

        public ReadOnlyCollection<ProvinceRevision> Revisions
        {
            get
            {
                return new ReadOnlyCollection<ProvinceRevision>(revisions);
            }
        }

        public void Add(ProvinceRevision revision)
        {
            revisions.Add(revision);
        }
    }
}