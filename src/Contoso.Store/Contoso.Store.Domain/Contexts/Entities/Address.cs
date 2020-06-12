using Contoso.Store.Domain.BaseEntity;
using Contoso.Store.Domain.Contexts.Enums;

namespace Contoso.Store.Domain.Contexts.Entities
{
    public class Address : Entity
    {
        public Address(
            string street,
            int number,
            string complement,
            string district,
            string state,
            string country,
            EAddressType addressType)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            State = state;
            Country = country;
            AddressType = addressType;
        }

        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public EAddressType AddressType { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} {Complement} - {District}/{State}";
        }
    }
}
