using System.Diagnostics.CodeAnalysis;

namespace TestTaskWebApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [AllowNull]
        public string Name { get; set; }

        [AllowNull]
        public string MobilePhone { get; set; }

        [AllowNull]
        public string JobTitle { get; set; }

        [AllowNull]
        public DateTime BirthDate { get; set; }
    }
}
