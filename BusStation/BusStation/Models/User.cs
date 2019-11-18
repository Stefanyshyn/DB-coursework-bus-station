using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public DateTime CreateAt { get; set; }

        public User(int id, string username, string password, string lastName, string firstName, DateTime createAt)
        {
            this.Id = id;
            this.Username = username.Trim();
            this.Password = password.Trim();
            this.Profile = new Profile { FirstName = firstName.Trim(), LastName = lastName.Trim() };
            this.CreateAt = createAt;
        }
        public User(int id, string username, string password, DateTime createAt)
        {
            this.Id = id;
            this.Username = username.Trim();
            this.Password = password.Trim();
            this.Profile = null;
            this.CreateAt = createAt;
        }

        public override string ToString()
        {
            return this.Id + " " + 
                this.Username + " " + 
                (this.Profile != null ? this.Profile.ToString() + " " : "") 
                + this.CreateAt.ToString();
        }
    }
}
 