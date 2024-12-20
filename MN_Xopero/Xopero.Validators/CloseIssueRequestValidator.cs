using FluentValidation;
using Xopero.Contracts.Requests;

namespace Xopero.Validators;

public class CloseIssueRequestValidator : AbstractValidator<CloseIssueRequest> 
{
    public CloseIssueRequestValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(request => request.HostingService).NotNull().IsInEnum();
    }
}