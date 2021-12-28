using AutoMapper;
using ContactsAPI.Contracts;
using ContactsAPI.Models;

namespace ContactsAPI.Mapping
{
    public class RequestToDomainProfile : Profile
    {

        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
