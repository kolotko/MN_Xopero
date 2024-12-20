using FluentValidation;
using Xopero.Contracts.Requests;

namespace Xopero.Validators;

public class GetIssueRequestValidator : AbstractValidator<GetIssueRequest> 
{
    public GetIssueRequestValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(request => request.HostingService).NotNull().IsInEnum();
    }
}