﻿using System.Collections.Generic;
using System.Text;

namespace Cognas.ApiTools.SourceGenerators.QueryScaffold;

/// <summary>
/// 
/// </summary>
internal static class GenerateInitiateQueryEndpoints
{
    #region Field Declarations

    private static readonly HashSet<int> _queryApiVersions = [];

    #endregion

    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public static void ClearApiVersions() => _queryApiVersions.Clear();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryEndpointInitiatorBuilder"></param>
    /// <param name="detail"></param>
    public static void Generate(StringBuilder queryEndpointInitiatorBuilder, QueryScaffoldDetail detail)
    {
        if (_queryApiVersions.Add(detail.ApiVersion))
        {
            queryEndpointInitiatorBuilder.Append("\t\tRouteGroupBuilder apiVersionRouteV");
            queryEndpointInitiatorBuilder.Append(detail.ApiVersion);
            queryEndpointInitiatorBuilder.Append(" = webApplication.GetApiVersionRoute(");
            queryEndpointInitiatorBuilder.Append(detail.ApiVersion);
            queryEndpointInitiatorBuilder.AppendLine(");");
        }
        queryEndpointInitiatorBuilder.Append("\t\twebApplication.InitiateApi<");
        queryEndpointInitiatorBuilder.Append(detail.ModelNamespace);
        queryEndpointInitiatorBuilder.Append('.');
        queryEndpointInitiatorBuilder.Append(detail.ModelName);
        queryEndpointInitiatorBuilder.Append(", ");
        queryEndpointInitiatorBuilder.Append(detail.ResponseName);
        queryEndpointInitiatorBuilder.Append(">(");
        queryEndpointInitiatorBuilder.Append(detail.ApiVersion);
        queryEndpointInitiatorBuilder.Append(", apiVersionRouteV");
        queryEndpointInitiatorBuilder.Append(detail.ApiVersion);
        queryEndpointInitiatorBuilder.AppendLine(");");
    }

    #endregion
}