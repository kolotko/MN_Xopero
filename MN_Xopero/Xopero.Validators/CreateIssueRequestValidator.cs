using FluentValidation;
using Xopero.Contracts.Requests;

namespace Xopero.Validators;

public class CreateIssueRequestValidator : AbstractValidator<CreateIssueRequest> 
{
    public CreateIssueRequestValidator()
    {
        RuleFor(request => request.HostingService).NotNull().IsInEnum();
        RuleFor(request => request.Title).NotEmpty();
        RuleFor(request => request.Body).NotEmpty();
    }
}