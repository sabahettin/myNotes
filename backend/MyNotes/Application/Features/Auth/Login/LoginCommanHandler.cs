using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Auth.Login
{
    internal sealed class LoginCommanHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p =>
            p.UserName == request.UserNameOrMail || p.Email == request.UserNameOrMail, cancellationToken);
            if (appUser == null)
            {
                return Result<LoginCommandResponse>.Failure("User not found");
            }

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
            if (!isPasswordCorrect)
            {
                return Result<LoginCommandResponse>.Failure("Password is wrong!");
            }
            string token = jwtProvider.CreateToken(appUser);
            LoginCommandResponse response = new(token);
            return Result<LoginCommandResponse>.Succeed(response);
        }
    }
}
