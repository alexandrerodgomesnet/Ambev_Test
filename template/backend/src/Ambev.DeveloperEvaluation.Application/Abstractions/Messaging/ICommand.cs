using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

public interface ICommand : IRequest { }
public interface ICommand<TRequest> : IRequest<TRequest> { }