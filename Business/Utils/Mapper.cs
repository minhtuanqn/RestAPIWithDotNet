using AutoMapper;
using Business.Dto;
using Data.Entity;

namespace Business.Utils
{
    public class Mapper
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentDTO, Department>();
            });
            return configuration.CreateMapper();
        }
    }
}
