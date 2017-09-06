using joindernoteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joindernoteService.Services
{
    public interface ITokenService
    {
        Token CreateToken(Usuario usuario);
        string DecodingToken(string token);
        bool SaveToken(Token token);
    }
}