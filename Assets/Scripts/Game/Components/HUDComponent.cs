using Assets.Gamepad;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Actions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
*Descripcion de la clase:
*Clase para extender la funcionalidad de la UI del player
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components

{
    public class HUDComponent : BaseComponent
    {
        #region propiedades publicas

        public Transform Transform { get => _transform; set => _transform = value; }
        public GameObject UICanvasPlayer { get => _uiCanvasPlayer; set => _uiCanvasPlayer = value; }
        public GamepadInput GamepadInput { get => _gamepadInput; set => _gamepadInput = value; }
        public Image IsPressedButton { get => _isPressedButton; set => _isPressedButton = value; }
        #endregion

        #region variables privadas

        [Header("Transform")]
        private Transform _transform = null;
        private EntityController _entityController = null;
        //hijos del canvas que representa la UI
        private List<GameObject> _uiGameByTypeOfCanvas = new List<GameObject>();
        private GameObject _uiCanvasPlayer;
        [SerializeField] private GamepadInput _gamepadInput;//ocupa el 6 lugar dentro del canvas de UI
        private InputControlComponent _controlPlayersComponent;
        private Image _isPressedButton;//GO de imagen para saber si se ha pulsado un boton
        private bool _isButtonPushORDragPressed;//para saber si el boton de empujar esta presionado.TODO: falta mostrar una imagen por boton pulsado
        private bool _isButtonClimbPressed;//para saber si el boton de subir esta presionado.TODO: falta mostrar una imagen por boton pulsado
        private bool _isButtonUsePressed;//para saber si el boton de usar esta presionado.TODO: falta mostrar una imagen por boton pulsado
        private bool _isButtonBackActionPressed;//para saber si el boton de volver a una accion anterior esta presionado.TODO: falta mostrar una imagen por boton pulsado


        #endregion

        #region Metodos sobreescritos de la clase BaseComponent

        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            //siempre se inicia el componente dandole un id unico, que corresponde con el IdPlayersController
            _entityId = (uint) arg[0];
            //cacheamos la transform
            this.Transform = transform;
            //Obtenemos el EntityController
            this._entityController = _transform.GetComponent<EntityController>();
            
            /*********************************************************************
             * Recorremos List<BaseComponent> para cachear los que nos interesen
             *********************************************************************/
            #region cacheo de componentes

            foreach (var bc in list)
            {
                if (bc is InputControlComponent && _controlPlayersComponent == null)
                {
                    //cacheamos algunos que nos interesan en esta clase.
                    _controlPlayersComponent = bc as InputControlComponent;
                }

            } 
            #endregion
        }
        
        public override void ISetData(params object[] arg)
        {
            foreach (var _arg in arg)
            {
                if (_arg is GameObject) { 
                    //recibimos el canvas UI del player controller
                   _uiCanvasPlayer = _arg as GameObject;
                    //se almacena todos los botones del player
                    ConfigurationControlUI(_uiCanvasPlayer);
                }
                //si se recibe es para saber si el boton de empujar esta presionado o no
                if (_arg is PushORDrag)
                {
                    //presionado/no presionado
                    _isButtonPushORDragPressed = ((PushORDrag)_arg)._isActing;
                    //activo/inactiva la imagen
                    _isPressedButton.gameObject.SetActive(_isButtonPushORDragPressed);
                }
                
                //si se recibe es para saber si el boton de usar esta presionado o no
                if (_arg is Use)
                {
                    //presionado/no presionado
                    _isButtonUsePressed = ((Use)_arg)._isActing; 
                    //activo/inactiva la imagen
                    _isPressedButton.gameObject.SetActive(_isButtonUsePressed);
                }
                //si se recibe es para saber si el boton de subir esta presionado o no
                if (_arg is Climb)
                {
                    //presionado/no presionado
                    _isButtonClimbPressed = ((Climb)_arg)._isActing;
                    //activo/inactiva la imagen
                    _isPressedButton.gameObject.SetActive(_isButtonClimbPressed);
                }
            }
            

            //Debug.Log("UICanvasPlayer: " + _uiCanvasPlayer.name);

        }

        public override void IRefreshData(params object[] arg)
        {
            //nada implementado
        }
        public override void IUpday(float value)
        {
            //nada implementado
        }

        #endregion
        public override void IFixedUpday(float value)
        {
            //nada implementado
        }
        
        #region Metodos privados
        //Almacenamos todos los controles tipo botones de la UI
        private void ConfigurationControlUI(GameObject canvasUI) {
            /***********************************************************
             * Recorremos el canvas UI para extraer todos los controles.
             ************************************************************/
            #region Obtencion de controles de UI
            foreach (Transform child2 in canvasUI.transform)
            {
                
                #region Controles de Becky
                //si corresponde al player1
                if (_entityController.NameId.Equals(GameEnums.NameIdCharacter.CharacterType1.ToString()))
                {
                    //Debug.Log("child2º: " + child2.name+ " _entityController.NamePlayer "+ PlayersController.NamePlayer);

                    //control de gamepad
                        _gamepadInput=child2.GetComponent<GamepadInput>();
                         //se envia el gamepad al ControlPlayerComponent
                        _controlPlayersComponent.ISetData(_gamepadInput);
                        //imagen para saber si se ha presionado un boton.
                        _isPressedButton = child2.GetComponent<Image>();
                        _isPressedButton.gameObject.SetActive(false);
                    /*if (child2.name.Equals(GameEnums.NameUICanvasGame.Gamepad_Becky.ToString()))
                    {
                        

                    }*/
                    
                } 
                #endregion
               

            }
            #endregion
        }

        #region Observadores
        //Metodo para escuchar cuando el player Entra en colision con un objeto
            /**
             * **************Secuencia para realizar el movimiento del cubo, animaciones y sonido*******************************
             * -El player es detectado que colisiona.
             * -Se halla la direccion de movimiento
             * -Se verifica que solo puede mover el cubo si se encuentra en la direccion de movimiento 
             * de su posible movimiento, marcado por FuturePosition
             * -Se verifica que ademas de estar en colision con el cubo, el player tiene el boton de empujar presionado
             * -Se carga una animacion pre empuje del cubo.
             * -Se carga un sonido pre empuje del cubo
             * -Se verifica que ademas de tener el boton pulsado y en contacto con el cubo, se tiene el strick en la direccion FuturePosition
             * -Se carga una animacion de empuje del cubo.
             * -Se carga un sonido de empuje del cubo
             * -Se produce el movimiento del cubo y del player. Este movimiento sera acorde al valor de desplazamiento del stick y 
             * con un modificador segun el material de cubo.
             */
        public void OnPlayerEnterInteraction()
        {
            //comprobamos hacia quien va dirigido el mensaje
        }
        //Metodo para escuchar cuando el player Sale en colision con un objeto
        public void OnPlayerExitInteraction( ) {
            //comprobamos hacia quien va dirigido el mensaje
              
        }

        #endregion
        #endregion
    }
}

