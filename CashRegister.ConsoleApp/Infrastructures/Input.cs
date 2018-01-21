using System;

namespace CashRegister.ConsoleApp.Infrastructures
{
    public static class Input
    {
        public static bool ReadBool(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return ReadBool();
        }

        public static bool ReadBool ()
        {
            string input = Console.ReadLine();
            bool value;

            while (!bool.TryParse(ValidateInputForBool(input), out value))
            {
                Output.DisplayPrompt("Please enter [Y]es or [N]o");
                input = Console.ReadLine();
            }

            return value;
        }

        private static string ValidateInputForBool(string input)
        {
            if (input.ToLower() == "y")
                return "true";
            else if (input.ToLower() == "n")
                return "false";
            else
                return input;
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static double ReadDouble(string prompt, double min, double max)
        {
            Output.DisplayPrompt(prompt);
            return ReadDouble(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static double ReadDouble(double min, double max)
        {
            double value = ReadDouble();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter a double between {0} and {1} (inclusive)", min, max);
                value = ReadDouble();
            }

            return value;
        }

        public static double ReadDouble()
        {
            string input = Console.ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an double");
                input = Console.ReadLine();
            }

            return value;
        }

        public static int ReadInt()
        {
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}
