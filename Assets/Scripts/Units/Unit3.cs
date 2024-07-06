using System;
using UnityEngine;

namespace Units
{
    public class Unit3 : Unit, IConcreteUnit
    {
        public void Init(int power, int specCost, int baseCost, int ID)
        {
            InitBase(power, specCost, baseCost, ID);
            DoSomethingSpecific();
        }
        public void DoSomethingSpecific()
        {
            //Only for example
        }
    }
}
