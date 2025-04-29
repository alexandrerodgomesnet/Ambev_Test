using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using Ambev.DeveloperEvaluation.Common.Results;
using Ambev.DeveloperEvaluation.Common.Results.Extensions;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateSaleRequest> _validatorUpdate;
    private readonly IValidator<GetSaleRequest> _validatorGet;
    private readonly IValidator<DeleteSaleRequest> _validatorDelete;
    public SalesController(IMediator mediator, IMapper mapper
        , IValidator<UpdateSaleRequest> validatorUpdate
        , IValidator<GetSaleRequest> validatorGet
        , IValidator<DeleteSaleRequest> validatorDelete
        )
    {
        _mediator = mediator;
        _mapper = mapper;
        _validatorUpdate = validatorUpdate;
        _validatorGet = validatorGet;
        _validatorDelete = validatorDelete;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken) =>
        await Result.Create(request)
            .Map(_mapper.Map<CreateSaleCommand>)
            .TapAsync(cmd => _mediator.Send(cmd, cancellationToken))
            .Map(_mapper.Map<CreateSaleResponse>)
            .Match<CreateSaleResponse, IActionResult>(
                onSuccess: CreateSuccessSale,
                onFailure: FailureSale
            );

    private CreatedResult CreateSuccessSale(CreateSaleResponse response) =>
        Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });

    private BadRequestObjectResult FailureSale(Error[] errors) =>
        BadRequest(new ValidationResultDetail
        {
            IsValid = false,
            Errors = errors.Select(o => new ValidationErrorDetail()
            {
                Error = o.Code,
                Detail = o.Description
            })
        });

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSale([FromRoute] Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        //var validationResult = await _validatorUpdate.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors.Select(o => (ValidationErrorDetail)o));

        var command = _mapper.Map<UpdateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        //await _publisher.SendMessageAsync(response, _routingKey);

        return Ok(new ApiResponseWithData<UpdateSaleResponse>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data = _mapper.Map<UpdateSaleResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        //var validationResult = await _validatorGet.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        //await _publisher.SendMessageAsync(response, _routingKey);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRequest { Id = id };
        //var validationResult = await _validatorDelete.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        var apiResponse = new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        };

        //await _publisher.SendMessageAsync(apiResponse, _routingKey);

        return Ok(apiResponse);
    }
}