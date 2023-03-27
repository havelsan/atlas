
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugEntry")] 

    /// <summary>
    /// Hastanın İlaçları Giriş
    /// </summary>
    public  partial class PatientOwnDrugEntry : EpisodeAction
    {
        public class PatientOwnDrugEntryList : TTObjectCollection<PatientOwnDrugEntry> { }
                    
        public class ChildPatientOwnDrugEntryCollection : TTObject.TTChildObjectCollection<PatientOwnDrugEntry>
        {
            public ChildPatientOwnDrugEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientOwnDrugEntry_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? SendAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRYDETAIL"].AllPropertyDefs["SENDAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRYDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetPatientOwnDrugEntry_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientOwnDrugEntry_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientOwnDrugEntry_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("065f9abd-7f5c-4083-a574-165464a083a7"); } }
    /// <summary>
    /// Eczane Onay
    /// </summary>
            public static Guid PharmacyApproval { get { return new Guid("43493267-c747-42f7-babb-8e234848af23"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("51713295-ded2-4c67-8fbd-d1c108fb7c62"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("68de1a7c-7ec2-4ba0-9960-16b106ecef5f"); } }
        }

        public static BindingList<PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class> GetPatientOwnDrugEntry(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRY"].QueryDefs["GetPatientOwnDrugEntry"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class> GetPatientOwnDrugEntry(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGENTRY"].QueryDefs["GetPatientOwnDrugEntry"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreatePatientOwnDrugEntryDetailsCollection()
        {
            _PatientOwnDrugEntryDetails = new PatientOwnDrugEntryDetail.ChildPatientOwnDrugEntryDetailCollection(this, new Guid("40e485a6-d559-4b25-95ae-86b75d2c696b"));
            ((ITTChildObjectCollection)_PatientOwnDrugEntryDetails).GetChildren();
        }

        protected PatientOwnDrugEntryDetail.ChildPatientOwnDrugEntryDetailCollection _PatientOwnDrugEntryDetails = null;
        public PatientOwnDrugEntryDetail.ChildPatientOwnDrugEntryDetailCollection PatientOwnDrugEntryDetails
        {
            get
            {
                if (_PatientOwnDrugEntryDetails == null)
                    CreatePatientOwnDrugEntryDetailsCollection();
                return _PatientOwnDrugEntryDetails;
            }
        }

        virtual protected void CreatePatientLastUseDrugsCollection()
        {
            _PatientLastUseDrugs = new PatientLastUseDrug.ChildPatientLastUseDrugCollection(this, new Guid("319dfbef-17d8-42b5-8dfd-1c5c5c637281"));
            ((ITTChildObjectCollection)_PatientLastUseDrugs).GetChildren();
        }

        protected PatientLastUseDrug.ChildPatientLastUseDrugCollection _PatientLastUseDrugs = null;
        public PatientLastUseDrug.ChildPatientLastUseDrugCollection PatientLastUseDrugs
        {
            get
            {
                if (_PatientLastUseDrugs == null)
                    CreatePatientLastUseDrugsCollection();
                return _PatientLastUseDrugs;
            }
        }

        protected PatientOwnDrugEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGENTRY", dataRow) { }
        protected PatientOwnDrugEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGENTRY", dataRow, isImported) { }
        public PatientOwnDrugEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugEntry() : base() { }

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