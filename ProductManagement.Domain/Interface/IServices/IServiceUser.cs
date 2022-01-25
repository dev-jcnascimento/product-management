using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.User;

namespace ProductManagement.Domain.Interface.IServices
{
    public interface IServiceUser
    {
        AuthenticateUserResponse Authenticate(AuthenticateUserRequest request);
        CreateUserResponse Create(CreateUserRequest request);
        UpdateUserResponse Update(UpdateUserRequest request);
        UpdateAdminUserResponse UpdateAdmin(Guid id, string role);
        UserResponse GetById(Guid id);
        IEnumerable<UserResponse> List();
        ResponseBase Delete(Guid id);
    }
}
