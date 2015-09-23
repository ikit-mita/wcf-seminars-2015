using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic;
using BookStore.Model;
using Mita;
using Mita.Mvvm;

namespace BookStore.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrderEditViewModel : ChildViewModel
    {
        private Employee _employee;
        private Order _order;
        private string _isbn;
        private ICollection<Customer> _customers;
        private Customer _customer;
        private ICollection<BookAmount> _availableBooks;
        private string _errorMessage;

        public OrderEditViewModel()
        {
            SaveCommand = new DelegateCommand(() => Task.Run((Action)Save), () => Customer != null);
            AddBookCommand = new DelegateCommand<BookAmount>(AddBook);
        }

        [Import]
        private IUsersLogic UsersLogic { get; set; }

        [Import]
        private IBooksLogic BooksLogic { get; set; }

        [Import]
        private IOrdersLogic OrdersLogic { get; set; }

        public Order Order
        {
            get { return _order; }
            private set
            {
                if (Equals(value, _order)) return;
                _order = value;
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
                ReloadBooks();
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value == _errorMessage) return;
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (Equals(value, _customers)) return;
                _customers = value;
                OnPropertyChanged();
            }
        }

        public ICollection<BookAmount> AvailableBooks
        {
            get { return _availableBooks; }
            set
            {
                if (Equals(value, _availableBooks)) return;
                _availableBooks = value;
                OnPropertyChanged();
            }
        }

        [CommandDependency("SaveCommand")]
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (Equals(value, _customer)) return;
                _customer = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand<BookAmount> AddBookCommand { get; private set; }

        public Task InitializeAsync(Employee employee)
        {
            return Task.Run(() => Initialize(employee));
        }

        public void Initialize(Employee employee)
        {
            using (StartOperation())
            {
                _employee = employee;
                Order = new Order
                    {
                        EmployeeId = _employee.Id,
                        OrderedBooks = new ObservableCollection<OrderedBook>()
                    };

                ReloadCustomers();
                ReloadBooks();
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            UsersLogic.Dispose();
            BooksLogic.Dispose();
            OrdersLogic.Dispose();
        }

        private void Save()
        {
            using (StartOperation())
            {
                var validationMessage = OrdersLogic.ValidateOrder(Order, _employee.BranchId);
                if (!validationMessage.IsNullOrEmpty())
                {
                    ErrorMessage = validationMessage;
                    return;
                }

                Order.Date = DateTime.Now;
                Order.Customer = Customer;
                OrdersLogic.SaveOrder(Order, _employee.BranchId);

                Close(true);
            }

        }

        private void ReloadCustomers()
        {
            Customers = UsersLogic.GetAllCustomers();
        }

        private void ReloadBooks()
        {
            AvailableBooks = BooksLogic.SearchBooks(_employee.BranchId, ISBN.TrimSafe(), onHandOnly: true);
        }

        private void AddBook(BookAmount bookAmount)
        {
            if (bookAmount == null)
            {
                return;
            }

            var orderedBook = Order.OrderedBooks.FirstOrDefault(ob => ob.BookId == bookAmount.BookId);

            if (orderedBook == null)
            {
                orderedBook = new OrderedBook
                {
                    Amount = 1,
                    Book = bookAmount.Book,
                    BookId = bookAmount.BookId,
                    Order = Order,
                    OrderId = Order.Id,
                    Price = bookAmount.Book.Price
                };

                Order.OrderedBooks.Add(orderedBook);
            }
        }
    }

}
