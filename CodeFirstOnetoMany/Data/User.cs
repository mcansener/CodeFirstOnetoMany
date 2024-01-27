namespace CodeFirstOnetoMany.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
