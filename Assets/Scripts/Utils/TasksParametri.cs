using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase:
*  Clase static parametrizada ademas donde el parametro que puede recibir solo es de la clase MonoBehaviour
*  para realizar tareas, alternativa a Courrutines.
*  La clase es static pero dentro de ella se pueden realizar muchas instancias muchas tareas.
*  La clase tendra una lista static de Action<U> parametrizados.
*  La clase tiene un metodo para añadir nuevos elementos (Action<T>) de tipo Action parametrizados
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Utils
{
    public static class TasksParametri<T> 
    {
        #region variables publicas
        //podemos acotar los elementos que va a guardar esta lista indicandolo con un numero
        public static List<Task<T>> TasksListParametri = new List<Task<T>>(15);
        #endregion

        #region Metodos publico
        //Metodo static para añadir una tarea a la lista de tareas sin parametrizar
        public static void AddNewTask(float time, Action<T> _action)
        {
            time = Time.time;
            TasksListParametri.Add(new Task<T>(time,_action));
        }
        //Metodo static para hacer loop
        public static void Loop(T obj)
        {
            if (TasksFuncions.TasksList.Count == 0) return;

            //loop de las tareas. TODO: poner en un metodo diferente. O en el GameController
            foreach (TasksParametri<T>.Task<T> item in TasksParametri<T>.TasksListParametri)
            {

                if (Time.time > item._initialMoment)
                {
                    item._actionParametri.Invoke(obj);
                    TasksParametri<T>.TasksListParametri.Remove(item);
                    Debug.Log("SALIDA: Time.time: " + Time.time + " _initialMoment: " + item._initialMoment);
                    break;
                }

            }
        }
        #endregion

        #region Clases internas

        //clase interna para definir una tarea, donde Action esta parametrizado
        public class Task<U>
        {
            public float _initialMoment;
            public Action<U> _actionParametri;

            public Task()
            {
            }

            public Task(float initial, Action<U> action)
            {
                _initialMoment = Time.time+initial;
                _actionParametri = action;

                
            }
            //metodo de muestra para saber como se llama a un Action parametrizado
            void ejecutarActionParametrizado(U param) { 

                _actionParametri(param);
            }
        }
        #endregion
    }
}