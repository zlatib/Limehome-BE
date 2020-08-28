namespace HotelsApp.Infrastructure.HereMap
{
    using HotelsApp.Infrastructure.HereMap.ContactsModels;

    public class PropertyLocationModel
    {
        public AddressModel Address { get; set; }

        public decimal[] Position { get; set; }
    }
}