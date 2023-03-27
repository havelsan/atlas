
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityHealthRequest")] 

    public  partial class CommunityHealthRequest : BaseAction, IWorkListBaseAction
    {
        public class CommunityHealthRequestList : TTObjectCollection<CommunityHealthRequest> { }
                    
        public class ChildCommunityHealthRequestCollection : TTObject.TTChildObjectCollection<CommunityHealthRequest>
        {
            public ChildCommunityHealthRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityHealthRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("87dbb858-61d6-4382-b0c9-2b9f767a7107"); } }
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("99487212-6349-4e95-86cc-ed0640cc3e9e"); } }
    /// <summary>
    /// Sonuç
    /// </summary>
            public static Guid Completed { get { return new Guid("79c82302-4daf-477a-aecb-d3eb8935d274"); } }
            public static Guid Cancelled { get { return new Guid("dd153f5a-0e00-427a-bd65-2cba4291f660"); } }
    /// <summary>
    /// İstek Kabul
    /// </summary>
            public static Guid RequestAcception { get { return new Guid("2bbe889a-6e10-47de-b7ea-068eb0bdc252"); } }
        }

        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

        public string Deliverer
        {
            get { return (string)this["DELIVERER"]; }
            set { this["DELIVERER"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public bool? NoCharge
        {
            get { return (bool?)this["NOCHARGE"]; }
            set { this["NOCHARGE"] = value; }
        }

    /// <summary>
    /// Numunenin Alındığı Yer
    /// </summary>
        public string SamplePlace
        {
            get { return (string)this["SAMPLEPLACE"]; }
            set { this["SAMPLEPLACE"] = value; }
        }

    /// <summary>
    /// Adres
    /// </summary>
        public string Adresses
        {
            get { return (string)this["ADRESSES"]; }
            set { this["ADRESSES"] = value; }
        }

    /// <summary>
    /// Numune Türü
    /// </summary>
        public string SampleType
        {
            get { return (string)this["SAMPLETYPE"]; }
            set { this["SAMPLETYPE"] = value; }
        }

        public ResUser ApprovalDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVALDOCTOR"); }
            set { this["APPROVALDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Technician
        {
            get { return (ResUser)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GeneralInvoice MyGeneralInvoice
        {
            get { return (GeneralInvoice)((ITTObject)this).GetParent("MYGENERALINVOICE"); }
            set { this["MYGENERALINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CommunityPayer CommunityHealthPayer
        {
            get { return (CommunityPayer)((ITTObject)this).GetParent("COMMUNITYHEALTHPAYER"); }
            set { this["COMMUNITYHEALTHPAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProceduresCollection()
        {
            _Procedures = new CommunityHealthProcedure.ChildCommunityHealthProcedureCollection(this, new Guid("c31284f0-def7-490b-be34-12dd72dcb6d0"));
            ((ITTChildObjectCollection)_Procedures).GetChildren();
        }

        protected CommunityHealthProcedure.ChildCommunityHealthProcedureCollection _Procedures = null;
        public CommunityHealthProcedure.ChildCommunityHealthProcedureCollection Procedures
        {
            get
            {
                if (_Procedures == null)
                    CreateProceduresCollection();
                return _Procedures;
            }
        }

        protected CommunityHealthRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityHealthRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityHealthRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityHealthRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityHealthRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYHEALTHREQUEST", dataRow) { }
        protected CommunityHealthRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYHEALTHREQUEST", dataRow, isImported) { }
        public CommunityHealthRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityHealthRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityHealthRequest() : base() { }

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