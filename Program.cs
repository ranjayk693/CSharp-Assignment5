using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000); 
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

//Defining AsyncWriteSystem which will perform the async write opertion on file(tmp.txt)
public class AsyncWriteSystem
{
    //Declaring a private member variable of type BackgroundOperation
    private readonly BackgroundOperation backgroundOperation;

    public AsyncWriteSystem()
    {
        //creating the instance of background opertion
        backgroundOperation = new BackgroundOperation();
    }

    //Method to perform file handling operation asynchronously 
    public async Task Run()
    {
        //Declearing a boolean value to run this file
        bool IsRun = true;
        while (IsRun)
        {
            Console.WriteLine("Please Select the one of the following option:");
            Console.WriteLine("1. Write 'Hello World'");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("4. Exit From the console");
            Console.WriteLine("Enter your choice (1, 2, , 3 or 4):");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await WriteOperationFile("Hello World");
                    break;
                case "2":
                    await WriteOperationFile(DateTime.Now.ToString());
                    break;
                case "3":
                    await WriteOperationFile(Environment.OSVersion.VersionString);
                    break;
                case "4":
                    IsRun = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    //Function to perform the write operation asynchrously 
    private async Task WriteOperationFile(string message)
    {
        try
        {
            await backgroundOperation.WriteToFileAsync(message);
            Console.WriteLine("Data written to file successfully!");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error occur while writing on the file");
        }
    }
}

//Main class
public class Program
{
    //async define the asynchrounous operation
    public static async Task Main(string[] args)
    {
        AsyncWriteSystem file_system = new AsyncWriteSystem();
        await file_system.Run();
    }
}
