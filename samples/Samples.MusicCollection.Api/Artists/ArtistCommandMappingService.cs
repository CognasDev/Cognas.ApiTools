﻿using Cognas.ApiTools.Mapping;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed class ArtistCommandMappingService : CommandMappingServiceBase<Artist, ArtistRequest, ArtistResponse>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistCommandMappingService"/>
    /// </summary>
    public ArtistCommandMappingService()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Artist RequestToModel(ArtistRequest request)
    {
        Artist model = new()
        {
            ArtistId = request.ArtistId ?? 0,
            Name = request.Name
        };
        return model;
    }

    #endregion
}