using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningMVC.Models
{
    public class UserList
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
    }
}