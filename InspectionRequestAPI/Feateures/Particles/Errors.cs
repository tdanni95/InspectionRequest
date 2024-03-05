using ErrorOr;

namespace InspectionRequestAPI.Feateures.Particles;

public static partial class Errors
{
    public static class Particles{
        public static Error FailedToCreate => Error.Failure("Particlecreate.Failed", "Failed to create particle");
        public static Error NameTaken => Error.Conflict("Particlecreate.NameTaken", "Particle name is taken");

        public static Error NotFOund => Error.NotFound("Particle.NotFound", "Particle with given id not found");
    }
}