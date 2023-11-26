using BodyBuildingLife.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuildingLife.Domain.Entities.Assets
{
    public  class Asset : Auditable
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
