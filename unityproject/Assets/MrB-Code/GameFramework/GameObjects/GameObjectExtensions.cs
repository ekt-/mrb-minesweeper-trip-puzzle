﻿using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.GameFramework.GameObjects
{
    /// <summary>
    /// Extension methods for game objects
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns all monobehaviours (casted to T)
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T[] GetInterfaces<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            var mObjs = gObj.GetComponents<MonoBehaviour>();

            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        /// <summary>
        /// Returns the first monobehaviour that is of the interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T GetInterface<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return gObj.GetInterfaces<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T GetInterfaceInChildren<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return gObj.GetInterfacesInChildren<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets all monobehaviours in children that implement the interface of type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T[] GetInterfacesInChildren<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

            var mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();

            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        /// <summary>
        /// Calls GameObject.Destroy on all children of transform. and immediately detaches the children
        /// from transform so after this call tranform.childCount is zero.
        /// </summary>
        public static void DestroyChildren(this GameObject gObj)
        {
            for (int i = gObj.transform.childCount - 1; i >= 0; --i)
            {
                Object.Destroy(gObj.transform.GetChild(i).gameObject);
            }
            gObj.transform.DetachChildren();
        }

        /// <summary>
        /// Get the path to the gameobject by iterating through the parent items.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static string GetPath(this GameObject current)
        {
            if (current.transform.parent == null)
                return "/" + current.name;
            return current.transform.parent.gameObject.GetPath() + "/" + current.name;
        }
    }
}