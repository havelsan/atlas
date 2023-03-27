
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsultationRequest")] 

    /// <summary>
    /// Konsültasyon İstek İşleminin Yapıldığı Temel Nesnedir
    /// </summary>
    public  partial class ConsultationRequest : EpisodeAction, IReasonOfReject
    {
        public class ConsultationRequestList : TTObjectCollection<ConsultationRequest> { }
                    
        public class ChildConsultationRequestCollection : TTObject.TTChildObjectCollection<ConsultationRequest>
        {
            public ChildConsultationRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsultationRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("0940633a-2a67-4750-9c47-4da177b0ac83"); } }
            public static Guid Request { get { return new Guid("7c1abce5-7586-4f14-867f-a96222d970b1"); } }
            public static Guid Completed { get { return new Guid("a9389755-ad9e-4932-aed0-cdf6a111c532"); } }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public object RequestDescription
        {
            get { return (object)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yatağında
    /// </summary>
        public bool? InPatientBed
        {
            get { return (bool?)this["INPATIENTBED"]; }
            set { this["INPATIENTBED"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

        protected ConsultationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsultationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsultationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsultationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsultationRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSULTATIONREQUEST", dataRow) { }
        protected ConsultationRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSULTATIONREQUEST", dataRow, isImported) { }
        public ConsultationRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsultationRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsultationRequest() : base() { }

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