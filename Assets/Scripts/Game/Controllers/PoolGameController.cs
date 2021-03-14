using Assets.Scripts.Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase:
*  Clase de pool para tener todos los objetos guardados
*  
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/

namespace Assets.Scripts.Game.Controller
{
    [System.Serializable]
    public class PoolGameController : MonoBehaviour
    {
        [System.Serializable]
        public struct PrefabCharacter { }
        [System.Serializable]
        public struct VisualAppearance { }

        [Header("Valores Generales de la Pool")]
        [Tooltip("Posicion del spanw")]
        [SerializeField] private Transform poolSpanwPoint = null;
        [Tooltip("Total de elemento de un tipo")]
        [SerializeField] private int totalItemOneType = 100;//Este es un ejemplo generico. Aqui habria balas, granadas,misiles,municion,...etc
        [SerializeField] private GameObject [] prefabItem = null;
        [SerializeField] private GameObject[] prefabCharacter = null;//TODO: crear una clase PrefabCharacter en lugar de un GO
        /*
         *Pool de enemigos
         *string=key ClassName/GoupType
         */
        private Dictionary<string, List<EntityController>> poolData = new Dictionary<string, List<EntityController>>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
