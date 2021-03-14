
namespace Assets.Scripts.Game.Commun
{
		
/**
*Descripcion de la clase: Clase enum para diferentes definiciones para el proyecto en global.
*Todas las clases pueden acceder a el.
*Version:v01
*Fecha:02/01/2021
**/
public class GameEnums
{   /**
     * Se enumera el tipo de sistema de modificacion de los atributos.
     * ADDITION: Se suma o resta un numero
     * PERCENTAGE: Se aplica un porcentaje para sumar o restar a los atributos
     * CRITICS: TODO:
     * MAX:.El numero mayor de este enum para hacer for
     */
    [System.Serializable]
    public enum Modifier
    {
        ADDITION=0,
        PERCENTAGE=1,
        CRITICS=2,
        MAX=3
    }
        /**
         * Se enumera todos los tipos de character por su NameId.
         * MAX:.El numero mayor de este enum para hacer for
         */
        [System.Serializable]
    public enum NameIdCharacter
    {
        CharacterType1,
        EnemyType1,
        BossEnemyType1,
        MAX
        
    }
    /**
     * Se enumera todas las clases del proyecto para tenerlas con un id cada una de ellas.
     * MAX:.El numero mayor de este enum para hacer for
     */
    [System.Serializable]
    public enum NameClassGame
    {
        AutoLobby,
        MessageMMS,
        MessageConectedMMS,
        MessagesControllerMMS,
        GameManager,
        EventManager,
        GUIManager,
        MAX

    }
        [System.Serializable]
        //Enun con los nombres de todos las animaciones
        public enum NameAnimations
        {
            Idle,
            Run,
            Jump,
            Hit,
            WallJump,
            Fall,
            MAX
        }
        [System.Serializable]
        //Enun con los nombres de todos los sonidos
        public enum NameSounds
        {
            Idle,
            Run,
            Jump,
            Hit,
            WallJump,
            Fall,
            MAX
        }
        /**
         * Se enumera el tipo de mensaje que se va a envia dentro del ****MANAGER MESSAGES SYSTEM  [MMS]****
         * MAX:.El numero mayor de este enum para hacer for
         */
        [System.Serializable]
    public enum MessagesTypes {
        //Conexiones
        ConectedMMS=0,
        DisconectedMMS = 1,
        JoinRoomMMS=2,
        OutRoomMMS=3,
        InitPlayerMMS = 4,
        //Juego
        GameOverMMS = 5,
        RemovePlayerMMS = 6,
        DeathPlayerMMS=7,
        MoveMMS = 8,
        StopMoveMMS = 9,
        AttackMMS = 10,
        HitMMS = 11,
        RemoveEnemyMMS = 12,
        DeathEnemyMMS = 13,
        EmptyMMS=14,
        MAX



    }
    

    } /**/
	}
