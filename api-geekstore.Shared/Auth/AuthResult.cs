﻿

namespace api_geekstore.Shared.Auth
{
    public class AuthResult
    {
        
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
