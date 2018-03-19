using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.DTO
{
    public class ApiToken
    {
        public string Id { get; set; }

        public DateTimeOffset ExpiredTime { get; set; }
    }
}
