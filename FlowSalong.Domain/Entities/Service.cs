using System;

namespace FlowSalong.Domain.Entities
{
    public class Service
    {
        // 🔑 Byt till Guid så att det matchar repository och handlers
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
