using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Customer
    {
        public int Id { get; set; }
        private Guid _guid;
        [Required] public string FName { get; set; }
        [Required] public string LName { get; set; }
        public string? Description { get; set; } 
        public string? Address { get; set; }
        [Required] public DateOnly DateOfBirth { get; set; }
        public double InitialCredit { get; set; } = 0;
        public Account? account { get; set; }

        public void setGuid(Guid guid) 
        {
            _guid = guid;
        }
        public Guid getGuid()
        {
            return _guid;
        }
    }
}
