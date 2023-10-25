﻿using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Notifications;
using H.Core;
using H.Core.Calculators.UnitsOfMeasurement;
using H.Core.Enumerations;
using Prism.Commands;
using Prism.Events;

namespace H.Avalonia.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        #region Fields
        private string _title;
        private string _subtitle;
        private PrototypeStorage? _prototypeStorage;
        private Storage? _storage;

        public IRegionManager RegionManager;

        //private ObservableCollection<Farm> _copiedFarmsUsedForSimulation;
        private EmissionDisplayUnits _selectedEmissionDisplayUnits;

        #endregion

        protected ViewModelBase()
        {
        }
        protected ViewModelBase(PrototypeStorage prototypeStorage)
        {
            PrototypeStorage = prototypeStorage;
        }

        protected ViewModelBase(IRegionManager regionManager)
        {

        }

        protected ViewModelBase(IRegionManager regionManager, PrototypeStorage prototypeStorage)
        {
            PrototypeStorage = prototypeStorage;
        }
        
        protected ViewModelBase(IRegionManager? regionManager, IEventAggregator? eventAggregator, PrototypeStorage? prototypeStorage)
        {
            if (regionManager != null)
            {
                this.RegionManager = regionManager;
            }
            else
            {
                throw new ArgumentNullException(nameof(regionManager));
            }

            if (eventAggregator != null)
            {
                this.EventAggregator = eventAggregator;
            }
            else
            {
                throw new ArgumentNullException(nameof(eventAggregator));
            }

            if (prototypeStorage != null)
            {
                this.PrototypeStorage = prototypeStorage;
                //this.Storage.ApplicationData.GlobalSettings.PropertyChanged += GlobalSettingsOnPropertyChanged;
            }
            else
            {
                throw new ArgumentNullException(nameof(prototypeStorage));
            }

            this.Construct();
        }
        
        protected ViewModelBase(IRegionManager? regionManager, IEventAggregator? eventAggregator, Storage? storage)
        {
            if (regionManager != null)
            {
                this.RegionManager = regionManager;
            }
            else
            {
                throw new ArgumentNullException(nameof(regionManager));
            }

            if (eventAggregator != null)
            {
                this.EventAggregator = eventAggregator;
            }
            else
            {
                throw new ArgumentNullException(nameof(eventAggregator));
            }

            if (storage != null)
            {
                this.Storage = storage;
                //this.Storage.ApplicationData.GlobalSettings.PropertyChanged += GlobalSettingsOnPropertyChanged;
            }
            else
            {
                throw new ArgumentNullException(nameof(storage));
            }

            this.Construct();
        }

        
        #region Properties
        /// <summary>
        /// A storage file that contains various data items that are shored between viewmodels are passed around the system. This storage
        /// item is instantiated using Prism and through Dependency Injection, is passed within the system.
        /// </summary>
        public PrototypeStorage? PrototypeStorage
        {
            get => _prototypeStorage;
            set => SetProperty(ref _prototypeStorage, value);
        }
        
        public Storage Storage
        {
            get { return _storage; }
            set { SetProperty(ref _storage, value); }
        }
        
        public IEventAggregator EventAggregator { get; set; }

        public DelegateCommand<object> OkCommand { get; set; }
        public DelegateCommand<object> CancelCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand BackCommand { get; set; }
        public DelegateCommand ResultsCommand { get; set; }
        public DelegateCommand ResetStageState { get; set; }

        /// <summary>
        /// The title of the view.
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// The subtitle of the view.
        /// </summary>
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }
        
        public bool WindowWasCancelled { get; set; }

        // Active farm property must be readonly so that all views and view models get the same instance of the ActiveFarm property from the GlobalSettings instance. 
        // If this isn't readonly, then each view model will get a different instance of this property and the instances will be out of sync when one copy of the active farm is updated.
        // The issue is that an instance of this class 'ViewModelBase' is created for each class that inherits from it which is pretty much all view models - therefore unless this property
        // is readonly (returns same object each time), then all view models will get different copies of the ActiveFarm which is not what we want.
        // public Farm ActiveFarm
        // {
        //     get { return this.Storage.ApplicationData.GlobalSettings.ActiveFarm; }
        // }

        // public ObservableCollection<Farm> CopiedFarmsUsedForSimulation
        // {
        //     get { return _copiedFarmsUsedForSimulation; }
        //     set { SetProperty(ref _copiedFarmsUsedForSimulation, value); }
        // }

        public EmissionDisplayUnits SelectedEmissionDisplayUnits
        {
            get => _selectedEmissionDisplayUnits;
            set => SetProperty(ref _selectedEmissionDisplayUnits, value);
        }

        public UnitsOfMeasurementCalculator UnitCalculator { get; set; }
        
        
        /// <summary>
        /// The notification manager that handles displaying notifications on the page.
        /// </summary>
        public WindowNotificationManager NotificationManager { get; set; }
        
        #endregion
        
        #region Public Methods
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>Navigation validation checker.</summary>
        /// <remarks>Override for Prism 7.2's IsNavigationTarget.</remarks>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns><see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.</returns>
        public virtual bool OnNavigatingTo(NavigationContext navigationContext)
        {
            return true;
        }
        
        public void Construct()
        {

            //this.CopiedFarmsUsedForSimulation = new ObservableCollection<Farm>();

            //this.ResultsCommand = new DelegateCommand(this.OnResults);

            this.UnitCalculator = new UnitsOfMeasurementCalculator();
        }
        
        #endregion
    }
}
