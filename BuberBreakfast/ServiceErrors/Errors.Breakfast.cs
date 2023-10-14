using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error InvalidName => Error.Validation(
            code: "breakfast.InvalidName",
            description: $"Breakfast name must be atleast {Models.Breakfast.MIN_NAME_LENGTH} long and at most {Models.Breakfast.MAX_NAME_LENGTH} long!s"
        );

        public static Error InvalidDescription => Error.Validation(
           code: "breakfast.InvalidDescription",
           description: $"Breakfast description must be atleast {Models.Breakfast.MIN_NAME_LENGTH} long and at most {Models.Breakfast.MAX_NAME_LENGTH} long!"
       );

        public static Error NotFound => Error.NotFound(
            code: "breakfast.NotFound",
            description: "Breakfast not found!"
        );
    }
}