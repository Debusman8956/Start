using System.Text.RegularExpressions;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("input NAME & BIRTHDATE");



// 1. Ask the user for their name
Console.Write("Enter your name: ");
string name = Console.ReadLine();



// 2. Ask the user for their birthdate and validate the format (MM/dd/yyyy)
string birthDateInput;
DateTime birthDate;
while (true)
{
    Console.Write("Enter your birthdate (MM/dd/yyyy): ");
    birthDateInput = Console.ReadLine();
    
    // Check if the input matches the correct format using Regex
    if (Regex.IsMatch(birthDateInput, @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/(19|20)\d{2}$"))
    {
        // Try to parse the date to a DateTime object
        if (DateTime.TryParse(birthDateInput, out birthDate))
        {
            break;
        }
    }
    Console.WriteLine("Invalid date format. Please try again.");
}



// 3. Calculate the user's age based on their birthdate
int age = DateTime.Now.Year - birthDate.Year;
if (DateTime.Now < birthDate.AddYears(age)) // Check if birthday has passed this year
{
    age--;
}
Console.WriteLine($"Hello {name}, you are {age} years old.");



// 4. Save the user's info to a file called "user_info.txt"
string userInfo = "Name: " + name + "\nBirthdate: " + birthDateInput + "\nAge: " + age + "\n";
File.WriteAllText("user_info.txt", userInfo);
Console.WriteLine("User info saved to 'user_info.txt'.");



// 5. Read and show the content of "user_info.txt"
string fileContent = File.ReadAllText("user_info.txt");
Console.WriteLine("\nContents of 'user_info.txt':");
Console.WriteLine(fileContent);



// 6. Ask the user to enter a directory path
Console.Write("Enter a directory path: ");
string directoryPath = Console.ReadLine();



// 7. List all files in the specified directory
if (Directory.Exists(directoryPath))
{
    string[] files = Directory.GetFiles(directoryPath);
    Console.WriteLine("\nFiles in the specified directory:");
    foreach (string file in files)
    {
        Console.WriteLine(Path.GetFileName(file)); // Display only the file name
    }
}
else
{
    Console.WriteLine("The directory does not exist.");
}



// 8. Ask the user to enter a string
Console.Write("\nEnter a string: ");
string userString = Console.ReadLine();



// 9. Format the string to title case (first letter capitalized for each word)
string[] words = userString.ToLower().Split(' ');
for (int i = 0; i < words.Length; i++)
{
    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
}
string titleCaseString = string.Join(" ", words);
Console.WriteLine($"Formatted string in title case: {titleCaseString}");



// 10. Trigger garbage collection
GC.Collect();
GC.WaitForPendingFinalizers();
Console.WriteLine("Garbage collection triggered.");