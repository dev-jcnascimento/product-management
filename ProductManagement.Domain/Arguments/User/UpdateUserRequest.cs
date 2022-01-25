namespace ProductManagement.Domain.Arguments.User
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
