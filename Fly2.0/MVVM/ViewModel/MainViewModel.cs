using Fly2_0.Core;

namespace Fly2_0.MVVM.ViewModel
{
    class MainViewModel : ApplicationViewModel
    {
        public RelayCommand MainWindowViewCommand { get; set; }


        public MainWindowViewModel MainWindowVm { get; set; }

        /// <summary>
        /// ///////////////
        /// </summary>
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand BookingStatusViewCommand { get; set; }
        public RelayCommand CheckinViewCommand { get; set; }
        public SearchViewModel SearchVm { get; set; }
        public Chek_inViewModel CheckinVm { get; set; }
        /// <summary>
        /// /////////
        /// </summary>

        public RelayCommand RegistrationViewCommand { get; set; }
        public RegistrationViewModel RegistrationVm { get; set; }

        /// <summary>
        /// //////
        /// </summary>
        /// 
        public RelayCommand AddViewCommand { get; set; }
        public RelayCommand DeleteViewCommand { get; set; }
        public RelayCommand ChangeViewCommand { get; set; }
        public RelayCommand ReportViewCommand { get; set; }
        public RelayCommand OrdersViewCommand { get; set; }


        public ChooseTableViewModel AddVm { get; set; }
        public ReservedTicketsReportViewModel DeleteVm { get; set; }
        public ChangeViewModel ChangeVm { get; set; }
        public ComplitedFlightsReportViewModel ReportVm { get; set; }
        public OrdersViewModel OrdersVm { get; set; }
        /// <summary>
        /// ///
        /// </summary>

        public RelayCommand AircraftViewCommand { get; set; }
        public RelayCommand AirticketsViewCommand { get; set; }
        public RelayCommand FlightViewCommand { get; set; }
        public RelayCommand TicketTypeViewCommand { get; set; }
        public RelayCommand UsersViewCommand { get; set; }
        public RelayCommand PassportViewCommand { get; set; }
        public RelayCommand ContactViewCommand { get; set; }
        public RelayCommand AddressViewCommand { get; set; }
        public AircraftViewModel AircraftVm { get; set; }
        public AirticketsViewModel AirticketsVm { get; set; }
        public FlightViewModel FlightVm { get; set; }
        public TicketTypeViewModel TicketTypeVm { get; set; }
        public UsersViewModel UsersVm { get; set; }
        public PassportViewModel PassportVm { get; set; }
        public AddressViewModel AddressVm { get; set; }
        public ContactViewModel ContactVm { get; set; }

        /// <summary>
        /// //////////
        /// </summary>


        public RelayCommand ChooseFlightViewCommand { get; set; }
        public RelayCommand ChooseTicketTypeViewCommand { get; set; }
        public RelayCommand BookingTicketViewCommand { get; set; }

        public ChooseFlightViewModel ChooseFlightVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private object _currentViewSearch;

        public object CurrentViewSearch
        {
            get { return _currentViewSearch; }
            set
            {
                _currentViewSearch = value;
                OnPropertyChanged();
            }
        }

        private object _currentViewAdmin;

        public object CurrentViewAdmin
        {
            get { return _currentViewAdmin; }
            set
            {
                _currentViewAdmin = value;
                OnPropertyChanged();
            }
        }

        private object _currentViewTable;

        public object CurrentViewTable
        {
            get { return _currentViewTable; }
            set
            {
                _currentViewTable = value;
                OnPropertyChanged();
            }
        }

        private object _currentViewUser;

        public object CurrentViewUser
        {
            get { return _currentViewUser; }
            set
            {
                _currentViewUser = value;
                OnPropertyChanged();
            }
        }

        private object _currentViewBooking;

        public object CurrentViewBooking
        {
            get { return _currentViewBooking; }
            set
            {
                _currentViewBooking = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {

            MainWindowVm = new MainWindowViewModel();
            RegistrationVm = new RegistrationViewModel();
            CurrentView = MainWindowVm;
            ///////////////////
            SearchVm = new SearchViewModel();
            CheckinVm = new Chek_inViewModel();
            CurrentViewSearch = SearchVm;
            //////////////////
            AddVm = new ChooseTableViewModel();
            DeleteVm = new ReservedTicketsReportViewModel();
            ChangeVm = new ChangeViewModel();
            ReportVm = new ComplitedFlightsReportViewModel();
            OrdersVm = new OrdersViewModel();
            CurrentViewAdmin = ReportVm;
            //////////////////
            AircraftVm = new AircraftViewModel();
            AirticketsVm = new AirticketsViewModel();
            FlightVm = new FlightViewModel();
            TicketTypeVm = new TicketTypeViewModel();
            CurrentViewTable = AircraftVm;
            //////////////////
            UsersVm = new UsersViewModel();
            PassportVm = new PassportViewModel();
            AddressVm = new AddressViewModel();
            ContactVm = new ContactViewModel();
            CurrentViewUser = UsersVm;
            ////////////////////
            ChooseFlightVm = new ChooseFlightViewModel();
            CurrentViewBooking = ChooseFlightVm;

            MainWindowViewCommand = new RelayCommand(o =>
            {
                CurrentView = MainWindowVm;
            }
         );
            RegistrationViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegistrationVm;
            }
         );

            ///////////////////////////
            SearchViewCommand = new RelayCommand(o =>
            {
                CurrentViewSearch = SearchVm;
            }
         );

            CheckinViewCommand = new RelayCommand(o =>
            {
                CurrentViewSearch = CheckinVm;
            }
         );
            ///////////////////////////
            ///
            AddViewCommand = new RelayCommand(o =>
            {
                CurrentViewAdmin = AddVm;
            }
);
            DeleteViewCommand = new RelayCommand(o =>
            {
                CurrentViewAdmin = DeleteVm;
            }
);
            ChangeViewCommand = new RelayCommand(o =>
            {
                CurrentViewAdmin = ChangeVm;
            }
);
            ReportViewCommand = new RelayCommand(o =>
            {
                CurrentViewAdmin = ReportVm;
            }
);
            OrdersViewCommand = new RelayCommand(o =>
            {
                CurrentViewAdmin = OrdersVm;
            }
);

            /////////////////////////////////
            ///
            AircraftViewCommand = new RelayCommand(o =>
            {
                CurrentViewTable = AircraftVm;
            }
);
            AirticketsViewCommand = new RelayCommand(o =>
            {
                CurrentViewTable = AirticketsVm;
            }
);
            FlightViewCommand = new RelayCommand(o =>
            {
                CurrentViewTable = FlightVm;
            }
);
            TicketTypeViewCommand = new RelayCommand(o =>
            {
                CurrentViewTable = TicketTypeVm;
            }
);

            /////////////////////
            UsersViewCommand = new RelayCommand(o =>
            {
                CurrentViewUser = UsersVm;
            }
);
            ContactViewCommand = new RelayCommand(o =>
            {
                CurrentViewUser = ContactVm;
            }
);
            PassportViewCommand = new RelayCommand(o =>
            {
                CurrentViewUser = PassportVm;
            }
);
            AddressViewCommand = new RelayCommand(o =>
            {
                CurrentViewUser = AddressVm;
            }
);

            //////////////////////
            ///
            ChooseFlightViewCommand = new RelayCommand(o =>
            {
                CurrentViewBooking = ChooseFlightVm;
            }
);
        }
    }
}
