using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Objects;
using CommonClasses.Interfaces;
using System.Windows;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using Utilities;
using System.Reflection;

namespace EzerLaMorehEntity
{
    [Serializable]
    public abstract  class DCObjectContext  
    {

        #region Methods

       

       

        

        #endregion

        public T CreateObject<T>() where T : class
        {
            Func<object> constructorDelegateForType;
            T t = default(T);
            Type type = typeof(T);

            object o = new object();
            t = o as T;

            //this.MetadataWorkspace.ImplicitLoadAssemblyForType(type, null);
            //ClrEntityType item = this.MetadataWorkspace.GetItem<ClrEntityType>(type.FullName, DataSpace.OSpace);
            //EntityProxyTypeInfo entityProxyTypeInfo = null;
            //if (this.ContextOptions.ProxyCreationEnabled)
            //{
            //    EntityProxyTypeInfo proxyType = EntityProxyFactory.GetProxyType(item);
            //    entityProxyTypeInfo = proxyType;
            //    if (proxyType == null)
            //    {
            //        constructorDelegateForType = LightweightCodeGenerator.GetConstructorDelegateForType(item) as Func<object>;
            //        t = (T)(constructorDelegateForType() as T);
            //        return t;
            //    }
            //    t = (T)entityProxyTypeInfo.CreateProxyObject();
            //    IEntityWrapper entityWrapper = EntityWrapperFactory.CreateNewWrapper(t, null);
            //    entityWrapper.InitializingProxyRelatedEnds = true;
            //    try
            //    {
            //        entityWrapper.AttachContext(this, null, MergeOption.NoTracking);
            //        entityProxyTypeInfo.SetEntityWrapper(entityWrapper);
            //        if (entityProxyTypeInfo.InitializeEntityCollections != null)
            //        {
            //            DynamicMethod initializeEntityCollections = entityProxyTypeInfo.InitializeEntityCollections;
            //            object[] objArray = new object[] { entityWrapper };
            //            initializeEntityCollections.Invoke(null, objArray);
            //        }
            //        return t;
            //    }
            //    finally
            //    {
            //        entityWrapper.InitializingProxyRelatedEnds = false;
            //        entityWrapper.DetachContext();
            //    }
            //}
            //constructorDelegateForType = LightweightCodeGenerator.GetConstructorDelegateForType(item) as Func<object>;
            //t = (T)(constructorDelegateForType() as T);
            return t;
        }
        


        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        #region CommentedOut Original

        //public int SaveChanges()
        //{
        //    return 0;
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        ////public string  CheckDefaultInstance()
        ////{
        ////   Utilities.RegistryClass regClass = new RegistryClass();

        ////   return regClass.RegVal;            
        ////}

        //public virtual int SaveChanges(SaveOptions options)
        //{ 
        //    //this.OnSavingChanges();
        //    //if ((SaveOptions.DetectChangesBeforeSave & options) != SaveOptions.None)
        //    //{
        //    //    this.ObjectStateManager.DetectChanges();
        //    //}
        //    //if (this.ObjectStateManager.SomeEntryWithConceptualNullExists())
        //    //{
        //    //    throw new InvalidOperationException(Strings.ObjectContext_CommitWithConceptualNull);
        //    //}
        //    //bool flag = false;
        //    int objectStateEntriesCount = 0;//this.ObjectStateManager.GetObjectStateEntriesCount(EntityState.Added | EntityState.Deleted | EntityState.Modified);
        //    //EntityConnection connection = (EntityConnection)this.Connection;
        //    //if (0 < objectStateEntriesCount)
        //    //{
        //    //    if (this._adapter == null)
        //    //    {
        //    //        IServiceProvider factory = DbProviderFactories.GetFactory(connection) as IServiceProvider;
        //    //        if (factory != null)
        //    //        {
        //    //            this._adapter = factory.GetService(typeof(IEntityAdapter)) as IEntityAdapter;
        //    //        }
        //    //        if (this._adapter == null)
        //    //        {
        //    //            throw EntityUtil.InvalidDataAdapter();
        //    //        }
        //    //    }
        //    //    this._adapter.AcceptChangesDuringUpdate = false;
        //    //    this._adapter.Connection = connection;
        //    //    this._adapter.CommandTimeout = this.CommandTimeout;
        //    //    try
        //    //    {
        //    //        this.EnsureConnection();
        //    //        flag = true;
        //    //        bool flag1 = false;
        //    //        if (connection.CurrentTransaction == null && !connection.EnlistedInUserTransaction)
        //    //        {
        //    //            flag1 = null == this._lastTransaction;
        //    //        }
        //    //        using (DbTransaction dbTransaction = null)
        //    //        {
        //    //            if (flag1)
        //    //            {
        //    //                dbTransaction = connection.BeginTransaction();
        //    //            }
        //    //            objectStateEntriesCount = this._adapter.Update(this.ObjectStateManager);
        //    //            if (dbTransaction != null)
        //    //            {
        //    //                dbTransaction.Commit();
        //    //            }
        //    //        }
        //    //    }
        //    //    finally
        //    //    {
        //    //        if (flag)
        //    //        {
        //    //            this.ReleaseConnection();
        //    //        }
        //    //    }
        //    //    if ((SaveOptions.AcceptAllChangesAfterSave & options) != SaveOptions.None)
        //    //    {
        //    //        try
        //    //        {
        //    //            this.AcceptAllChanges();
        //    //        }
        //    //        catch (Exception exception1)
        //    //        {
        //    //            Exception exception = exception1;
        //    //            if (EntityUtil.IsCatchableExceptionType(exception))
        //    //            {
        //    //                throw EntityUtil.AcceptAllChangesFailure(exception);
        //    //            }
        //    //            throw;
        //    //        }
        //    //    }
        //    //}
        //     return objectStateEntriesCount;
        //}

        ///// <summary>Gets the object state manager used by the object context to track object changes.</summary>
        ///// <returns>The <see cref="T:System.Data.Objects.ObjectStateManager" /> used by this <see cref="T:System.Data.Objects.ObjectContext" />.</returns>
        ////public ObjectStateManager ObjectStateManager
        ////{
        ////    get
        ////    {
        ////        if (this._cache == null)
        ////        {
        ////            this._cache = new ObjectStateManager(this._workspace);
        ////        }
        ////        return this._cache;
        ////    }
        ////}

        //public T CreateObject<T>() where T : class
        //{
        //    Func<object> constructorDelegateForType;
        //    T t = default(T);
        //    Type type = typeof(T);

        //    object o = new object();
        //    t =  o as T;

        //    //this.MetadataWorkspace.ImplicitLoadAssemblyForType(type, null);
        //    //ClrEntityType item = this.MetadataWorkspace.GetItem<ClrEntityType>(type.FullName, DataSpace.OSpace);
        //    //EntityProxyTypeInfo entityProxyTypeInfo = null;
        //    //if (this.ContextOptions.ProxyCreationEnabled)
        //    //{
        //    //    EntityProxyTypeInfo proxyType = EntityProxyFactory.GetProxyType(item);
        //    //    entityProxyTypeInfo = proxyType;
        //    //    if (proxyType == null)
        //    //    {
        //    //        constructorDelegateForType = LightweightCodeGenerator.GetConstructorDelegateForType(item) as Func<object>;
        //    //        t = (T)(constructorDelegateForType() as T);
        //    //        return t;
        //    //    }
        //    //    t = (T)entityProxyTypeInfo.CreateProxyObject();
        //    //    IEntityWrapper entityWrapper = EntityWrapperFactory.CreateNewWrapper(t, null);
        //    //    entityWrapper.InitializingProxyRelatedEnds = true;
        //    //    try
        //    //    {
        //    //        entityWrapper.AttachContext(this, null, MergeOption.NoTracking);
        //    //        entityProxyTypeInfo.SetEntityWrapper(entityWrapper);
        //    //        if (entityProxyTypeInfo.InitializeEntityCollections != null)
        //    //        {
        //    //            DynamicMethod initializeEntityCollections = entityProxyTypeInfo.InitializeEntityCollections;
        //    //            object[] objArray = new object[] { entityWrapper };
        //    //            initializeEntityCollections.Invoke(null, objArray);
        //    //        }
        //    //        return t;
        //    //    }
        //    //    finally
        //    //    {
        //    //        entityWrapper.InitializingProxyRelatedEnds = false;
        //    //        entityWrapper.DetachContext();
        //    //    }
        //    //}
        //    //constructorDelegateForType = LightweightCodeGenerator.GetConstructorDelegateForType(item) as Func<object>;
        //    // t = (T)(constructorDelegateForType() as T);
        //    return t;
        //}

        #endregion
        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
       
       
    }

    /// <summary>Specifies the behavior of the object context when the <see cref="M:System.Data.Objects.ObjectContext.SaveChanges(System.Data.Objects.SaveOptions)" /> method is called.</summary>
    [Flags]
    public enum SaveOptions
    {
        /// <summary>Changes are saved without the <see cref="M:System.Data.Objects.ObjectContext.DetectChanges" /> or the <see cref="M:System.Data.Objects.ObjectContext.AcceptAllChangesAfterSave" /> methods being called.</summary>
        None,
        /// <summary>After changes are saved, the <see cref="M:System.Data.Objects.ObjectContext.AcceptAllChangesAfterSave" /> method is called, which resets change tracking in the <see cref="T:System.Data.Objects.ObjectStateManager" />.</summary>
        AcceptAllChangesAfterSave,
        /// <summary>Before changes are saved, the <see cref="M:System.Data.Objects.ObjectContext.DetectChanges" /> method is called to synchronize the property values of objects that are attached to the object context with data in the <see cref="T:System.Data.Objects.ObjectStateManager" />.</summary>
        DetectChangesBeforeSave
    }
}
