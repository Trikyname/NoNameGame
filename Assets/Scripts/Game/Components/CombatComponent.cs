using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase componente CombatComponent
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components
{
    public class CombatComponent : BaseComponent
    {   
        
        public Transform Transform { get => _transform; set => _transform = value; }
        public EntityController EntityController { get => _entityController; set => _entityController = value; }

        [Header("Transform")]
        private Transform _transform = null;
        private EntityController _entityController = null;

        

        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            LogMessages.PrintMethoAndHour("InitComponet", this);
            //siempre se inicia el componente dandole un id unico
            EntityId = (uint)arg[0];
            //cacheamos la transform
            this._transform = transform;

            //Obtenemos el PlayersController
            this._entityController = _transform.GetComponent<EntityController>();
        }

        
    }
}