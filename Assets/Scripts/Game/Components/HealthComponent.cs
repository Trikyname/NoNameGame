using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase componente HealthComponent
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components
{
    public class HealthComponent : BaseComponent
    {
        private float _healthValue;
        private float _initialMaxHealthValue;
        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            //obtenemos el valor de salud para asociarselo a EntityController
            float value = entityData.AttributeAndModifiersController.GetAttribute<HealthAttr>().Value;
            LogMessages.PrintMethoAndHour("InitComponet", this);
            //normalmente se usa ISetData dentro del Init de su propio componente
            ISetData(entityData.CharacterId,value);
        }

        public override void ISetData(params object[] arg)
        {
            _entityId = (uint)arg[0];
            _healthValue = (float) arg[1];
            _initialMaxHealthValue = _healthValue;

        }

    }
}