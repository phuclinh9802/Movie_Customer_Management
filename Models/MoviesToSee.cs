using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class MoviesToSee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string DateAdded { get; set; }

        [Required]
        public byte NumberInStock { get; set; }


        public GenresType GenresType { get; set; }
        
        //FK
        public int GenresTypeId { get; set; }
    }
}