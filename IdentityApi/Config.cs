// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;

using System.Collections.Generic;

namespace IdentityApi
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            {
                 new ApiResource("coreapi", "E-commerce API",new List<string> {"role"})
             };
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                 // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "spa",
                   // ClientSecrets = { new Secret("secret".Sha256()) },
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,

                    // // where to redirect to after login
                     RedirectUris = { "http://localhost:4200" },

                    // // where to redirect to after logout
                    // PostLogoutRedirectUris = { "http://localhost:5001/connect/endsession" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        "coreapi"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    //Access token life time in seconds
                    AccessTokenLifetime = 1800,
                    IdentityTokenLifetime = 1800,
                    //AllowOfflineAccess = false
                }
            };
        
    }
}