using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public abstract class Entity
    {
        //contains the events that will be dispatched by the entity
        private readonly List<IDomainEvent> _domainEvents = new();

        //property that returns the events
        public List<IDomainEvent> DomainEvents => _domainEvents.ToList();

        //unique identifier for the entity
        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity()
        { }

        //method that adds an event to the list
        public void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}