using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/**
*Descripcion de la clase: 
*Clase para leer los archivos.json de una carpeta, formatearlo y almacenarlos en un contenedor static de tipo string para acceso general al juego.
*IMPORT:
*Hay dos formas de leer .json
*  *****Ejemplo 1: var jsonString = Resources.Load<TextAsset>("DataAssets/" + GameEnums.NAME_FILE_JSON.Character1);***
*  *****Ejemplo 2: string _jsonString = File.ReadAllText(Application.dataPath+"/DataObject/" + GameEnums.NAME_FILE_JSON.EnemyType2 + ".json");
*   
*Todos los valores que lee son string asi que se debe de procesar
*
************************TODO:
* Rehacer el sistema de obstencion de datos desde .json
* 1. Lectura de carpeta con todos los .json
* 2. Almacenamiento en un Array de TextAsset
* 3. Creacion de una clase singleton DataDDBB (y monoviebiour) que contenga una List<EntityData> unica, con todos los Tipos de EntityDatas de juego
* 4. La clase DataDDBB debe formatear los datos desde .json a EntityData.
* 5. La clase DataDDBB se inicia una unica vez en el juego (Desde el GameController o desde el Core).
* 
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    [Serializable]
    public static class ReadJsonFileEntityData
    {
        
        /**
         * Metodo que inicia la lectura de todos los json dentro de la carpera Constants.FOLDER_DATA_JSON
         * y que contienen todos los datos de cada uno de estos ficheros, que representan todos los Character del
         * juego.
         */
        public static void Init()
        {
            Debug.LogWarning("Init [ ReadJsonFileEntityData] " + DateTime.Now);
           
            //Leemos y almacenamos los datos en el contenedor
            ReadFolderDataObject();

            /**SOLO PARA TEST**/
            //GetNameFileJson();
            //DoTestCharacterContent(CharacterListGame);
            //List<BaseAttribute> ba = GetAttributesFromCharacterByClassName("EnemyType1");
            //DoTestAttributesContent(ba);
            
        }

        #region Lectura y guardado de .json
        
        /**
         * Metodo de lectura .json
         * -se ejecuta de manera recurrente por lo que lee y guarda cada fichero .json
         * -formateo a la clase CharacterList
         */
        private static string ReadOneFile(string file)
        {
            
            /***File.ReadAllText****/
            string _jsonString =File.ReadAllText(Application.dataPath + Constants.FOLDER_DATA_JSON + file);


            /**TEST*/
            //Debug.Log("Lectura de archivo .json por:[metodo File.ReadAllText]" + file + _jsonString);
            return _jsonString;
        }
        /**
         * Metodo de lectura de archivos
         * -obtener el nombre de los archivos .json que se encuentra en la carperta definida en la Constants.cs
         *   
         */
        public static TextAsset[] ReadFolderDataObject()
        {
            
             try {

                string path = Application.dataPath + Constants.FOLDER_DATA_JSON;
                string[] files = Directory.GetFiles(path, "*.json");
                TextAsset[] textAssets = null;
                if (files != null)
                {
                    //Recorremos los nombres de los archivos encontrados
                    //Lo formateamos para que solo apareca el nombre del archivo
                    for (int i = 0; i < files.Length; ++i)
                    {
                        //Reemplaza el nombre de la ruta por nada, de forma que se obtiene el nombre del archivo .json
                        files[i] = files[i].Replace(path, "");
                        //Debug.Log("Archivos: " + files[i]);

                        /*
                         * Se ejecuta dentro de un for, para todos los ficheros que se encuentran en la
                         * carpeta Constants.FOLDER_DATA_JSON.
                         * Lee cada uno de estos archivos .json (un solo registro) y lo guarda dentro de un contenedor (List Character)
                         * que contendrá todos los datos de los ficheros .json
                         */
                        
                        TextAsset text = new TextAsset(ReadOneFile(files[i]));
                        textAssets[i] = text;

                    }
                    return textAssets;
                }

            } catch (Exception ex) {
                 Debug.LogError("Excepcion: " + ex.Message);
                }

            return null;
        }

        #endregion

        



    }


}
