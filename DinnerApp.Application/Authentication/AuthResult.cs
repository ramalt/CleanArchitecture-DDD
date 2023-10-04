using DinnerApp.Domain.Models.User;

namespace DinnerApp.Application.Services.Authentication;

public record AuthResult(User User, string Token);
