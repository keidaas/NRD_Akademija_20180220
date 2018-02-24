﻿using akademija.Application.main.employee.dto;
using akademija.Application.main.inventory.dto;
using akademija.Application.main.inventoryType.dto;
using akademija.EF.entities;
using AutoMapper;
using System.Linq;

namespace akademija.Application.automapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Inventory, opt => opt.MapFrom(x => x.EmployeeInventory.Select(y => y.Inventory).ToList()));
            CreateMap<Inventory, InventoryViewDto>();
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryType, InventoryTypeDto>();

        }
    }
}
