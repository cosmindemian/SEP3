﻿using System.Collections.Generic;
using System.Threading.Tasks;
using gateway.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Client.Interfaces
{
    public interface ILocationService
    {
        Task<SendLocationReturnDto> CreateLocation(CreateLocationDto dto, string token);
        Task<IEnumerable<GetPickUpPointDto>> GetAllPickupPoints();
        Task DeletePickupPoint(long id, string token);
    }
}