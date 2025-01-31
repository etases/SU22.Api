﻿using System.Security.Cryptography;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CP.Api.Services;

public static class Hasher
{
    // See: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-2.2

    public static string GenerateSalt()
    {
        // generate a 128-bit salt using a secure PRNG
        byte[] salt = new byte[128 / 8];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return Convert.ToBase64String(salt);
    }

    public static string HashPassword(string strSalt, string password)
    {
        byte[] salt = Convert.FromBase64String(strSalt);

        // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA1,
            10000,
            256 / 8));

        return hashed;
    }
}