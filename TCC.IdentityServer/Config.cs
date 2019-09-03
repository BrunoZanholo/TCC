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
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "tcc-front-end",
                    ClientName = "TCC Front-End",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,

                    RedirectUris = { "http://localhost:5001/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "website"
                    }
                }
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