namespace IML
{

    using System.Configuration;
    using System.Linq;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentValidation;
    using Incoding.Block.IoC;
    using Incoding.CQRS;
    using Incoding.Data;
    using Incoding.EventBroker;
    using NHibernate.Context;


    public static class Bootstrapper
    {
        #region Factory constructors

        public static void Start()
        {
            IoCFactory.Instance.Initialize(init => init.WithProvider(new StructureMapIoCProvider(registry =>
                                                                                                     {
                                                                                                         registry.For<IDispatcher>().Use<DefaultDispatcher>();
                                                                                                         registry.For<IEventBroker>().Use<DefaultEventBroker>();
                                                                                                         
                                                                                                     })));
            
        }

        #endregion
    }


}