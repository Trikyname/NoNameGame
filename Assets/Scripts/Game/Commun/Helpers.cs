using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Components;
using System;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase con diferentes funcionalidades comunes al juego y de empleo habitual
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Game.Scripts.Commun
{
    public static class Helpers
    {
        private static uint _id = 0;

        //Clase para generar un id unico de forma automatica. La almacena en esta clase static
        public static uint GetId()
        {
            _id++;

            if (_id > uint.MaxValue)
            {
                _id = 1;
            }

            return _id;
        }
        /**
         * Metodo de uso interno templatizado para crear una instancia de una clase dado su className y algunos parametros para
         * inicializarla segun su correspondiente constructor.
         */
        public static I CreateInstance<I>(string namespaceName, string className, params object[] someParams) where I : class
        {
            var typeClass = System.Type.GetType(namespaceName + className);
            return Activator.CreateInstance(typeClass, someParams) as I;
        }
        /**
         * Metodo para crear un BaseComponet desde un string con el className de cada uno.
         * Asumimos que el namespace es Constants.NE_COMPONENT
         */
        public static BaseComponent CreateComponentFromOneClassName(string className)
        {

                //Debug.Log("Value componente [" + value+ "]");
                          
            return Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, className, new object[] { });
        }
        /**
         * Metodo para crear una List<BaseComponet> desde una List<string> con el className de cada uno.
         */
        public static List<BaseComponent> CreateListComponentFromListClassName(List<string> className)
        {

            List<BaseComponent> comps = new List<BaseComponent>();
            foreach (string value in className)
            {
                //Debug.Log("Value componente [" + value+ "]");
                comps.Add(Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, value));
            }
            return comps;
        }
        /**
         * Metodo para crear una List<BaseComponet> desde una Array <string> con el className de cada uno.
         */
        public static List<BaseComponent> CreateListComponentFromListClassName(string[] className)
        {

            List<BaseComponent> comps = new List<BaseComponent>();
            foreach (string value in className)
            {
               // Debug.Log("Value componente [" + value+ "]");
                comps.Add(Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, value));
            }
            return comps;
        }
        /**
         * Metodo para crear un BaseComponet desde un string con el className dado.
         */
        public static BaseComponent CreateComponentFromClassName(List<string> classNames,string className)
        {

            List<BaseComponent> comps = new List<BaseComponent>();
            foreach (string value in classNames)
            {
                
                if (className== value) {
                    //Debug.Log("Value componente [" + value+ "]");
                    comps.Add(Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, value));
                    break;
                } 
               
            }
            return comps[0];
        }
        /**
         * Metodo para crear un BaseComponet desde un string con el className dado.
         */
        public static BaseComponent CreateComponentFromClassName(string[] classNames, string className)
        {

            List<BaseComponent> comps = new List<BaseComponent>();
            foreach (string value in classNames)
            {

                if (className == value)
                {
                    //Debug.Log("Value componente [" + value+ "]");
                    comps.Add(Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, value));
                    break;
                }

            }
            return comps[0];
        }
    }
}