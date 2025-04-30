using Microsoft.AspNetCore.Identity;

namespace Person_json.Entities
{
    public class Person :IdentityUser
    {
        public int PersonId { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

// reader@gmail.com
// Reader@123


// writer@gmail.com
// Writer@123