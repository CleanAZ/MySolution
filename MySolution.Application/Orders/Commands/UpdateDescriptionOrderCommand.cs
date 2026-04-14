using MediatR;
namespace MySolution.Application.Command;
public record UpdateDescriptionOrderCommand (string description,Guid id):IRequest<string>;