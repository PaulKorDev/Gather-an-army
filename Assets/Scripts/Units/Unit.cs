using UnityEngine;

namespace Units
{
    public abstract class Unit : MonoBehaviour
    {
        private int _power;
        private int _cost;
        protected int _baseCost;
        protected int _specialCost;

        protected void InitBase (int power, int specialCost, int baseCost)
        {
            _power = power;
            _specialCost = specialCost;
            _baseCost = baseCost;
            _cost = _baseCost;
        }

        public int GetCost() => _cost;

        public int GetPower() => _power;

        public void SetBaseCost()
        {
            _cost = _baseCost;
        }
        public void SetSpecialCost()
        {
            _cost = _specialCost;
        }
    }
}
