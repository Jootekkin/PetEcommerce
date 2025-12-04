
using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.DTOs.PetDtos;
using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Service.BaseService
{
    #region Interfaces
    public interface IPetService
    {
        Task<PagedResult<Pet>> GetAllPetsAsync(PetPagedRequest petrequest);
        Task<Pet?> GetPetInfoAsync(Guid petId);
        Task<bool> CreatePetAsync(Pet pet);
        Task<bool> UpdatePetAsync(Pet pet);
        Task<bool> DeletePetAsync(Guid petId);
    }
    #endregion


    #region Implementations
    public class PetService : IPetService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public async Task<PagedResult<Pet>> GetAllPetsAsync(PetPagedRequest petrequest)
        {
            petrequest.ApplyFilters();

            var result = await _unitOfWork.PetsRepository.GetAllAsync(petrequest);

            if (result == null)
            {
                new PagedResult<Pet>()
                {
                    Items = null,
                    TotalCount = 0,
                    PageNumber = petrequest.PageNumber,
                    PageSize = petrequest.PageSize,
                    TotalPages = 0,
                    HasNextPage = false,
                    HasPreviousPage = false
                };
            }
            return result;
        }

        public async Task<Pet?> GetPetInfoAsync(Guid petId)
        {
            var result = await _unitOfWork.PetsRepository.GetByIdAsync(petId);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> CreatePetAsync(Pet pet)
        {
            await _unitOfWork.PetsRepository.AddAsync(pet);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePetAsync(Pet pet)
        {
            await _unitOfWork.PetsRepository.UpdateAsync(pet);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePetAsync(Guid petId)
        {
            await _unitOfWork.PetsRepository.DeleteAsync(petId);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
    #endregion
}
