using Assets.Scripts.Game.Datas;
using System.Collections.Generic;
using UnityEngine;

/**
*Descripcion de la clase:
*  Clase abstracta para gestionar las distintas funcionalidades que puede tener un player. Cada una de estas funciones
*  estara contenida en un componente. El player debe tener una lista de componentes asociados para extender las funcionalidades
*  que quiera poseer
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Components

{
    public abstract class BaseComponent
    {
        public bool CanExecuteComponet { get => _canExecuteComponet; set => _canExecuteComponet = value; }
        public uint EntityId { get => _entityId; set => _entityId = value; }

        protected bool _canExecuteComponet = false;
        protected uint _entityId = 0;

        public abstract void InitComponet(Transform transform, EntityData entityData, List<BaseComponent> list, params object[] arg);
        
        public bool ICanExecuteComponet
        {
            get {
                return _canExecuteComponet; 
            }
        }

        public virtual uint GetEntityId
        {
            get {
                return _entityId;
            }
            
        }

        

        public virtual bool IIsBusy()
        {
            return false;
        }
        public virtual bool ICanExecute()
        {
            return false;
        }
        public virtual void IUpday(float value = 0f) { }

        public virtual void IFixedUpday(float value = 0f) { }

        public virtual void IUpdayData(EntityData entityData) { }


        public virtual void IGamePaused(bool value) { }
        public virtual void ISetData(params object[] arg) { }

        public virtual void IRefreshData(params object[] arg) { }
        public virtual void IReset()
        {
            _canExecuteComponet = false;
        }
        public virtual void IResetForPool()
        {
            _canExecuteComponet = false;
        }
        public virtual void IStart()
        {
            _canExecuteComponet = true;
        }
        public virtual void IStop()
        {
            _canExecuteComponet = false;
        }

        public virtual void IExecute() { }

        public virtual void IExecuteWithResponse(System.Action OnExecuted) { }

        public virtual void IDestroy() { }
        public virtual void IOnEnable() { }

        public virtual void IOnDisable() { }
    }
}

