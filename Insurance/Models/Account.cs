namespace Insurance.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Balance { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateExpiration => DateCreation.AddYears(1);
        public char Status { get; set; }//Account status; S=Suspended, A=Active
    }
}
