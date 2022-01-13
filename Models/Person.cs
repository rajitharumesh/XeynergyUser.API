using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XeynergyUser.API.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public StringBuilder getFullName()
        {
            StringBuilder sb = new StringBuilder();
            var result = sb.Append(FirstName + " " + LastName);
            return result;
        }
    }
}
