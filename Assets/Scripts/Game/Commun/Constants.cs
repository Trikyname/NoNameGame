using System.Collections;
using UnityEngine;
/**
*Descripcion de la clase: 
* Clase con constantes que se usan de forma habitual
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public static class Constants
    {

        //Nombre de la carpeta donde se encuentra los archivos .json
        public static string FOLDER_DATA_JSON = "/DataObject/";

        
        //Nombres de los NAMESPACE
        public static string NE_ATTRIBUTE = "Assets.Scripts.Game.Datas.Attribute.";
        public static string NE_COMPONENT = "Assets.Scripts.Game.Components.";
        public static string NE_COMUN = "Assets.Scripts.Game.Comun.";
        public static string NE_MESSAGES_SYSTEM = "Assets.Scripts.Game.Comun.MessagesSystem.";
        public static string NE_CONTROLLER = "Assets.Scripts.Game.Controllers.";
        public static string NE_DATAS = "Assets.Scripts.Game.Datas.";
        public static string NE_DATABD = "Assets.Scripts.Game.Datas.DataBD.";
        public static string NE_DEVICE = "Assets.Scripts.Game.Datas.Device.";
        public static string NE_GAME = "Assets.Scripts.Game.";
        public static string NE_EDITOR = "Assets.Scripts.Game.Editor.";
        public static string NE_UTIL = "Assets.Scripts.Game.Utils.";
        public static string NE_GAMEPAD = "Assets.Gamepad.";
        public static string NE_ACTIONS = "Assets.Scripts.Game.Datas.Actions.";

        /*
         * Nombre de los archivos .json donde se definen las entidades.
         * Usar si no se van a generar nuevos .json desde la ventana del Editor de Unity y van a ser
         * siempre los mismos.
         * 
         */
        public static string[] NAME_FILE_JSON ={
        "CharacterType1",
        "CharacterType2",
        "CharacterType3",
        "CharacterType4",
        "EnemyType1",
        "EnemyType2",
        "EnemyType3",
        "EnemyType4",
        "EnemyType5",
        "EnemyType6",
        "BossEnemyType1",
        "BossEnemyType2",
        "BossEnemyType3",
        "BossEnemyType4",
        "BossEnemyType5",
        "BossEnemyType6"
        };

        
        
    }
}