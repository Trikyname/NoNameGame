using Assets.Gamepad;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Actions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/**
*Descripcion de la clase:
*  Clase para gestionar el control del input del player
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components

{

    public class InputControlComponent : BaseComponent
	{

        #region propiedades
        //public Joystick Joystick { get => _joystick; set => _joystick = value; }
        public bool MoveBlocked { get => _moveBlocked; set => _moveBlocked = value; }

        #endregion

        #region variables

        private float _moveZ = 0;
        private float _moveX = 0;
        [Header("Movimiento")]//TODO: Determinar si va a ser con fisica o con transform
        [SerializeField] private float _speedMove = 0;
        [SerializeField] private Vector2 _inputMove;
        [SerializeField] private GamepadController _controls = null;
        [SerializeField] private GamepadInput _gamepadInput = null;
        [SerializeField] protected bool _moveBlocked = false;//flag bloquear el movimiento del player
        private float movementY = 0;
        private float movementX = 0;
               
        [Header("Transform")]
        private Transform _transform = null;
        private EntityController _entityController = null;
        private MovementRigidbodyComponent _movePlayersComponent = null;
        private HUDComponent _uiComponent =null;
        private Vector2 _movement;
        private int index = 1;



        #endregion


        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
		{
            LogMessages.PrintMethoAndHour("InitComponet", this);
            //siempre se inicia el componente dandole un id unico
            _entityId = (uint)arg[0];
            //cacheamos la transform
            this._transform = transform;
           
            /*****************************************************************
             * recorremos List<BaseComponent> para cachear el que nos interesa
             *****************************************************************/
            foreach (var bc in list)
			{
					//cacheamos algunos que nos interesan en esta clase.
					if (bc is MovementRigidbodyComponent && _movePlayersComponent == null)
					{

						_movePlayersComponent = bc as MovementRigidbodyComponent;

					}
                                        
                    //cacheamos algunos que nos interesan en esta clase.
                    if (bc is HUDComponent && _uiComponent == null)
                    {

                        _uiComponent = bc as HUDComponent;

                    }
                    
            }
			//Obtenemos el PlayersController
			this._entityController = _transform.GetComponent<EntityController>();

            

        }

        public override void ISetData(params object[] arg)
		{
            foreach (var _arg in arg)
            {
                
                if (_arg is GamepadInput)
                {
                    //obtenemos la clase que instancia GamepadController desde el parametro.
                    _gamepadInput = (GamepadInput)_arg;
                    //le damos el mismo nombre que al player. Solo para ver en el Editor
                    _gamepadInput.Name = _entityController.NameId;
                    //obtenemos el GamepadController que se instancia en la clase GamepadInput
                    _controls = _gamepadInput.Controls;
                    //llamamos al metodo propio de esta clase, para suscribimos evento  para leer el valor del stick derecho
                    //no se hace en OnEnable del Players Controller por que aun no se ha iniciado este componente
                    this.IOnEnable();

                }

            }
            
        }

		public override void IRefreshData(params object[] arg)
		{
			
		}
		public override void IUpday(float value)
		{
			//actualiza la posicion de input
			CurrentValueInput();
		}

		public override void IFixedUpday(float value)
		{

		}

        public override void IOnEnable()
        {
            _controls.Gamepad.Enable();
            //si el player es el que suscribimos evento  para leer el valor del **stick derecho**
            if (_entityController.NameId.Equals(GameEnums.NameIdCharacter.CharacterType1.ToString()))
            {
                _controls.Gamepad.Right_Stick.performed += context => DoMovement(context);// una forma de hacerlo
                //_controls.Gamepad.Right_Stick.performed += MovementAndRotation;//otra forma de hacerlo
                _controls.Gamepad.Right_Stick.canceled += context => DoMovement(context);

                _controls.Gamepad.R1.performed += context => Use(context);// boton R1
                _controls.Gamepad.R1.canceled += context => Use(context);// boton R1
                _controls.Gamepad.R2.performed += context => PushORDrag(context);// boton R2
                _controls.Gamepad.R2.canceled += context => PushORDrag(context);// boton R2
                _controls.Gamepad.Cross.performed += context => Climb(context);// boton X
                _controls.Gamepad.Cross.canceled += context => Climb(context);// boton X
                
            }
            
            //controles comunes
            _controls.Gamepad.Triangle.performed += context => Back(context);// boton Triangulo
            _controls.Gamepad.Triangle.canceled += context => Back(context);// boton Triangulo
            /**/

        }

        public override void IOnDisable()
        {
            _controls.Gamepad.Disable();
            //si el player es Hope suscribimos evento  para leer el valor del **stick derecho**
            if (_entityController.NameId.Equals(GameEnums.NameIdCharacter.CharacterType1.ToString()))
            {
                _controls.Gamepad.Right_Stick.performed -= context => DoMovement(context);// una forma de hacerlo
                //_controls.Gamepad.Right_Stick.performed += MovementAndRotation;//otra forma de hacerlo
                _controls.Gamepad.Right_Stick.canceled -= context => DoMovement(context);

                _controls.Gamepad.R1.performed -= context => Use(context);// boton R1
                _controls.Gamepad.R1.canceled -= context => Use(context);// boton R1
                _controls.Gamepad.R2.performed -= context => PushORDrag(context);// boton R2
                _controls.Gamepad.R2.canceled -= context => PushORDrag(context);// boton R2
                _controls.Gamepad.Cross.performed -= context => Climb(context);// boton X
                _controls.Gamepad.Cross.canceled -= context => Climb(context);// boton X

            }
            
            //controles comunes
            _controls.Gamepad.Triangle.performed -= context => Back(context);// boton Triangulo
            _controls.Gamepad.Triangle.canceled -= context => Back(context);// boton Triangulo
            /**/


        }

        #region Metodos privados
        
        //Metodo para obtener el valor de desplazamiento del stick del gamepad. Este metodo está suscrito a un Action [performed]
        public void DoMovement(InputAction.CallbackContext context)
        {

            Move value = new Move(_entityId, context.control.IsPressed());
            //obtenemos el valor del stick
            _movement = context.ReadValue<Vector2>();
            //informamos al componente de interaccion del valor de movimiento, nombre del control y si esta o no presionado
            //_interactionPlayersComponent.ISetData(value, _movement, context.control.IsPressed());

            /*Debug.Log(" move: " + _movement +
             " _movePlayersComponent.DirecctionMovement: " + _entityController.transform.forward.Vector3RoundToInt());*/
                        
            //solo permitimos 2 IsPressed
            if (index>2) {
                index = 1;
            }
            /**/
            
             

        }
        //Metodo para saber si se ha pulsado el boton del gamepad. Este metodo está suscrito a un Action [canceled]
        public void PushORDrag(InputAction.CallbackContext context)
        {
            
            //informamos al componente de interaccion si el boton push esta presionado
            PushORDrag value = new PushORDrag(_entityId, context.control.IsPressed());
           //_interactionPlayersComponent.ISetData(value, context.control.name);
            //informamos al componente de UI si el boton push esta presionado
            _uiComponent.ISetData(value, context.control.name);
            //siempre que dejamos de pulsar se para la animacion
            if (context.control.IsPressed()==false) {
                //mensaje envia para cambiar la animacion de push, el movimiento  desbloqueado
                /*MessageStopPushItemMMS _messageStopPushItemMMS = new MessageStopPushItemMMS();
                _messageStopPushItemMMS.SetData(
                    true,
                    _entityId,//id del player
                    _entityId,//id del player
                    false,//movimiento bloqueado/desbloqueado
                    EnumsGame.NameAnimations.Pushing.ToString(),//animacion empujar
                    EnumsGame.NameSounds.Pushing.ToString());//sonido empujar
                                                             //enviamos este tipo de mensaje
                MessagesControllerMMS<MessageStopPushItemMMS>.Post((int)EnumsGame.MessagesTypes.MessageStopPushItemMMS, _messageStopPushItemMMS);
                */
            }
            //obtenemos si el es pulsado o no el boton
            //Debug.Log("DoPushORDrag: " + context.control.IsPressed());

        }
        
        private void Back(InputAction.CallbackContext context)
        {
            //informamos al componente de interaccion si el boton push esta presionado
            Back value = new Back(_entityId, context.control.IsPressed());
            //_interactionPlayersComponent.ISetData(value, context.control.name);
            //informamos al componente de UI si el boton push esta presionado
            _uiComponent.ISetData(value, context.control.name);
            //Debug.Log("DoBack: " + context.control.IsPressed());
        }

        private void Climb(InputAction.CallbackContext context)
        {
            
            //informamos al componente de interaccion si el boton Climb esta presionado
            Climb value = new Climb(_entityId, context.control.IsPressed());
            //_interactionPlayersComponent.ISetData(value, context.control.name);
            //informamos al componente de UI si el boton push esta presionado
            _uiComponent.ISetData(value, context.control.name);
            //Debug.Log("Climb: " + context.control.IsPressed());
        }

        

        private void Use(InputAction.CallbackContext context)
        {
            
            //Debug.Log("Use: " + context.control.IsPressed());
        }

        /**Proporciona el valor de los controles. TODO: incluir los demas controles*/
        private void CurrentValueInput()
        {
            
            //comprobamos si el movimiento esta bloqueado, y si es asi, no se pasa informacion sobre los controles
            if (_moveBlocked == true) return;
            
            /********************
              * Control Gamepad
              ********************/
            #region Control Gamepad
            if (_movement == null) return;//TODO: Mirar estos return
            _movePlayersComponent.IRefreshData(_movement);
            #endregion

            /********************
             * Control Teclado
             ********************/
            #region Control Player
            if (_entityController.NameIdByEnum.Equals(GameEnums.NameIdCharacter.CharacterType1.ToString()))
            { 
                //TODO: Mirar por que no se cumple esta condicion
                Debug.Log("_entityController.NameIdByEnum : "+ _entityController.NameIdByEnum+ "--- GameEnums.NameIdCharacter.CharacterType1: " + GameEnums.NameIdCharacter.CharacterType1.ToString());
            
            }
                
                /**Control de un player01**/
                /*if (Input.GetKey(KeyCode.W))
                {
                    movementY = 1f;
                    _movePlayersComponent.IRefreshData(new Vector2(0, movementY));

                }
                if (Input.GetKey(KeyCode.S))
                {

                    movementY = -1f;
                    _movePlayersComponent.IRefreshData(new Vector2(0, movementY));
                }*/
                if (Input.GetKey(KeyCode.A))//izquierda
                {
                    movementX = -1f;
                    _movePlayersComponent.IRefreshData(new Vector2(movementX, 0));
                    //Debug.Log("Izquierda: "+ movementX);
                }
                if (Input.GetKey(KeyCode.D))//derecha
                {
                    movementX = +1f;
                    _movePlayersComponent.IRefreshData(new Vector2(movementX, 0));
                    //Debug.Log("Derecha: " + movementX);
                }
                
                if (Input.GetKey(KeyCode.Space))//salto
                {
                    movementY = 1f;
                    _movePlayersComponent.IRefreshData(new Vector2(0, movementY));
                    Debug.Log("Saltando...");
                }
                if (Input.GetKey(KeyCode.F))//ataque
                {

                    Debug.Log("Atacando...");
                }
                if (Input.GetKey(KeyCode.E))//lanzar
                {

                    Debug.Log("Lanzando...");
                }
                /*
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {

                    movementY = -1f;
                    movementX = -1f;
                    _movePlayersComponent.IRefreshData(new Vector2(movementX, movementY));
                }
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    movementY = 1f;
                    movementX = 1f;
                    _movePlayersComponent.IRefreshData(new Vector2(movementX, movementY));
                }
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    movementY = -1f;
                    movementX = 1f;
                    _movePlayersComponent.IRefreshData(new Vector2(movementX, movementY));
                }*/
            
            #endregion

        }

        #region Metodos de acciones
        
        
        #endregion
        #endregion


        #region Metodos nativo de Unity

        public void OnDisable()

        {
            //llamamos al metodo propio de esta clase desde PlayersController
            this.IOnDisable();

        }
        #endregion
    }
}
	
