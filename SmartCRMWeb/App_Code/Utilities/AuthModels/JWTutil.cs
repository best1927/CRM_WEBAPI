using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jose;
using AuthModels;
/// <summary>
/// Summary description for JWTutil
/// </summary>
public class JWTutil
{
    public JWTutil()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    private static  byte[] Base64UrlDecode(string arg) // This function is for decoding string to   

    {
        string s = arg;
        s = s.Replace('-', '+'); // 62nd char of encoding  
        s = s.Replace('_', '/'); // 63rd char of encoding  
        switch (s.Length % 4) // Pad with trailing '='s  
        {
            case 0: break; // No pad chars in this case  
            case 2: s += "=="; break; // Two pad chars  
            case 3: s += "="; break; // One pad char  
            default:
                throw new System.Exception(
            "Illegal base64url string!");
        }
        return Convert.FromBase64String(s); // Standard base64 decoder  
    }
    private static  long ToUnixTime(DateTime dateTime)
    {
        return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }
    public static  string GetJwt(string user, string pass) //function for JWT Token  
    {
        byte[] secretKey = Base64UrlDecode(configKey.secretKey);//pass key to secure and decode it  
        DateTime issued = DateTime.Now;
        var User = new Dictionary<string, object>()
                    {
                        {"user", user},
                        {"pass", pass},

                         {"iat", ToUnixTime(issued).ToString()}
                    };

        string token = JWT.Encode(User, secretKey, JwsAlgorithm.HS256);



        return token;
    }

    public static  string VerifyJWT(string authenToken) //function for JWT Token  
    {
        byte[] secretKey = Base64UrlDecode(configKey.secretKey);//pass key to secure and decode it  
        string token = string.Empty;
        try
        {
            token = JWT.Decode(authenToken, secretKey, JwsAlgorithm.HS256);
        }
        catch (Exception e)
        {

            throw new UnauthorizedAccessException("invid token", e);
        }


        return token;
    }
}