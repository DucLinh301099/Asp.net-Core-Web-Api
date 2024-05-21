namespace asp.net_web_api.Models
{
    public class productVM
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }   

    }
    public class product : productVM
    {
        public Guid Id { get; set; }
    }
}
