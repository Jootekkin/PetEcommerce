using PetEcommerce.Domain.UploadedFiles;

namespace PetEcommerce.Domain.DTOs.PetDtos
{
    public class PetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? BreedName { get; set; } // e.g., Labrador, Siamese
        public string? SpeciesName { get; set; } // e.g., Dog, Cat
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<UploadedFileInfo> uploadedFiles { get; set; } = new List<UploadedFileInfo>();
    }
}
