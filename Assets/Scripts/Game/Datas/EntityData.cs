
using Assets.Scripts.Game.Controllers;
using System.Collections.Generic;
/**
*Descripcion de la clase: 
*Clase que representa los datos de las Entidades:
*-Se almacena la id unica de la Entidad.
*-Lista de componentes de tipo string para crear clases desde sus nombres.
*-Pasa los atributos a la clase controladora de atributos.
*TODO:
*-Lista de equipo (armas, armaduras, botas,...)
*-Capacidad de llevar equipo,...
*-Comportamiento
*
******************Descripcion del sistema de atributo:
*Los atributos los almacena el controller de atributos en una lista. Esta no cambia, son los obtenidos de los archivos json
*El controller de atributo, tiene una lista con todos los modificadores de los diferentes atributos.
*Sera necesario un metodo para comprobar todos los modificadores que se producen sobre un atributo. 
*Hay una especie de historico de modificadores a cada atributo.
*Este es el sistema por el cual consultando los modificadores que se le hacen a cada atributo se obtiene el valor actual del atributo
*dado.
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas
{
    [System.Serializable]
    public class EntityData
    {
        //assign a number for enemies or players
         public uint CharacterId { get;private set; }
        public string NameId { get; private set; }
        public string GroupType { get; private set; }
        public string PortraitName { get; private set; }
        public string ClassName { get; private set; }
        public string PrefabName { get; private set; }
        public string WeaponMain { get; private set; }
        public string WeaponSecundary { get; private set; }
        public string DetectionComponentName { get; private set; }
        public string Behaviour { get; private set; }
        //Este contiene una lista de Atributos y una lista de Modificadores
        public AttributeAndModifiersController AttributeAndModifiersController { get; private set; }
        public List<string> Components { get; set; }
        public List<string> Devices { get; set; }
        



        /**
         * Carga los datos en las variables contenidas en esta clase y en la clase AttributeAndModifiersController.
         * 
         * -un id que identifica a la Entidad
         * -un contenedor con los atributos para la clase AttributeAndModifiersController
         * -un contenedor con los componentes para la clase EntityData
         */


        #region Constructores
        public EntityData()
        {
        }
        public EntityData(EntityData eD)
        {
            CharacterId = eD.CharacterId;
            NameId = eD.NameId;
            GroupType = eD.GroupType;
            PortraitName = eD.PortraitName;
            ClassName = eD.ClassName;
            PrefabName = eD.PrefabName;
            WeaponMain = eD.WeaponMain;
            WeaponSecundary = eD.WeaponSecundary;
            DetectionComponentName = eD.DetectionComponentName;
            Behaviour = eD.Behaviour;
            AttributeAndModifiersController = eD.AttributeAndModifiersController;
            Components = eD.Components;
            Devices = eD.Devices;
        }
        public EntityData(
            uint characterid,
            string id,
            string groupType,
            string name,
            string classname,
            string prefabName,
            string weaponMain,
            string weaponSecundary,
            string detectionComponentName,
            string behaviour,
            AttributeAndModifiersController attributes,
            List<string> componentes,
            List<string> devices)
        {
            CharacterId = characterid;
            NameId = id;
            GroupType = groupType;
            PortraitName = name;
            ClassName = classname;
            PrefabName = prefabName;
            WeaponMain = weaponMain;
            WeaponSecundary = weaponSecundary;
            DetectionComponentName = detectionComponentName;
            Behaviour = behaviour;
            AttributeAndModifiersController = attributes;
            Components = componentes;
            Devices = devices;
        }
        public EntityData Clone()
        {
            return new EntityData(this);
        }
        
        #endregion
         
    }

}