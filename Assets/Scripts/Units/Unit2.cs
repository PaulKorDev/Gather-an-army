using System;
using UnityEngine;

namespace Units
{
    public class Unit2 : Unit
    {
        public void Init(int power, int specCost, int baseCost)
        {
            InitBase(power, specCost, baseCost);
            DoSomethingUnusual();
        }
        public void DoSomethingUnusual()
        {
            Debug.Log(String.Concat("I am super ", ToString()));
        }
    }
}
