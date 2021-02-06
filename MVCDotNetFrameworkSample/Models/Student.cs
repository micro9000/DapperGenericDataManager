using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDotNetFrameworkSample.Models
{
    [Table("AreasDepts")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string StdNum { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pswd { get; set; }


        // If you need to add additional property, that don't exist in your table
        // just use this two attributes [Write(false)] and [Computed]
        //[Write(false)]
        //[Computed]
        //public bool OtherProperty
        //{
        //    get;
        //    set;
        //}
    }
}