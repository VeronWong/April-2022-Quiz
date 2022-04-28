using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuizTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "";
            while (input != "END")
            {
                Console.WriteLine("Type in END to stop.");
                Console.Write("Calculation : ");
                input = Console.ReadLine().TrimStart().TrimEnd();
                if (input.ToUpper() != "END")
                {
                    List<string> inputList = input.Split(" ").ToList();
                    List<string> tempList = new List<string>();
                    double value = 0;
                    int tempPost = 0;
                    double tempValue;
                    if (InputValidation(inputList))
                    {
                        inputList  = inputList.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                        while (inputList.Contains("/") || inputList.Contains("*"))
                        {
                            for (int j = 1; j < inputList.Count; j+=2)
                            {
                                if (inputList[j] == "/" || inputList[j] == "*")
                                {
                                    tempPost = j;
                                    break;
                                }
                            }

                            for (int i = 0; i < inputList.Count; i++)
                            {
                                if ((inputList[i] == "/" || inputList[i] == "*") && i == tempPost)
                                {
                                    if (inputList[i] == "/")
                                        tempValue = Division(Convert.ToDouble(inputList[i - 1]), Convert.ToDouble(inputList[i + 1]));
                                    else
                                        tempValue = Multiplication(Convert.ToDouble(inputList[i - 1]), Convert.ToDouble(inputList[i + 1]));
                                    tempList.Add(tempValue.ToString());
                                }
                                else
                                {
                                    if (i != tempPost - 1 && i != tempPost + 1)
                                        tempList.Add(inputList[i]);
                                }
                            }
                            inputList = tempList;
                            tempList = new List<string>();
                        }

                        while (inputList.Contains("+") || inputList.Contains("-"))
                        {
                            for (int j = 1; j < inputList.Count; j+=2)
                            {
                                if (inputList[j] == "+" || inputList[j] == "-")
                                {
                                    tempPost = j;
                                    break;
                                }
                            }

                            for (int i = 0; i < inputList.Count; i++)
                            {
                                if (i == tempPost)
                                {
                                    if (inputList[i] == "+")
                                        tempValue = Addition(Convert.ToDouble(inputList[i - 1]), Convert.ToDouble(inputList[i + 1]));
                                    else
                                        tempValue = Minus(Convert.ToDouble(inputList[i - 1]), Convert.ToDouble(inputList[i + 1]));
                                    tempList.Add(tempValue.ToString());
                                }
                                else
                                {
                                    if (i != tempPost - 1 && i != tempPost + 1)
                                        tempList.Add(inputList[i]);
                                }
                            }
                            inputList = tempList;
                            tempList = new List<string>();
                        }

                        if (inputList.Count == 1)
                        {
                            value = Convert.ToDouble(inputList[0]);
                        }

                        Console.WriteLine("Your answer in 4 decimal points : " + Math.Round(value, 4));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid inputs. Please try again");
                        Console.WriteLine();
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Thank you for using me.");
        }

        private static bool InputValidation(List<string> inputList)
        {
            for(int i = 0; i < inputList.Count; i++)
            {
                if(!Regex.IsMatch(inputList[i], @"^[0-9]+$"))
                {
                    if(!Regex.IsMatch(inputList[i], @"^[\+\-\*\/]+$"))
                        return false;
                }
            }
            return true;
        }

        private static double Division(double integerBefore, double integerAfter)
        {
            return integerBefore / integerAfter;
        }

        private static double Multiplication(double integerBefore, double integerAfter)
        {
            return integerBefore * integerAfter;
        }

        private static double Addition(double integerBefore, double integerAfter)
        {
            return integerBefore + integerAfter;
        }

        private static double Minus(double integerBefore, double integerAfter)
        {
            return integerBefore - integerAfter;
        }
    }
}
