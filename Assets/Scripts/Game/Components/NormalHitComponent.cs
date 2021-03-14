using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controller;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using System.Collections.Generic;
using UnityEngine;

/**
*Descripcion de la clase:
*Clase para extender la funcionalidad del player
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components

{
    public class NormalHitComponent : BaseComponent
    {
        #region propiedades publicas

        public Transform Transform { get; private set; }
        public EntityController EntityController { get; private set;}

        #endregion

        #region variables privadas

        [Header("Transform")]
        private Transform _transform = null;
        private EntityController _entityController = null;


        #endregion

        #region Metodos sobreescritos de la clase BaseComponent

        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            LogMessages.PrintMethoAndHour("InitComponet", this);
            this.Transform = transform;

            //Obtenemos el PlayersController
            this.EntityController = Transform.GetComponent<EntityController>();

        }
        public override void ISetData(params object[] arg)
        {
            //nada implementado
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


        #endregion
    }
}

