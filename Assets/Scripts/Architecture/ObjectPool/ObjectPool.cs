﻿using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Architecture.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        //Uncomment if using Assets.Scripts.Architecture.ReactiveProperty, and you will can to change pool limit dinamicaly.
        //public ReactiveProperty<int> PoolLimit;

        //Comment if using Assets.Scripts.Architecture.ReactiveProperty
        private int _poolLimit;
        public bool AutoExpand { get; set; }

        private readonly Func<T> _factory;
        private readonly Action<T> _returnEffect;
        private readonly Action<T, int> _getEffect;

        private Queue<T> _pool = new Queue<T>();
        private List<T> _activeObjects;

        public ObjectPool(List<T> activeObjects, Func<T> Factory, Action<T, int> GetEffect, Action<T> ReturnEffect, int precount, bool autoExpand = true, int poolLimit = 0)
        {
            _activeObjects = activeObjects;
            AutoExpand = autoExpand;
            _factory = Factory;
            _getEffect = GetEffect;
            _returnEffect = ReturnEffect;

            //Can uncomment if using Assets.Scripts.Architecture.ReactiveProperty
            //PoolLimit = new ReactiveProperty<int>(poolLimit);
            //PoolLimit.OnChanged += CheckPoolLimit;

            //Comment if using Assets.Scripts.Architecture.ReactiveProperty
            _poolLimit = poolLimit;

            CreatePool(precount);
        }


        public T GetObject(int ID)
        {
            if (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();       
                _getEffect(obj, ID);
                _activeObjects.Add(obj);
                return obj;
            } else if (AutoExpand)
            {
                T obj = CreateObject(ID, true);
                //CheckPoolLimit(PoolLimit.Value); //Uncomment if using Assets.Scripts.Architecture.ReactiveProperty
                CheckPoolLimit(_poolLimit); //Comment if using Assets.Scripts.Architecture.ReactiveProperty
                return obj;
            }
                
            Debug.LogError($"No free {typeof(T).Name} objects in pool");
            return null;
        }

        public List<T> GetAllObjects()
        {
            List<T> allObjects = new List<T>();

            foreach (T obj in _pool)
                allObjects.Add(obj);
            foreach (T obj in _activeObjects)
                allObjects.Add(obj);

            return allObjects;
        }
        public List<T> GetAllActiveObjects()
        {
            return _activeObjects;
        }

        public void ReturnObject(T obj)
        {
            _returnEffect(obj);
            _activeObjects.Remove(obj);
            _pool.Enqueue(obj);
        }
        public void ReturnAllActiveObjects()
        {
            foreach (T obj in _activeObjects)
            {
                _returnEffect(obj);
                _pool.Enqueue(obj);
            }
            _activeObjects.Clear();
        }

        public int CountFreeObjects()
        {
            return _pool.Count;
        }
        public int CountActiveObjects()
        {
            return _activeObjects.Count;
        }
        public int CountAllObjects()
        {
            return CountActiveObjects() + CountFreeObjects();
        }
        private void CheckPoolLimit(int currentPoolLimit)
        {
            int ObjectsInPoolCount = CountAllObjects();
            if (ObjectsInPoolCount < currentPoolLimit)
                AutoExpand = true;
            else if (ObjectsInPoolCount >= currentPoolLimit)
                AutoExpand = false;
            if (currentPoolLimit <= 0) //0 OR less mean that pool hasn't limit
                AutoExpand = true;
        }

        private void CreatePool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ReturnObject(CreateObject()); 
            }
        }

        private T CreateObject(int ID = 1, bool isActiveByDefault = false)
        {
            T createdObject = _factory();
            _getEffect(createdObject, ID);
            _activeObjects.Add(createdObject);
            return createdObject;

        }
    }
}
