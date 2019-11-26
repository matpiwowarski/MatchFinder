using System;
using System.Collections.Generic;
using System.Text;

namespace MatchFinder.Tables
{
  public class RegUserTable
    {
        //Making New Folder for Register and Login Table
        //initializing Register and user table
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
    }
}
