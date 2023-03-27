
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalConsultationRequest")] 

    /// <summary>
    /// Diş Konsültasyon İstek
    /// </summary>
    public  partial class DentalConsultationRequest : EpisodeAction
    {
        public class DentalConsultationRequestList : TTObjectCollection<DentalConsultationRequest> { }
                    
        public class ChildDentalConsultationRequestCollection : TTObject.TTChildObjectCollection<DentalConsultationRequest>
        {
            public ChildDentalConsultationRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalConsultationRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("e188298f-c9a7-45c5-9311-c94d21407bcc"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d376395f-f61e-44fa-b3d2-96af9dbb09e3"); } }
            public static Guid Cancelled { get { return new Guid("ee03b94a-e07e-46d5-bdb9-d025d55c4fc3"); } }
        }

        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Dişler
    /// </summary>
        public string SelectedToothNumbers
        {
            get { return (string)this["SELECTEDTOOTHNUMBERS"]; }
            set { this["SELECTEDTOOTHNUMBERS"] = value; }
        }

        public DentalExamination DentalExamination
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION"); }
            set { this["DENTALEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ProcedureDoctor
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResPoliclinic ConsultationDepartment
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("CONSULTATIONDEPARTMENT"); }
            set { this["CONSULTATIONDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepartmentCollection()
        {
            _Department = new DentalConsultationDepartment.ChildDentalConsultationDepartmentCollection(this, new Guid("8a804053-98e1-44d6-b375-98639c161f79"));
            ((ITTChildObjectCollection)_Department).GetChildren();
        }

        protected DentalConsultationDepartment.ChildDentalConsultationDepartmentCollection _Department = null;
        public DentalConsultationDepartment.ChildDentalConsultationDepartmentCollection Department
        {
            get
            {
                if (_Department == null)
                    CreateDepartmentCollection();
                return _Department;
            }
        }

        protected DentalConsultationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalConsultationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalConsultationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalConsultationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalConsultationRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALCONSULTATIONREQUEST", dataRow) { }
        protected DentalConsultationRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALCONSULTATIONREQUEST", dataRow, isImported) { }
        public DentalConsultationRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalConsultationRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalConsultationRequest() : base() { }

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