﻿using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - retorna byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte byte array para string   
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
                }

                return builder.ToString();
            }
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName",email),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,                         // Claims aqui
                notBefore: DateTime.Now,        // Data de início da validade
                expires: DateTime.Now.AddHours(8), // Expiração
                signingCredentials: credentials // Credenciais
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
