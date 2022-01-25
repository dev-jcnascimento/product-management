using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.User;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Extensions;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Domain.Interface.IServices;
using ProductManagement.Domain.ValueObject;

namespace ProductManagement.Domain.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public AuthenticateUserResponse Authenticate(AuthenticateUserRequest request)
        {
            User user = _repositoryUser.GetBy(x => x.Email.Webmail == request.Email && x.Password.Word == request.Password.ConvertToMD5());  

            return (AuthenticateUserResponse)user;
        }
        public CreateUserResponse Create(CreateUserRequest request)
        {
            var name = new Name(request.FistName, request.LastName);
            var email = new Email(request.Email);
            var password = new Password(request.Password);

            var user = new User(name, email, password);
            var response = _repositoryUser.Create(user);
            _repositoryUser.Save();
            return (CreateUserResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            var user = _repositoryUser.GetById(id);
            if (user == null)
                return null;
             _repositoryUser.Delete(user);
            return new ResponseBase();
        }

        public IEnumerable<UserResponse> List()
        {
            return _repositoryUser.List().ToList().Select(x => (UserResponse)x).ToList();
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            User user = _repositoryUser.GetById(request.Id);
            if (user == null) return new UpdateUserResponse();

            var name = new Name(request.FistName, request.LastName);
            var email = new Email(request.Email);

            user.UpdateUser(name, email);
            var response = _repositoryUser.Update(user);
            _repositoryUser.Save();
            return (UpdateUserResponse)response;
        }

        public UpdateAdminUserResponse UpdateAdmin(Guid id,string role)
        {
            User user = _repositoryUser.GetById(id);
            if (user == null) return new UpdateAdminUserResponse();

            user.UpdateRole(role);
            var response = _repositoryUser.Update(user);
            _repositoryUser.Save();
            return (UpdateAdminUserResponse)response;
        }

        public UserResponse GetById(Guid id)
        {
           var user = _repositoryUser.GetById(id);
            if (user == null) return null;
            return (UserResponse)user;
        }
    }
}
