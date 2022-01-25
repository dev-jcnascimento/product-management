namespace ProductManagement.Domain.Arguments.User
{
    public class UpdateAdminUserResponse
    {
        public Guid Id { get; set; }
        public string Role { get; set; }

        public static explicit operator UpdateAdminUserResponse(Entities.User entities)
        {
            return new UpdateAdminUserResponse { Id = entities.Id, Role = entities.Role.ToString() };
        }
    }
}

