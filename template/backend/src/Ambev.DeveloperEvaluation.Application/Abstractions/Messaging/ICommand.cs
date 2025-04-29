using Ambev.DeveloperEvaluation.Common.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

//Command without use of Result
public interface ICommand : IRequest { }
public interface ICommand<TResponse> : IRequest<TResponse> { }

//Command with use of Result
public interface ICommandResult : IRequest<Result> { }
public interface ICommandResult<TResponse> : IRequest<Result<TResponse>> { }