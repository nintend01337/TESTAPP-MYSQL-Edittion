using MySQL_Prototype.DB;
using MySQL_Prototype.Helpers;
using System;


namespace MySQL_Prototype
{
    public class App
    {
        //IDbConnector connector = new MysqlConnector();


        public App()
        {
            Start();
            //connector.OpenConnection();

        }

        private void Start()
        {
            Cui.MainMenu();
            PullEvent();
        }

        private void PullEvent()
        {
            while (true)
            {
                Cui.ClearScreen();
                Cui.MainMenu();
                var input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        AddCustomer();
                        break;

                    case "2":
                        FetchCustomers();
                        break;

                    case "3":
                        AddOrder();
                        break;

                    case "4":
                        FetchOrders();
                        break;

                    case "5":
                        FetchOrdersById();
                        break;

                    case "6":
                        RemoveCustomerById();
                        break;

                    case "7":
                        RemoveOrderById();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }

        private void AddCustomer()
        {
            Console.WriteLine("Добавление Клиента :\n");
            Console.WriteLine("Имя:\n");
            var firstName = Console.ReadLine();
            Console.WriteLine("Фамилия:\n");
            var lastName = Console.ReadLine();
            Console.WriteLine("Имейл:\n");
            var email = Console.ReadLine();
            Console.WriteLine("Телефон:\n");
            var phoneNumber = Console.ReadLine();

            string queryString = $"insert into Customers(FirstName,LastName,Email,PhoneNumber) values" +
                                 $" ('{firstName}','{lastName}','{email}','{phoneNumber}')";

            //string queryString = $"insert into Customers(FirstName,LastName,Email,PhoneNumber) values" +
            //                   $" ('@Par1','@Par2','@Par3','@Par4')";

            //var par = new Dictionary <string, object>
            //{
            //    { "@Par1", $"{firstName}" },
            //    { "@Par2", $"{lastName}" } ,
            //    { "@Par3", $"{email}" } ,
            //    { "@Par4", $"{phoneNumber}" }

            //};

            QueryExecutor queryExecutor = new QueryExecutor();

            if (queryExecutor.ExecuteNonQuery(queryString) > 0)
            {
                Console.WriteLine("Операция выполнена успешно!");
            }

        }

        private void AddOrder()
        {
            Cui.ClearScreen();
            FetchCustomers();

            Console.WriteLine("Добавление заказа:\n");
            Console.WriteLine("Код клиента:\n");
            var customerID = Console.ReadLine();
            Console.WriteLine("Имя заказа:\n");
            var orderName = Console.ReadLine();
            Console.WriteLine("Сумма:\n");
            var orderAmount = Console.ReadLine();


            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string queryString = $"insert into Orders(CustomerID,OrderName,OrderDate,OrderAmount) values" +
                                $"('{customerID}','{orderName}', convert(datetime,'{date}',120),'{orderAmount}')";

            if (Validator.ValidateDigits(customerID) && Validator.ValidateDecimal(orderAmount))
            {
                QueryExecutor queryExecutor = new QueryExecutor();

                if (queryExecutor.ExecuteNonQuery(queryString) > 0)
                {
                    Console.WriteLine("Операция выполнена успешно!");
                }
            }
        }

        private void FetchCustomers()
        {
            string queryString = $"SELECT * FROM Customers";

            Cui.ClearScreen();
            Console.WriteLine("Получение списка клиентов:\n");
            QueryExecutor queryExecutor = new QueryExecutor();
            string result = queryExecutor.ExecuteQuery(queryString);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private void FetchOrders()
        {
            Console.WriteLine("Получение списка заказов");
            string queryString = $"SELECT O.OrderID, C.FirstName, C.LastName,O.OrderName,O.OrderDate,O.OrderAmount " +
                                 $"FROM Orders AS O INNER JOIN Customers AS C ON O.CustomerID = C.CustomerID;";
            Cui.ClearScreen();
            QueryExecutor queryExecutor = new QueryExecutor();
            string result = queryExecutor.ExecuteQuery(queryString);
            Console.WriteLine(result);

            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.....");
            Console.ReadKey();
        }
        private void FetchOrdersById()
        {
            Console.WriteLine("Получение списка заказов по ID клиента");
            Console.WriteLine("Введите Id клиента:");
            var clientID = Console.ReadLine();
            if (Validator.ValidateDigits(clientID))
            {
                string queryString = $"SELECT O.OrderID, C.FirstName, C.LastName,O.OrderName,O.OrderDate,O.OrderAmount " +
                                     $"FROM Orders AS O INNER JOIN Customers AS C ON O.CustomerID = C.CustomerID " +
                                     $"WHERE O.CustomerID = {clientID};";
                Cui.ClearScreen();
                QueryExecutor queryExecutor = new QueryExecutor();
                string result = queryExecutor.ExecuteQuery(queryString);
                Console.WriteLine(result);


                Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Введены неверный ID");
                FetchOrdersById();
            }
        }

        private void RemoveCustomerById()
        {
            FetchCustomers();
            Console.WriteLine("Удаление клиента по ID");
            Console.WriteLine("Введите Id клиента для удаления:");
            var clientID = Console.ReadLine();

            if (Validator.ValidateDigits(clientID))
            {
                string queryString = $"DELETE FROM Customers WHERE CustomerID = {clientID}";
                QueryExecutor queryExecutor = new QueryExecutor();

                if (queryExecutor.ExecuteNonQuery(queryString) > 0)
                {
                    Console.WriteLine("Операция выполнена успешно!");
                }
                Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Введены неверный ID");
                RemoveCustomerById();
            }
        }
        private void RemoveOrderById()
        {
            FetchOrders();
            Console.WriteLine("Удаление заказа по ID");
            Console.WriteLine("Введите Id заказа:");
            var orderID = Console.ReadLine();

            if (Validator.ValidateDigits(orderID))
            {
                string queryString = $"DELETE FROM Orders WHERE OrderID = {orderID}";
                QueryExecutor queryExecutor = new QueryExecutor();

                if (queryExecutor.ExecuteNonQuery(queryString) > 0)
                {
                    Console.WriteLine("Операция выполнена успешно!");
                }
                Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Введены неверный ID");
                RemoveOrderById();
            }
        }
    }
  
}
