namespace ToDo
{
    static class Program
    {
        public static List<ToDoItem> ToDoItems = new List<ToDoItem>();
        
        public static void Main(string[] parameters)
        {
            ToDoItems.Add(new ToDoItem("Go to shopping"));
            ToDoItems.Add(new ToDoItem("Check garbage"));
            ToDoItems.Add(new ToDoItem("Wipe the door", true));
            ToDoItems.Add(new ToDoItem("cook"));
            ToDoItems.Add(new ToDoItem("go to school", true));
            ToDoItems.Add(new ToDoItem("last item"));

            bool continueRunning = true;
            do
            {
                int operationType = getUserInput();
                Console.Clear();

                switch (operationType)
                {
                    case 1:
                        printTodoItemList();
                        Console.ReadKey();
                        break;
                    case 2:
                        addTodoItem();
                        break;
                    case 3:
                        markAsCompleted();
                        break;
                    case 4:
                        deleteTodoItem();
                        break;
                    case 5:
                        editTodoItem();
                        break;
                    case 9:
                        continueRunning = false;
                        break;
                }

                Console.Clear();
            } while (continueRunning);
        }

        private static int getUserInput()
        {
            bool isValidInput = false;
            int operationType = 0;

            do
            {
                Console.WriteLine("Please type 1 to list all to do items");
                Console.WriteLine("Please type 2 to add a new item");
                Console.WriteLine("Please type 3 to mark as completed to an item");
                Console.WriteLine("Please type 4 to delete an item ");
                Console.WriteLine("Please type 5 to edit an item");
                Console.WriteLine("Please type 9 to exit. ");

                Console.Write("Please select operation type: ");
                string input = Console.ReadLine() ?? "";

                int.TryParse(input, out operationType);
                if ((operationType >= 1 && operationType <= 5) || operationType == 9)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid option! ");
                    Console.WriteLine(new String('-', 25));
                }
            } while (!isValidInput);

            return operationType;
        }

        private static void printTodoItemList()
        {
            if (ToDoItems.Count == 0)
            {
                Console.WriteLine("No item can be found, press any key to return to the main window. ");
                return;
            }
            int indexNumber = 1;
            
            foreach (var item in ToDoItems.Where(t =>t.Marked == false).OrderBy(t => t.Name))
            {
                // 1. [ ] go to shopping
                Console.WriteLine(indexNumber + ". " + item);
                //indexNumber = indexNumber + 1;
                indexNumber++;
            }
            Console.WriteLine(new string('-', 25));
            foreach (var item in ToDoItems.Where(t =>t.Marked == true).OrderBy(t => t.Name))
            {
                // 1. [ ] go to shopping
                Console.WriteLine(indexNumber + ". " + item);
                //indexNumber = indexNumber + 1;
                indexNumber++;
            }
        }

        private static void addTodoItem()
        {
            Console.Write("Please enter an argument: ");
            string input = Console.ReadLine() ?? "";
            if (input.Length <= 0)
            {
                Console.WriteLine("Invalid Input, press any key to return to the main menu. ");
                Console.ReadKey();
                return;
            }
            
            ToDoItems.Add(new ToDoItem(input));
        }

        private static void markAsCompleted()
        {
            if (ToDoItems.Count == 0)
            {
                Console.WriteLine("No item can be found, press any key to return to the main window. ");
                return;
            }
            printTodoItemList();

            Console.Write("Please select the item that you want to mark: ");
            string input = Console.ReadLine() ?? "";
            int.TryParse(input, out int indexNumber);
            if (indexNumber > 0 && indexNumber <= ToDoItems.Count)
            {
                var unMarkedToDoItems = ToDoItems
                    .Where(t => !t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                var markedToDoItems = ToDoItems
                    .Where(t => t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                
                ToDoItem item = unMarkedToDoItems.Concat(markedToDoItems).ToList()[indexNumber - 1];
                item.Marked = !item.Marked;
            }
            else
            {
                Console.WriteLine("Invalid Input, press any key to return to the main menu. ");
                Console.ReadKey();
                return;
            }
        }

        private static void deleteTodoItem()
        {
            if (ToDoItems.Count == 0)
            {
                Console.WriteLine("No item can be found, press any key to return to the main window. ");
                return;
            }
            printTodoItemList();

            Console.Write("Please select the item that you want to delete: ");
            string input = Console.ReadLine() ?? "";
            int.TryParse(input, out int indexNumber);
            if (indexNumber > 0 && indexNumber <= ToDoItems.Count)
            {
                var unMarkedToDoItems = ToDoItems
                    .Where(t => !t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                var markedToDoItems = ToDoItems
                    .Where(t => t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                
                ToDoItem item = unMarkedToDoItems.Concat(markedToDoItems).ToList()[indexNumber - 1];
                
                ToDoItems.Remove(item);
            }
            else
            {
                Console.WriteLine("Invalid Input, press any key to return to the main menu. ");
                Console.ReadKey();
                return;     
            }
        }
        
        private static void editTodoItem()
        {
            if (ToDoItems.Count == 0)
            {
                Console.WriteLine("No item can be found, press any key to return to the main window. ");
                return;
            }
            printTodoItemList();

            Console.Write("Please select the item that you want to edit: ");
            string input = Console.ReadLine() ?? "";
            int.TryParse(input, out int indexNumber);
            if (indexNumber > 0 && indexNumber <= ToDoItems.Count)
            {

                var unMarkedToDoItems = ToDoItems
                    .Where(t => !t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                var markedToDoItems = ToDoItems
                    .Where(t => t.Marked)
                    .OrderBy(t => t.Name)
                    .ToList();
                
                ToDoItem item = unMarkedToDoItems.Concat(markedToDoItems).ToList()[indexNumber - 1];
                
                Console.Clear();
                Console.WriteLine("You can see the item below: ");
                Console.WriteLine(new string('-', 25));
                Console.WriteLine(item.Name);
                Console.WriteLine(new string('-', 25));
                Console.Write("Please enter the new value: ");
                
                string updatedName = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(updatedName))
                {
                    Console.WriteLine("Invalid Input, press any key to return to the main menu. ");
                    Console.ReadKey();
                    return;
                }

                item.Name = updatedName;
            }
            else
            {
                Console.WriteLine("Invalid Input, press any key to return to the main menu. ");
                Console.ReadKey();
                return;     
            }
        }
    }   
}
