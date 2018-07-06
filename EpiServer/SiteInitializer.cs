#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:EpiServer:SiteInitializer.cs
// Usage:          

#endregion

using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace EpiServer
{
	[InitializableModule]
	[ModuleDependency(typeof(ServiceContainerInitialization), typeof(InitializationModule))]
	public class SiteInitializer : IConfigurableModule
	{
		public void Initialize(InitializationEngine context)
		{
			// Attach event handlers here
		}

		public void Uninitialize(InitializationEngine context)
		{
			// Detach event handlers here
		}

		public void ConfigureContainer(ServiceConfigurationContext context)
		{
			var container = context.StructureMap();
			container.Configure(creg => creg.AddRegistry<SiteBootstrapper>());
		}
	}
}
