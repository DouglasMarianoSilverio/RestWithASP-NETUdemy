namespace RestWithASPNETUdemy.Models
{
    public class Person
    {
        public long? Id { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Address  { get; set; }
        //todo - use enum
        public string Gender { get; set; }
    }
}
