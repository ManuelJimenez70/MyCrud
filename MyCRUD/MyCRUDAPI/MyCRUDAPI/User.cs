namespace MyCRUDAPI
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string Estate { get; set; }
        public DateTime StartDate { get; set; }

        public static implicit operator Task<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}
