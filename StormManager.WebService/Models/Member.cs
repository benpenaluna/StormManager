namespace StormManager.WebService.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Member
    {
        [StringLength(8)]
        public string Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(320)]
        public string EmailAddress { get; set; }
    }
}
