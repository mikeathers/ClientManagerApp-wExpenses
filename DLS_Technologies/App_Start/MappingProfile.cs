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
        public MappingProfile()
        {
            CreateMap<ExpenseForm, ExpenseFormDto>().ForMember(e => e.Id, opt => opt.Ignore());
            CreateMap<ExpenseFormDto, ExpenseForm>().ForMember(e => e.Id, opt => opt.Ignore());
        }
    }
}