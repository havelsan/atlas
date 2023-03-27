
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalTimeDemand")] 

    public  partial class AdditionalTimeDemand : BaseAction, IWorkListBaseAction
    {
        public class AdditionalTimeDemandList : TTObjectCollection<AdditionalTimeDemand> { }
                    
        public class ChildAdditionalTimeDemandCollection : TTObject.TTChildObjectCollection<AdditionalTimeDemand>
        {
            public ChildAdditionalTimeDemandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalTimeDemandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("40f95474-d567-4baf-9046-739766bd4f61"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approve { get { return new Guid("973e1f71-5b25-43a2-a520-ca9a555c8d8f"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("ba51552d-7222-4666-bd40-055df8d8218c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Rejected { get { return new Guid("90cec306-afa1-4915-a070-78bdfb7f79a4"); } }
        }

        public int? ExtraDuration
        {
            get { return (int?)this["EXTRADURATION"]; }
            set { this["EXTRADURATION"] = value; }
        }

        public DurationType? DurationType
        {
            get { return (DurationType?)(int?)this["DURATIONTYPE"]; }
            set { this["DURATIONTYPE"] = value; }
        }

        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        public ArgeProject Project
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROJECT"); }
            set { this["PROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AdditionalTimeDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalTimeDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalTimeDemand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalTimeDemand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalTimeDemand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALTIMEDEMAND", dataRow) { }
        protected AdditionalTimeDemand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALTIMEDEMAND", dataRow, isImported) { }
        public AdditionalTimeDemand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalTimeDemand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalTimeDemand() : base() { }

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