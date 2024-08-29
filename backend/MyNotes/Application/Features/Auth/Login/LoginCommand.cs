using MediatR;
using TS.Result;

namespace Application.Features.Auth.Login
{
    public sealed record LoginCommand(
        string UserNameOrMail,
        string Password
    ) : IRequest<Result<LoginCommandResponse>>;
}
