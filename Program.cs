namespace A1Ticketing
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read Ticket System.");
                Console.WriteLine("2) Add Ticket.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            
                            // display array data
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file, true);
                    char response;
                    do
                    {
                        Console.WriteLine("Enter Another Ticket (Y/N)?");
                        response = Convert.ToChar(Console.ReadLine().ToUpper());
                        if (response == 'N')
                            break;
                        Console.WriteLine("Enter Ticket ID: ");
                        string ID = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Summary: ");
                        string SUMMARY = Console.ReadLine();
                        Console.WriteLine("Enter Current Status (OPEN/CLOSED): ");
                        string STATUS = Console.ReadLine();
                        Console.WriteLine("Enter Level of Priority (LOW/HIGH): ");
                        string PRIORITY = Console.ReadLine();
                        Console.WriteLine("Enter Submitter's FULL NAME: ");
                        string SUBMITTER = Console.ReadLine();
                        Console.WriteLine("Enter FULL NAME of Assigned: ");
                        string ASSIGNED = Console.ReadLine();
                        char WATCHING;
                        string WATCH;
                        List<string> WATCHER = new List<string>();
                        do
                        {
                            Console.WriteLine("Enter Watching Names? (Y/N?)");
                            WATCHING = Convert.ToChar(Console.ReadLine().ToUpper());
                            if (WATCHING == 'N')
                                break;
                            WATCHER.Add(Console.ReadLine());
                        } while (WATCHING == 'Y');
                        WATCH = string.Join("|", WATCHER);
                        sw.WriteLine($"{ID},{SUMMARY},{STATUS},{PRIORITY},{SUBMITTER},{ASSIGNED},{WATCH}");
                    } while (response == 'Y');
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}