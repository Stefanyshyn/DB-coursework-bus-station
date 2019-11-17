using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Profile profile { get; set; }
        public DateTime createAt { get; set; }

        public User(int id, string username, string password, string lastName, string firstName, DateTime createAt)
        {
            this.id = id;
            this.username = username.Trim();
            this.password = password.Trim();
            this.profile = new Profile { firstName = firstName.Trim(), lastName = lastName.Trim() };
            this.createAt = createAt;
        }
        public User(int id, string username, string password, DateTime createAt)
        {
            this.id = id;
            this.username = username.Trim();
            this.password = password.Trim();
            this.profile = null;
            this.createAt = createAt;
        }

        public override string ToString()
        {
            return this.id + " " + 
                this.username + " " + 
                (this.profile != null ? this.profile.ToString() + " " : "") 
                + this.createAt.ToString();
        }
    }
}
 