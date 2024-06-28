﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Samples.MusicCollection.Api.AllMusic.Abstractions;
using Samples.MusicCollection.Api.AllMusic.Extensions;
using Samples.MusicCollection.Api.Config;

namespace Samples.MusicCollection.Api.AllMusic.Base;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class CommandQueryMicroserviceEndpointsBase<TRequest, TResponse> :
    QueryMicroserviceEndpointsBase<TResponse>, ICommandQueryMicroserviceEndpoints
    where TRequest : notnull
    where TResponse : class
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public ICommandQueryMicroserviceBusinessLogic<TRequest, TResponse> CommandBusinessLogic { get; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="CommandQueryMicroserviceEndpointsBase{TRequest,TResponse}"/>
    /// </summary>
    /// <param name="commandBusinessLogic"></param>
    /// <param name="queryBusinessLogic"></param>
    /// <param name="routes"></param>
    protected CommandQueryMicroserviceEndpointsBase(ICommandQueryMicroserviceBusinessLogic<TRequest, TResponse> commandBusinessLogic,
                                                    IQueryMicroserviceBusinessLogic<TResponse> queryBusinessLogic,
                                                    IOptions<AllMusicRoutes> routes) : base(queryBusinessLogic, routes)
    {
        ArgumentNullException.ThrowIfNull(commandBusinessLogic, nameof(commandBusinessLogic));
        CommandBusinessLogic = commandBusinessLogic;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPost(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            $"/{Route(Routes.Value)}",
            async ([FromBody] TRequest request) => await CommandBusinessLogic.PostAsync(request).ConfigureAwait(false)
        )
        .MapPostConfiguration<TRequest, TResponse>(ApiVersion, Tag);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPut(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            $"/{Route(Routes.Value)}/{{id}}",
            async ([FromRoute] int id, [FromBody] TRequest request) => await CommandBusinessLogic.PutAsync(request).ConfigureAwait(false)
        )
        .MapPutConfiguration<TRequest, TResponse>(ApiVersion, Tag);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDelete(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            $"/{Route(Routes.Value)}/{{id}}",
            async ([FromRoute] int id) => await CommandBusinessLogic.DeleteAsync(id).ConfigureAwait(false)
        )
        .MapDeleteConfiguration(ApiVersion, Tag);
    }

    #endregion
}