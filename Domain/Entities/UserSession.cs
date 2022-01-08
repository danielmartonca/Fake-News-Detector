using Domain.Common;
using System;

namespace Domain.Entities
{
    public class UserSession : BaseEntity
    {
        public string Username { get; set; }
        public Guid SessionId { get; set; }

    }
}
