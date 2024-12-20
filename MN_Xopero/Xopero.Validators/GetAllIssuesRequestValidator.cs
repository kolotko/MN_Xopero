using FluentValidation;
using Xopero.Contracts.Requests;

namespace Xopero.Validators;

public class GetAllIssuesRequestValidator : AbstractValidator<GetAllIssuesRequest> 
{
    public GetAllIssuesRequestValidator()
    {
        RuleFor(request => request.HostingService).NotNull().IsInEnum();
    }
}