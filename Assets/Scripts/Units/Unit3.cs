using System;
using UnityEngine;

namespace Units
{
    public class Unit3 : Unit, IConcreteUnit
    {
        public void Init(int power, int specCost, int baseCost)
        {
            InitBase(power, specCost, baseCost);
            DoSomethingSpecific();
        }
        public void DoSomethingSpecific()
        {
            //Only for example
        }
    }
}
