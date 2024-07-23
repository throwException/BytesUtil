using System;
using System.Collections.Generic;

namespace ThrowException.CSharpLibs.DataObjectLib
{
    public interface IDataContext<TDataObject>
        where TDataObject : IDataObject
    {
        void BeginTransaction();
        void Commit();
        long Count<T>() where T : TDataObject, new();
        long Count<T>(Condition condition) where T : TDataObject, new();
        T Create<T>(Guid id) where T : TDataObject, new();
        T Create<T>() where T : TDataObject, new();
        void Delete<T>(Guid id) where T : TDataObject, new();
        void Delete<T>(Condition condition) where T : TDataObject, new();
        void Dispose();
        T Load<T>(Guid id) where T : TDataObject, new();
        IEnumerable<T> Load<T>() where T : TDataObject, new();
        IEnumerable<T> Load<T>(Condition condition) where T : TDataObject, new();
        void Rollback();
        void Save(TDataObject obj);
    }
}