using FluentValidator;
using System;

namespace Contoso.Store.Domain.BaseEntity
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
