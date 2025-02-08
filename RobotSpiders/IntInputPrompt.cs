using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders
{
    internal class IntInputPrompt
    {
        /// <summary>
        /// Helper method to write out console prompt and read input.
        /// Tries to parse input to int and does not allow console to continue until int is entered.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="invalidInputMessage"></param>
        /// <returns>parsed input as int</returns>
        public static int InputPrompt(string prompt,string invalidInputMessage) 
        {
            bool inputNeeded = true;
            int parsedInput = 0;
            while (inputNeeded)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();
                if (int.TryParse(input, out parsedInput))
                {
                    inputNeeded = false;
                }
                else
                {
                    Console.WriteLine(invalidInputMessage);
                }
            }

            return parsedInput;
        }

        /// <summary>
        /// Helper method to write out console prompt and read input.
        /// Tries to parse input to int and does not allow console to continue until int is entered.
        /// lowerLimit and upperLimit provides range that input must be between.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="typeInvalidMessage"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <param name="notAcceptibleRangeMessage"></param>
        /// <returns>parsed input as int</returns>
        public static int InputPromptWithConstraints(string prompt, string typeInvalidMessage,int lowerLimit, int upperLimit, string notAcceptibleRangeMessage)
        {
            bool constraintsSatisfied = false;
            int input = 0;
            while (!constraintsSatisfied)
            {
                input = InputPrompt(prompt, typeInvalidMessage);
                constraintsSatisfied = input >= lowerLimit && input <= upperLimit;
                if (!constraintsSatisfied)
                {
                    Console.WriteLine(notAcceptibleRangeMessage);
                }
            }
            return input;
        }
    }
}
