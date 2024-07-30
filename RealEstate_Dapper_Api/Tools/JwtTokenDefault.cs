namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefault
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhot";
        public const string Key = "REALestate..0145332103045685Asp.NetCore8.0.1+-*/";
        public const int Expire = 20;//  20 dk ayakta kalsın token bunu normalde veri tabanında çekecektide neyse
    }
}
