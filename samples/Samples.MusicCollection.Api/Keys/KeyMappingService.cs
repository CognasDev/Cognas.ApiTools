﻿using Cognas.ApiTools.Mapping;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public sealed class KeyMappingService : MappingServiceBase<Key, KeyRequest, KeyResponse>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="KeyMappingService"/>
    /// </summary>
    public KeyMappingService()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override KeyResponse ModelToResponse(Key model)
    {
        KeyResponse response = new()
        {
            KeyId = model.KeyId,
            CamelotCode = model.CamelotCode,
            Name = model.Name
        };
        return response;
    }

    #endregion
}