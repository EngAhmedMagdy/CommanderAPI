using System.ComponentModel.DataAnnotations;

namespace Commander.Data
{
    public class CommanderCreateDto {

        public string Line {get;set;}
        public string HowTo {get;set;}

        public string Platform {get;set;}

       
    }
}