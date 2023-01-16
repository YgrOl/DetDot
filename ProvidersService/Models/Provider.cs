namespace ProvidersService.Models
{
    public class Provider
    {
        public int Id {get; set;}

        public string Made {get; set;}

        public string Factory {get; set;}

        public int DetailId {get; set;}

        public Detail Detail {get; set;}
    }
}