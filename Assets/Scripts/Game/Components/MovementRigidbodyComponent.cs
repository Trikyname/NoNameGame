using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Attribute;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase:
*  Clase para gestionar el movimiento del player
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components

{

    public class MovementRigidbodyComponent: BaseComponent
	{
		
        public float SpeedMove { get => _speedMove; set => _speedMove = value; }
        public Vector3 DirecctionMovement { get => _direcctionMovement; set => _direcctionMovement = value; }

        private float _moveY = 0;
		private float _moveX = 0;
		[Header("Movimiento")]//TODO: Determinar si va a ser con fisica o con transform
		[SerializeField]	private float _speedMove = 0;//usado para la velocidad de movimiento. Sera la velocidad de desplazamiento de objetos.
		[SerializeField]	private Vector2 _inputMove=Vector2.zero;//valor de movimiento del input. inicial valor 0
		[SerializeField] private Rigidbody2D _rigidbody = null;
        private EntityController _entityController;//CharacterAnimationComponent
		private CharacterAnimationComponent _characterAnimationComponent;
		private float _gravity = -9.8f;
		[SerializeField] private Vector3 _direcctionMovement;//direccion de movimiento. Importante para el movimiento de cubos.
		[Header("Transform")]
		private Transform _transform;

        

        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
		{
				LogMessages.PrintMethoAndHour("InitComponet", this);
				//siempre se inicia el componente dandole un id unico
				_entityId = (uint)arg[0];
				//cacheamos la transform
				this._transform = transform;
				this._rigidbody = transform.GetComponent<Rigidbody2D>();
				//obtenemos el valor de movimiento para asociarselo a EntityController
				float value = entityData.AttributeAndModifiersController.GetAttribute<MovementSpeedAttr>().Value;
				//Obtenemos el PlayersController
				this._entityController = _transform.GetComponent<EntityController>();
				//Obtenemos la velocidad desde PlayersController
				this._speedMove = value;
				Debug.Log("_speedMove: " + _speedMove);

			/**recorremos List<BaseComponent> para iniciar cada uno*/
			foreach (var bc in list)
				{
					if (bc is CharacterAnimationComponent && _characterAnimationComponent == null)
					{
					//cacheamos algunos que nos interesan en esta clase.
					_characterAnimationComponent = bc as CharacterAnimationComponent;


					}
				}

		}
		public override void IUpday(float value) {
			//movimiento con transform
			MoveAndLookByTransform(_inputMove);
		}

		public override void IFixedUpday(float value) {
			
		}

		public override void ISetData(params object[] arg)
		{
			
		}
		public override void IRefreshData(params object[] arg)
        {
			/**
			 * Recorremos el array de objetos que pueden tener diferente procedencia.
			 * Lo mas importante es que sean de diferentes tipos de clases o crear clases especificas
			 * para poder cachear los datos del array
			 */
            foreach (var _arg in arg)
            {
				if (_arg is Vector2 ) { 
					_inputMove = (Vector2)_arg ;
					//Debug.Log("_inputMoveX : " + _inputMove.x+ " _inputMoveY : " + _inputMove.y);
				}
            }
			
		}

        #region Metodos privados
        /**
		* Movimiento del jugador con transform. 
		* TODO: Desacoplar el valor procedente del imput (en este caso joystick) en otro componente.
		* Asi podriamos tener varios formas de imput (joystick, teclas, raton, gamepad,..)
		*/
        private void MoveAndLookByTransform(Vector2 inputMove)
		{
			
			_moveY = inputMove.y * _speedMove;
			//Debug.Log(" valor de _joystick.Horizontal: " + _joystick.Horizontal);
			_moveX = inputMove.x * _speedMove;
			//Debug.Log(" _moveX: " + _moveX+ " _moveY: " + _moveY+ " _transform.position: " + _transform.position);
			_transform.position += new Vector3(_moveX, _moveY,0 ) * Time.deltaTime;
			//_rigidbody.velocity += new Vector2(_moveX, _rigidbody.velocity.y) * Time.deltaTime;
			//_rigidbody.AddForce(new Vector2(_moveX, _rigidbody.velocity.y));
			//Debug.Log("Posicion del player: "+ transform.position);
			//direccion de movimiento
			DirecctionMovement = this._transform.position + new Vector3(_moveX, _moveY,0 );//una forma de expresar la direccion del player
			//DirecctionMovement = _transform.forward;//otra forma de expresar la direccion del player
			
			//reseteo el valor del input cuando finaliza la secuencia
			_inputMove = Vector2.zero;
			//Debug.Log("_moveY: " + _moveY + " _moveX: " + _moveX + " IRefreshData");
			//Debug.DrawLine(_transform.position, DirecctionMovement, Color.green);

            /*** - Animaciones de caminar ****/
            #region Animaciones
			/**
			 * Comprobado que si es mejor cambiar la animacion aqui que el  componente de control,
			 * ya que en este ultimo cuando se bloquea el movimiento la animacion depende del movimiento de stick
			 * y no es dependiente de que no se mueva el player
			 * 
			 */
				if (_characterAnimationComponent.Animator == null) return;
				//si el movimiento no es cero
				if (_moveY != 0 || _moveX != 0)
				{
					//animacion con tansicion idle->caminar
					//_characterAnimationComponent.IdleToRunAnimation();
				}
				else
				{
					//animacion con tansicion caminar->idle
					//_characterAnimationComponent.RunToIdleAnimation();
				} 
            #endregion

        }

		


		#endregion
	}
}
	
