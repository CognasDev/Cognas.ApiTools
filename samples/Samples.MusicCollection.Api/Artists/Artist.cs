﻿using Cognas.ApiTools.SourceGenerators.Attributes;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
[IncludeInModelIdService]
[CommandScaffold(typeof(ArtistRequest), typeof(ArtistResponse), 1, false)]
[QueryScaffold(typeof(ArtistResponse), 1)]
public sealed record Artist
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [Id]
    public required int ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="Artist"/>
    /// </summary>
    public Artist()
    {
    }

    #endregion
}