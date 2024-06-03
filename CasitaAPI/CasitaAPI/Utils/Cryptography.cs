namespace CasitaAPI.Utils
{
    public class Cryptography
    {
        public static string GenerateHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool MatchHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
