using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XeynergyUser.API.Models
{
    public class UserGroup
    {
        public UserGroup()
        {
            Users=new List<User>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        [ForeignKey("RuleId")]
        public int RuleId { get; set; }
        public string GroupName { get; set; }

        public List<User> Users { get; set; }
        public AccessRule AccessRule { get; set; }
    }
}
