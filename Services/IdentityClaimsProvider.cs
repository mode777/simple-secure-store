using SimpleSecureStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SimpleSecureStore.Services
{
    public class IdentityClaimsProvider : IClaimsProvider
    {
        private readonly ClaimsIdentity _identity;

        public IdentityClaimsProvider(ClaimsIdentity identity)
        {
            _identity = identity;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return _identity.Claims;
        }
    }
}
