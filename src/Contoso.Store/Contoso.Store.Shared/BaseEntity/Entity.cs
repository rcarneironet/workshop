using FluentValidator;
using System;

namespace Contoso.Store.Shared.BaseEntity
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
