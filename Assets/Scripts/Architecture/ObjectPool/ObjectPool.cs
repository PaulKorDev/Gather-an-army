﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Architecture.Reactive;

namespace Assets.Scripts.Architecture.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        //Uncomment if using Assets.Scripts.Architecture.ReactiveProperty, and you will can to change pool limit dinamically.
        //public ReactiveProperty<int> PoolLimit;

        //Comment if using Assets.Scripts.Architecture.ReactiveProperty
        private int _poolLimit;
        public bool AutoExpand { get; set; }

        private readonly Func<T> _factory;
        private readonly Action<T> _returnEffect;
        private readonly Action<T, int> _getEffect;

        //private List<T> _freeObjects = new List<T>();
        private Queue<T> _freeObjects = new Queue<T>();
        private ReactiveList<T> ActiveObjects;

        public ObjectPool(ReactiveList<T> activeObjects, Func<T> Factory, Action<T, int> GetEffect, Action<T> ReturnEffect, int precount, bool autoExpand = true, int poolLimit = 0)
        {
            ActiveObjects = activeObjects;
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

        #region Get and Return methods
        public T GetObject(int ID)
        {
            if (_freeObjects.Count > 0)
            {
                T obj = _freeObjects.Dequeue();
                _getEffect(obj, ID);
                ActiveObjects.Add(obj);
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
        public void ReturnObject(T obj)
        {
            _returnEffect(obj);
            ActiveObjects.Remove(obj);
            _freeObjects.Enqueue(obj);
        }
        public void ReturnAllActiveObjects()
        {
            for (int i = ActiveObjects.Count - 1; i >= 0; i--)
            {
                T obj = ActiveObjects.GetElement(i);
                _returnEffect(obj);
                _freeObjects.Enqueue(obj);
            }
            ActiveObjects.Clear();
        }
        #endregion


        #region Count methods
        public int CountFreeObjects()
        {
            return _freeObjects.Count;
        }
        public int CountActiveObjects()
        {
            return ActiveObjects.Count;
        }
        public int CountAllObjects()
        {
            return CountActiveObjects() + CountFreeObjects();
        }
        #endregion
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
            ActiveObjects.Add(createdObject);
            return createdObject;

        }

    }
}
