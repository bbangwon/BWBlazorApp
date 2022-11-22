using MachineApp.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineApp.Models
{
    [Table("MachinesMedias")]
    public class MachineMedia : AuditableBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int MediaId { get; set; }
    }
}
