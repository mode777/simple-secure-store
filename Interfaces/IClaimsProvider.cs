﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleSecureStore.Interfaces
{
    interface IClaimsProvider
    {
        IEnumerable<Claim> GetUserClaims();
    }
}
