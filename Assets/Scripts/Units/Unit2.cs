using System;
using UnityEngine;

namespace Units
{
    public class Unit2 : Unit, IConcreteUnit
    {
        public void Init(int power, int specCost, int baseCost)
        {
            InitBase(power, specCost, baseCost);
            DoSomethingUnusual();
        }
        public void DoSomethingUnusual()
        {
            //Only for example
        }
    }
}
