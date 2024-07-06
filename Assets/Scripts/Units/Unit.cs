using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        private int _power;
        private int _cost;
        protected int _baseCost;
        protected int _specialCost;

        public int ID { get; private set; }

        public void Init (int power, int specialCost, int baseCost, int ID)
        {
            _power = power;
            _specialCost = specialCost;
            _baseCost = baseCost;
            _cost = _baseCost;

            this.ID = ID; 
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
