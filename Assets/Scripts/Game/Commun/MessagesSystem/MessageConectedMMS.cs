using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
*Clase para crear un ***mensaje TIPO conexion*** del MANAGER MESSAGE SYSTEM, propio para notificar la conexion del jugador al servidor, el numero de room
* en el que esta y si es el anfitrion (es decir el que ha creado la room). 
* TODO: Completar la descripcion.
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun.MessaageSystem

{
    [System.Serializable]
    public class MessageConectedMMS : MessageMMS
    {
        public bool IsConected { get; protected set; }//cliente conectado
        public string NameClient { get; protected set; }//nombre del cliente
        public string NameRoom { get; protected set; }//numero de room
        public bool IsServer { get; protected set; }//que cliente es el que ha creado la room, es el server


        #region Constructores
        public MessageConectedMMS()
        {
        }

        public MessageConectedMMS(bool isLocal, uint senderId, uint clientId, bool isServer, bool isConected, string nameClient, string nameRoom)
        {
            IsLocal = isLocal;
            SenderId = senderId;
            ClientId = clientId;
            IsConected = isConected;
            NameClient = nameClient;
            NameRoom = nameRoom;
            IsServer = isServer;
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Metodo para establecer las variables que contiene este tipo de mensaje
        /// </summary>

        public void SetData(bool isLocal, uint senderId, uint clientId, bool isConected, string nameClient, string nameRoom, bool isServer)
        {
            IsLocal = isLocal;
            SenderId = senderId;
            ClientId = clientId;
            IsConected = isConected;
            NameClient = nameClient;
            NameRoom = nameRoom;
            IsServer = isServer;
        }
        /**
         * No usar un genrico ya que consume mucha memoria instanciar objetos en tiempo de ejecucion. 
         * Ademas es un caos de mensajeria sin definir los tipos
         */
        //public void SetData(params object[] args) {}

        #endregion
    }
}
