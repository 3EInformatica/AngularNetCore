using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Models
{
    internal record BaseTabella
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedUser { get; set; }
    }
}
