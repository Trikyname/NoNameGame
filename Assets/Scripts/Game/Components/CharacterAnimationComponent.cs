using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase componente CharacterAnimationComponent
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components
{
    public class CharacterAnimationComponent : BaseComponent
    {
        #region Variables privadas
        private Transform _transform;
        private EntityController _entityController;
        private Animator _animator;
        #endregion

        #region Propiedades publicas
        public Animator Animator { get => _animator; set => _animator = value; } 
        #endregion

        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            LogMessages.PrintMethoAndHour("InitComponet", this);
            //siempre se inicia el componente dandole un id unico
            _entityId = (uint)arg[0];
            //cacheamos la transform
            this._transform = transform;
            //Obtenemos el EntityController
            this._entityController = _transform.GetComponent<EntityController>();
            this._animator = _transform.GetComponent<Animator>();
        }
        public override void ISetData(params object[] arg)
        {
            foreach (var _arg in arg)
            {
                //recibe de otros componentes
                //animator
                if (_arg is Animator)
                {
                    //obtenemos el animator desde el parametro.
                    _animator = (Animator)_arg;

                }
            }
        }

        public override void IRefreshData(params object[] arg)
        {
            //nada implementado
        }
        #region Metodos privados
        #region Animaciones
        /*
         * Para las animaciones de MIXAMO esta es la transicion:
         * Idle->Walking
         * Idle-PushORDrag
         * 
         */
        //animacion con tansicion caminar->idle
        public void RunToIdleAnimation()
        {
            this.Animator.SetBool(GameEnums.NameAnimations.Run.ToString(), false);
            //this.Animator.SetBool(EnumsGame.NameAnimations.Idle.ToString(), true);
        }
        //animacion con tansicion idle->caminar
        public void IdleToRunAnimation()
        {
            this.Animator.SetBool(GameEnums.NameAnimations.Run.ToString(), true);
            //this.Animator.SetBool(EnumsGame.NameAnimations.Idle.ToString(), false);

        }
        //animacion con tansicion idle->push
        public void IdleToJumpAnimation()
        {

            this.Animator.SetBool(GameEnums.NameAnimations.Jump.ToString(), true);
            //this.Animator.SetBool(EnumsGame.NameAnimations.Idle.ToString(), false);
        }
        public void JumpToIdleAnimation()
        {

            this.Animator.SetBool(GameEnums.NameAnimations.Jump.ToString(), false);
            //this.Animator.SetBool(EnumsGame.NameAnimations.Idle.ToString(), true);
        }
        #endregion


        #endregion
    }
}