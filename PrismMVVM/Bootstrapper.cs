﻿using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using PrismMVVM.Views;
using System;
using System.Windows;

namespace PrismMVVM
{
    /// <summary>
    /// Initailisiert die Shell und registriert abhängige Klassen
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Lädt und konfiguriert den Container
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.AddNewExtension<Interception>();

            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);

            ModuleManager moduleManager = Container.TryResolve<ModuleManager>();
            moduleManager.LoadModule("EmployeeModule");
        }

        /// <summary>
        /// Lädt und konfiguriert den ModuleCatalog
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Module.Employee.EmployeeModule));
        }

        /// <summary>
        /// Erzeugt eine neue Shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(t =>
            {
                return Container.Resolve(t);
            });

            // Use the container to create an instance of the shell.
            MainWindow view = this.Container.TryResolve<MainWindow>();
            return view;
        }

        /// <summary>
        /// Initialisiert die Shell
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            Application.Current.MainWindow.Show();

            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", new Uri("EmployeeEditor", UriKind.Relative));
        }
    }
}