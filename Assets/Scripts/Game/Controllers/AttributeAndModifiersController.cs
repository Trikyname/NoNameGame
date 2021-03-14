
using Assets.Game.Scripts.Commun;
using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Datas;
using Assets.Scripts.Game.Datas.Attribute;
using System.Collections.Generic;
using UnityEngine;
/**
*Descripcion de la clase: 
*Clase controller donde se:
*-Almacena los atributos originales de la Entidad. Son solo de lectura
*-Amacena los modificadores que se van realizando a todos los atributo. 
*Se obtendra todos los modificadores que se realizan sobre
*un atributo dado
*
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Controllers
{
    public class AttributeAndModifiersController
    {
        /**
         * Lista de atributos que posee la Entidad. Su origen es de los .json
         * Son los valores originales de la Entidad, solo de lectura, ya que no se van a modificar.
         * 
         */
        [SerializeField]
        public List<BaseAttribute> _attributes_ori = new List<BaseAttribute>();

        /**Lista de todos los modificadores que se producen y que afectan a los diversos atributos.
          * La clase Modifier contiene el tipo de atributo dado, por lo que se sabe todos los modificadores que se le ha realizado
          * a un atributo concreto.
          */
        [SerializeField]
        public List<Modifier> _modifiers = new List<Modifier>();

        #region Constructor

        public AttributeAndModifiersController()
        {
        }
        /**Constructor que admite la lista de Atributos ya como BaseAttribute*/
        public AttributeAndModifiersController(List<BaseAttribute> attr)
        {
            _attributes_ori = attr;
           
        } 
        #endregion

        public void Destroy()
        {
            var total = _modifiers.Count - 1;
            for (var i = total; i > -1; --i)
            {
                _modifiers[i].Destroy();
            }

            _modifiers.Clear();
            _modifiers = null;
        }



        #region attributes
        /// <summary>
        /// Se busca en la matriz de atributos por la clase de atributo que tiene la Entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public BaseAttribute GetAttribute<T>()
        {
            for (var i = 0; i < _attributes_ori.Count; ++i)
            {
                if (_attributes_ori[i] is T)
                {
                    return _attributes_ori[i];
                }
            }

            return null;
        }

        public BaseAttribute GetAttribute(string name)
        {
            for (var i = 0; i < _attributes_ori.Count; ++i)
            {
                if (_attributes_ori[i].AttributeName == name)
                {
                    return _attributes_ori[i];
                }
            }

            return null;
        }

        public void RemoveAttribute<T>()
        {
            for (var i = 0; i < _attributes_ori.Count; ++i)
            {
                if (_attributes_ori[i] is T)
                {
                    _attributes_ori.RemoveAt(i);
                    break;
                }
            }
        }

        public float GetAttributeDefaultValue<T>()
        {
            var attr = GetAttribute<T>();
            return attr == null ? 0f : attr.Value;
        }

        public float GetAttributeDefaultValue(string name)
        {
            var attr = GetAttribute(name);
            return attr == null ? 0f : attr.Value;
        }

        /**
         * Metodo para encontrar el valor de un atributo dado
         */

        public float GetAttributeValue<T>()
        {
            var existingModifiers = new List<Modifier>();

            //loop and search if a modifier exists
            for (var i = 0; i < _modifiers.Count; ++i)
            {
                /**
                 * Buscamos en el contenedor de los modificadores aquellos que sean del tipo de atributo
                 * dado y los almacenamos en un contenedor temporal de forma que tenemos todos los
                 * modificadores que se le van haciendo a un atributo dado
                 */
                if (_modifiers[i].Attribute is T)
                {
                    existingModifiers.Add(_modifiers[i]);
                }
            }


            //no modifiers, return default value
            if (existingModifiers.Count == 0)
            {
                return GetAttributeDefaultValue<T>();
            }


            var finalValue = 0f;
            var multValue = 0f;
            var additionValue = 0f;
            var foundValue = false;

            //something exists
            for (var i = 0; i < existingModifiers.Count; ++i)
            {
                if (existingModifiers[i].ModifierType == GameEnums.Modifier.PERCENTAGE)
                {
                    multValue += existingModifiers[i].Attribute.Value;
                    finalValue = GetAttributeDefaultValue<T>();
                    foundValue = true;
                }
                else if (existingModifiers[i].ModifierType == GameEnums.Modifier.ADDITION)
                {
                    additionValue = GetAttributeDefaultValue<T>();

                    foundValue = true;
                    //first operation we add the base value
                    //next operations will only increment/decrement the value
                    if (finalValue == 0)
                    {
                        finalValue += additionValue + existingModifiers[i].Attribute.Value;
                    }
                    else
                    {
                        finalValue += existingModifiers[i].Attribute.Value;
                    }
                }
            }


            //we had modifiers, but none of them apply to the attribute
            //we are looking, so just return the default value
            if (finalValue == 0f && !foundValue)
            {
                return finalValue = GetAttributeDefaultValue<T>();
            }

            return finalValue + (finalValue * multValue);
        }
        #endregion



        #region add and get modifiers
        public void AddModifier(Modifier modifier)
        {
            var canAdd = true;
            var positionId = 0;

            for (var i = 0; i < _modifiers.Count; ++i)
            {
                if (modifier.Attribute.AttributeName.Equals(_modifiers[i].Attribute.AttributeName))
                {
                    if (modifier.ModifierType == _modifiers[i].ModifierType)
                    {
                        positionId = i;
                        canAdd = false;
                        break;
                    }
                }
            }


            if (canAdd)
            {
                _modifiers.Add(modifier);
            }
            else
            {
                var tmpmodifier = _modifiers[positionId];

                var value = tmpmodifier.Attribute.Value; //get our "original" value
                value += modifier.Attribute.Value; //add the new value that came in, as we want to overwrite the existing value

                //prepare the constructor parameters
                //BaseAttribute(float value, float minvalue, float maxvalue, float increasestep, GameEnums.Modifier modifier)
                var argTypeInstruction = new object[]
                {
                    value,
                    tmpmodifier.Attribute.MinValue,
                    tmpmodifier.Attribute.MaxValue,
                    tmpmodifier.Attribute.IncreaseStep,
                    tmpmodifier.ModifierType
                };

                //create the new attribute, usando la clase Helpers en lugar del metodo privado de esta misma clase. TODO:Borrar este metodo privado
                var newAttr = Helpers.CreateInstance<BaseAttribute>(
                    Constants.NE_ATTRIBUTE,
                    modifier.Attribute.AttributeName,
                    argTypeInstruction);

                //create the new modifier to be added
                var mod = new Modifier(tmpmodifier.Id, tmpmodifier.ModifierType, newAttr);

                //replace the modifier with this new one
                _modifiers[positionId] = mod;
            }
        }

        public Modifier GetModifier<T>()
        {
            for (var i = 0; i < _modifiers.Count; ++i)
            {
                if (_modifiers[i].Attribute is T)
                {
                    return _modifiers[i];
                }
            }

            return null;
        }
        #endregion


        #region remove modifiers
        public void RemoveModifier(Modifier aModifier)
        {
            for (var i = _modifiers.Count - 1; i > -1; --i)
            {
                if (_modifiers[i] == aModifier)
                {
                    _modifiers.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveModifier<T>()
        {
            for (var i = _modifiers.Count - 1; i > -1; --i)
            {
                if (_modifiers[i].Attribute is T)
                {
                    _modifiers.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveAllModifiersWithType<T>()
        {
            for (var i = _modifiers.Count - 1; i > -1; --i)
            {
                if (_modifiers[i].Attribute is T)
                {
                    _modifiers.RemoveAt(i);
                }
            }
        }

        public void RemoveAllModifiers()
        {
            _modifiers.Clear();
        }
        #endregion


    }
}