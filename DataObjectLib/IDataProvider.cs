using System;
using System.Collections.Generic;
using System.Reflection;
using ThrowException.CSharpLibs.DataObjectLib;

namespace ThrowException.CSharpLibs.DataObjectLib
{
    public interface IDataProvider<TDataObject> : IDisposable
        where TDataObject : IDataObject
    {
        IDataContext<TDataObject> CreateContext();
        ITransaction BeginTransaction();
        void Save(TDataObject obj, ITransaction transaction = null);
        void Delete<T>(Guid id, ITransaction transaction = null) where T : TDataObject, new();
        void Delete<T>(ITransaction transaction = null) where T : TDataObject, new();
        void Delete<T>(Condition condition, ITransaction transaction = null) where T : TDataObject, new();
        T Load<T>(Guid id, ITransaction transaction = null) where T : TDataObject, new();
        IEnumerable<T> Load<T>(ITransaction transaction = null) where T : TDataObject, new();
        IEnumerable<T> Load<T>(Condition condition, ITransaction transaction = null) where T : TDataObject, new();
        IEnumerable<Guid> List<T>(ITransaction transaction = null) where T : TDataObject, new();
        IEnumerable<Guid> List<T>(Condition condition, ITransaction transaction = null) where T : TDataObject, new();
        long Count<T>(ITransaction transaction = null) where T : TDataObject, new();
        long Count<T>(Condition condition, ITransaction transaction = null) where T : TDataObject, new();
    }
}
