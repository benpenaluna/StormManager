namespace StormManager.Standard.Models
{
    public class Member
    {
        public virtual string Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Position { get; set; }
        public virtual string Status { get; set; }
        public virtual string EmailAddress { get; set; }
    }
}
