Console.WriteLine(DateTime.Now);

while (true) {
    Console.WriteLine("Enter a date (yyyy-mm-dd) or type \"exit\" to quit:");
    string input = Console.ReadLine();

    if (input.ToLower() == "exit") {
        break;
    }
    else {
        try {
            DateTime user_date = DateTime.ParseExact(input, "dd-MM-yyyy", null);

            DateTime today = DateTime.Now;

            if (user_date < today)
            {
                TimeSpan difference = today - user_date;
                Console.WriteLine($"{difference.Days} days have passed since {user_date:yyyy-MM-dd}.");
            }
            else if (user_date > today)
            {
                TimeSpan difference = user_date - today;
                Console.WriteLine($"{difference.Days} days remain until {user_date:yyyy-MM-dd}.");
            }
            else
            {
                Console.WriteLine($"{user_date:yyyy-MM-dd} is today.");
            }
        }
        catch (FormatException){
            Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
        }
    }
}