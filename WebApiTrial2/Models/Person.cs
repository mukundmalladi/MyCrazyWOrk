using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTrial2.Models
{
    [Table("Person")]//, Schema = "AdventureWorks2012")]
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        [Required]
        public string PersonType { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

       
    }
}