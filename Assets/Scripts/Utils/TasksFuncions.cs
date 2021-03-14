using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase:
*  Clase statica  para realizar tareas, alternativa a Courrutines.
*  La clase es static pero dentro de ella se pueden realizar muchas instanciar muchas tareas.
*  La clase tendra una lista de tareas static, es decir este listado es propio de la clase.
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Utils
{
    public static class TasksFuncions 
    {
        #region variables publicas
        //podemos acotar los elementos que va a guardar esta lista indicandolo con un numero
        public static List<TaskFunction> TasksList = new List<TaskFunction>(15);
        
        #endregion

        #region Metodos publico
        //Metodo static para añadir una tarea a la lista de tareas sin parametrizar
        public static void AddNewTask(float time, Action action) {
            
            TasksList.Add(new TaskFunction(time, action));
        }
        
        
        //Metodo static para hacer loop
        public static  void Loop() 
        {
            if (TasksFuncions.TasksList.Count == 0) return;

            //loop de las tareas. TODO: poner en un metodo diferente. O en el GameController
            foreach (TasksFuncions.TaskFunction item in TasksFuncions.TasksList)
            {
                
                if (Time.time > item._initialMoment)
                {
                    item._action();
                    TasksFuncions.TasksList.Remove(item);
                    //Debug.Log("SALIDA: Time.time: "+ Time.time + " _initialMoment: "+ item._initialMoment);
                    break;
                }
                
            }
        }
       
        #endregion

        #region Clases internas
        //clase interna para definir una tarea
        public class TaskFunction
        {
            public float _initialMoment;
            public Action _action;
            


            public TaskFunction()
            {
                //Desde cualquier parte del codigo podremos usar esta construccion de esta forma
                //Tasks.AddNewTask(1f, ejecutarActionSinParametrizado());
            }

            public TaskFunction(float initial, Action action)
            {
                _initialMoment = Time.time + initial;
                _action = action;
                
            }
            
            
            void ejecutarTareas() {

                foreach (TasksFuncions.TaskFunction item in TasksList)
                {
                    if (Time.time> item._initialMoment) {
                        item._action();
                        TasksList.Remove(item);
                        break;
                    }
                }
                
            }
        }
        
        #endregion
    }
}