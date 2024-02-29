using ErrorOr;
using FluentValidation;
using InspectionRequestAPI.Common.Models;
using InspectionRequestAPI.Entities;
using InspectionRequestAPI.Infrastructure.Persistence;
using MediatR;

namespace InspectionRequestAPI.Feateures.Users.Register;

public record RegisterCommand(string ForName, string SurName, string Login, string Password, string Email, string PhoneNumber) : IRequest<ErrorOr<Created>>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(u => u.ForName).NotEmpty();
        RuleFor(u => u.SurName).NotEmpty();
        RuleFor(u => u.Login).Matches("^[a-zA-Z0-9_]*$").WithMessage("Login can only contain letters, numbers, and underscores.");
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Email).NotEmpty();
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<Created>>
{
    private readonly InspectionRequestDbContext _dbContext;

    public RegisterCommandHandler(InspectionRequestDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ErrorOr<Created>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var User = new User
        {
            Id = Guid.NewGuid(),
            ForName = request.ForName,
            SurName = request.SurName,
            Login = request.Login,
            Password = request.Password,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        User.DomainEvents.Add(new UserRegisteredDomainEvent(User));

        _dbContext.users.Add(User);
        await _dbContext.SaveChangesAsync();

        return Result.Created;
    }

    public class UserRegisteredDomainEvent : DomainEvent
    {
        public User User { get; }
        public UserRegisteredDomainEvent(User user)
        {
            User = user;
        }
    }

    public class UserRegisteredDomainEventHandler : INotificationHandler<DomainEventNotification<UserRegisteredDomainEvent>>
    {
        private readonly ILogger<UserRegisteredDomainEventHandler> _logger;

        public UserRegisteredDomainEventHandler(ILogger<UserRegisteredDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<UserRegisteredDomainEvent> notification, CancellationToken cancellationToken)
        {   
            _logger.LogInformation($"User registered: {notification.DomainEvent.User.ForName} {notification.DomainEvent.User.SurName}\nUsername: {notification.DomainEvent.User.Login}");
            return Task.CompletedTask;
        }
    }
}
