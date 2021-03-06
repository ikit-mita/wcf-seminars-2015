﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using BookStore.BusinessLogic;
using BookStore.Model;
using Mita;
using Mita.Mvvm;

namespace BookStore.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewModel : ChildViewModel
    {
        private string _searchString;
        private string _isbn;
        private Employee _employee;
        private ICollection<BookAmount> _amounts;

        public MainViewModel()
        {
            SearchCommand = new DelegateCommand(() => Task.Run((Action)Search));
            CreateOrderCommand = new DelegateCommand(CreateOrder);
        }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IUsersLogic UsersLogic { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IBooksLogic BooksLogic { get; set; }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                OnPropertyChanged();
            }
        }

        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if (value == _isbn) return;
                _isbn = value;
                OnPropertyChanged();
            }
        }

        public Employee Employee
        {
            get { return _employee; }
            private set
            {
                if (Equals(value, _employee)) return;
                _employee = value;
                OnPropertyChanged();
            }
        }

        public ICollection<BookAmount> Amounts
        {
            get { return _amounts; }
            set
            {
                if (Equals(value, _amounts)) return;
                _amounts = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SearchCommand { get; private set; }

        public DelegateCommand CreateOrderCommand { get; private set; }

        public Task InitializeAsync(int userId)
        {
            return Task.Run(() => Initialize(userId));
        }

        public void Initialize(int userId)
        {
            using (StartOperation())
            {
                Employee = UsersLogic.GetEmployeeByUserId(userId);
                Title = "Booko: " + Employee.Branch.Name;
            }
        }

        private void Search()
        {
            using (StartOperation())
            {
                if (ISBN.IsNullOrEmpty() && SearchString.IsNullOrEmpty())
                {
                    Amounts = new BookAmount[] { };
                    return;
                }

                Amounts = BooksLogic.SearchBooks(Employee.BranchId, ISBN, SearchString);
            }
        }

        private void CreateOrder()
        {
            var vm = ServiceLocator.GetInstance<OrderEditViewModel>();
            vm.InitializeAsync(Employee);
            vm.Parent = this;
            vm.Show();
            vm.Closed += OnOrderEditViewModelClosed;
        }

        private void OnOrderEditViewModelClosed(object sender, EventArgs e)
        {
            var orderEditViewModel = sender as OrderEditViewModel;

            if (orderEditViewModel != null && orderEditViewModel.ModalResult)
            {
                BooksLogic.Dispose();
                BooksLogic = ServiceLocator.GetInstance<IBooksLogic>();
                Search();
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            UsersLogic.Dispose();
            BooksLogic.Dispose();
        }
    }
}
