﻿using System;
using UnityEngine;

namespace Units
{
    public class Unit1 : Unit
    {
        public void Init(int power, int specCost, int baseCost)
        {
            InitBase(power, specCost, baseCost);
            DoSomethingUnically();
        }
        public void DoSomethingUnically()
        {
            Debug.Log(String.Concat("I am ", ToString()));
        }
    }
}
