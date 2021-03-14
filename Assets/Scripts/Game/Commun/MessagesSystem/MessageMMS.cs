/**
 *Descripcion de la clase: 
 *Clase abstracta para crear un mensaje dentro del MANAGER MESSAGE SYSTEM, que es el sistema
 * de mensajeria que permite notificar a las diferentes clases acciones y reacciones. 
 * TODO: Completar la descripcion.
 *Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun.MessaageSystem

{
    [System.Serializable]
    public abstract class MessageMMS
    {

        /// <summary>
        /// IsLocal: Completar.
        /// 
        /// SenderId:
        /// Clase que manda el mensaje para que la clase que lo reciba sepa de su procedencia. Este id estara almacenado en un enum
        /// global para todo el game.
        /// 
        /// ClientId:
        /// Identificador unico asociado al cliente que manda el mensaje, para saber que cliente envia el mensaje para online.
        /// Ejemplo. Puede ocurrir que una misma clase de dos jugadores diferentes manda el mensaje informando a una clase tipo GameManager
        /// que esta suscrito al MMS y receciona el mensaje de todos los player que se unen al juego.
        /// 
        /// </summary>
        public bool IsLocal { get; protected set; }//si debe enviarse fuera de la aplicacion es decir a la red
        public uint SenderId { get; protected set; }//que entidad/clase ha mandado el mensaje. Recomendado que cada clase tenga un id
        public uint ClientId { get; protected set; }//que cliente esta usando el mensaje


        #region Constructores
        //Por defecto
        public MessageMMS()
        {

        }

        protected MessageMMS(bool isLocal, uint senderId, uint clientId)
        {
            IsLocal = isLocal;
            SenderId = senderId;
            ClientId = clientId;

        }

        #endregion

    }
}
