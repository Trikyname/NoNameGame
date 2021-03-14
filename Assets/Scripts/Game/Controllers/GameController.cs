using Assets.Game.Scripts.Commun;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.DataBD;
using System.Collections.Generic;
using UnityEngine;

/**
*Descripcion de la clase: 
*Clase singleton<T> templatizada para controlar los aspectos generales del juego. 
*TODO: Debe saber cuando EntityController de tipo player (marcarlo como una interfaz: IPlayer) para saber cuantos jugadores estan en la
*sala
*
*TODO:
*Esta clase debe llamar a una clase de tipo SceneController que sera la que conozca cuantos enemigos
*(marcarlo con interfaz: IEnemy,IEnemyBoss,...) hay en esa escena
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        #region Propiedades
        public static GameController Self
        {
            get { return _self; }
        }

        #endregion

        private static GameController _self;
        //players y enemigos. Todos los EntityController del juego.
        [SerializeField] private EntityController [] _entityControllers=null;
        [HideInInspector]
        [SerializeField] private EntityData _entityData;
        [Tooltip("Nivel de juego")]
        [SerializeField]  private uint _level = 0;
        [Tooltip("Base de datos")]
        [SerializeField] private DataBD _dataBase = null;
        [Header("Todos los personajes del juego")]
        [Tooltip("GO del juego tanto player como enemigos")]
        [SerializeField]  public List<GameObject> _playersAndEnemies;//TODO:
        [Header("Prefab board hex")]
        [Tooltip("Camara principal")]
        [SerializeField]  private Camera _activeCam;
        

       
            
            private void Awake()
        {

            LogMessages.PrintMethoAndHour("Awake", this);
            if (Self == null)
            {

                _self = this;

                DontDestroyOnLoad(this);

            }
            //localizamos la camara
            _activeCam = FindObjectOfType<Camera>();
            /*
             * Se inicia la cargan todos los EntityDatas de juego
            *   _dataBase = FindObjectOfType<DataBD>(); Si no asociamos DataBD al GameController
            *   _dataBase =GetComponent<DataBD>(); Si asociamos DataBD al GameController
            *    _dataBase = DataBD.GetInstance(); Si es una instancia desde la clase
            */
            _dataBase = GetComponent<DataBD>();
            
;            _dataBase.Init();
            
            //localizamos la EntityController. TODO: Habrá tantos EntityController como player y enemigos hay
            _entityControllers = FindObjectsOfType<EntityController>();
            
            /*
             * Localizamos un Entity por el nameId proporcionado por el nameId que se le ponga desde el EDITOR
             * Inicializa cada EntityController y le pasamos el entityData que corresponda a cada EntityController
             */
            foreach (EntityController item in _entityControllers)
             {
                
                _entityData = _dataBase.GetCharacterDataByIdName(item.NameIdByEnum.ToString());
                //Debug.Log("_entityData " + _entityData.NameId);
                //le pasamos la Id
                item.Init(_entityData, _activeCam, _level, new object[] {Helpers.GetId()});
            }


            //Debug.Log("ID "+ DataBD.Instance._idDataBase);//TODO: No funciona, por que la clase no es static ¿?
            //Debug.Log("ID "+ _dataBase._idDataBase);//Si funciona, por que se accede atravez de una instancia ¿?

        }
        // Use this for initialization
        void Start()
        {
            LogMessages.PrintMethoAndHour("Start",this);
            
        }
        // Update is called once per frame
        void Update()
        {
            /**
             * Llama en cada frame al IOnUpdate de los player.
             * En los player, dentro de este metodo se recorre los componentes de cada player.
             * En este IOnUpdate se recorren todos los componentes y se llama a su metodo IUpday();
             * Dentro de cada IUpday de cada componente contendrá la logica del componente y actuará
             * como el metodo nativo del motor, es decir se llama en cada frame.
             */

            foreach (EntityController item in _entityControllers)
            {
                item.IOnUpdate();
            }
        }
        private void FixedUpdate()
        {
            /**
             * Llama en cada frame al IOnUpdate de los player.
             * En los player, dentro de este metodo se recorre los componentes de cada player.
             * En este IOnUpdate se recorren todos los componentes y se llama a su metodo IUpday();
             * Dentro de cada IUpday de cada componente contendrá la logica del componente y actuará
             * como el metodo nativo del motor, es decir se llama en cada frame.
             */

            foreach (EntityController item in _entityControllers)
            {
                item.IOnFixedUpdate();
            }
        }
        #region REGISTERS
        /***************************REGISTERS******************************/
        /**
         * Metodo para registrar el player en esta clase y que queda almacenada en una variable
         * desde la cual se tiene acceso por parte de todas las demas clases.
         * La suscripcion se hace desde el player
         */
        public static void RegisterSomething()
        {
            //nada implementado

        }
        #endregion


        #region MANAGER MESSAGE SYSTEM
        /*******************************MANAGER MESSAGE SYSTEM*************************************/
        /*En otra clase se crea un mensaje Tipo con los parametro que queremos enviar a otra nueva clase para
        * que pueda disponer de datos
        *  -cargamos los parametros en el mensaje.
        *  -enviamos el mensaje
        *  -sera recepcionado por el observer en otra clase
        */

        //_message.SetData(true, (int)GameEnums.NameClassGame.AutoLobby, 1, PhotonNetwork.IsConnected, PhotonNetwork.NickName, PhotonNetwork.CurrentRoom.Name, PhotonNetwork.IsMasterClient);

        //MessagesControllerMMS<MessageConectedMMS>.Post((int)GameEnums.MessagesTypes.ConectedMMS, _message);

        /*******Se crea un OBSERVER del MANAGER MESSAGE SYSTEM para recepcionar el mensaje TIPO conexion. TODO: Modo de prueba************/
        //Creamos la variable controller de mensajes especifica del TIPO de mensaje de conexion
        //MessagesControllerMMS<MessageConectedMMS>.AddObserver((int)GameEnums.MessagesTypes.ConectedMMS, OnPlayerConnected);
        //Aqui se crea el metodo OnPlayerConnected que recibe como parametro MessageConectedMMS que contiene los datos que necesitamos para actualizar esta clase

        #endregion


    }
}
