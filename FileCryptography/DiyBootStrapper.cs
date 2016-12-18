using FileCryptography.Application.Interfaces.Services;
using FileCryptography.Application.Services;
using FileCryptography.Domain;
using FileCryptography.Domain.Commands;
using FileCryptography.Domain.Events;
using FileCryptography.Domain.Interfaces.Events;
using FileCryptography.Domain.Interfaces.Repositories;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Repositories;
using FileCryptography.Infrastructure.CommandHandler;
using FileCryptography.Infrastructure.EventDispatcher;
using FileCryptography.Infrastructure.EventHandler;
using FileCryptography.Infrastructure.Interfaces;
using FileCryptography.Infrastructure.Interfaces.CommandHandler;
using FileCryptography.Infrastructure.Interfaces.Ioc;
using FileCryptography.Infrastructure.Interfaces.Logging;
using FileCryptography.Infrastructure.Ioc;
using FileCryptography.Infrastructure.Logging;
using FileCryptography.Infrastructure.Services.Cqrs;
using FileCryptography.Infrastructure.Services.Domain;
using FileCryptography.Infrastruture.Interfaces.Domain;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography
{
    public class DiyBootStrapper
    {
        public DiyBootStrapper(IUnityContainer unityContainer)
        {
            unityContainer.RegisterInstance<ILogger>(new NtfsFileLogger(@"C:\Temp"), new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IEventDispatcher, UnityWrappedContainer>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IContainer, UnityWrappedContainer>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IRepository, InMemoryRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICommandService, CommandService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IQueryService, QueryService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICryptographyExecutionService, GnuPgExecutionService>();
            unityContainer.RegisterType<IOperatingSystemCommandExecutor, WindowsCmdExecutor>();
            unityContainer.RegisterType<IAppCommandIntepretorFactory, AppCommandIntepretorFactory>();
            unityContainer.RegisterType<ICommandHandler<GenerateKeyPairCommand>, CreateKeyCommandHandler>();
            unityContainer.RegisterType<ICommandHandler<DecryptFileCommand>, DecrypeFileCommandHandler>();
            unityContainer.RegisterType<IEventHandler<FileDecryptedEvent>, AuditLoggingEventHandler>("Hld1");
            unityContainer.RegisterType<IEventHandler<KeyPairGeneratedEvent>, AuditLoggingEventHandler>("Hld2");
            unityContainer.RegisterType<IApplicationService, FileCryptographyApplicationService>(new ContainerControlledLifetimeManager());
            DomainEvents.Dispatcher = unityContainer.Resolve<IEventDispatcher>();

            unityContainer.RegisterType<MainWindow>(new ContainerControlledLifetimeManager());
        }
    }
}
