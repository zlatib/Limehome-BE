using HotelsApp.Core.Entities;
using HotelsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsApp.Core.Contracts.Repositories
{
    public interface IPropertiesRepository
    {
        List<PropertyModel> GetProperties(int pageNo=0, int pageSize=25);
        PropertyModel GetProperty(string propertyId, bool includeBookings=false);
        PropertyModel AddProperty(PropertyModel hotel);
        PropertyModel UpdateProperty(PropertyModel hotel);
        void DeleteProperty(string propertyId);
    }
}
