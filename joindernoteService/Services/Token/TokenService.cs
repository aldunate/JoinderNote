using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using joindernoteData;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace joindernoteService.Services
{
    public class TokenService : ITokenService
    {
        private JoinderNoteDb db = new JoinderNoteDb();
        private string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public Token CreateToken(Usuario usuario)
        {
            var today = DateTime.Now;
            var payload = new Dictionary<string, object>
            {
                { "sub", usuario.Id },
                { "iat", today },
                { "exp", today.AddDays(1) }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var tokenString = encoder.Encode(payload, secret);
            Token token = new Token();
            token.Nombre = tokenString;
            token.FechaCrea = today;
            token.FechaExp = today.AddDays(1);
            return token;
        }

        // Verifica
        public string DecodingToken(string token)
        {          
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer(); 
                 IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                return json;
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return  "Token has invalid signature";
            }

        }


        public bool SaveToken(Token token)
        {
            
            try
            {
                db.Token.Add(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            
        }


        /*
        Custom JSON serializer

        By default JSON serialization is done by JsonNetSerializer implemented using Json.Net. To configure a different one first implement the IJsonSerializer interface:

        public class CustomJsonSerializer : IJsonSerializer
        {
            public string Serialize(object obj)
            {
                // Implement using favorite JSON Serializer
            }

            public T Deserialize<T>(string json)
            {
                // Implement using favorite JSON Serializer
            }
        }
        And then pass this serializer as a dependency to JwtEncoder constructor:

        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        IJsonSerializer serializer = new CustomJsonSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

        */



    }
    }


