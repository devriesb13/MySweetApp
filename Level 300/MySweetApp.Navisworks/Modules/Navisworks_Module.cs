using MySweetApp.Core.Constants;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using MySweetApp.Core.Views;
using MySweetApp.Navisworks.Models;
using Prism.Ioc;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Reflection;
using System.Windows;

namespace MySweetApp.Navisworks.Modules
{
    internal class Navisworks_Module : ModuleBase
    {
        private readonly ILoggerFacade loggerfacade;

        public Navisworks_Module(IRegionManager regionManager, ILoggerFacade loggerFacade) : base(regionManager)
        {
            loggerfacade = loggerFacade;
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RegisterViewWithRegion(RegionNames.Contents, typeof(Contents_View));

            var currentassemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            var coreresources = new Uri($"/{currentassemblyname};component/Resources/Core_Resources.xaml", UriKind.Relative);

            RegionManager.RegisterViewWithRegion(RegionNames.Results, () =>
            {
                var view = containerProvider.Resolve<DefaultResults_View>();

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = coreresources });

                return view;
            });
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISelectionType, Line_SelectionType>(typeof(Line_SelectionType).FullName);
            containerRegistry.Register<ISelectionType, Circle_SelectionType>(typeof(Circle_SelectionType).FullName);
            containerRegistry.Register<ISelectionType, Wall_SelectionType>(typeof(Wall_SelectionType).FullName);

#if NAVIS2019

            containerRegistry.Register<ISelectionType, Floor_SelectionType>(typeof(Floor_SelectionType).FullName);

#endif
        }
    }
}