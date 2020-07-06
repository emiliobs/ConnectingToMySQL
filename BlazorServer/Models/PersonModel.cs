using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        public String  FirstName { get; set; }

        public string LastName { get; set; }
    }
}
