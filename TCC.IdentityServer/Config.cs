using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace TCC.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("tcc_auth", "TCC.Auth")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // Hybrid Flow = OpenId Connect + OAuth
                // To use both Identity and Access Tokens
                new Client
                {
                    ClientId = "tcc_auth_client",
                    ClientName = "Fiver.Security.AuthServer.Client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowOfflineAccess = true,
                    RequireConsent = false,

                    RedirectUris = { "http://localhost:3001/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:3001/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "tcc_auth"
                    },
                },              
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "administrador",
                    Password = "administrador",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Bruno Administrador"),
                        new Claim(JwtClaimTypes.Role, "administrador"),
                        new Claim(JwtClaimTypes.GivenName, "Bruno Zanholo"),
                        new Claim(JwtClaimTypes.Email, "administrador@tcc.com.br"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "gerente",
                    Password = "gerente",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Maria Gerente"),
                        new Claim(JwtClaimTypes.Role, "gerente"),
                        new Claim(JwtClaimTypes.GivenName, "Maria"),
                        new Claim(JwtClaimTypes.Email, "gerente@tcc.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "engenheiro",
                    Password = "engenheiro",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "João Engenheiro"),
                        new Claim(JwtClaimTypes.Role, "engenheiro"),
                        new Claim(JwtClaimTypes.GivenName, "João"),
                        new Claim(JwtClaimTypes.Email, "engenheiro@tcc.com")
                    }
                } ,
                new TestUser
                {
                    SubjectId = "3",
                    Username = "juridico",
                    Password = "juridico",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Alberto Juridico"),
                        new Claim(JwtClaimTypes.Role, "juridico"),
                        new Claim(JwtClaimTypes.GivenName, "Alberto"),
                        new Claim(JwtClaimTypes.Email, "juridico@tcc.com")
                    }
                }
            };
        }
    }
}