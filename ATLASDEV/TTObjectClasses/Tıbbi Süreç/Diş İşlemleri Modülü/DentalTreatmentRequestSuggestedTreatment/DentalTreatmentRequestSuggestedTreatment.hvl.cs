
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalTreatmentRequestSuggestedTreatment")] 

    public  partial class DentalTreatmentRequestSuggestedTreatment : TTObject
    {
        public class DentalTreatmentRequestSuggestedTreatmentList : TTObjectCollection<DentalTreatmentRequestSuggestedTreatment> { }
                    
        public class ChildDentalTreatmentRequestSuggestedTreatmentCollection : TTObject.TTChildObjectCollection<DentalTreatmentRequestSuggestedTreatment>
        {
            public ChildDentalTreatmentRequestSuggestedTreatmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalTreatmentRequestSuggestedTreatmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetSuggestedDentalTreatments_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? MasterAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERACTION"]);
                }
            }

            public Guid? Treatment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENT"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public OLAP_GetSuggestedDentalTreatments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSuggestedDentalTreatments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSuggestedDentalTreatments_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c919300e-a96f-4dc4-a4bb-5d1cf76a5506"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("82f8840c-ede6-4d62-bf65-0a66dcdecf2b"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7d0854ef-67f5-4682-8eed-79e599b5f291"); } }
        }

    /// <summary>
    /// Diş Tedavi Sayısı
    /// </summary>
        public static BindingList<DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments_Class> OLAP_GetSuggestedDentalTreatments(string MA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUESTSUGGESTEDTREATMENT"].QueryDefs["OLAP_GetSuggestedDentalTreatments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MA", MA);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Diş Tedavi Sayısı
    /// </summary>
        public static BindingList<DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments_Class> OLAP_GetSuggestedDentalTreatments(TTObjectContext objectContext, string MA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUESTSUGGESTEDTREATMENT"].QueryDefs["OLAP_GetSuggestedDentalTreatments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MA", MA);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequestSuggestedTreatment.OLAP_GetSuggestedDentalTreatments_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? Emergency
        {
            get { return (bool?)this["EMERGENCY"]; }
            set { this["EMERGENCY"] = value; }
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Tedavi Birimi
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalTreatmentRequest DentalTreatmentRequest
        {
            get { return (DentalTreatmentRequest)((ITTObject)this).GetParent("DENTALTREATMENTREQUEST"); }
            set { this["DENTALTREATMENTREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önerilen Diş Tedavi
    /// </summary>
        public DentalTreatmentDefinition SuggestedTreatmentProcedure
        {
            get { return (DentalTreatmentDefinition)((ITTObject)this).GetParent("SUGGESTEDTREATMENTPROCEDURE"); }
            set { this["SUGGESTEDTREATMENTPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diş İstek Türü
    /// </summary>
        public DentalRequestTypeDefinition DentalRequestType
        {
            get { return (DentalRequestTypeDefinition)((ITTObject)this).GetParent("DENTALREQUESTTYPE"); }
            set { this["DENTALREQUESTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALTREATMENTREQUESTSUGGESTEDTREATMENT", dataRow) { }
        protected DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALTREATMENTREQUESTSUGGESTEDTREATMENT", dataRow, isImported) { }
        public DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalTreatmentRequestSuggestedTreatment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalTreatmentRequestSuggestedTreatment() : base() { }

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