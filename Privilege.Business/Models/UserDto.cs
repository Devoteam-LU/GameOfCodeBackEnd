using System.Collections.Generic;

namespace Privilege.Business.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Interests { get; set; }

        public int CreditScore { get; set; }
        public double Apy { get; set; }
    }
}