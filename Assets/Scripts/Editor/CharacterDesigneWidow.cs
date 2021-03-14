using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

/**
*Descripcion de la clase: 
********************Ejemplo para EditorWindow************
* Clase para crear una ventana en el Editor para crear character, basado en json
* 
* 
*Version:v01
*Fecha:02/01/2021
**/

namespace Scripts.Editor
{

    public class CharacterDesigneWidow : EditorWindow
    {
        Texture2D _textureHeaderSeccion;
        Texture2D _textureRightSeccion;
        Texture2D _textureLeftSeccion;
        Texture2D _textureCenterSeccion;

        Color  _colorCenterSeccion=new Color(23/256f,40/256f,100/256f,1);
        Color _colorRightSeccion = new Color(23 / 256f, 40 / 256f, 100 / 256f, 1);
        Color _colorLeftSeccionn = new Color(23 / 256f, 40 / 256f, 100 / 256f, 1);
        Color _colorLeftSeccion = new Color(23 / 256f, 40 / 256f, 100 / 256f, 1);


        Rect _headerSeccion;
        Rect _rightSeccion;
        Rect _leftSeccion;
        Rect _centerSeccion;

        [MenuItem ("Window/Windows/Character Designer")]
        static void OpenWindow() {
            CharacterDesigneWidow _window = GetWindow<CharacterDesigneWidow>();
            //CharacterDesigneWidow _windowSecond= (CharacterDesigneWidow)GetWindow(typeof(CharacterDesigneWidow));
            _window.minSize = new float2(600f,300f);
            _window.Show();
        }
        /**Similar a start() o Awake()*/
        private void OnEnable()
        {

        }
        /**Similar a update(). Se llama 1 o mas veces por interaccion. No se llama frame por segundo*/
        private void OnGUI()
        {
            
        }
        private void InitTextures() { 
        
        }
        /**Define los valores de Rect y pinta las texturas en base a los Rect*/
        private void DrawLayouts()
        {

        }
        /**Pinta el contenido del header*/
        private void DrawHeader()
        {

        }
        /**Pinta el contenido del CenterSeccion*/
        private void DrawCenterSeccion()
        {

        }
        /**Pinta el contenido del RightSeccion*/
        private void DrawRightSeccion()
        {

        }
        /**Pinta el contenido del LeftSeccion*/
        private void DrawLeftSeccion()
        {

        }

    } 
}
