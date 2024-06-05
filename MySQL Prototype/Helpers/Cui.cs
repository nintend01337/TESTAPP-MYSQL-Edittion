using System;

namespace MySQL_Prototype.Helpers
{
    public static class Cui
    {
        public static void MainMenu()
        {
            Console.WriteLine("Выберите действие :\n" +
                "1. Добавить Нового Клиента\n" +
                "2. Просмотр Клиентов\n" +
                "3. Добавление заказа\n" +
                "4. Просмотр списка всех заказов\n" +
                "5. Просмотр заказов отдельного клиента\n" +
                "6. Удаление Клиента\n" +
                "7. Удаление Заказа");

        }

        public static void ClearScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}
