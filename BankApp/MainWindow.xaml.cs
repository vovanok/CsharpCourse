using BankApp.BusinessLogic;
using System;
using System.Linq;
using System.Windows;

namespace BankApp
{
    public partial class MainWindow : Window
    {
        private Bank bank = new Bank();

        public MainWindow()
        {
            InitializeComponent();

            bank.CreateEmployee("Вася", "123", OperationTypes.PushMoney | OperationTypes.OpenAccount);
            bank.CreateEmployee("Тома", "123", OperationTypes.PullMoney | OperationTypes.CloseAccount);

            Client client1 = bank.CreateClient("Дядя Вася");
            Client client2 = bank.CreateClient("Дядя Петя");
            Client client3 = bank.CreateClient("Дядя Игнат");
            bank.CreateClient("Геннадий");

            bank.CreateAccount(client1);
            bank.CreateAccount(client1);
            bank.CreateAccount(client1);

            bank.CreateAccount(client2);
            bank.CreateAccount(client2);

            bank.CreateAccount(client3);
            bank.CreateAccount(client3);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login();

            lbClients.ItemsSource = bank.Clients;
        }

        private void Login()
        {
            LoginWindow loginWindow = new LoginWindow();
            bool? loginResult = loginWindow.ShowDialog();

            if (loginResult == null || loginResult.Value == false)
            {
                ShowError("Вы не можете не войти");
                Close();
                return;
            }

            if (!bank.LoginEmployee(loginWindow.EmployeeName, loginWindow.EmployeePassword))
            {
                ShowError($"Сотрудник в логином {loginWindow.EmployeeName} не найден");
                Login();
            }
        }

        private void On_tbFilterClientName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateClientList();
        }

        private void UpdateClientList()
        {
            lbClients.ItemsSource =
                !string.IsNullOrEmpty(tbFilterClientName.Text)
                    ? bank.Clients.Where(client => IsStringContains(client.Name, tbFilterClientName.Text))
                    : bank.Clients;
        }

        private bool IsStringContains(string stringValue, string containedString)
        {
            return stringValue.IndexOf(containedString, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void On_lbClients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RefreshAccountsList();
        }

        private void RefreshAccountsList()
        {
            Client selectedClient = lbClients.SelectedItem as Client;
            if (selectedClient == null)
                return;

            lbAccounts.ItemsSource =
                bank.Accounts.Where(item => item.OwnerClient == selectedClient);
        }

        private void On_btnPushMoney_Click(object sender, RoutedEventArgs e)
        {
            DoMoneyOperation(bank.PushMoney);
        }

        private void On_btnPullMoney_Click(object sender, RoutedEventArgs e)
        {
            DoMoneyOperation(bank.PullMoney);
        }

        private void DoMoneyOperation(Action<Account, decimal> operationMethod)
        {
            Account selectedAccount = lbAccounts.SelectedItem as Account;
            if (selectedAccount == null)
            {
                MessageBox.Show("Не выбран счет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal enteredDeltaMoney;
            if (!decimal.TryParse(tbDeltaMoney.Text, out enteredDeltaMoney))
            {
                MessageBox.Show("Введена некорректная сумма", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                operationMethod(selectedAccount, enteredDeltaMoney);
                RefreshAccountsList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void On_btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = lbClients.SelectedItem as Client;
            if (selectedClient == null)
                return;

            try
            {
                bank.AddAccount(selectedClient);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RefreshAccountsList();
        }

        private void On_btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = lbAccounts.SelectedItem as Account;
            if (selectedAccount == null)
            {
                MessageBox.Show("Не выбран счет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                bank.DeleteAccount(selectedAccount);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RefreshAccountsList();
        }
    }
}
