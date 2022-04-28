using System;
using System.Collections.Generic;
using System.Linq;

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
                input = Console.ReadLine();
                if(input.ToUpper() != "END")
                {
                    List<string> inputList = input.Split(" ").ToList();
                    double value = 0;
                    List<string> tempList = new List<string>();
                    int tempPost = 0;
                    double tempValue;

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

                    Console.WriteLine("Your answer : " + value);
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Thank you for using me.");
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
