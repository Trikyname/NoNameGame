using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase componente InteractionComponent
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components
{
    public class InteractionComponent : BaseComponent
    {
        public override void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg)
        {
            LogMessages.PrintMethoAndHour("InitComponet", this);
        }

        
    }
}