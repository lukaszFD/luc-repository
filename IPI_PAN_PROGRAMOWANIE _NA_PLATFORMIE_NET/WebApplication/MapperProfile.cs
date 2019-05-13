using AuthDatabase.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TodoItemViewModel, ToDoItemDTO>().ReverseMap();
        }
    }
}
