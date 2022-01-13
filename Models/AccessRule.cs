using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XeynergyUser.API.Models
{
    public class AccessRule
    {
        public AccessRule()
        {
            UserGroups = new List<UserGroup>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public bool Permission { get; set; }
        public List<UserGroup> UserGroups { get; set; }

        public virtual List<AccessRule> getUserNameList(bool permission)
        {
            return new List<AccessRule>();
        }
    }
}
