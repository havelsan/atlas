
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugProductionTestDetail")] 

    /// <summary>
    /// İlaç üretim işleminde üretilen ilaç bilgilerini tutan sınıftır
    /// </summary>
    public  partial class DrugProductionTestDetail : TTObject
    {
        public class DrugProductionTestDetailList : TTObjectCollection<DrugProductionTestDetail> { }
                    
        public class ChildDrugProductionTestDetailCollection : TTObject.TTChildObjectCollection<DrugProductionTestDetail>
        {
            public ChildDrugProductionTestDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugProductionTestDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DrugTestDetailReportNQL_Class : TTReportNqlObject 
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

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGPRODUCTIONTESTDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Productanalysestestdefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTANALYSESTESTDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTANALYSISTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Analyser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANALYSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DrugTestDetailReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugTestDetailReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugTestDetailReportNQL_Class() : base() { }
        }

        public static BindingList<DrugProductionTestDetail.DrugTestDetailReportNQL_Class> DrugTestDetailReportNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGPRODUCTIONTESTDETAIL"].QueryDefs["DrugTestDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugProductionTestDetail.DrugTestDetailReportNQL_Class> DrugTestDetailReportNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGPRODUCTIONTESTDETAIL"].QueryDefs["DrugTestDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        public ResUser RequestedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTEDBY"); }
            set { this["REQUESTEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Analyser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANALYSER"); }
            set { this["ANALYSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugProductionTest DrugProductionTest
        {
            get { return (DrugProductionTest)((ITTObject)this).GetParent("DRUGPRODUCTIONTEST"); }
            set { this["DRUGPRODUCTIONTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductAnalysisTestDefinition ProductAnalysisTestDefinition
        {
            get { return (ProductAnalysisTestDefinition)((ITTObject)this).GetParent("PRODUCTANALYSISTESTDEFINITION"); }
            set { this["PRODUCTANALYSISTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugProductionTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugProductionTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugProductionTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugProductionTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugProductionTestDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGPRODUCTIONTESTDETAIL", dataRow) { }
        protected DrugProductionTestDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGPRODUCTIONTESTDETAIL", dataRow, isImported) { }
        public DrugProductionTestDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugProductionTestDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugProductionTestDetail() : base() { }

    }
}