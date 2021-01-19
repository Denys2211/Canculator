﻿using System;
using System.Data;
using System.Linq;

namespace ConsoleApp
{
    class CalcFacade
    {
        Audit audit;
        Calculator calculator;
        internal CalcFacade(Audit audit,Calculator calculator)
        {
            this.audit = audit;
            this.calculator = calculator;
        }
        internal void Start()
        {
            for(; ; )
            {
                calculator.DataEntry(out string input, out string[] symbol);
                audit.CheckAvailability(input, out string verify);
                if (verify == "false")
                    continue;
                audit.CheckQuantity(input, symbol, out string verify1);
                if (verify1 == "false")
                    continue;
                audit.СheckNumericCharacter(input, symbol, out string verify2);
                if (verify2 == "false")
                    continue;
                calculator.Evaluate(input, out double result);
                calculator.OutputDisplay(result);
            }
        }
    }
}

