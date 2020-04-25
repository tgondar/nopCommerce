using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Models;

namespace Nop.Plugin.Appointment.Scheduler.Infrastructure.Mapper
{
    public class MapperConfiguration : Profile, IOrderedMapperProfile
    {
        public MapperConfiguration()
        {
            CreateAppointmentMaps();
        }

        protected virtual void CreateAppointmentMaps()
        {
            CreateMap<TekAppointment, AppointmentModel>()
                .ForMember(model => model.CreatedOn, options => options.Ignore());

            CreateMap<AppointmentModel, TekAppointment>()
                .ForMember(entity => entity.CreatedOnUtc, options => options.Ignore());
        }

        public int Order => 1;
    }
}
