using ErrorOr;

namespace InspectionRequestAPI.Feateures.Users;

public static partial class Errors
{
    public static class User{
        public static Error NotFound => Error.NotFound("User.Notfound", "User with given username does not exist");
        public static Error InvalidCredentials => Error.Validation("Auth.Credentials", "Invalid credentials");

        public static Error UserNameTaken => Error.Validation("Username.Taken", "Username is taken");
    }
}