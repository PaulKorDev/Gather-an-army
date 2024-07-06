using System;
using UnityEngine;

namespace Units
{
    public class Unit1 : Unit, IConcreteUnit
    {
        public void Init(int power, int specCost, int baseCost, int ID)
        {
            InitBase(power, specCost, baseCost, ID);
            DoSomethingUnically();
        }
        public void DoSomethingUnically()
        {
            //Only for example
        }
    }
}
