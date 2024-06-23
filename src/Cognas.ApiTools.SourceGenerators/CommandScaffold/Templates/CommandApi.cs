﻿using Cognas.ApiTools.BusinessLogic;
using Cognas.ApiTools.Mapping;
using Cognas.ApiTools.MinimalApi;
using Cognas.ApiTools.Shared;
using Model = {0};
using Request = {1};
using Response = {2};

namespace {3}.v{4};

/// <summary>
/// Auto generated by decoration using <see cref="Cognas.ApiTools.SourceGenerators.Attributes.CommandScaffoldAttribute"/>.
/// </summary>
#nullable enable
public sealed partial class {5}CommandApi : CommandApiBase<Model, Request, Response>
{{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public override int ApiVersion => {4};

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="{5}CommandApi"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="commandMappingService"></param>
    /// <param name="queryMappingService"></param>
    /// <param name="modelIdService"></param>
    /// <param name="commandBusinessLogic"></param>
    public {5}CommandApi
    (
        ILogger<{5}CommandApi> logger,
        ICommandMappingService<Model, Request, Response> commandMappingService,
        IQueryMappingService<Model, Response> queryMappingService,
        IModelIdService modelIdService,
        ICommandBusinessLogic<Model> commandBusinessLogic
    )
    : base(logger, commandMappingService, queryMappingService, modelIdService, commandBusinessLogic)
    {{
    }}

    #endregion
}}