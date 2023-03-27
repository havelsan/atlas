
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalProviderServiceRequest")] 

    /// <summary>
    /// Dış XXXXXXlerden yapılan hizmet istek bilgileri
    /// </summary>
    public  partial class ExternalProviderServiceRequest : TTObject
    {
        public class ExternalProviderServiceRequestList : TTObjectCollection<ExternalProviderServiceRequest> { }
                    
        public class ChildExternalProviderServiceRequestCollection : TTObject.TTChildObjectCollection<ExternalProviderServiceRequest>
        {
            public ChildExternalProviderServiceRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalProviderServiceRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ExternalProviderServiceRequest> GetExtProviderByUniqueRefNo(TTObjectContext objectContext, long UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPROVIDERSERVICEREQUEST"].QueryDefs["GetExtProviderByUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<ExternalProviderServiceRequest>(queryDef, paramList);
        }

        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

        public string ReferringDoctor
        {
            get { return (string)this["REFERRINGDOCTOR"]; }
            set { this["REFERRINGDOCTOR"] = value; }
        }

        public string ConsultingDoctor
        {
            get { return (string)this["CONSULTINGDOCTOR"]; }
            set { this["CONSULTINGDOCTOR"] = value; }
        }

        public string HospitalService
        {
            get { return (string)this["HOSPITALSERVICE"]; }
            set { this["HOSPITALSERVICE"] = value; }
        }

        public string RequestService
        {
            get { return (string)this["REQUESTSERVICE"]; }
            set { this["REQUESTSERVICE"] = value; }
        }

        public DateTime? AdmitDate
        {
            get { return (DateTime?)this["ADMITDATE"]; }
            set { this["ADMITDATE"] = value; }
        }

        public int? Quantity
        {
            get { return (int?)this["QUANTITY"]; }
            set { this["QUANTITY"] = value; }
        }

        public string ProcedureCode
        {
            get { return (string)this["PROCEDURECODE"]; }
            set { this["PROCEDURECODE"] = value; }
        }

        public string OrderingFacility
        {
            get { return (string)this["ORDERINGFACILITY"]; }
            set { this["ORDERINGFACILITY"] = value; }
        }

        public string ProcedureName
        {
            get { return (string)this["PROCEDURENAME"]; }
            set { this["PROCEDURENAME"] = value; }
        }

        public string ClinicalInformation
        {
            get { return (string)this["CLINICALINFORMATION"]; }
            set { this["CLINICALINFORMATION"] = value; }
        }

        public DateTime? ScheduledDate
        {
            get { return (DateTime?)this["SCHEDULEDDATE"]; }
            set { this["SCHEDULEDDATE"] = value; }
        }

        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

        public string Diags
        {
            get { return (string)this["DIAGS"]; }
            set { this["DIAGS"] = value; }
        }

        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

        public string PlacerOrderNumber
        {
            get { return (string)this["PLACERORDERNUMBER"]; }
            set { this["PLACERORDERNUMBER"] = value; }
        }

        public string FillerOrderNumber
        {
            get { return (string)this["FILLERORDERNUMBER"]; }
            set { this["FILLERORDERNUMBER"] = value; }
        }

        public string HL7Message
        {
            get { return (string)this["HL7MESSAGE"]; }
            set { this["HL7MESSAGE"] = value; }
        }

        public string OrderStatus
        {
            get { return (string)this["ORDERSTATUS"]; }
            set { this["ORDERSTATUS"] = value; }
        }

        public string MessageControlId
        {
            get { return (string)this["MESSAGECONTROLID"]; }
            set { this["MESSAGECONTROLID"] = value; }
        }

        public RadiologyTest RadiologyTest
        {
            get { return (RadiologyTest)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalProviderServiceRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalProviderServiceRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalProviderServiceRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalProviderServiceRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalProviderServiceRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPROVIDERSERVICEREQUEST", dataRow) { }
        protected ExternalProviderServiceRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPROVIDERSERVICEREQUEST", dataRow, isImported) { }
        public ExternalProviderServiceRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalProviderServiceRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalProviderServiceRequest() : base() { }

    }
}