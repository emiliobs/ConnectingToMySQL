using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cupCoffee = PourCofee();
            Console.WriteLine("Coffee is ready.");

            var eggssTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggssTask, baconTask, toastTask };

            while(breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggssTask)
                {
                    Console.WriteLine("Eggs are ready.");
                }
                else if(finishedTask == baconTask)
                {
                    Console.WriteLine("Bacon is ready.");
                }
                else if(finishedTask == toastTask)
                {
                    Console.WriteLine("Toas is ready.");
                }

                breakfastTasks.Remove(finishedTask);
            }

            var cupJuice = PourJuice();
            Console.WriteLine("Juice is ready.");
            Console.WriteLine("breakfast is ready.");

            Console.WriteLine("*****   sincrono   ******");

            var cup = PourCofee();
            Console.WriteLine("Cofee is ready");

            var eggs = FryEggs(2);
            Console.WriteLine("Eggs are ready");

            var bacon = FryBacon(3);
            Console.WriteLine("Bacon is ready");

            var toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toas is ready");

            var juice = PourJuice();
            Console.WriteLine("Juice is ready");

            Console.WriteLine("Breakfast is ready");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }


        private static  async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster.");
            }

            Console.WriteLine("Start toasting....");
            await Task.Delay(3000);

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Putting {slices} slices of bacon in the pan");
            Console.WriteLine("Cooking first of bacon....");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg>  FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan.....");
            await Task.Delay(3000);
            Console.WriteLine($"Cracking  {howMany} eggs");
            Console.WriteLine("Cooking the eggs ......");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on the plate");

            return new Egg();
        }

        private static Juice PourJuice()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private  static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast.");
        }

        private  static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster.");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"Putting {slices} slices of bacon in the pan");
            Console.WriteLine("Cooking firts side bacon...");
            Task.Delay(300).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("fliing a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }


        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the pan.....");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Craking {howMany} eggs");
            Console.WriteLine("Cooking the eggs....");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCofee()
        {
            Console.WriteLine("pouring coffee");
            return new Coffee();
        }



    }
}
