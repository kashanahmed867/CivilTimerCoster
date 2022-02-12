using System;

namespace CivilTimerCoster
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = "y";
            while (option == "y")
            {
                // var i_houses = 1;
                Console.WriteLine("******************************");
                Console.WriteLine("Welcome to Civil Timer Coster!");
                Console.WriteLine("------------------------------");
                Console.WriteLine("User Input Section");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Set initial no of workers:");
                var i_workers = Console.ReadLine();
                Console.WriteLine("Set initial no of days which worker requires to build single house:");
                var i_days = Console.ReadLine();
                Console.WriteLine("Set salary of worker per day:");
                var i_salary_per_day = Console.ReadLine();

                // get usefull information from the user
                Console.WriteLine("Enter no of workers available:");
                var a_worker = Console.ReadLine();
                Console.WriteLine("Enter no of house required to build:");
                var r_houses = Console.ReadLine();
                Console.WriteLine("Enter builtup area of single house in square feets (ft^2):");
                var r_area = Console.ReadLine();
                Console.WriteLine("Enter approximately cost per square feet:");
                var r_cost = Console.ReadLine();
                Console.WriteLine("Enter your budget amount:");
                var a_budget = Console.ReadLine();

                // single worker needs = number of days * number of workers
                var work_time = Int32.Parse(i_days) * Int32.Parse(i_workers);

                // rate of work for single house
                var rate_of_work = 1 / work_time;

                // require days to complete single house with available workers
                var r_days = work_time / Int32.Parse(a_worker);

                // require days to complete all houses with available workers
                var r_days_final = r_days * Int32.Parse(r_houses);

                // require amount to build single house
                var r_salary = r_days * Int32.Parse(i_salary_per_day);

                // require total amount to build all houses
                var r_salary_final = r_days_final * Int32.Parse(i_salary_per_day);

                // require material cost to build single house
                var h_cost = Int32.Parse(r_cost) * Int32.Parse(r_area);

                // require material cost to build all houses
                var h_cost_final = h_cost * Int32.Parse(r_houses);

                // print the results
                Console.WriteLine("------------------------------");
                Console.WriteLine("Time & Cost Estimation Section");
                Console.WriteLine("------------------------------");
                Console.WriteLine($"There are {r_days} days required to build single house, and {r_days_final} days are required to build all houses.");
                Console.WriteLine($"There is Rs{r_salary}. amount required to build single house, and Rs{r_salary_final}. total amount is required to build all houses.");
                Console.WriteLine($"There is Rs{h_cost}. material cost required to build single house, and Rs{h_cost_final}. total material cost is required to build all houses.");

                // calculating construction cost
                Console.WriteLine("------------------------------");
                Console.WriteLine("Total Cost Details Section");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Approximate cost on various work of material as per thumb rule:");
                Console.WriteLine($"Cement (16.4 %): Rs{h_cost_final / 100 * 16.4}.");
                Console.WriteLine($"Sand (12.3 %): Rs{h_cost_final / 100 * 12.3}.");
                Console.WriteLine($"Aggregate (7.4 %): Rs{h_cost_final / 100 * 7.4}.");
                Console.WriteLine($"Steel (24.6 %): Rs{h_cost_final / 100 * 24.6}.");
                Console.WriteLine($"Finishers (16.5 %) (Paint (4.1 %) + Tiles (8.0 %) + Bricks (4.4 %)): Rs{h_cost_final / 100 * 16.5}.");
                Console.WriteLine($"Fittings (22.8 %) (Window (3.0 %) + Doors (3.4 %) + Plumbing (5.5 %) + Eletrical (6.8 %) + Sanitary (4.1 %)): Rs{h_cost_final / 100 * 22.8}.");

                Console.WriteLine("------------------------------");
                Console.WriteLine("Final Result Section");
                Console.WriteLine("------------------------------");
                // showing result if budget is good to start construction or how many houses you can construct within budget amount
                if (Int32.Parse(a_budget) >= (r_salary_final + h_cost_final))
                {
                    Console.WriteLine("Congratulation! You can start construction with your available budget.");
                }
                else if (Int32.Parse(a_budget) <= 0)
                {
                    Console.WriteLine("Sorry! You need to clear previous cost first.");
                }
                else
                {
                    // houses can construct within the available budget
                    var b_houses = Int32.Parse(a_budget) / (r_salary_final + h_cost_final);
                    Console.WriteLine("Sorry! You cannot start construction within your available budget.");
                    Console.WriteLine($"But you can build {b_houses} houses with your budget.");
                }

                // check if user want calculate for again or not
                Console.WriteLine("\nDo you want to run again? Enter y/n");
                option = Console.ReadLine();
            }
        }
    }
}
