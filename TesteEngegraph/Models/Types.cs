using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteEngegraph.Models
{
    public class Types
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Types()
        {
        }

        public Types(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
