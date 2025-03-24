using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.CreateSale.Sales;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sale operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSaleRequest> _validatorCreate;
    private readonly IValidator<GetSaleRequest> _validatorGet;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper
    , IValidator<CreateSaleRequest> validatorCreate
    , IValidator<GetSaleRequest> validatorGet
        )
    {
        _mediator = mediator;
        _mapper = mapper;
        _validatorCreate = validatorCreate;
        _validatorGet = validatorGet;
    }

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validatorCreate.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(o => (ValidationErrorDetail)o));

        var command = _mapper.Map<CreateSaleCommand>(request); 
        command.MakeDiscount();       
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    // /// <summary>
    // /// Retrieves a user by their ID
    // /// </summary>
    // /// <param name="id">The unique identifier of the user</param>
    // /// <param name="cancellationToken">Cancellation token</param>
    // /// <returns>The user details if found</returns>
    // [HttpGet("{id}")]
    // [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> GetUser([FromRoute] Guid id, CancellationToken cancellationToken)
    // {
    //     var request = new GetUserRequest { Id = id };
    //     var validator = new GetUserRequestValidator();
    //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //     if (!validationResult.IsValid)
    //         return BadRequest(validationResult.Errors);

    //     var command = _mapper.Map<GetUserCommand>(request.Id);
    //     var response = await _mediator.Send(command, cancellationToken);

    //     return Ok(new ApiResponseWithData<GetUserResponse>
    //     {
    //         Success = true,
    //         Message = "User retrieved successfully",
    //         Data = _mapper.Map<GetUserResponse>(response)
    //     });
    // }

    // /// <summary>
    // /// Deletes a user by their ID
    // /// </summary>
    // /// <param name="id">The unique identifier of the user to delete</param>
    // /// <param name="cancellationToken">Cancellation token</param>
    // /// <returns>Success response if the user was deleted</returns>
    // [HttpDelete("{id}")]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    // {
    //     var request = new DeleteUserRequest { Id = id };
    //     var validator = new DeleteUserRequestValidator();
    //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //     if (!validationResult.IsValid)
    //         return BadRequest(validationResult.Errors);

    //     var command = _mapper.Map<DeleteUserCommand>(request.Id);
    //     await _mediator.Send(command, cancellationToken);

    //     return Ok(new ApiResponse
    //     {
    //         Success = true,
    //         Message = "User deleted successfully"
    //     });
    // }
}
