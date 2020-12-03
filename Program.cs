using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Tracker
{
    // **************************************************
    //
    // Title: Fitness Tracker
    // Description: Gather body mass index information and workouts for the user within C#.
    // Application Type: Console
    // Author: Bode, Brandon
    // Dated Created: 11/18/2020
    // Last Modified: 12/03/2020
    //
    // **************************************************

    class Program
    {

        static void Main(string[] args)
        {
            DisplayReadandSetTheme();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        #region FITNESS TRACKER MAIN MENU

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;
            int height = 0, weight = 0, repsCompleted = 0, setsCompleted = 0;
            int bodymassindex = 0, totalReps = 0;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // Show menu and get input from user
                //
                Console.WriteLine("\ta) Record Height");
                Console.WriteLine("\tb) Record Weight");
                Console.WriteLine("\tc) Generate Body Mass Index");
                Console.WriteLine("\td) Evaluation of Body Mass Index");
                Console.WriteLine("\te) Suggested Workouts");
                Console.WriteLine("\tf) Sets and Reps Tracker");
                Console.WriteLine("\tg) Settings");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // gather user input and process with a switch case code block
                //
                switch (menuChoice)
                {
                    case "a":
                        height = RecordHeight();
                        break;

                    case "b":
                        weight = RecordWeight();
                        break;

                    case "c":
                        bodymassindex = GenerateBMI(height, weight);

                        break;

                    case "d":
                        EvalBMI(bodymassindex);
                        break;

                    case "e":
                        SuggestedWorkout(bodymassindex);
                        break;

                    case "f":
                        TrackRepsSets(repsCompleted, setsCompleted);
                        break;

                    case "g":
                        Settings(DisplayReadandSetTheme, DisplaySetNewTheme);
                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        #endregion
        #region TRACK REPS AND SETS
        /// <summary>
        /// Method of tracking reps and sets for user
        /// </summary>
        static void TrackRepsSets(int repsCompleted, int setsCompleted)
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;
            int totalReps = 0;
            

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // Show menu and get input from user
                //
                Console.WriteLine("\ta) Track Number of Sets");
                Console.WriteLine("\tb) Track Number of Reps");
                Console.WriteLine("\tc) View Sets and Reps");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // gather user input and process with a switch case code block
                //
                switch (menuChoice)
                {
                    case "a":
                        setsCompleted = TrackSets();
                        break;

                    case "b":
                        repsCompleted = TrackReps();
                        break;

                    case "c":
                        //doesnt work right
                        GenerateTracker(repsCompleted, setsCompleted);
                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
            
        }
        /// <summary>
        /// LOOK AT THIS
        /// </summary>
        /// <param name="repsCompleted"></param>
        /// <param name="setsCompleted"></param>
        /// <returns></returns>
        static int GenerateTracker(int repsCompleted, int setsCompleted)
        {
            int totalReps;

            DisplayScreenHeader("\t\tSets and Reps Tracker");

            Console.WriteLine("\tCongrats on fishing your workout!");
            Console.WriteLine();
            Console.WriteLine("\tLets look at what you have accomplished!");
            DisplayContinuePrompt();
            Console.WriteLine("\t\tPlease Wait...");
            LoadingDisplay();

            Console.WriteLine($"\t\tYou have completed {setsCompleted} sets!");
            Console.WriteLine($"\t\tYou have completed a total number of {totalReps = setsCompleted * repsCompleted} reps!");
            DisplayContinuePrompt();

            return totalReps;
        }

        /// <summary>
        /// Method used to track reps for user
        /// </summary>
        /// <returns></returns>
        static int TrackReps()
        {
            int repsCompleted;
            bool validReps = false;

            //
            // do while loop used to validate
            //
            do
            {
                DisplayScreenHeader("\t\tSets and Reps Tracker");

                Console.WriteLine();
                GetValidInteger("\tEnter the number of Reps completed: ", 0, 600, out repsCompleted);
                Console.WriteLine();

                Console.Write($"\tIs {repsCompleted} correct [ yes || no ]?");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    validReps = true;
                    Console.WriteLine();
                    Console.WriteLine("\tYour reps were saved into the Fitness Tracker.");
                }

            } while (!validReps);

            DisplayContinuePrompt();
            return repsCompleted;
        }

        /// <summary>
        /// Method used to track sets for user
        /// </summary>
        /// <returns>setsCompleted</returns>
        static int TrackSets()
        {
            int setsCompleted;
            bool validSets = false;

            //
            // do while loop used to validate
            //
            do
            {
                DisplayScreenHeader("\t\tSets and Reps Tracker");

                Console.WriteLine();
                GetValidInteger("\tEnter the number of sets completed: ", 0, 600, out setsCompleted);
                Console.WriteLine();

                Console.Write($"\tIs {setsCompleted} correct [ yes || no ]?");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    validSets = true;
                    Console.WriteLine();
                    Console.WriteLine("\tYour sets were saved into the Fitness Tracker.");
                }

            } while (!validSets);

            DisplayContinuePrompt();
            return setsCompleted;
        }
        #endregion

        #region SUGGESTED WORKOUT MENU
        static void SuggestedWorkout(int bodymassindex)
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // Show menu and get input from user
                //
                Console.WriteLine("\ta) Warmup and Stretch");
                Console.WriteLine("\tb) Cardio Training");
                Console.WriteLine("\tc) Weight Training");
                Console.WriteLine("\td) Diet Suggestions");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // gather user input and process with a switch case code block
                //
                switch (menuChoice)
                {
                    case "a":
                        Warmup();
                        break;

                    case "b":
                        CardioTraining(bodymassindex);
                        break;

                    case "c":
                        WeightTraining(bodymassindex);
                        break;

                    case "d":
                        DietSuggestion();
                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        /// <summary>
        /// Suggests Diets and foods to eat depending on whether the user wants to gain or lose weight
        /// </summary>
        static void DietSuggestion()
        {
            bool validResponse = true;
            string userResponse;
            //
            //Do loop used to read users response and respond accordingly
            //
            do
            {
                DisplayScreenHeader("\tDiet Suggestions");

                Console.WriteLine("\tAn important part of living a healthy life is your diet.");
                Console.WriteLine("\tLet the fitness tracker help you with your diet!");
                Console.WriteLine();
                DisplayContinuePrompt();

                Console.Clear();
                DisplayScreenHeader("\tDiet Suggestions");

                Console.Write("\tAre you trying to [ lose or gain ] weight? Please enter 'lose' or 'gain': ");
                userResponse = Console.ReadLine().ToLower();


                if (userResponse == "lose")
                {
                    validResponse = false;
                    string[] diets = { "Atkins", "Keto", "Paleo", "Low-fat", "Low-carb" };

                    Console.WriteLine("\t\tGenerating advice...");
                    LoadingDisplay();

                    Console.WriteLine("\tYou selected to lose weight.");
                    Console.WriteLine();
                    Console.WriteLine("\tSince you want to lose weight you should intake less calories then the daily average.");
                    Console.WriteLine();
                    Console.WriteLine("\tYou can also try a low carb diet, while also eating plenty of fruits and vegetables.");
                    Console.WriteLine();
                    Console.WriteLine("\tWith less calories and more physical activity you can lose up a few pounds a week!");
                    Console.WriteLine();
                    DisplayContinuePrompt();

                    DietDisplayTable(diets);
                }
                else if (userResponse == "gain")
                {
                    validResponse = false;
                    string[] foods = { "Protein Powder", "Rice", "Red Meats", "Pasta", "Potatoes", "Nuts and Seeds", "Chicken", "Eggs" };

                    Console.WriteLine("\t\tGenerating advice...");
                    LoadingDisplay();

                    Console.WriteLine("\tYou selected to gain weight.");
                    Console.WriteLine();
                    Console.WriteLine("\tSince you want to gain weight you should intake more calories then the daily average.");
                    Console.WriteLine();
                    Console.WriteLine("\tYou should eat high caloric food with plenty of carbohydrates and protein.");
                    Console.WriteLine();
                    DisplayContinuePrompt();

                    DietDisplayTable(foods);
                }
                else
                {
                    Console.WriteLine("Please enter 'lose' or 'gain'.");
                    DisplayContinuePrompt();
                }
            } while (validResponse);
        }

        /// <summary>
        /// Generates Weight Training Exercise Based on BMI
        /// </summary>
        /// <param name="bodymassindex"></param>
        static void WeightTraining(int bodymassindex)
        {
            DisplayScreenHeader("\tWeight Training Exercise");

            Console.WriteLine("\tThe Fitness Tracker will generate a weight training workout based on your BMI.");
            DisplayContinuePrompt();

            Console.WriteLine("Generating Workout...");
            LoadingDisplay();

            if (bodymassindex <= 24)
            {
                string[] weight = { "Back Squats (3-5 reps)", "Bench Press (3-5 reps)", "Lat Pull Down (10 reps)", "Bicep Curls (10 reps)", "Tricep Extensions (10 reps)", "Weighted Step Ups (10 reps)", "Shoulder Press (8-10 reps)", "Dumbell Flys (8-10 reps)", "Weighted Lunges (8-10 reps)" };
                DisplayTable(weight);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times using moderate to heavy weights.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 29 && bodymassindex >= 25)
            {
                string[] weight = { "Back Squats (8-10 reps)", "Bench Press (8-10 reps)", "Lat Pull Down (12 reps)", "Bicep Curls (12 reps)", "Tricep Extensions (12 reps)", "Weighted Step Ups (8-10 reps)", "Shoulder Press (10-12 reps)", "Dumbell Flys (10-12 reps)", "Weighted Lunges (10-12 reps)" };
                DisplayTable(weight);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times using light to moderate weight.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 39 && bodymassindex >= 30)
            {
                string[] weight = { "Back Squats (12-15 reps)", "Bench Press (12-15 reps)", "Lat Pull Down (10 reps)", "Bicep Curls (10 reps)", "Tricep Extensions (10 reps)", "Weighted Step Ups (6-10 reps)", "Shoulder Press (12-15 reps)", "Dumbell Flys (12-15 reps)", "Weighted Lunges (5-7 reps)" };
                DisplayTable(weight);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times using light weight.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 54 && bodymassindex >= 40)
            {
                string[] weight = { "Back Squats (15 reps)", "Bench Press (15 reps)", "Lat Pull Down (10 reps)", "Bicep Curls (10-12 reps)", "Tricep Extensions (10-12 reps)", "Shoulder Press (15 reps)", "Dumbell Flys (15 reps)", "Weighted Lunges (5 reps)" };
                DisplayTable(weight);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times with little to no weight.");
                Console.WriteLine("\t*** If you are unable to do an exercise try replacing it with an easier one or reduce reps ***");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
        }
        /// <summary>
        /// Generates Cardio Workout for User Based on BMI
        /// </summary>
        /// <param name="bodymassindex"></param>
        static void CardioTraining(int bodymassindex)
        {
            DisplayScreenHeader("\tCardio Training Exercise");

            Console.WriteLine("\tThe Fitness Tracker will generate a cardio workout based on your BMI.");
            DisplayContinuePrompt();

            Console.WriteLine("Generating Workout...");
            LoadingDisplay();

            if (bodymassindex <= 24)
            {
                string[] cardio = { "Jumping Jacks (50 reps)", "Jumping Lunges (30 reps)", "Burpees (20 reps)", "Mountain Climbers (40 reps)", "Squats (30 reps)", "Hop Overs (20 reps)", "Jumping Jacks (20 reps)", "Jumping Lunges (20 reps)", "Burpees (10 reps)" };
                DisplayTable(cardio);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three to five times.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 29 && bodymassindex >= 25)
            {
                string[] cardio = { "Jog in Place (1 min)", "Jumping Jacks (1 min)", "Power Knees (30 reps)", "Squat Jumps (20 reps)", "Jump Rope (30 reps)", "Plank (30 secs)" };
                DisplayTable(cardio);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 39 && bodymassindex >= 30)
            {
                string[] cardio = { "Jog in Place (30 secs)", "Jumping Jacks (20 reps)", "Squat Jumps (10 reps)", "Hop Overs (10 reps)", "Burpees (5 reps)" };
                DisplayTable(cardio);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times.");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 54 && bodymassindex >= 40)
            {
                string[] cardio = { "Jog in Place (15 secs)", "Jumping Jacks (10 reps)", "Squat Jumps (10 reps)", "Hop Overs (5 reps)", "Mountain Climbers (5 reps)" };
                DisplayTable(cardio);

                Console.WriteLine();
                Console.WriteLine("\tRepeat three times.");
                Console.WriteLine("\t*** If you are unable to do an exercise try replacing it with an easier one ***");
                Console.WriteLine("\tTake breaks when needed. Push yourself!");
                DisplayContinuePrompt();
            }
        }


        /// <summary>
        /// Warmup for user
        /// </summary>
        static void Warmup()
        {
            //
            //Array used to hold information for warmup
            //
            string[] warmups = { "Jumping Jacks (50 reps)", "Bodyweight Squats (20 reps)", "Lunges (10 reps)", "Hip Extensions (10 reps)", "Hip Rotations (10 reps)", "Foward Leg Swings (10 reps)", "Side Leg Swings (10 reps)", "Push-ups (10-20 reps)", "Spider-man Steps (5 reps)", };
            DisplayScreenHeader("\t\tWarmup and Stretch");

            Console.WriteLine("\tTo get started lets show you a warmup!");
            DisplayContinuePrompt();
            //
            // Display table headers
            //
            Console.WriteLine(
                "Warmup #".PadLeft(15) +
                "Exercise".PadLeft(15)
                );
            Console.WriteLine(
               "-----------".PadLeft(15) +
               "-----------".PadLeft(15)
               );

            //
            // display table data
            //

            for (int i = 0; i < warmups.Length; i++)
            {
                Console.WriteLine(
               (i + 1).ToString().PadLeft(15) + "    " +
               warmups[i].ToString().PadLeft(15)
               );
            }

            Console.WriteLine();
            Console.WriteLine("\t\t*** Change warmup reps to fit your needs ***");
            DisplayContinuePrompt();

        }

        /// <summary>
        /// Method for exercise table 
        /// </summary>
        /// <param name="prompt"></param>
        static void DisplayTable(string[] prompt)
        {
            Console.WriteLine(
                "Activity #".PadLeft(15) +
                "Exercise".PadLeft(15)
                );
            Console.WriteLine(
               "-----------".PadLeft(15) +
               "-----------".PadLeft(15)
               );

            //
            // display table data
            //

            for (int i = 0; i < prompt.Length; i++)
            {
                Console.WriteLine(
               (i + 1).ToString().PadLeft(15) + "    " +
               prompt[i].ToString().PadLeft(15)
               );
            }

            DisplayContinuePrompt();

        }
          
        /// <summary>
        /// Display table for diet and food
        /// </summary>
        /// <param name="prompt"></param>
        static void DietDisplayTable(string[] prompt)
        {
            Console.WriteLine(
               "Diet #".PadLeft(15) +
               "Name".PadLeft(15)
               );
            Console.WriteLine(
               "-----------".PadLeft(15) +
               "-----------".PadLeft(15)
               );

            //
            // display table data
            //

            for (int i = 0; i < prompt.Length; i++)
            {
                Console.WriteLine(
               (i + 1).ToString().PadLeft(15) + "    " +
               prompt[i].ToString().PadLeft(15)
               );
            }

            DisplayContinuePrompt();
        }
        #endregion
        #region GENERATE BMI WITH USER INPUT
        /// <summary>
        /// Evaluates BMI input and gives feedback based on BMI
        /// </summary>
        /// <param name="bodymassindex"></param>
        static void EvalBMI(int bodymassindex)
        {
            DisplayScreenHeader("\t\tEvaluate your BMI");

            Console.WriteLine("\tBMI stands for body mass index.");
            Console.WriteLine("\tIt is often used to determine weight category.");
            Console.WriteLine();
            DisplayContinuePrompt();
            Console.WriteLine($"\tThe BMI generated for you based on your height and weight was {bodymassindex}");
            Console.WriteLine();
            if (bodymassindex <= 24)
            {
                Console.WriteLine($"\tWith a BMI of {bodymassindex} you are considered to be Normal.");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 29 && bodymassindex >= 25)
            {
                Console.WriteLine($"\tWith a BMI of {bodymassindex} you are considered to be Overweight.");
                Console.WriteLine();
                Console.WriteLine("\tCorrecting your diet and increasing exercise you can lower your BMI.");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 39 && bodymassindex >= 30)
            {
                Console.WriteLine($"\tWith a BMI of {bodymassindex} you are considered to be Obese.");
                Console.WriteLine();
                Console.WriteLine("\tCorrecting your diet is a must.");
                Console.WriteLine("\tActivity levels need to be increased to keep you from getting severe health problems.");
                DisplayContinuePrompt();
            }
            if (bodymassindex <= 54 && bodymassindex >= 40)
            {
                Console.WriteLine($"\tWith a BMI of {bodymassindex} you are considered to be extremely obese.");
                Console.WriteLine();
                Console.WriteLine("\tA life change needs to happen to lower risk for heart disease and other severe health problems.");
                Console.WriteLine("\tA strict diet and exercise plan is needed.");

            }
            else
            {
                Console.WriteLine("\tError. Please recalculate your BMI.");
            }
        }

        /// <summary>
        /// Determine and save users bmi
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns>bodymassindex</returns>
        static int GenerateBMI(int height, int weight)
        {
            int bodymassindex;
            DisplayScreenHeader("\t\tGenerate Body Mass Index");

            Console.WriteLine($"\tThe height you entered was {height}.");
            Console.WriteLine($"\tThe weight you entered was {weight}.");
            Console.WriteLine();
            Console.WriteLine("\tThe Fitness Tracker is about to generate your BMI.");
            DisplayContinuePrompt();
            Console.WriteLine("\tGenerating BMI. Please wait.");

            for (int i = 0; i < 4; i++)
            {
                //countdown to simulate loading
                Console.WriteLine("\t\t\t{0}", i);
                System.Threading.Thread.Sleep(500);
            }

            Console.WriteLine();
            //
            //bmi = mass * 703 / height^2
            //
            Console.WriteLine($"\t\t\t\tBMI = {bodymassindex = weight * 703 / (height * height)}");
            DisplayContinuePrompt();

            return bodymassindex;
        }

        /// <summary>
        /// Gathers Weight from User
        /// </summary>
        /// <returns>weight</returns>
        static int RecordWeight()
        {
            int weight;
            bool validWeight = false;

            //
            // do while loop used to validate
            //
            do
            {
                DisplayScreenHeader("\t\tRecord Weight for Fitness Tracker");

                Console.WriteLine();
                GetValidInteger("\tEnter your weight in pounds as a whole number: ", 0, 600, out weight);
                Console.WriteLine();

                Console.Write($"\tIs {weight} the correct weight in pounds [ yes || no ]?");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    validWeight = true;
                    Console.WriteLine();
                    Console.WriteLine("\tYour weight was saved into the Fitness Tracker.");
                }

            } while (!validWeight);

            DisplayContinuePrompt();
            return weight;
        }

        /// <summary>
        /// Gathers the users height 
        /// </summary>
        /// <returns>height</returns>
        static int RecordHeight()
        {
            int height;
            bool validHeight = false;

            //
            //do while loop used for validation
            //
            do
            {
                DisplayScreenHeader("\t\tRecord Height for Fitness Tracker");

                Console.WriteLine();
                GetValidInteger("\tEnter your height in inches as a whole number: ", 0, 600, out height);
                Console.WriteLine();

                Console.Write($"\tIs {height} the correct height in inches [ yes || no ]?");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    validHeight = true;
                    Console.WriteLine();
                    Console.WriteLine("\tYour height was saved into the Fitness Tracker.");
                }

            } while (!validHeight);

            DisplayContinuePrompt();
            return height;
        }

        /// <summary>
        /// Method for Validation of Integers from User
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="validInteger"></param>
        /// <returns></returns>
        static int GetValidInteger(string prompt, int minimumValue, int maximumValue, out int validInteger)
        {
            bool validIntegers;

            do
            {
                Console.Write(prompt);
                //
                //If the user enters a zero or a number less than zero
                //they will be asked to input a valid integer
                //
                if (minimumValue <= 1 && maximumValue <= 0)
                {
                    validIntegers = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!validIntegers)
                    {
                        Console.WriteLine("\tPlease enter a valid integer.");
                    }
                }
                else
                {
                    validIntegers = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!validIntegers)
                    {
                        Console.WriteLine("\tPlease enter a valid integer value.");
                    }
                    else if (validInteger < minimumValue)
                    {
                        validIntegers = false;
                        Console.WriteLine("Please enter an integer that is greater then 0.");
                    }
                }
            } while (!validIntegers);

            return validInteger;
        }
        #endregion

        #region PERSISTENCE

        /// <summary>
        /// Settings for application. Change Theme
        /// </summary>
        /// <param name="displayReadandSetTheme"></param>
        /// <param name="displaySetNewTheme"></param>
        static void Settings(Action displayReadandSetTheme, Action displaySetNewTheme)
        {
            displayReadandSetTheme();
            DisplaySetNewTheme();
        }

        /// <summary>
        /// ***************************************************
        /// *       Read and Set Theme (Persistence)          *
        /// ***************************************************
        /// </summary>
        static void DisplayReadandSetTheme()
        {
            //set variables
            //
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            string fileIOStatusMessage;

            // read theme from data and set the theme
            themeColors = ReadThemeDataExceptions(out fileIOStatusMessage);
            if (fileIOStatusMessage == "Complete")
            {
                Console.ForegroundColor = themeColors.foregroundColor;
                Console.BackgroundColor = themeColors.backgroundColor;
                Console.Clear();

                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme read from the data file.\n");
            }
            else
            {
                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme was not successfully read from data file.");
                Console.WriteLine($"\t*** {fileIOStatusMessage} ***\n");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// ***************************************************
        /// *       Set New Console Theme Screen              *
        /// ***************************************************
        /// </summary>
        static void DisplaySetNewTheme()
        {
            //set and list variables
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;
            string fileIOStatusMessage;

            DisplayScreenHeader("Set the New Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.WriteLine("\tWould you like to change the current theme of the application [ yes | no ]?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    // query the user for console colors
                    // use a method to gather console colors
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    // Set the new theme the user selected
                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.WriteLine("\tIs this the new theme you would like to use?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        fileIOStatusMessage = WriteThemeDataExceptions(themeColors.foregroundColor, themeColors.backgroundColor);
                        if (fileIOStatusMessage == "Complete")
                        {
                            Console.WriteLine("\n\tNew theme was added to data file.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNew theme was not added to data file successfully.");
                            Console.WriteLine($"\t*** {fileIOStatusMessage} ***\n");
                        }
                    }
                } while (!themeChosen);
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// method for gathering console colors from user 
        /// </summary>
        /// <param name="property">foreground or background</param>
        /// <returns>user's console color</returns>
        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.WriteLine($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\t*** It appears you did not provide a valid console color. Please enter a valid console color. ***\n");
                }
                else
                {
                    validConsoleColor = true;
                }
            } while (!validConsoleColor);

            return consoleColor;
        }

        /// <summary>
        /// read theme info to data file with try/catch block
        /// returning a file IO status message using an out parameter
        /// </summary>
        /// <returns>tuple of foreground and background</returns>
        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeDataExceptions(out string fileIOStatusMessage)
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor = ConsoleColor.White;
            ConsoleColor backgroundColor = ConsoleColor.Black;

            //try catch used for validation
            try
            {
                themeColors = File.ReadAllLines(dataPath);
                if (Enum.TryParse(themeColors[0], true, out foregroundColor) &&
                    Enum.TryParse(themeColors[1], true, out backgroundColor))
                {
                    fileIOStatusMessage = "Complete";
                }
                else
                {
                    fileIOStatusMessage = "Data file incorrectly formated.";
                }
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to read data file.";
            }

            return (foregroundColor, backgroundColor);
        }

        /// <summary>
        /// write theme info to data file with try/catch block
        /// returning a file IO status message using an out parameter
        /// </summary>
        /// <returns>tuple of foreground and background</returns>
        static string WriteThemeDataExceptions(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";
            string fileIOStatusMessage = "";

            try
            {
                File.WriteAllText(dataPath, foreground.ToString() + "\n");
                File.AppendAllText(dataPath, background.ToString());
                fileIOStatusMessage = "Complete";
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to write to data file.";
            }

            return fileIOStatusMessage;
        }

        #endregion

        #region FITNESS TRACKER USER INTERFACE

        /// <summary>
        /// Set Up for Console Theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFitness Tracker");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Displays the Screen Header
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\t {headerText}");
            Console.WriteLine();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Fitness Tracker!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Display Continue Prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Method for a loading display
        /// </summary>
        static void LoadingDisplay()
        {
            for (int i = 0; i < 4; i++)
            {
                //countdown to simulate loading
                Console.WriteLine("\t\t\t{0}", i);
                System.Threading.Thread.Sleep(500);

            }
        }
    }
    #endregion
} 

