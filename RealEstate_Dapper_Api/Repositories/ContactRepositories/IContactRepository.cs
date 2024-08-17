using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        public Task<List<ResultContactDto>> GetAllContactAsync();
        public Task<List<Last4ContactResultDto>> GetLast4Contact();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);
        //void UpdateContact(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIDContactDto> GetContact(int id);
    }
}
