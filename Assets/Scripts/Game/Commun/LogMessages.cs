using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 ****Descripcion de la clase****
 *Clase que sirve para mostrar un Log que incluye el nombre de la clase
 *que lo ejecuta y ademas almacena este texto en un contenedor para su posterior revision.
 *      TODO:
 *  Que se muestre tipos de mensajes como de error, infor, warning
 *  Que el contenedor almacene por tipos de mensajes (error, info, warning,...).
 *  
 *Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public static class LogMessages
    {
        //Contenedor de mensajes logs del juego, para revision.
        private static List<string> _logsTexts = new List<string>();
        //Contenedor de mensajes logs del juego, para revision.
        private static List<string> _logsTextsWarning = new List<string>();

        //Muestra un LogDebug y los almacena en el contenedor
        public static void PrintLogDebug(string text, System.Object clase)
        {
            string _text = text + ":" + clase.GetType().ToString();
            //Si el contenedor de LogsTexts no es nulo almacena el log
            if (_logsTexts != null)
            {
                _logsTexts.Add(text);
            }

            Debug.Log(_text);
        }
        public static void PrintMethoAndHour(string metodo, System.Object clase) {
            string text = metodo + " [" + clase.GetType().ToString() + "] " + DateTime.Now;
            //Si el contenedor de LogsTexts no es nulo almacena el log
            if (_logsTextsWarning != null)
            {
                _logsTextsWarning.Add(text);
            }
            //Los ponemos en un warning para filtrar en el Editor
            Debug.LogWarning(text);
        }

    }
}