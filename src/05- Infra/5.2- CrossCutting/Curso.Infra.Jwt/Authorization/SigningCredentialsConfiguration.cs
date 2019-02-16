using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Curso.Infra.Jwt.Authorization
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "curso_camadas123";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}