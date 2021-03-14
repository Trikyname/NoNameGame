
using System;
using System.Collections.Generic;
/**
*Descripcion de la clase: 
*   -Clase static para controlar los mensajes que se envian entre clases dentro del MANAGER MESSAGE SYSTEM.Se permite 
*   notificar a las diferentes clases acciones y crear la logica a estas dando lugar una respuesta. 

*   -Esta clase tiene un Dictionary con Key=int (coincide con el int de un enum para saber que tipo de mensaje), Value=List<Action<T>> ( lista
* que almacena a su vez Action parametrizados [Actition<T>])
*   -Esta clase tiene un metodo para añadir elementos a Dictionary.
*   -Esta clase tiene un metodo para eliminar elementos de Dictionary.
*   -Esta clase tiene un metodo para eliminar todos los elementos de Dictionary.
*   -Esta clase tiene un metodo Post que busca en Dictionary segun recibe un Key (1 argumento del metodo), el Value, este 
*    es una List<Action<T>>. Hallado esta List, la recorremos para encontrar el elemento de la misma, que
*    coincide con el 2 argumento del metodo Post. De esta forma localizamos la Action<T> concreta segun 1 y 2 argumento del metodo Post.
*    
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun.MessaageSystem

{
    public static class MessagesControllerMMS<U>
    {
        private static Dictionary<int, List<Action<U>>> messagesTable = new Dictionary<int, List<Action<U>>>();

        //Metodo para suscribirse para recibir mensajes
        public static void AddObserver(int messageType, Action<U> handler)
        {

            List<Action<U>> _list = null;
            //Si en la coleccion de mensajes no se encuentra la lista de acciones, no existe, instanciamos una nueva y la añadimos
            if (!messagesTable.TryGetValue(messageType, out _list))
            {

                _list = new List<Action<U>>();
                messagesTable.Add(messageType, _list);
            }
            //Si en la lista de acciones no se encuentra la accion, la añadimos
            if (!_list.Contains(handler))
            {

                messagesTable[messageType].Add(handler);
            }
        }
        //Metodo para desuscribirse de recibir mensajes
        public static void RemoveObserver(int messageType, Action<U> handler)
        {

            List<Action<U>> _list = null;
            //Si en la coleccion de mensajes se encuentra la lista de acciones, si exite
            if (messagesTable.TryGetValue(messageType, out _list))
            {

                //Si en la lista de acciones  se encuentra la accion, la eliminamos
                if (_list.Contains(handler))
                {

                    messagesTable[messageType].Remove(handler);
                }

            }


        }
        //Metodo para enviar los mensajes
        public static void Post(int messageType, U param)
        {

            List<Action<U>> _list = null;
            //Si en la coleccion de mensajes se encuentra la lista de acciones, si exite
            if (messagesTable.TryGetValue(messageType, out _list))
            {
                //Si la lista ademas no tiene ningun contenido, salimos de este metodo
                if (_list.Count == 0) return;
                /*
                 * Este for recorre la lsita desde el ultimo elemento al primero (al reves de como suele ocurrir) para
                 * elimianar primero el ultimo de los añadidos. Ultimo en entrar Primero en salir.
                */
                for (int i = _list.Count - 1; i > -1; i--)
                {

                    _list[i](param);
                }

            }


        }
        //Metodo para eliminar un elemento de la colleccion por el tipo de mensaje 
        public static void ClearMessageTable(int messageType)
        {


            //Si en la coleccion de mensajes se encuentra la lista de acciones, si exite
            if (messagesTable.ContainsKey(messageType))
            {
                //Elimina un elemento de la coleccion por el tipo de mensaje
                messagesTable.Remove(messageType);
            }


        }
        //Metodo para eliminar todos los elementos de la colleccion 
        public static void ClearMessageTable()
        {


            //Si en la coleccion de mensajes se encuentra la lista de acciones, si exite
            if (messagesTable != null)
            {
                //Elimina un elemento de la coleccion por el tipo de mensaje
                messagesTable.Clear();
            }


        }

    }
}
