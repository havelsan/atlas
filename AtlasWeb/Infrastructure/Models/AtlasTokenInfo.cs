using System;

namespace Infrastructure.Models
{
    public class AtlasTokenInfo
    {
        public Guid UserId { get; set; }
        public Guid TokenIdentifier { get; set; }
    }
}
