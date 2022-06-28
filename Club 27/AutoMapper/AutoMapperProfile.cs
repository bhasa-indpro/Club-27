using AutoMapper;
using Club_27.Models;
using Club_27.ViewModels;

namespace Club_27.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Enrollment, EnrollmentViewModelAutoMapper>()
                .ForMember(d => d.EmployeeName, s => s.MapFrom(src => src.Employee.EmployeeName))
                //.ForMember(d => d.ActivityName, s => s.MapFrom(src => string.Join(", ",src.Activity.ActivityName.ToList().Select(x=>x)) ))
                .ForMember(d => d.ActivityName, s => s.MapFrom(src => src.Activity.ActivityName))
                .ReverseMap();
        }
    }
}
