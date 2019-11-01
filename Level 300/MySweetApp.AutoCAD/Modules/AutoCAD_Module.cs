using MySweetApp.AutoCAD.Models;
#if ACAD2019 || ACAD2020
using MySweetApp.AutoCAD.Views;
#endif

using MySweetApp.Core.Constants;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using MySweetApp.Core.Views;
using Prism.Ioc;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Reflection;
using System.Windows;
using AAW = Autodesk.AutoCAD.Windows;

namespace MySweetApp.AutoCAD.Modules
{
    class AutoCAD_Module : ModuleBase
    {
        private readonly ILoggerFacade loggerfacade;

        public AutoCAD_Module(IRegionManager regionManager, ILoggerFacade loggerFacade) : base(regionManager)
        {
            loggerfacade = loggerFacade;
        }

        public static AAW.PaletteSet PaletteSet { get; private set; }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RegisterViewWithRegion(RegionNames.Contents, typeof(Contents_View));

            var currentassemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            var coreresources = new Uri($"/{currentassemblyname};component/Resources/Core_Resources.xaml", UriKind.Relative);

#if ACAD2019 || ACAD2020

            RegionManager.RegisterViewWithRegion(RegionNames.Results, () =>
            {
                var view = containerProvider.Resolve<Results_View>();

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = coreresources });

#if ACAD2020

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri($"/{currentassemblyname};component/Resources/Blocks_Resources.xaml", UriKind.Relative) });

#endif

                return view;
            });

#else

            RegionManager.RegisterViewWithRegion(RegionNames.Results, () =>
            {
                var view = containerProvider.Resolve<DefaultResults_View>();

                view.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = coreresources });

                return view;
            });

#endif

            PaletteSet?.AddVisual("General", Bootstrapper.Instance.MainView);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISelectionType, Line_SelectionType>(typeof(Line_SelectionType).FullName);
            containerRegistry.Register<ISelectionType, Circle_SelectionType>(typeof(Circle_SelectionType).FullName);
            containerRegistry.Register<ISelectionType, Polyline_SelectionType>(typeof(Polyline_SelectionType).FullName);

            loggerfacade.Log("registered core types", Category.Info, Priority.Low);

#if ACAD2020

            containerRegistry.Register<ISelectionType, Blocks_SelectionType>(typeof(Blocks_SelectionType).FullName);
            loggerfacade.Log("registered specific acad 2020 - blocks", Category.Info, Priority.Low);

#endif
            if (PaletteSet is null)
            {
                PaletteSet = new AAW.PaletteSet(AppData.DISPLAYAPPNAME, AppData.DISPLAYAPPNAME, new Guid(AppData.APPID))
                {
                    MinimumSize = new System.Drawing.Size(350, 350)
                };

                loggerfacade.Log("Created instance of paletteset", Category.Info, Priority.Low);

                containerRegistry.RegisterInstance(PaletteSet);

                loggerfacade.Log("Registered instance of paletteset with the container", Category.Info, Priority.Low);
            }
        }
    }
}