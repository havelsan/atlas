
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikNetProtokol")] 

    /// <summary>
    /// Sağlık Net Protokol
    /// </summary>
    public  partial class SaglikNetProtokol : TTObject
    {
        public class SaglikNetProtokolList : TTObjectCollection<SaglikNetProtokol> { }
                    
        public class ChildSaglikNetProtokolCollection : TTObject.TTChildObjectCollection<SaglikNetProtokol>
        {
            public ChildSaglikNetProtokolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikNetProtokolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("a29b77c2-14a7-4092-a524-1ff9831edba7"); } }
            public static Guid Cancelled { get { return new Guid("f3814488-da47-4cbb-ad46-544b592f12a9"); } }
        }

    /// <summary>
    /// Bağlı Protokol
    /// </summary>
        public string bagliProtokolNo
        {
            get { return (string)this["BAGLIPROTOKOLNO"]; }
            set { this["BAGLIPROTOKOLNO"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? islemTarihi
        {
            get { return (DateTime?)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

    /// <summary>
    /// MHRS Alanı
    /// </summary>
        public string MHRS
        {
            get { return (string)this["MHRS"]; }
            set { this["MHRS"] = value; }
        }

    /// <summary>
    /// Episode
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCodeDefinition ProtokolTipi
        {
            get { return (SKRSCodeDefinition)((ITTObject)this).GetParent("PROTOKOLTIPI"); }
            set { this["PROTOKOLTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCodeDefinition HastaTipi
        {
            get { return (SKRSCodeDefinition)((ITTObject)this).GetParent("HASTATIPI"); }
            set { this["HASTATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCodeDefinition KlinikKodu
        {
            get { return (SKRSCodeDefinition)((ITTObject)this).GetParent("KLINIKKODU"); }
            set { this["KLINIKKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SaglikNetProtokol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikNetProtokol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikNetProtokol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikNetProtokol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikNetProtokol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKNETPROTOKOL", dataRow) { }
        protected SaglikNetProtokol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKNETPROTOKOL", dataRow, isImported) { }
        public SaglikNetProtokol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikNetProtokol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikNetProtokol() : base() { }

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