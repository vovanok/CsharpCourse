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

            bank.CreateEmployee("Вася", "123", OperationTypes.None);
            bank.CreateEmployee("Тома", "123", OperationTypes.None);

            bank.CreateClient("Дядя Вася");
            bank.CreateClient("Дядя Петя");
            bank.CreateClient("Дядя Игнат");
            bank.CreateClient("Геннадий");
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
    }
}
