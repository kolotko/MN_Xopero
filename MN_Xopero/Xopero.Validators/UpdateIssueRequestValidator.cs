using FluentValidation;
using Xopero.Contracts.Requests;

namespace Xopero.Validators;

public class UpdateIssueRequestValidator : AbstractValidator<UpdateIssueRequest> 
{
    public UpdateIssueRequestValidator()
    {
        RuleFor(request => request.HostingService).NotNull().IsInEnum();
        RuleFor(request => request.Id).NotNull();
        RuleFor(request => request.Title).NotEmpty();
        RuleFor(request => request.Body).NotEmpty();
    }
}