namespace PetEcommerce.Domain.BaseRoute
{
    public class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;


        public static class Pets
        {
            public const string GetAllPets = Base + "/pets";
            public const string GetPetById = Base + "/pets/{petId}";
            public const string CreatePet = Base + "/pets/CreatePet";
            public const string UpdatePet = Base + "/pets/UpdatePet";
            public const string DeletePet = Base + "/pets/DeletePet/{petId}";
        }

        public static class Toys
        {
            public const string GetAllToys = Base + "/Toys";
            public const string GetPetById = Base + "/Toys/{ToyId}";
            public const string CreateToy = Base + "/Toys/CreateToy";
            public const string UpdateToy = Base + "/Toys/UpdateToy";
            public const string DeleteToy = Base + "/Toys/DeleteToy/{ToyId}";
        }


    }
}
