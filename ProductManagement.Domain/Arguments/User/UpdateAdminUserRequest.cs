namespace ProductManagement.Domain.Arguments.User
{
    public class UpdateAdminUserRequest
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
