using AutoMapper;
using scooters.WebAPI.Models;
using scooters.Services.Models;

namespace scooters.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Pages

        CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse, UserPreviewModel>().ReverseMap();
        
        #endregion

        #region City

        CreateMap<CityModel, CityResponse>().ReverseMap();
        CreateMap<UpdateCityRequest, UpdateCityModel>().ReverseMap();
        CreateMap<CityPreviewModel, CityPreviewResponse>().ReverseMap();
        CreateMap<CityResponse, CityPreviewModel>().ReverseMap();
        
        #endregion

        #region Booking

        CreateMap<BookingModel, BookingResponse>().ReverseMap();
        CreateMap<UpdateBookingRequest, UpdateBookingModel>().ReverseMap();
        CreateMap<BookingPreviewModel, BookingPreviewResponse>().ReverseMap();
        CreateMap<BookingResponse, BookingPreviewModel>().ReverseMap();
        
        #endregion

        #region Penalty

        CreateMap<PenaltyModel, PenaltyResponse>().ReverseMap();
        CreateMap<UpdatePenaltyRequest, UpdatePenaltyModel>().ReverseMap();
        CreateMap<PenaltyPreviewModel, PenaltyPreviewResponse>().ReverseMap();
        CreateMap<PenaltyResponse, PenaltyPreviewModel>().ReverseMap();
        
        #endregion
        #region Scooter

        CreateMap<ScooterModel, ScooterResponse>().ReverseMap();
        CreateMap<UpdateScooterRequest, UpdateScooterModel>().ReverseMap();
        CreateMap<ScooterPreviewModel, ScooterPreviewResponse>().ReverseMap();
        CreateMap<ScooterResponse, ScooterPreviewModel>().ReverseMap();
        
        #endregion

        #region UserPenalty

        CreateMap<UserPenaltyModel, UserPenaltyResponse>().ReverseMap();
        CreateMap<UpdateUserPenaltyRequest, UpdateUserPenaltyModel>().ReverseMap();
        CreateMap<UserPenaltyPreviewModel, UserPenaltyPreviewResponse>().ReverseMap();
        CreateMap<UserPenaltyResponse, UserPenaltyPreviewModel>().ReverseMap();
        
        #endregion

       

        #region Admin

        CreateMap<AdminModel, AdminResponse>().ReverseMap();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
        CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
        CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();
        
        #endregion

    }
}