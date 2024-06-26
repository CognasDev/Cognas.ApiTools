﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed record ArtistRequest
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("artistId")]
    public int? ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    [Required]
    [StringLength(250)]
    public required string Name { get; set; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistRequest"/>
    /// </summary>
    public ArtistRequest()
    {
    }

    #endregion
}