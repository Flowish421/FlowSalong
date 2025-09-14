using System;

namespace FlowSalong.Domain.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
