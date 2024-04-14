using System.ComponentModel.DataAnnotations;

namespace backendCRUD.Models
{
    public class Todo
    {

        [Key]
        public int id { get; set; }
        public string todotitle { get; set; }
        public string todoabout
        {
            get; set;

        }
     }
}

