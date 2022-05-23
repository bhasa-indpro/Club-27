using AutoMapper;
using Club_27.Models;
using Club_27.ViewModels;

namespace Club_27.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Enrollment, EnrollmentViewModelAutoMapper>().ReverseMap();
        }
    }
}
