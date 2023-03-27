
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientTransfer")] 

    /// <summary>
    /// Birimlerarası Nakil
    /// </summary>
    public  partial class PatientTransfer : EpisodeAction
    {
        public class PatientTransferList : TTObjectCollection<PatientTransfer> { }
                    
        public class ChildPatientTransferCollection : TTObject.TTChildObjectCollection<PatientTransfer>
        {
            public ChildPatientTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Request { get { return new Guid("a9b89ce3-7d22-4af5-9d48-4c2d13d8886d"); } }
            public static Guid ClinicApproval { get { return new Guid("2d4ee347-2ac9-4e60-98a4-8839dec81fe7"); } }
            public static Guid Cancelled { get { return new Guid("1382fc1d-c83a-45ef-8734-d4bc7db2da80"); } }
            public static Guid Transferred { get { return new Guid("bfd105a6-627c-4251-ac5c-ce146610eab9"); } }
        }

        public static BindingList<PatientTransfer> GetTransferredByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTTRANSFER"].QueryDefs["GetTransferredByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PatientTransfer>(queryDef, paramList);
        }

        public string ReturnToRequestReason
        {
            get { return (string)this["RETURNTOREQUESTREASON"]; }
            set { this["RETURNTOREQUESTREASON"] = value; }
        }

        public string ReturnToRequestByClinicReason
        {
            get { return (string)this["RETURNTOREQUESTBYCLINICREASON"]; }
            set { this["RETURNTOREQUESTBYCLINICREASON"] = value; }
        }

    /// <summary>
    /// Klinik Onay Açıklaması
    /// </summary>
        public string ClinicApprovalDescription
        {
            get { return (string)this["CLINICAPPROVALDESCRIPTION"]; }
            set { this["CLINICAPPROVALDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public long? ProtocolNo
        {
            get { return (long?)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

        public string ReasonForTransfer
        {
            get { return (string)this["REASONFORTRANSFER"]; }
            set { this["REASONFORTRANSFER"] = value; }
        }

    /// <summary>
    /// Onay Açıklaması
    /// </summary>
        public string ApprovalDescription
        {
            get { return (string)this["APPROVALDESCRIPTION"]; }
            set { this["APPROVALDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yatak
    /// </summary>
        public ResBed Bed
        {
            get { return (ResBed)((ITTObject)this).GetParent("BED"); }
            set { this["BED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nakil Yapılacak Oda Grubu
    /// </summary>
        public ResRoomGroup RoomGroup
        {
            get { return (ResRoomGroup)((ITTObject)this).GetParent("ROOMGROUP"); }
            set { this["ROOMGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Oda
    /// </summary>
        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nakil Yapılacağı Klinik
    /// </summary>
        public ResClinic TreatmentClinic
        {
            get { return (ResClinic)((ITTObject)this).GetParent("TREATMENTCLINIC"); }
            set { this["TREATMENTCLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication OldInPatientTrtmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("OLDINPATIENTTRTMENTCLINICAPP"); }
            set { this["OLDINPATIENTTRTMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication NewInPatientTrtmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("NEWINPATIENTTRTMENTCLINICAPP"); }
            set { this["NEWINPATIENTTRTMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yattığı Klinik / Servis
    /// </summary>
        public ResWard PhysicalStateClinic
        {
            get { return (ResWard)((ITTObject)this).GetParent("PHYSICALSTATECLINIC"); }
            set { this["PHYSICALSTATECLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTTRANSFER", dataRow) { }
        protected PatientTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTTRANSFER", dataRow, isImported) { }
        public PatientTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientTransfer() : base() { }

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