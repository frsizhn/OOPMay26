using System;

class Program
{
    static void Main(string[] args)
    {

        double[] temp = new double[10];
        int[] time = new int[10];
        
        char locationChoice;
        

        do {
            Console.WriteLine("\n--- ENTER DATA FOR LOCATION ---");
            

            for(int i = 0; i < 10; i++) {
                Console.Write($"Enter temperature {i + 1}: ");
                temp[i] = Convert.ToDouble(Console.ReadLine());
                
                Console.Write($"Enter time (minute) {i + 1}: ");
                time[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            char menuChoice;
            bool keepGoing = true;
            

            while(keepGoing) {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("a) Compute min and max");
                Console.WriteLine("b) Compute avg");
                Console.WriteLine("c) Get all temperature greater than a threshold");
                Console.WriteLine("d) Reread the data");
                Console.WriteLine("e) Exit this location");
                Console.Write("Enter choice: ");
                
                string input = Console.ReadLine();
                menuChoice = string.IsNullOrEmpty(input) ? ' ' : input[0];
                
                if(menuChoice == 'a' || menuChoice == 'A') {
                    double minVal = temp[0];
                    double maxVal = temp[0];
                    int minTime = time[0];
                    int maxTime = time[0];
                    
                    for(int i = 1; i < 10; i++) {
                        if(temp[i] < minVal) {
                            minVal = temp[i];
                            minTime = time[i];
                        }
                        if(temp[i] > maxVal) {
                            maxVal = temp[i];
                            maxTime = time[i];
                        }
                    }
                    Console.WriteLine($"Min Temperature: {minVal} at {minTime} mins");
                    Console.WriteLine($"Console.WriteLineMax Temperature: {maxVal} at {maxTime} mins");
                }
                else if(menuChoice == 'b' || menuChoice == 'B') {
                    double sum = 0;
                    for(int i = 0; i < 10; i++) {
                        sum += temp[i];
                    }
                    Console.WriteLine($"Average Temperature: {sum / 10.0}");
                }
                else if(menuChoice == 'c' || menuChoice == 'C') {
                    Console.Write("Enter threshold value: ");
                    double limit = Convert.ToDouble(Console.ReadLine());
                    
                    Console.WriteLine($"Temperatures higher than {limit}:");
                    for(int i = 0; i < 10; i++) {
                        if(temp[i] > limit) {
                            Console.WriteLine($"- Temp: {temp[i]} at {time[i]} mins");
                        }
                    }
                }
                else if(menuChoice == 'd' || menuChoice == 'D') {
                    Console.WriteLine("\n--- Rereading 10 data points ---");
                    for(int i = 0; i < 10; i++) {
                        Console.Write($"Enter temperature {i + 1}: ");
                        temp[i] = Convert.ToDouble(Console.ReadLine());
                        Console.Write($"Enter time (minute) {i + 1}: ");
                        time[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else if(menuChoice == 'e' || menuChoice == 'E') {
                    keepGoing = false; // Breaks the menu loop
                }
                else {
                    Console.WriteLine("Invalid choice!");
                }
            }
            
            Console.Write("\nDo you want to go to another location? (y/n): ");
            string locInput = Console.ReadLine();
            locationChoice = string.IsNullOrEmpty(locInput) ? 'n' : locInput[0];
            
        } while(locationChoice == 'y' || locationChoice == 'Y');
        
        Console.WriteLine("Program ended.");
    }
}
