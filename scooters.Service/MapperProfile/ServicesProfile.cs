using AutoMapper;
using scooters.Entities.Models;
using scooters.Services.Models;

namespace scooters.Services.MapperProfile;

public class ServicesProfile : Profile
{
public ServicesProfile()
{
#region Users


CreateMap<User, UserModel>().ReverseMap();
CreateMap<User, UserPreviewModel>()
.ForMember(x => x.Number, y => y.MapFrom(u => u.Number))
.ForMember(x => x.FirstName, y => y.MapFrom(u => u.FirstName))
.ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
.ForMember(x => x.DateOfBirth, y => y.MapFrom(u => u.DateOfBirth))
.ForMember(x => x.Is_bloked, y => y.MapFrom(u => u.Is_bloked));


#endregion

#region Admin


CreateMap<Admin, AdminModel>().ReverseMap();
CreateMap<Admin, AdminPreviewModel>()
.ForMember(x => x.Login, y => y.MapFrom(u => u.Login));

#endregion

#region Booking

CreateMap<Booking, BookingModel>().ReverseMap();
CreateMap<Booking, BookingPreviewModel>()
.ForMember(x => x.TimeOfBooking, y => y.MapFrom(u => u.TimeOfBooking))
.ForMember(x => x.TimeOfStart, y => y.MapFrom(u => u.TimeOfStart))
.ForMember(x => x.TimeOfFinish, y => y.MapFrom(u => u.TimeOfFinish));

#endregion
#region City

CreateMap<City, CityModel>().ReverseMap();
CreateMap<City, CityPreviewModel>()
.ForMember(x => x.Name, y => y.MapFrom(u => u.Name));

#endregion

#region Penalty

CreateMap<Penalty, PenaltyModel>().ReverseMap();
CreateMap<Penalty, PenaltyPreviewModel>()
.ForMember(x => x.TypePenalty, y => y.MapFrom(u => u.TypePenalty))
.ForMember(x => x.AmountPenalty, y => y.MapFrom(u => u.AmountPenalty));


#endregion

#region Scooter

CreateMap<Scooter, ScooterModel>().ReverseMap();
CreateMap<Scooter, ScooterPreviewModel>()
.ForMember(x => x.Address, y => y.MapFrom(u => u.Address))
.ForMember(x => x.IsBooking, y => y.MapFrom(u => u.IsBooking))
.ForMember(x => x.Price, y => y.MapFrom(u => u.Price));


#endregion

#region UserPenalty

CreateMap<UserPenalty, UserPenaltyModel>().ReverseMap();
CreateMap<UserPenalty, UserPenaltyPreviewModel>()
.ForMember(x => x.IsPaidFor, y => y.MapFrom(u => u.IsPaidFor));


#endregion
}
}