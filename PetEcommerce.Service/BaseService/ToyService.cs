using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.DTOs.ToyDtos;
using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Service.BaseService
{
    #region Interfaces
    public interface IToyService
    {
        Task<PagedResult<Toy>> GetAllToysAsync(ToyPagedRequest toyRequest);
        Task<Toy?> GetToyInfoAsync(Guid toyId);
        Task<bool> CreateToyAsync(Toy toy);
        Task<bool> UpdateToyAsync(Toy toy);
        Task<bool> DeleteToyAsync(Guid toyId);
    }
    #endregion

    #region Implementations
    public class ToyService : IToyService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public ToyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<PagedResult<Toy>> GetAllToysAsync(ToyPagedRequest toyRequest)
        {
            toyRequest.ApplyFilters();
            var result = await _unitOfWork.ToysRepository.GetAllAsync(toyRequest);
            if (result == null)
            {
                new PagedResult<Toy>()
                {
                    Items = null,
                    TotalCount = 0,
                    PageNumber = toyRequest.PageNumber,
                    PageSize = toyRequest.PageSize,
                    TotalPages = 0,
                    HasNextPage = false,
                    HasPreviousPage = false
                };
            }
            return result;
        }
        public async Task<Toy?> GetToyInfoAsync(Guid toyId)
        {
            var result = await _unitOfWork.ToysRepository.GetByIdAsync(toyId);
            return result;
        }
        public async Task<bool> CreateToyAsync(Toy toy)
        {
            await _unitOfWork.ToysRepository.AddAsync(toy);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateToyAsync(Toy toy)
        {
            await _unitOfWork.ToysRepository.UpdateAsync(toy);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteToyAsync(Guid toyId)
        {

            await _unitOfWork.ToysRepository.DeleteAsync(toyId);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
    #endregion
}
