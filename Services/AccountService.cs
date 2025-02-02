using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using MyHotelWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MyHotelWebAPI.Controllers;

namespace MyHotelWebAPI.Services
{
    public interface IAccountService
    {
        string GenerateJWT(LoginDto dto);
        void RegisterClient(ClientDto Dto);
        PersonResult GetPersonById(string token, int id);
    }
    public class AccountService : IAccountService
    {
        private readonly MyHotelWebDB _dbContext;
        private readonly IPasswordHasher<Client> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(MyHotelWebDB dbContext, IPasswordHasher<Client> passwordhasher, AuthenticationSettings authenticationSettings1)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordhasher;
            _authenticationSettings = authenticationSettings1;
        }
        public void RegisterClient(ClientDto Dto)
        {
            var newUser = new Client
            {
                Email = Dto.Email,
                Type = Dto.Type,
                Name = Dto.Name,
                Phone = Dto.Phone,
                Address = Dto.Address,
                Postal_Code = Dto.Postal_Code
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, Dto.Password);

            newUser.Password = hashedPassword;
            _dbContext.Clients.Add(newUser);
            _dbContext.SaveChanges();
        }


        public string GenerateJWT(LoginDto dto)
        {
            var user = _dbContext.Clients.FirstOrDefault(x => x.Email == dto.Email);

            if (user is null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Type),
                new Claim("Client_IP", user.Client_ID.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public PersonResult GetPersonById(string token, int id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return new PersonResult
                {
                    IsTokenValid = false,
                    User = null
                };
            }

            token = token.Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);

            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(token))
            {
                return new PersonResult
                {
                    IsTokenValid = false,
                    User = null
                };
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = _authenticationSettings.JwtIssuer,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            ClaimsPrincipal claimsPrincipal;
            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch
            {
                return new PersonResult
                {
                    IsTokenValid = false,
                    User = null
                };
            }

            var person = _dbContext.Clients.FirstOrDefault(c => c.Client_ID == id);

            return new PersonResult
            {
                IsTokenValid = true,
                User = person
            };
        }

    }
}