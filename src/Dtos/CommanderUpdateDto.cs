using System.ComponentModel.DataAnnotations;

namespace Commander.Data
{
    public class CommanderUpdateDto {

        [Required]
        public string Line {get;set;}

        [Required]
        public string HowTo {get;set;}

        [Required]
        public string Platform {get;set;}

       
    }
}