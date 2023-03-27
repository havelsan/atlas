
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisRequestSuggestedProsthesis")] 

    public  partial class DentalProsthesisRequestSuggestedProsthesis : TTObject
    {
        public class DentalProsthesisRequestSuggestedProsthesisList : TTObjectCollection<DentalProsthesisRequestSuggestedProsthesis> { }
                    
        public class ChildDentalProsthesisRequestSuggestedProsthesisCollection : TTObject.TTChildObjectCollection<DentalProsthesisRequestSuggestedProsthesis>
        {
            public ChildDentalProsthesisRequestSuggestedProsthesisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisRequestSuggestedProsthesisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetSuggestedDentalProsthesis_Class : TTReportNqlObject 
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

            public OLAP_GetSuggestedDentalProsthesis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSuggestedDentalProsthesis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSuggestedDentalProsthesis_Class() : base() { }
        }

        public static BindingList<DentalProsthesisRequestSuggestedProsthesis> GetAllProsthesisByTechnician(TTObjectContext objectContext, Guid TECHNICIAN)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS"].QueryDefs["GetAllProsthesisByTechnician"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TECHNICIAN", TECHNICIAN);

            return ((ITTQuery)objectContext).QueryObjects<DentalProsthesisRequestSuggestedProsthesis>(queryDef, paramList);
        }

    /// <summary>
    /// Diş Tedavi Sayısı
    /// </summary>
        public static BindingList<DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis_Class> OLAP_GetSuggestedDentalProsthesis(string MA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS"].QueryDefs["OLAP_GetSuggestedDentalProsthesis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MA", MA);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Diş Tedavi Sayısı
    /// </summary>
        public static BindingList<DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis_Class> OLAP_GetSuggestedDentalProsthesis(TTObjectContext objectContext, string MA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS"].QueryDefs["OLAP_GetSuggestedDentalProsthesis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MA", MA);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequestSuggestedProsthesis.OLAP_GetSuggestedDentalProsthesis_Class>(objectContext, queryDef, paramList, pi);
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
    /// Diş Durum
    /// </summary>
        public DisDurumEnum? CurrentState
        {
            get { return (DisDurumEnum?)(int?)this["CURRENTSTATE"]; }
            set { this["CURRENTSTATE"] = value; }
        }

    /// <summary>
    /// Renk
    /// </summary>
        public string Color
        {
            get { return (string)this["COLOR"]; }
            set { this["COLOR"] = value; }
        }

    /// <summary>
    /// Dış Lab
    /// </summary>
        public string ExternalLab
        {
            get { return (string)this["EXTERNALLAB"]; }
            set { this["EXTERNALLAB"] = value; }
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
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Protez Birimi
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önerilen Diş Tedavi
    /// </summary>
        public DentalProsthesisDefinition SuggestedProsthesisProcedure
        {
            get { return (DentalProsthesisDefinition)((ITTObject)this).GetParent("SUGGESTEDPROSTHESISPROCEDURE"); }
            set { this["SUGGESTEDPROSTHESISPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalProsthesisRequest DentalProthesisRequest
        {
            get { return (DentalProsthesisRequest)((ITTObject)this).GetParent("DENTALPROTHESISREQUEST"); }
            set { this["DENTALPROTHESISREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Technician Technician
        {
            get { return (Technician)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS", dataRow) { }
        protected DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS", dataRow, isImported) { }
        public DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisRequestSuggestedProsthesis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisRequestSuggestedProsthesis() : base() { }

    }
}