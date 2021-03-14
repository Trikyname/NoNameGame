using Assets.Game.Scripts.Commun;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Components;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.DataBD;
using Assets.Scripts.Game.Datas.Device;
using System;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
*Clase para controlar todas la Entities, sea Enemigo, Player, Enemigo tipo boss,...etc
*
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Controllers
    
{   
    [System.Serializable]
    public class EntityController : MonoBehaviour, IControllerable, IEntity, IHitableCharacter, ITarget
    {
        #region propiedades publicas

        public string NameId { get; set; }
        public GameEnums.NameIdCharacter NameIdByEnum { get; set; }
        #endregion

        #region variables privadas

        [Header("Caracteristicas")]
        [Tooltip("GameObject del player")]
        [SerializeField] private GameObject _characterAttachedGO = null;//Prefab asociado al EntityController
        [Tooltip("Id del player")]
        [SerializeField] private uint _characterId;//id unico que identifica a las EntityControllers
        [Tooltip("Entity del player")]
        [SerializeField] private EntityData _entityData = null;//Datos de la Entidad
        [Tooltip("Nombre del player")]
        [SerializeField] private string _nameId;//Nombre del EntityController con correspondencia con NameId de su EntityData
        [Tooltip("Nombre del player")] 
        [SerializeField] private GameEnums.NameIdCharacter _nameIdByEnum;//Nombre del EntityController con correspondencia con NameId de su EntityData. Para el Editor
        [SerializeField] private List<BaseComponent> _components = new List<BaseComponent>(12);//Lista de componentes
        [SerializeField] private List<BaseDevice> _devices = new List<BaseDevice>(10);//Lista de devices
        [Tooltip("Camara")]
        [SerializeField] private Camera _activeCam = null;//Camara
        [Tooltip("Canvas IU del player")]
        [SerializeField] private GameObject _uiCanvasPlayer;//canva de la UI del player
        
        [Header("Animacion")]
        [Tooltip("Animacion del player")]
        [SerializeField] private Animator _animator = null;
        
        [Header("Fisica")]
        [Tooltip("Fuerza de salto")]
        [SerializeField] private float _force = 50;
        [Tooltip("Rigidbody del player")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;//Transform asociado al EntityController
        [Tooltip("Nivel")]
        [SerializeField] private uint _level = 0;
        
        [Header("Estado")]
        [Tooltip("Pausado")]
        [SerializeField] private bool isPaused;
        [Tooltip("Desactivado")]
        [SerializeField] private bool isDisable;
        [Tooltip("Vidas")]
        [SerializeField] private uint _live = 1;

        /**Cacheo de los componentes de este entitycontroller*/
        private MovementRigidbodyComponent _moveComponent = new MovementRigidbodyComponent();
        #endregion


        #region Metodos propio del controlador
        /**
         * TODO: Des la lista de componentes tengo las variables de componentes mas usados como:
         * -compenente de salud
         * -componente de combate
         * -componente de muerte
         * -Ademas tengo una lista de EntityAction para eventos
         * -Entity de comportamiento
         * Otro elemento de animaciones(?¿)
         */

        public void Init(
            EntityData data,
            Camera camera,
            uint level,
            params object [] arg)
        {
            LogMessages.PrintMethoAndHour("Init", this);

            //EntityData
            this._entityData =data;
           
            //colocamos el nombre de la entidad en este entitycontroller obtenido desde su propio Entity
            this._nameId=_entityData.NameId;
            //id unico de la Entidad que transfiere al controller
            this._characterId = (uint)arg[0];
            //nivel del player
            this._level = level;
            //camara principal
            this._activeCam = camera;
            //Inicializamos el transform que contiene esta clase
             _transform = this.transform.GetComponent<Transform>();
            //Iniciamos el animator
            this._animator = _transform.GetComponent<Animator>();////solo para verlo en Editor. TODO: Quitar
            //Iniciamos el rigidbody
            this._rigidbody = transform.GetComponent<Rigidbody2D>();//solo para verlo en Editor. TODO: Quitar
            //Iniciamos el GameObject
            _characterAttachedGO = _transform.gameObject;

            //TEST
            //DoTest.DoTestEntityData(_entityData);
            //DoTest.DoTestComponentsContent(_entityData.Components);
           
            //Cargamos el Listado de componentes List<BaseComponent> ( NO:List<string>-----> SI: List<BaseComponent> )
            this._components = Helpers.CreateListComponentFromListClassName(_entityData.Components);
            //Cargamos Listado de devices List<BaseDevice> ( NO:List<string>-----> SI: List<BaseDevice> ).TODO: Por hacer
            
            
            /**recorremos List<BaseComponent> para iniciar cada uno*/
            foreach (BaseComponent bc in _components)
            {
                
                bc.InitComponet(_transform, _entityData, _components, new object[] { _characterId });//siempre se inicia con el id del entity controller que tiene los componentes

                //cacheamos algunos que nos interesan en esta clase.
                if (bc is MovementRigidbodyComponent && _moveComponent==null) {

                    _moveComponent = bc as MovementRigidbodyComponent;
                    Debug.Log("MovementRigidbodyComponent cacheado a EntityController");
                }
                //Aqui no cacheamos este componente.
                if (bc is CharacterAnimationComponent)
                {
                    if (_animator == null) return;
                    //le decimos al componente de animacion cual es su animator.
                    bc.ISetData(_animator);

                }
            }
        }

        /**
         * Metodo llamado desde Update de GameController (MonoBehaviour)
        *   Llamado en cada frame desde Update. Actua como un Update nativo pero es propio de esta clase custom (por
        *   lo que podria tener mas parametros.)
        *   Este metodo recorre los componentes de cada player y se llama a su metodo IUpday();
        *   Dentro de cada IUpday de cada componente contendrá la logica del componente y actuará
        *   como el metodo nativo del motor, es decir se llama en cada frame.
        */
        public void IOnUpdate()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].IUpday();
            }

        }
        /**
         * Metodo llamado desde FixedUpdate de GameController (MonoBehaviour)
        *   Llamado en cada frame desde Update. Actua como un Update nativo pero es propio de esta clase custom (por
        *   lo que podria tener mas parametros.)
        *   Este metodo recorre los componentes de cada player y se llama a su metodo IUpday();
        *   Dentro de cada IUpday de cada componente contendrá la logica del componente y actuará
        *   como el metodo nativo del motor, es decir se llama en cada frame.
        */
        public void IOnFixedUpdate()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].IFixedUpday();
            }
        }

        private List<BaseComponent> GetComponents()  { return _components;    }
        private List<BaseDevice> GetDevices() {return _devices; }

        #endregion

        #region Metodos propios del motor

        private void OnCollisionEnter(Collision collision)
        {

            //Debug.Log("OnCollisionEnter: [" + NamePlayer + "] colisiona con: " + collision.collider.name + "---GameController---  ID[" + IdPlayer + "]");
            //_interactionComponent.IOnCollisionEnter(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            //_interactionComponent.IOnCollisionExit(collision);
        }
        private void OnCollisionStay(Collision collision)
        {

        }
        public void OnDisable()
        {
            //_controlComponent.IOnDisable();
        }
        #endregion

    }
}