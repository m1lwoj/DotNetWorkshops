﻿namespace NorthwindAPI.Auth
{
    public interface IAuthService
    {
        bool Authenticate(string login, string password);
        string GenerateSecurityToken(string email, string password);
    }
}