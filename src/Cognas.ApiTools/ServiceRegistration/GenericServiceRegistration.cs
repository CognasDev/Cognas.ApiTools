﻿using Cognas.ApiTools.ServiceRegistration.Abstractions;
using Cognas.ApiTools.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cognas.ApiTools.ServiceRegistration;

/// <summary>
/// 
/// </summary>
public sealed class GenericServiceRegistration : IServiceRegistration
{
    #region Field Declarations

    private static readonly Lazy<IServiceRegistration> _lazyInstance = new(() => new GenericServiceRegistration());
    private static readonly Lazy<IEnumerable<Type>> _typesFromEntryAssembly = new(() => GetNonAbstractTypes());

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static IServiceRegistration Instance => _lazyInstance.Value;

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="GenericServiceRegistration"/>
    /// </summary>
    private GenericServiceRegistration()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="interfaceType"></param>
    /// <param name="serviceLifetime"></param>
    /// <param name="assembly"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public void AddServices(IServiceCollection serviceCollection, Type interfaceType, ServiceLifetime serviceLifetime, Assembly? assembly = null)
    {
        string interfaceName = interfaceType.Name;
        _typesFromEntryAssembly.Value.FastForEach(type =>
        {
            Type? implementedInterfaceType = type.GetInterface(interfaceName);
            if (implementedInterfaceType  != null)
            {
                Type[] genericArgumentTypes = implementedInterfaceType.GetGenericArguments();
                if (genericArgumentTypes.Any())
                {
                    switch (serviceLifetime)
                    {
                        case ServiceLifetime.Singleton:
                            serviceCollection.AddSingleton(implementedInterfaceType, type);
                            break;
                        case ServiceLifetime.Scoped:
                            serviceCollection.AddScoped(implementedInterfaceType, type);
                            break;
                        case ServiceLifetime.Transient:
                            serviceCollection.AddTransient(implementedInterfaceType, type);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(Enum.GetName(serviceLifetime));
                    }
                }
                else
                {
                    throw new NotSupportedException(type.Name);
                }
            }
        });
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static List<Type> GetNonAbstractTypes()
    {
        List<Type> types = [];
        Assembly.GetEntryAssembly()?.GetTypes().FastForEach(type => !type.IsAbstract, type => types.Add(type));
        return types;
    }

    #endregion
}