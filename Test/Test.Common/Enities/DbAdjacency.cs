using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Enities
{
    public class DbAdjacency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StartId { get; set; }

        [ForeignKey("StartId")]
        public virtual Node Start { get; set; }

        [Required]
        public int StopId { get; set; }

        [ForeignKey("StopId")]
        public virtual Node Stop { get; set; }
    }
}
