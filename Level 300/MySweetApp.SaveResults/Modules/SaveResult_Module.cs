using MySweetApp.Core.Constants;
using MySweetApp.Core.Models;
using MySweetApp.SaveResults.Contracts;
using MySweetApp.SaveResults.Services;
using MySweetApp.SaveResults.Views;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace MySweetApp.SaveResults
{
    public class SaveResult_Module : ModuleBase
    {
        public SaveResult_Module(IRegionManager regionManager) : base(regionManager)
        {
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RegisterViewWithRegion(RegionNames.Toolbar, typeof(SaveResult_View));
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISaveResult_Service, SaveResult_Service>();
        }
    }
}