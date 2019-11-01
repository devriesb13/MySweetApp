using MySweetApp.Core.Constants;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using MySweetApp.Core.Views;
using MySweetApp.Revit.Models;
using Prism.Ioc;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Reflection;
using System.Windows;

#if REVIT2019 || REVIT2020
using MySweetApp.Revit.Views;
#endif

namespace MySweetApp.Revit.Modules
{
    class Revit_Module : ModuleBase
    {
        private readonly ILoggerFacade loggerfacade;

        public Revit_Module(IRegionManager regionManager, ILoggerFacade loggerFacade) : base(regionManager)
        {
            loggerfacade = loggerFacade;
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RegisterViewWithRegion(RegionNames.Contents, typeof(Contents_View));

            var currentassemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            var coreresources = new Uri($"/{currentassemblyname};component/Resources/Core_Resources.xaml", UriKind.Relative);

#if REVIT2019 || REVIT2020

            RegionManager.RegisterViewWithRegion(RegionNames.Results, () =>
            {
                var view = containerProvider.Resolve<Results_View>();

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = coreresources });

                return view;
            });

#else

            RegionManager.RegisterViewWithRegion(RegionNames.Results,() =>
            {
                var view = containerProvider.Resolve<DefaultResults_View>();

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = coreresources });

                return view;
            });

#endif
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISelectionType, Wall_SelectionType>(typeof(Wall_SelectionType).FullName);

#if REVIT2019

            containerRegistry.Register<ISelectionType, Floor_SelectionType>(typeof(Floor_SelectionType).FullName);

#endif
        }
    }
}