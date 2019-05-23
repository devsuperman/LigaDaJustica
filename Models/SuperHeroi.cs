using System.ComponentModel.DataAnnotations;

namespace LigaDaJustica.Models
{
    public class SuperHeroi
	{	
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }	

        [Required, Display(Name = "Super Poder")]
        public string SuperPoder {get; set; }	
    }
}