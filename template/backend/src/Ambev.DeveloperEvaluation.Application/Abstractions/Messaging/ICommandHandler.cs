using Ambev.DeveloperEvaluation.Common.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

//CommandHandler without use of Result
public interface ICommandHandler<TCommand> 
    : IRequestHandler<TCommand>
    where TCommand : ICommand { }

public interface ICommandHandler<TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> { }

//CommandHandler with use of Result
public interface ICommandResultHandler<TCommand> 
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommandResult { }
public interface ICommandResultHandler<TCommand, TResponse> 
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommandResult<TResponse> { }