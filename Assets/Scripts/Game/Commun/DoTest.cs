using Assets.Scripts.Game.Datas.Attribute;
using Assets.Scripts.Game.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase static para hacer diferentes Test y que aparezcan en consola
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public static class DoTest
    {

        #region Metodos Test
        /**TEST.
         * Muestra el nombre de los componentes de un contenedor dado
         */
        public static void DoTestEntityData(EntityData result)
        {
            ToString("DoTestEntityData");
            //Comprobamos que el contendor no es nulo
            if (result == null) return;

            Debug.Log("NameId: [" + result.NameId + "]");
            Debug.Log("PortraitName: [" + result.PortraitName + "]");
            Debug.Log("PrefabName: [" + result.PrefabName + "]");
            Debug.Log("GroupType: [" + result.GroupType + "]");
            Debug.Log("WeaponMain: [" + result.WeaponMain + "]");
            Debug.Log("WeaponSecundary: [" + result.WeaponSecundary + "]");
            Debug.Log("Behaviour: [" + result.Behaviour + "]");
            Debug.Log("DetectionComponentName: [" + result.DetectionComponentName + "]");
            Debug.Log("CharacterId: [" + result.CharacterId + "]");
            Debug.Log("ClassName: [" + result.ClassName + "]");

            foreach (BaseAttribute attr in result.AttributeAndModifiersController._attributes_ori)
            {
                Debug.Log("AttributeName: [" + attr.AttributeName + "]");
                Debug.Log("IncreaseStep: [" + attr.IncreaseStep + "]");
                Debug.Log("MaxValue: [" + attr.MaxValue + "]");
                Debug.Log("MinValue: [" + attr.MinValue + "]");
                Debug.Log("FormulaType: [" + attr.FormulaType + "]");
                Debug.Log("IncreaseStep: [" + attr.IncreaseStep + "]");

            }

            foreach (string comp in result.Components)
            {
                Debug.Log("ClassName_componente: [" + comp + "]");
            }
            foreach (string dev in result.Devices)
            {
                Debug.Log("ClassName_device: [" + dev + "]");
            }
        }
        /**TEST.
         * Muestra el nombre de los componentes de un contenedor dado
         */
        public static void DoTestComponentsContent(List<string> result)
        {
            ToString("DoTestComponentsContent");
            //Comprobamos que el contendor no es nulo
            if (result == null) return;

            foreach (string comp in result)
            {
                Debug.Log("Comp: [" + comp.GetType() + "] " + comp);

            }
        }
        /**TEST.
         * Muestra el nombre de los devices de un contenedor dado
         */
        public static void DoTestDevicesContent(List<string> result)
        {
            ToString("DoTestDevicesContent");
            //Comprobamos que el contendor no es nulo
            if (result == null) return;

            foreach (string dev in result)
            {
                Debug.Log("Dev: [" + dev.GetType() + "] " + dev);

            }
        }
        
        /**TEST.
         * Muestra todos los campos de los BaseAttribute de un contenedor dado
         */
        public static void DoTestAttributesContent(List<BaseAttribute> _list)
        {
            ToString("DoTestAttributesContent");
            if (_list == null) { return; }

            foreach (BaseAttribute attr in _list)
            {
                Debug.Log("Value " + attr.Value);
                Debug.Log("MinValue " + attr.MinValue);
                Debug.Log("MaxValue " + attr.MaxValue);
                Debug.Log("AttributeName " + attr.AttributeName);
                Debug.Log("FormulaType: [" + attr.FormulaType + "]");
                Debug.Log("IncreaseStep: [" + attr.IncreaseStep + "]");

            }

            
        }
        #endregion
        private static void ToString(string methoName) {
            Debug.Log(methoName+" [DoTest.cs] ");
        }

    }
}