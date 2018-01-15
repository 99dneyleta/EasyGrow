using EasyGrow.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using EasyGrow.Data;

namespace EasyGrow.Helpers {

    public class JwtHelper
    { 
        public static ApplicationUser GetUserJwt(string accessToken, PlantContext context)
        {
            accessToken = accessToken.Remove(startIndex: accessToken.IndexOf("Bearer ", StringComparison.Ordinal), count: "Bearer ".Length);

            var handler = new JwtSecurityTokenHandler();
            var decodedJwtToken = handler.ReadJwtToken(accessToken);

            var mail = decodedJwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;
            var user =  context.Users.SingleOrDefault(r => r.Email == mail);

            return user;
        }
    }
}
