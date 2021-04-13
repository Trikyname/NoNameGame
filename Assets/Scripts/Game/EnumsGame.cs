using System.Collections;
using UnityEngine;
/**
*Descripcion de la clase:
*Clase Enum para almacenar varios enun comunes en el juego
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public class EnumsGame
    {
        //Enun con los nombres de los players para cada del juego
        [System.Serializable]
        public enum NamePlayer
        {

            Becky = 1,
            Hope = 2,
            MAX
        }
        //Enun con los nombres de las Tag para cada elemento del juego
        [System.Serializable]
        public enum TypeItems
        {

            Cubo=1,
            Altar = 2,
            Interruptor = 3,
            Box=4,
            MAX
        }
        //Enun con los nombres de los tipos de cubos y cajas
        [System.Serializable]
        public enum TypeCubeAndBox
        {

            Neutro,
            Helado,
            Color,
            Temporal,
            MAX
        }
        //Enun con los nombres de los colores de los Item
        [System.Serializable]
        public enum Color
        {
                        
            NoColor,
            ColorRosa,
            ColorMorado,
            MAX
        }
        //Enun con los nombres de todos los canvas UI hijos
        [System.Serializable]
        public enum NameUICanvasGame
        {

            Controles_Becky,
            Controles_Hope,
            Subir_Becky,
            Empujar_Bechy,
            Usar_Becky,
            Retroceder_Becky,
            Fixed_Joystick_Becky, 
            Gamepad_Becky,
            Subir_Hope,
            Empujar_Hope,
            Usar_Hope,
            Retroceder_Hope,
            Fixed_Joystick_Hope, 
            Gamepad_Hope,
            MAX

        }
        //Enun con los nombres de todos los componentes
        [System.Serializable]
        public enum NameComponents
        {
            MovePlayersComponent,
            InteractionPlayersComponent,
            ControlPlayersComponent,
            AudioPlayerComponent, 
            AnimationPlayerComponent,
            UIComponent,
            MAX
        }
        //Enun con los nombres de todos las animaciones
        [System.Serializable]
        public enum NameAnimations
        {
            Idle,
            Walking,
            Pushing,
            Drag,
            MAX
        }
        //Enun con los nombres de todos los sonidos
        [System.Serializable]
        public enum NameSounds
        {
            Idle,
            Walking,
            Pushing,
            Drag,
            MAX
        }
        //Enum con los nombre de todos los tipos de mensajes
        [System.Serializable]
        public enum MessagesTypes 
        {
            MessageStartBackActionMMS,
            MessageStoptBackActionMMS,
            MessageStartClimbItemMMS,
            MessageStopClimbItemMMS,
            MessageConectedMMS,
            MessageInteractionEnterColliderItemMMS,
            MessageInteractionEnterCollisionItemMMS,
            MessageInteractionExitColliderItemMMS,
            MessageInteractionExitCollisionItemMMS,
            MessageStartPushItemMMS,
            MessageStopPushItemMMS,
            MessageStartDragItemMMS,
            MessageStopDragItemMMS,
            MessageStartUseItemMMS,
            MessageStopUseItemMMS,
            MAX
        }
        public static string[] ConvertEnumToArray(string nameEnum) {

            object temp=new object();

            string [] typeClass1= (string[])System.Enum.GetValues(typeof(EnumsGame.NameComponents));
            var typeClass2 = System.Enum.GetName(typeof(EnumsGame.NameComponents), temp);
            
            return typeClass1;
        }


    }
    
}