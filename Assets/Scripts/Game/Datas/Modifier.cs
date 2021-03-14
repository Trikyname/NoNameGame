using Assets.Scripts.Game.Commun;
using Assets.Scripts.Game.Datas.Attribute;
/**
*Descripcion de la clase: 
*Clase para controlar la modificacion a los atributos que se puede dar duarante el juego.
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas
{
    [System.Serializable]
    public class Modifier
    {
        public uint Id { private set; get; } //Si ponemos un id unico el modificador no se podra aplicar dos veces.
        public GameEnums.Modifier ModifierType { private set; get; } //3 formulas basicas de modificar el atributo "percent", "addition" and "critics"
        public BaseAttribute Attribute { private set; get; } //Representa el atributo que se modifica

        #region constructors
        public Modifier() { }
        
        public Modifier(uint _id,
            GameEnums.Modifier _formula,
            BaseAttribute _attribute)
        {
            Id = _id;
            ModifierType = _formula;
            Attribute = _attribute;
        }


        public Modifier(Modifier modifier)
        {
            Id = modifier.Id;
            ModifierType = modifier.ModifierType;
            Attribute = modifier.Attribute;
        }

        public Modifier Clone()
        {
            return new Modifier(this);
        }
        #endregion


        //just clear the attribute
        public void Destroy()
        {
            Attribute = null;
        }

    }

}