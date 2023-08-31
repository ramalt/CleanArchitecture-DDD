using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Services.Authentication;

public record AuthResult(User user, string Token);
