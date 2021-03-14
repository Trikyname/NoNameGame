using Assets.Game.Scripts.Commun;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Components;
using Assets.Scripts.Game.Controllers;
using Assets.Scripts.Game.Datas.Attribute;
using Assets.Scripts.Game.Datas.Device;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
/**
*Descripcion de la clase: 
*Clase para almacenar a todos los datos de las EntityData. Es MonoBehaviour.
* Debemos arrastrar cada fichero json la lista de EntityData en el Editor.
* 
* TODO: Hacer que se lea los archivos contenidos en la carpera DataObject donde se encuentran los .json
* para que se pueble la lista de EntityData y evitar tenerlo que arrastrar manualmente.
* 
* 
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.DataBD
{
    [System.Serializable]
    public class DataBD : MonoBehaviour
    {
        #region variables privadas

        [Header("Ficheros")]
        [Tooltip("Ficheros con los datos para Character")]
        [SerializeField]private TextAsset[] _charactersTextList = null;
        private static DataBD _instance=null;//instancia de esta clase
        private List<EntityData> _charactersEntityData;//Contenedor de todas las EntityDatas de todos los archivos corresponiente a Character
        public uint _idDataBase = 23;
        #endregion


        #region propiedad publica
        public static DataBD Instance { get=> _instance;}//

        #endregion

        #region metodo propio
        public DataBD GetInstance()
        {   //Se crea una unica instancia de esta clase, si no existia antes
            if (Instance == null)
            {
                _instance = this;
                
            }
            return _instance;
        }


        #endregion
        
        #region constructor
        //constructor privado, por lo que no podremos hacer new()
        private DataBD()
         {

         }/**/

        #endregion

        #region Metodos propios del motor
        private void Awake()
        {
            if (Instance == null)
            {

                _instance = this;
                //_instance =FindObjectOfType(typeof(DataBD)) as DataBD;
                
                
            }

            //Al ponerlo aqui, y estar asociado al GameController, este no se destruye
            DontDestroyOnLoad(_instance);
        }

        #endregion

        public void Init()
        {
            LogMessages.PrintMethoAndHour("Init", this);
            //Representa el CharacterId en EntityData. Ira aumentando
            uint characterIdCounterTmp = 1;

            //se inicializa el contenedor de EntityDatas
            _charactersEntityData = new List<EntityData>(10);

            //Parsea los archivos contenidos en TextAsset[] del tipo .json
            ParseJsonCharactersData(_charactersTextList, ref characterIdCounterTmp);
        }

        #region Parse data desde json
        
        /*
         * Metodo para Parsear los datos tipo .json desde el contenedor de archivos .json*
         */
        private void ParseJsonCharactersData(TextAsset[] files, ref uint characterIdCounter)
        {
            LogMessages.PrintMethoAndHour("ParseJsonCharactersData", this);
            for (var i = 0; i < files.Length; ++i)
            {   
                    //elemento del contenedor
                    var charsData = files[i];
                    //Debug.Log("charsData: [" + charsData.text + "]");
                try
                {

                    //contenedor temp de Character (clase espejo del contenido del .json)
                    
                    //List<Character> temp = null;
                    ListCharacter temp=null;
                    //lectura del contenido de un .json y almacenamiento en contenedor temporal
                    temp = JsonUtility.FromJson<ListCharacter>(charsData.text);


                    foreach (Character charat in temp.Characters)
                    {
                        /*
                        Debug.Log("NameId: [" + charat.NameId + "]");
                        Debug.Log("PortraitName: [" + charat.PortraitName + "]");
                        Debug.Log("PrefabName: [" + charat.PrefabName + "]");
                        Debug.Log("GroupType: [" + charat.GroupType + "]");
                        Debug.Log("WeaponMain: [" + charat.WeaponMain + "]");
                        Debug.Log("WeaponSecundary: [" + charat.WeaponSecundary + "]");
                        Debug.Log("Behaviour: [" + charat.Behaviour + "]");
                        Debug.Log("DetectionComponentName: [" + charat.DetectionComponentName + "]");
                        Debug.Log("ClassName: [" + charat.ClassName + "]");
                        
                        for (int count0 = 0; count0 < charat.AttributeAndModifiersController.Count; count0++)
                        {
                            Debug.Log("Atributos: [" + charat.AttributeAndModifiersController[count0].AttributeName + "]");
                        }
                        for (int count1 = 0; count1 < charat.Components.Count; count1++)
                        {
                            Debug.Log("Componentes: [" + charat.Components[count1].ClassName + "]");
                        }
                        for (int count2 = 0; count2 < charat.Devices.Count; count2++)
                        {
                            Debug.Log("Devices: [" + charat.Devices[count2].ClassName + "]");
                        }
                        */
                    }

                        /*
                        * *
                        */
                        for (var j = 0; j < temp.Characters.Count; ++j)
                        {
                        //parse the character attributes
                        var attributesParsed = GetAttributesFromCharacter(temp.Characters);
                        //listados temporales para albergar los componentes y devices
                        List<string> components=new List<string>();
                        List<string> devices = new List<string>();
                        //recorremos los componentes y lo adicionamos a un List<string> temporal
                        foreach (Character.Component item in temp.Characters[j].Components)
                        {
                            components.Add(item.ClassName);
                        }

                        //recorremos los devices y lo adicionamos a un List<string> temporal
                        foreach (Character.Device item in temp.Characters[j].Devices)
                        {
                            devices.Add(item.ClassName);
                        }

                        /****Parametros de la clase EntityData********
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
                        */
                        var _entityData = new EntityData(
                            characterIdCounter,
                            temp.Characters[j].NameId,
                            temp.Characters[j].GroupType,
                            temp.Characters[j].PortraitName,
                            temp.Characters[j].ClassName,
                            temp.Characters[j].PrefabName,
                            temp.Characters[j].WeaponMain,
                            temp.Characters[j].WeaponSecundary,
                            temp.Characters[j].DetectionComponentName,
                            temp.Characters[j].Behaviour,
                            attributesParsed,
                            components,
                            devices);
                        //Añadimos los EntityDatas a la lista de EntityData
                        _charactersEntityData.Add(_entityData);
                        //se incrementa el contador con cada loop
                        characterIdCounter++;
                    }
                    LogMessages.PrintMethoAndHour("ParseJsonCharactersData: Se completa el relleno del contenedor de EntityDatas", this);
                }
                catch (Exception)
                {
                    Debug.LogError("Error al parsear archivo de character tipo .json numero en la lista= " + charsData.name);
                    return;
                }

            }
        }

        #endregion

        #region internal parse of elements

        /* 
         * Obtiene los atributos de un elemento del contenedor  CharacterListGame
        * y los almacena en un contenedor de BaseAttribute.
        *
        * -Se hace aqui la transicion de un elemento del contenedor[List Character ]
        * a un contenedor de atributos[List<BaseAttribute>]
        */
        private AttributeAndModifiersController GetAttributesFromCharacter(List<Character> characters)
        {
            LogMessages.PrintMethoAndHour("GetAttributesFromCharacter", this);
            //Comprobamos que el contendor no es nulo
            if (characters == null) return null;
            /* TEST
            Debug.Log("NameId: [" + characters[0].NameId + "]");
            Debug.Log("PortraitName: [" + characters[0].PortraitName + "]");
            Debug.Log("PrefabName: [" + characters[0].PrefabName + "]");
            Debug.Log("GroupType: [" + characters[0].GroupType + "]");
            Debug.Log("WeaponMain: [" + characters[0].WeaponMain + "]");
            Debug.Log("WeaponSecundary: [" + characters[0].WeaponSecundary + "]");
            Debug.Log("Behaviour: [" + characters[0].Behaviour + "]");
            Debug.Log("DetectionComponentName: [" + characters[0].DetectionComponentName + "]");
            Debug.Log("ClassName: [" + characters[0].ClassName + "]");
           */
            //No ponemos un array por que no sabemos el numero de elementos que va a tener 
            List<BaseAttribute> result = new List<BaseAttribute>();
            
            //Se recorre todos los elementos de esta lista    
            foreach (Character ch in characters)
            {
                
                //Recorremos la lista de atributos
                for (int i = 0; i < ch.Attributes.Count; ++i)
                    {


                    //Parse de FormulaType que es un campo de Attribute
                    /*
                    GameEnums.Modifier formulaType = (GameEnums.Modifier)Enum.Parse(typeof(GameEnums.Modifier),
                    ch.AttributeAndModifiersController[i].FormulaType);
                    */

                    
                    //TODO: Mirar como Parsearlo. Da error las instrucciones anteriores
                    
                    GameEnums.Modifier formulaType = GameEnums.Modifier.ADDITION;
                    //Debug.Log("formulaType: [" + formulaType.GetType() + "]");
                    /*
                    float value,
                    float minvalue,
                    float maxvalue,
                    float increasestep,
                    string attributeName,
                    GameEnums.Modifier formulaType
                    */
                    //Creamos una instancia de clase desde el nombre contenido en [entity.AttributeAndModifiersController[i].AttributeName]
                    BaseAttribute bA = Helpers.CreateInstance<BaseAttribute>(Constants.NE_ATTRIBUTE, ch.Attributes[i].AttributeName,
                            new object[]{
                                ch.Attributes[i].Value,
                                ch.Attributes[i].MinValue,
                                ch.Attributes[i].MaxValue,
                                ch.Attributes[i].IncreaseStep,
                                ch.Attributes[i].AttributeName,
                                formulaType
                            });
                    //Añadimos cada BaseAttribute al List<BaseAttribute>
                        result.Add(bA);
                    
                }
                

            }
            //Se inicializa el controller de atributos (dentro tendra una List<BaseAttribute> )
            AttributeAndModifiersController atrributes = new AttributeAndModifiersController(result);
            LogMessages.PrintMethoAndHour("GetAttributesFromCharacter: Se inicia el controller de atributos ", this);
            return atrributes;
        }

        /**
         * Obtiene una List<BaseComponent> de todos los componentes de un character por su nombre
         */
        public List<BaseComponent> GetComponentsFromCharacterByClassName(string classNameCharacter)
        {
            LogMessages.PrintMethoAndHour("GetComponentsFromCharacterByClassName", this);
            //Comprobamos que el contendor no es nulo
            if (_charactersEntityData == null) {
                Debug.Log("Contenedor de Entitys es nulo");

                return null;
            } 

            List<BaseComponent> result = new List<BaseComponent>();//No ponemos un array por que no sabemos el numero de elementos que va a tener 
            //Se recorre el contenedor con todos los archivos json     
            foreach (EntityData entity in _charactersEntityData)
            {
                //Buscamos en cada miembro del contenedor se cumpla la condicion del parametro dado
                if (entity.ClassName == classNameCharacter)
                {
                    //Recorremos la lista de atributos
                    for (int i = 0; i < entity.Components.Count; ++i)
                    {

                        //Debug.Log("Comp: [" + entity.ClassName + "]" + entity.Components[i].ClassName);
                        
                        //Creamos una isntancia de clase desde el nombre contenido en [entity.AttributeAndModifiersController[i].AttributeName]
                        BaseComponent bA = Helpers.CreateInstance<BaseComponent>(Constants.NE_COMPONENT, entity.Components[i],
                                new object[]{});

                        result.Add(bA);
                    }
                }

            }
            return result;
        }
        /**
         * Obtiene una List<BaseDevice> de todos los devices de un character por su nombre
         */
        public List<BaseDevice> GetDevicesFromCharacterByClassName(string classNameCharacter)
        {
            LogMessages.PrintMethoAndHour("GetDevicesFromCharacterByClassName", this);
            //Comprobamos que el contendor no es nulo
            if (_charactersEntityData == null)
            {
                Debug.Log("Contenedor de Entitys es nulo");

                return null;
            }

            List<BaseDevice> result = new List<BaseDevice>();//No ponemos un array por que no sabemos el numero de elementos que va a tener 
            //Se recorre el contenedor con todos los archivos json     
            foreach (EntityData entity in _charactersEntityData)
            {
                //Buscamos en cada miembro del contenedor se cumpla la condicion del parametro dado
                if (entity.ClassName == classNameCharacter)
                {
                    //Recorremos la lista de atributos
                    for (int i = 0; i < entity.Devices.Count; ++i)
                    {

                        //Debug.Log("Dev: [" + entity.ClassName + "]" + entity.Devices[i].ClassName);

                        //Creamos una isntancia de clase desde el nombre contenido en [entity.AttributeAndModifiersController[i].AttributeName]
                        BaseDevice dV = Helpers.CreateInstance<BaseDevice>(Constants.NE_DEVICE, entity.Devices[i],
                                new object[] { });

                        result.Add(dV);
                    }
                }

            }
            return result;
        }
        #endregion

        public void OnDestroy()
        {
            _charactersEntityData.Clear();
        }

        #region getters

        /**Propiedad para acceder al contenedor de EntityData solo lectura*/
        public ReadOnlyCollection<EntityData> GetCharactersEntityData
        {
            get { return _charactersEntityData.AsReadOnly(); }
        }
        /**Metodo para obtener una EntityData por su nombre*/
        public EntityData GetCharacterDataByClassName(string name)
        {
            LogMessages.PrintMethoAndHour("GetCharacterDataByClassName", this);
            //look in both players and npcs, enemies, etc
            for (var i = 0; i < _charactersEntityData.Count; ++i)
            {
                if (_charactersEntityData[i].ClassName.Equals(name))
                {
                    return _charactersEntityData[i];
                }
            }

            return null;
        }
        /**Metodo para obtener una EntityData por su idName*/
        public EntityData GetCharacterDataByIdName(string name)
        {
            LogMessages.PrintMethoAndHour("GetCharacterDataByIdName", this);
            //look in both players and npcs, enemies, etc
            for (var i = 0; i < _charactersEntityData.Count; ++i)
            {
                //Debug.Log("GetCharacterDataByIdName " + _charactersEntityData[i].NameId + "name:  " + name);
                if (_charactersEntityData[i].NameId.Equals(name))
                {
                    //Debug.Log("GetCharacterDataByIdName Equals " + _charactersEntityData[i].NameId+ "name:  " + name);
                    return _charactersEntityData[i];
                }
            }

            return null;
        }
        /**Metodo para obtener una EntityData por su idCharacter*/
        public EntityData GetCharacterDataByCharacterId(uint id)
        {
            LogMessages.PrintMethoAndHour("GetCharacterDataByCharacterId", this);
            //look in both players and npcs, enemies, etc
            for (var i = 0; i < _charactersEntityData.Count; ++i)
            {
                if (_charactersEntityData[i].CharacterId.Equals(id))
                {
                    return _charactersEntityData[i];
                }
            }

            return null;
        }
        
        #endregion
    }

    [System.Serializable]
    public class ListCharacter
    {
        public List<Character> Characters = new List<Character>();

        
    }
}
