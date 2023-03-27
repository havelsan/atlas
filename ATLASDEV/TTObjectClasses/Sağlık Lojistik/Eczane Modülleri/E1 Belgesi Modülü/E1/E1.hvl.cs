
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="E1")] 

    /// <summary>
    /// E1 Çizelgesi
    /// </summary>
    public  partial class E1 : StockAction, IStockOutTransaction
    {
        public class E1List : TTObjectCollection<E1> { }
                    
        public class ChildE1Collection : TTObject.TTChildObjectCollection<E1>
        {
            public ChildE1Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildE1Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid Record { get { return new Guid("7350686c-71af-4dea-91b2-27a7a0dc27e4"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approved { get { return new Guid("4fbe0ac5-f84d-462a-b749-662271f1028a"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("97c45011-edda-4ed6-8431-855e01802040"); } }
        }

        public static BindingList<E1> GetE1s(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["E1"].QueryDefs["GetE1s"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<E1>(queryDef, paramList);
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        protected E1(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected E1(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected E1(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected E1(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected E1(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "E1", dataRow) { }
        protected E1(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "E1", dataRow, isImported) { }
        public E1(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public E1(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public E1() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}