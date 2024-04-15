using System.ComponentModel.DataAnnotations;

namespace backendCRUD.Models
{
    public class Todo
    {
        // The [Key] attribute designates the 'id' property as the entity's primary key.
        [Key]
        public int id { get; set; }

        // The todo item's title is represented by the 'todotitle' property.
        public string todotitle { get; set; }

        // The todo item's description is represented by the 'todoabout' property.
        public string todoabout
        {
            get; set;

        }
     }
}

