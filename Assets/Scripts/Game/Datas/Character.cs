using System;
using System.Collections.Generic;
/**
*Descripcion de la clase: 
* Clase Character contenedora de los datos json. Esta clase es un espejo de los campos del fichero json.
* Character de manera que cuando se sean leidos este tipo de .json [Characters] pueda ser almacenado
* en esta clase.
* Normalmente esta informacion se volcara en las EntityDatas.
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/

namespace Assets.Scripts.Game.Datas
{
    [Serializable]
    public class Character
    {


        
        public List<Attribute> Attributes=new List<Attribute>();//Array de atributos string
        public List<Component> Components;//Array de componentes string
        public List <Device> Devices;//Array de atributos string
        public string NameId;
        public string PortraitName;
        public string ClassName;
        public string PrefabName;
        public string GroupType;
        public string WeaponMain;
        public string WeaponSecundary;
        public string DetectionComponentName;
        public string Behaviour;

        public Character()
        {
        }

        [Serializable]
        public class Attribute {
            public float Value;
            public float MinValue;
            public float MaxValue;
            public string FormulaType;
            public float IncreaseStep;
            public string AttributeName;
            

            public Attribute()
            {
            }
        }
        [Serializable]
        public class Component
        {
            public string ClassName;
            
            public Component()
            {
            }
        }
        [Serializable]
        public class Device
        {
            public string ClassName;

            public Device()
            {
            }
        }
    }
}