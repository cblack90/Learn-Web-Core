using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Models
{
    public class LoggedInUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }

        //need to build a LINQ query to get this information.

        //Also need to figure out how to add the company information to the user info programatically.  UI would add into an admin page.

        //have to create a new table for Company information?
    }
}
