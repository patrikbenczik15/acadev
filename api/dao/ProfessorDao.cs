using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace api.dao
{
    public class Professor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;


        // ! review list for professor
        // public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}