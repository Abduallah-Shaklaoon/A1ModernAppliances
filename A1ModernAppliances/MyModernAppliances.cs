using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// This program takes the input from the user when they want to parse through a data section of appliances. They will select their choice for which feature they wish to use then they will have to enter their choices accordingly.
    /// If the user selected checkout they have to enter a long ID number to find, and an output checks if it exists and is available to checkout
    /// If the user selected brand search, they enter a string which is sent to lower case to compare to brands, and all appliances belonging to that brand are displayed
    /// If the user selects appliance type choice, they get 4 more choices for refrigerators, vacuums, microwaves and dishwashers
    ///     If they select refrigerators they get prompted for the nuumber of doors and the refrigerators with matching door counts are displayed
    ///     If they select vacuums, they get prompted for voltage and vacuums with matching voltages are displayed
    ///     If they select microwaves, they get prompted for location type and vacuums with matching location types are displayed
    ///     If they select dishwashers, they get prompted for noise levels, and dishwashers with matching noise levels are displayed.
    /// If the user selects random appliance list theyare prompted for the number of random appliances to be shown and a list is printed accordingly
    /// Last option is to save the program data to a file and close the program
    /// </summary>
    /// <remarks>Author: Abduallah Shaklaoon </remarks>
    /// <remarks>Date: February 14</remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance:  ");

            // Create long variable to hold item number
            long? userItemNum;
        
            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            userItemNum = long.Parse(Console.ReadLine());

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            // Break out of loop (since we found what need to)
            foreach (var appliance in Appliances) 
            {
                if (appliance.ItemNumber == userItemNum)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if(foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.\n");
            }
            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance
            else if(foundAppliance.IsAvailable == true)
            {
                Console.WriteLine("Appliance \"{0}\" has been checked out.\n", foundAppliance.ItemNumber);
                foundAppliance.Checkout();
            }
            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.\n");
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter a brand to search for: ");

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string? userBrand = Console.ReadLine();
            // Create list to hold found Appliance objects
            List<Appliance> appliances = new List<Appliance>();
            // Iterate through loaded appliances
            foreach (var appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if ((appliance.Brand).ToLower() == userBrand.ToLower())
                {
                    // Add current appliance in list to found list
                    appliances.Add(appliance);
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            Console.WriteLine("Matching appliances:");
            DisplayAppliancesFromList(appliances, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");

            // Write "Enter number of doors: "

            // Create variable to hold entered number of doors
            string? userDoors;
            // Get user input as string and assign to variable
            userDoors = Console.ReadLine();
            // Convert user input from string to int and store as number of doors variable.
            int? numDoors = int.Parse(userDoors);
            // Create list to hold found Appliance objects
            List<Appliance> foundRefrierator = new List<Appliance>();
            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;
            Refrigerator? refrigerator;
            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list
            foreach (var appliance in Appliances)
            {
                if(appliance is Refrigerator)
                {
                    refrigerator = (Refrigerator)appliance;
                    if (numDoors == 0 || numDoors == (refrigerator).Doors)
                    {
                        foundRefrierator.Add(refrigerator);
                    }
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            Console.WriteLine("Matching refrigerators:");
            DisplayAppliancesFromList(foundRefrierator, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
            // Get user input as string
            // Create variable to hold voltage
            string? userVolt;
            userVolt = Console.ReadLine();
            int voltage;
            if (userVolt == "0")
            {
                voltage = 0;
            }
            else if( userVolt == "18")
            {
                voltage = 18;
            }
            else if (userVolt == "24")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            // Create found variable to hold list of found appliances.
            List<Appliance> foundVacuum = new List<Appliance>();
            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;
            Vacuum? vacuum;
            foreach(var appliance in Appliances)
            {
                if(appliance is Vacuum)
                {
                    vacuum = (Vacuum)appliance;
                    if (voltage == 0 || voltage == vacuum.BatteryVoltage)
                    {
                        foundVacuum.Add(vacuum);
                    }
                }
            }
            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            Console.WriteLine("Matching vacuums:");
            DisplayAppliancesFromList(foundVacuum, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"

            // Write "Enter room type:"
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
            // Get user input as string and assign to variable
            string? userInput = Console.ReadLine();
            // Create character variable that holds room type
            char? roomType;
            // Test input is "0"
                // Assign 'A' to room type variable
            // Test input is "1"
                // Assign 'K' to room type variable
            // Test input is "2"
                // Assign 'W' to room type variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method
                // return;
            if(userInput.ToLower() == "a")
            {
                roomType = 'A';
            }
            else if(userInput.ToLower() == "k") 
            {
                roomType = 'K';
            }
            else if(userInput.ToLower() =="w")
            {
                roomType = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> foundMicrowave = new List<Appliance>();
            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave
            Microwave? microwave;
            foreach(var appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    microwave = (Microwave)appliance;
                    if(roomType == 'A' ||  roomType == microwave.RoomType)
                    {
                        foundMicrowave.Add(microwave);
                    }
                }
            }
            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            Console.WriteLine("Matching microwaves:");
            DisplayAppliancesFromList(foundMicrowave, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");

            // Write "Enter sound rating:"
            string? userInput = Console.ReadLine();
            // Get user input as string and assign to variable

            // Create variable that holds sound rating
            //Branching if tree to check the input
            string? soundRating;
            if(userInput.ToLower() == "a")
            {
                soundRating = "Any";
            }
            else if( userInput.ToLower() == "qt")
            {
                soundRating = "Qt";
            }
            else if (userInput.ToLower() == "qr")
            {
                soundRating = "Qr";
            }
            else if(userInput.ToLower() == "qu")
            {
                soundRating = "Qu";
            }
            else if(userInput.ToLower() == "m")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            // Create variable that holds list of found appliances
            List<Appliance> foundDishwasher = new List<Appliance>();
            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher
            Dishwasher? dishwasher;
            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list
            foreach(var appliances in Appliances)
            {
                if(appliances is Dishwasher)
                {
                    dishwasher = (Dishwasher)appliances;
                    if(soundRating == "Any" ||  soundRating ==dishwasher.SoundRating)
                    {
                        foundDishwasher.Add(appliances);
                    }
                }
            }
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            Console.WriteLine("Matching dishwashers:");
            DisplayAppliancesFromList(foundDishwasher, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"
            // Get user input as string and assign to appliance type variable
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");
            // Get user input as string and assign to variable
            // Convert user input from string to int
            int userCount = int.Parse(Console.ReadLine());

            // Create variable to hold list of found appliances
            List<Appliance> foundAppliances = Appliances;


            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            foundAppliances.Sort(new RandomComparer());
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            Console.WriteLine("Random appliances: ");
            DisplayAppliancesFromList(foundAppliances, userCount);
        }
    }
}
