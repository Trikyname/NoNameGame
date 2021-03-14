using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
/**
*Descripcion de la clase: 
********************Ejemplo de Metodos de Extension************
* 
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Utils
{
    public static class ExtensionMethods
    {

        /******Extension de un Vector2 con parametros****
         * Si le proporcionamos un Vector3 para comparar y ver si son iguales en XZ del Vector3 con XY del Vector2
         * Devuelve true o false
         */
        #region Extension Vector2
        public static bool EqualXZ(this Vector2 pos, Vector3 valueToComparate)
        {
                       
            return (pos.x == valueToComparate.x && pos.y == valueToComparate.z) ? true : false;
        }
        #endregion
        /******Extension de un float3 con parametros****
         * Si en el metodo static el parametro es un float3 y le ponemos delante -this-, podremos
         * usar este metodo en un float3 (siempre el metodo se emplea en el primer argumento, no siendo este necesario
         * para el propio metodo, el segundo parametro si será necesario ponerlo en el metodo)
         * Sive para cambiar el valor en Y solamente.
         */
        #region Extension de float3
        public static void ChangeY(this float3 pos, float value)
        {
            pos = new float3(pos.x, value, pos.z);
        }
        /*
        * Sive para cambiar el valor en X solamente.
         */
        public static void ChangeX(this float3 pos, float value)
        {
            pos = new float3(value, pos.y, pos.z);
        }
        /*
        * Sive para cambiar el valor en Z solamente.
         */
        public static void ChangeZ(this float3 pos, float value)
        {
            pos = new float3(pos.x, pos.y, value);
        }
        /*
         * Sirve para hacer int todos los float de un Vector3
         */
        public static float3 Float3RoundToInt(this float3 value)
        {
            value = new float3(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y), Mathf.RoundToInt(value.z));

            return value;
        }

        /*
         * Convierte un Vector3 a Float3
         */
        public static float3 Vector3ToFloat3(this Vector3 value)
        {

            return new float3(value.x, value.y, value.z);
        } 
        #endregion

        /******Extension de un Vector3 con parametros****
         * Si en el metodo static el parametro es un float3 y le ponemos delante -this-, podremos
         * usar este metodo en un Vector3 (siempre el metodo se emplea en el primer argumento, no siendo este necesario
         * para el propio metodo, el segundo parametro si será necesario ponerlo en el metodo)
         * Sive para cambiar el valor en Y solamente.
         */
        #region Extension de Vector3
        public static void ChangeY(this Vector3 pos, float value)
        {
            pos = new Vector3(pos.x, value, pos.z);
        }
        /*
        * Sive para cambiar el valor en X solamente.
         */
        public static void ChangeX(this Vector3 pos, float value)
        {
            pos = new Vector3(value, pos.y, pos.z);
        }
        /*
        * Sive para cambiar el valor en Z solamente.
         */
        public static void ChangeZ(this Vector3 pos, float value)
        {
            pos = new Vector3(pos.x, pos.y, value);
        }
        /*
         * Sirve para hacer int todos los float de un Vector3
         */
        public static Vector3 Vector3RoundToInt(this Vector3 value)
        {
            value = new Vector3(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y), Mathf.RoundToInt(value.z));

            return value;
        }
        /*
         * Sirve para hacer int todos los float de un Vector3, devuelve un Vector3Int
         */
        public static Vector3Int Vector3ToVector3Int(Vector3 value)
        {

            return new Vector3Int(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y), Mathf.RoundToInt(value.z)); ;
        }
        /*
        * Convierte un Float3 a Vector3
        */
        public static Vector3 Float3ToVector3(this float3 value)
        {

            return new Vector3(value.x, value.y, value.z);
        }
        #endregion

        /******Extension de un float con parametros*****/
        #region Extension de un float
        //Sirve para saber si dado un rango el numero se encuentra dentro de este rango
        public static bool IsRange(this float num, float range)
        {
           
                return (num > -range && num < range) ? true : false;
        }
        #endregion

        /******Extension de un async con parametros y sin parametros****
         * La diferencias entre la Courrutine y las Async es que las primeras no devuelven datos y las
         * segundas si.
         * Las courrutines usan yield return WaitFor.. para demorar la ejecucion de las siguientes lineas de codigo
         * Los Async usan TaskFunction.Delay() para demorar la ejecucion  de las siguientes lineas de codigo.
         * 
         * Existen dos tipos de async:
         * Tipo void-> no devuelve parametros [private async void MyMetodo(){}]
         * Tipo Task<>-> devuelve parametros [private async Task<int> MyMetodo(){}]
         * 
         * Si se llama a la funcion async void desde una funcion no async, se puede controllar las Exepciones
         * Si se llama a la funcion async Task<> desde una funcion no async, NO se puede controllar las Exepciones, en estos casos
         * lo que hay que hacer es tres opciones:
         * Opcion 1: La funcion no asyn llama a la funcion async void y dentro de esta se llama a la funcion asyn Task<>
         * Opcion 2: La funcion no asyn llama a la funcion async Task<> y se le pone awake antes. [awake funcionNoAsync();]
         * Opcion 3: Crear una extension de Task para que se le añada awake.
         */
        #region Extension para Asincronia
        //Sirve para convertir una funcion Async en una Courrutina
        public static IEnumerator  AsCourrutine(this Task task)
        {

            while (!task.IsCompleted) {
                yield return null;
            }
            if (task.IsFaulted) {
                throw task.Exception;
            }
        }

        //Sirve para convertir una funcion Async en una Courrutina
        public static async void WrapperError(this Task task)
        {
            await task;
            
        }
        //Sirve para hacer que un metodo async de tipo Task<> puede se ejecutado dentro de un metodo no asincrono
        public static async Task<bool> Wrapper(this Task<bool> task)
        {
            
            return await task;
        }
        #endregion

        #region Extension para pasar de Array a List y viceversa
        /******Extension para pasar de Array a List***
         * 
         */
        public static List<T> ConverterArrayToList<T>(this T[] value, int size)
        {
            List<T> list = new List<T>(size);
            foreach (var item in value)
            {
                list.Add(item);
            }
            return list;
        }
        public static object[] ConverterListToArray<T>(this List<T> value)
        {
            object[] array = new object [value.Count];
            
            for (int i = 0; i < value.Count; i++)
            {
                array[i]= value[i];
            }
            
            return array;
        }/**/

        #endregion
    }
}