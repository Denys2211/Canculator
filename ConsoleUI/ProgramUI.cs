﻿using System;
using Calculator;
using Calculator.CustomerFacade.CoreModels;
using Calculator.CustomerFacade.Exceptions;

namespace ConsoleUI
{

    class ProgramUI
    {
        static void Main()
        {
            AppCalculator Canculator = new AppCalculator();
            Canculator.IDE.Notify += DisplayMessage;
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Select an operation:\n\t1 - Show calculation history\n\t2 - Expression calculation\n\t3 - To clean history\n\t4 - Show log");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 2:
                            Console.Write("Separated MatheXpression: ");
                            string input = Console.ReadLine();
                            double result = Canculator.IDE.Start(input);
                            Console.WriteLine($"Result calculations = {result}");
                            break;

                        case 1:
                            var history = Canculator.IDE.Calculation_history();
                            Console.WriteLine("Id_\t\tExpression\tResult\t\tDateTime");
                            Console.WriteLine(new string('_', 70));

                            foreach (History row in history)
                            {
                                Console.WriteLine($"{row.Id}\t{row.Expression}\t{row.Result}\t{row.DateTime}");
                                Console.WriteLine(new string('_', 70));
                            }
                            break;

                        case 3:
                            Canculator.IDE.Clean_Log();
                            break;

                        case 4:
                                Console.WriteLine(Canculator.IDE.ReadLogger());
                            break;

                        default:
                            throw new UserExceptions("Error!", choice);
                    }
                }
                catch (UserExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Incorect input: {ex.Value}");
                }
                catch (DataBExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CalcExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (AudExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("An error has occurred. Repeat the entry!");
                }
            }
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        }
}

