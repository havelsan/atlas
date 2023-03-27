
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRActionDataCorrection")] 

    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek Durumu Düzeltme
    /// </summary>
    public  partial class CMRActionDataCorrection : BaseDataCorrection, IWorkListBaseAction
    {
        public class CMRActionDataCorrectionList : TTObjectCollection<CMRActionDataCorrection> { }
                    
        public class ChildCMRActionDataCorrectionCollection : TTObject.TTChildObjectCollection<CMRActionDataCorrection>
        {
            public ChildCMRActionDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("d9790e13-5f79-433d-be62-19129fdf325b"); } }
            public static Guid Completed { get { return new Guid("700d8ba1-892d-4bd6-9ff7-4a176b35a168"); } }
            public static Guid New { get { return new Guid("96794408-5897-449f-b0a8-cc943dde2f62"); } }
        }

    /// <summary>
    /// Eski Kalibrasyon/Bakım/Onarım Durumu
    /// </summary>
        public string OldCMRActionStatus
        {
            get { return (string)this["OLDCMRACTIONSTATUS"]; }
            set { this["OLDCMRACTIONSTATUS"] = value; }
        }

    /// <summary>
    /// Yeni Kalibrasyon/Bakım/Onarım Durumu
    /// </summary>
        public string NewCMRActionStatus
        {
            get { return (string)this["NEWCMRACTIONSTATUS"]; }
            set { this["NEWCMRACTIONSTATUS"] = value; }
        }

    /// <summary>
    /// İş İstek No
    /// </summary>
        public string RequestNO
        {
            get { return (string)this["REQUESTNO"]; }
            set { this["REQUESTNO"] = value; }
        }

        public CMRActionRequest CMRActionRequest
        {
            get { return (CMRActionRequest)((ITTObject)this).GetParent("CMRACTIONREQUEST"); }
            set { this["CMRACTIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CMRActionDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRActionDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRActionDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRActionDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRActionDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTIONDATACORRECTION", dataRow) { }
        protected CMRActionDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTIONDATACORRECTION", dataRow, isImported) { }
        public CMRActionDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRActionDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRActionDataCorrection() : base() { }

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