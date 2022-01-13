using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XeynergyUser.API.Models
{
    public class User: Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public int AttachedCustomer { get; set; }

    }
}
 