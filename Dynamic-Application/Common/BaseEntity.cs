using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Application.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public long IsDeleted { get; set; }
    }
}
