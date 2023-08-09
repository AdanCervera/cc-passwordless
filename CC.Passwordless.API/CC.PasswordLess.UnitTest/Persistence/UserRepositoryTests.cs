using CC.Passwordless.API.Persistence.Implementation;
using CC.Passwordless.API.Persistence.Abstractions;
using CC.Passwordless.Exceptions.Authentication;

namespace CC.PasswordLess.UnitTest.Percistence
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task IsEmailExists_ValidEmail_ReturnsTrue()
        {            
            IUserRepository userRepository = new UserRepository();
            var result = await userRepository.isEmailExists("adan.cervera@gmail.com");
            Assert.True(result);
        }

        [Fact]
        public async Task IsEmailExists_InvalidEmail_ReturnsFalse()
        {
            IUserRepository userRepository = new UserRepository();
            var result = await userRepository.isEmailExists("invalid@gmail.com");
            Assert.False(result);
        }

        [Fact]
        public async Task IsEmailExists_NullEmail_ThrowsNoEmailFoundException()
        {
            IUserRepository userRepository = new UserRepository();
            await Assert.ThrowsAsync<NoEmailFoundException>(() => userRepository.isEmailExists(null));
        }
    }
}
