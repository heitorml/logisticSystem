using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Dto.Dtos
{
    public class AddressDto : BaseProperties
    {
        public string Number { get; set; }
        public string Logradouro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
    }
}
