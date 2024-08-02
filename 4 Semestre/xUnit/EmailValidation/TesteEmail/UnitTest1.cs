using Email;

namespace TesteEmail
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string email = "pedro@gmail.com";

            Assert.True(Email.Email.ValidarEmail(email));
        }
    }
}