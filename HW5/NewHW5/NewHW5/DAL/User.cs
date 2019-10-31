using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NewHW5.Models;
using System.Data.Entity;

namespace NewHW5.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=OurUserDB)")
        {

        }

        public virtual DBset<User> Users { get; set; }

    }
}