using AutoMapper;
using DLS_Technologies.Dtos.ExpenseDtos;
using DLS_Technologies.Models.ExpensesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLS_Technologies.App_Start
{
    public class MappingProfile : Profile
    {
        /// AutoMapper profile. DTO - Data Transfer Object.
        // Maps a class to a DTO and adds ignore options for the ID.
        // Using a DTO is safer as you are not directly working with a domain model object.         
        // Keep DTOs small and lightweight. 

        public MappingProfile()
        {
            CreateMap<ExpenseForm, ExpenseFormDto>().ForMember(e => e.Id, opt => opt.Ignore());
            CreateMap<ExpenseFormDto, ExpenseForm>().ForMember(e => e.Id, opt => opt.Ignore());
        }
    }
}