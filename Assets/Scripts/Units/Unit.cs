using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        private int _power;
        private int _cost;
        private int _baseCost;
        private int _specialCost;
        private int _id;

        public void Init (int power, int specialCost, int baseCost, int ID)
        {
            _power = power;
            _specialCost = specialCost;
            _baseCost = baseCost;
            _cost = _baseCost;
            _id = ID;
        }

        public int GetID() => _id;

        public int GetCost() => _cost;

        public int GetPower() => _power;

        public void SetBaseCost() => _cost = _baseCost;
        
        public void SetSpecialCost() => _cost = _specialCost;
        
    }
}
