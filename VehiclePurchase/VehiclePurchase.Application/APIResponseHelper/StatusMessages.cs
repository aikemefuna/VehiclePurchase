namespace VehiclePurchase.Application.APIResponseHelper
{
    public static class StatusMessage
    {
        public static class Vehicle
        {

            public const string RegistrationNumberAlreadyExisit = "There is already a vehicle with same registration number provided";
            public const string InvalidModelId = "Bad Request - Invalid Vehicle Model.";
            public const string InValidMakeId = "Bad Request - Invalid Vehicle Make.";
            public const string InValidBodyTypeId = "Bad Request - Invalid Vehicle Body Type.";
            public const string AddedSuccessfully = "Vehicle created successfully";
            public const string AddNotSuccessful = "Vehicle not created";

        }
        public static class VehicleBodyType
        {

            public const string TypeAlreadyExists = "There is already a type with same value as provided";

            public const string AddedSuccessfully = "Vehicle Body Type created successfully";
            public const string AddNotSuccessful = "Vehicle Body Type not created";

        }
        public static class VehicleMakeResponse
        {

            public const string MakeAlreadyExists = "There is already a make with same value as provided";

            public const string AddedSuccessfully = "Vehicle Make created successfully";
            public const string AddNotSuccessful = "Vehicle Make not created";

        }
        public static class VehicleModelResponse
        {

            public const string MakeAlreadyExists = "There is already a model with same value as provided";

            public const string AddedSuccessfully = "Vehicle model created successfully";
            public const string AddNotSuccessful = "Vehicle model not created";

        }
        public static class ThirdPartyPurchasesResponse
        {

            public const string InvalidVehicleId = "Bad Request - Invalid Vehicle.";
            public const string AddedSuccessfully = "Purchase created successfully";
            public const string AddNotSuccessful = "Purchase not created";
        }

    }
}
