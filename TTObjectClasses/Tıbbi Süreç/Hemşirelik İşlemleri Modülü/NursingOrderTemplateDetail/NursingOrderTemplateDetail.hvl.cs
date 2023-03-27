
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingOrderTemplateDetail")] 

    /// <summary>
    /// Hemşire Direktif Şablon Detayı
    /// </summary>
    public  partial class NursingOrderTemplateDetail : TTObject
    {
        public class NursingOrderTemplateDetailList : TTObjectCollection<NursingOrderTemplateDetail> { }
                    
        public class ChildNursingOrderTemplateDetailCollection : TTObject.TTChildObjectCollection<NursingOrderTemplateDetail>
        {
            public ChildNursingOrderTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingOrderTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingOrderTemplateDetailByTemplateID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public int? AmountForPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNTFORPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATEDETAIL"].AllPropertyDefs["AMOUNTFORPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATEDETAIL"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? RecurrenceDayAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECURRENCEDAYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATEDETAIL"].AllPropertyDefs["RECURRENCEDAYAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
                }
            }

            public GetNursingOrderTemplateDetailByTemplateID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingOrderTemplateDetailByTemplateID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingOrderTemplateDetailByTemplateID_Class() : base() { }
        }

        public static BindingList<NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID_Class> GetNursingOrderTemplateDetailByTemplateID(Guid NURSINGORDERTEMPLATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATEDETAIL"].QueryDefs["GetNursingOrderTemplateDetailByTemplateID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGORDERTEMPLATE", NURSINGORDERTEMPLATE);

            return TTReportNqlObject.QueryObjects<NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID_Class> GetNursingOrderTemplateDetailByTemplateID(TTObjectContext objectContext, Guid NURSINGORDERTEMPLATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATEDETAIL"].QueryDefs["GetNursingOrderTemplateDetailByTemplateID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGORDERTEMPLATE", NURSINGORDERTEMPLATE);

            return TTReportNqlObject.QueryObjects<NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uygulama Miktarı
    /// </summary>
        public int? AmountForPeriod
        {
            get { return (int?)this["AMOUNTFORPERIOD"]; }
            set { this["AMOUNTFORPERIOD"] = value; }
        }

    /// <summary>
    /// Uygulama Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? RecurrenceDayAmount
        {
            get { return (int?)this["RECURRENCEDAYAMOUNT"]; }
            set { this["RECURRENCEDAYAMOUNT"] = value; }
        }

        public ProcedureDefinition NursingOrderObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("NURSINGORDEROBJECT"); }
            set { this["NURSINGORDEROBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingOrderTemplate NursingOrderTemplate
        {
            get { return (NursingOrderTemplate)((ITTObject)this).GetParent("NURSINGORDERTEMPLATE"); }
            set { this["NURSINGORDERTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingOrderTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingOrderTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingOrderTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingOrderTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingOrderTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGORDERTEMPLATEDETAIL", dataRow) { }
        protected NursingOrderTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGORDERTEMPLATEDETAIL", dataRow, isImported) { }
        public NursingOrderTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingOrderTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingOrderTemplateDetail() : base() { }

    }
}