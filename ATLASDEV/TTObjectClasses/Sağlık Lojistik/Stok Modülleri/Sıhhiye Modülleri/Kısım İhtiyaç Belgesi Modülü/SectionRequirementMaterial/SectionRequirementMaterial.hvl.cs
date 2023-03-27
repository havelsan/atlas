
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SectionRequirementMaterial")] 

    /// <summary>
    /// Kısım İhtiyaç Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class SectionRequirementMaterial : StockActionDetailOut
    {
        public class SectionRequirementMaterialList : TTObjectCollection<SectionRequirementMaterial> { }
                    
        public class ChildSectionRequirementMaterialCollection : TTObject.TTChildObjectCollection<SectionRequirementMaterial>
        {
            public ChildSectionRequirementMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSectionRequirementMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSectionByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Requestamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetSectionByStoreIDForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSectionByStoreIDForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSectionByStoreIDForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalAmountByYear_Class : TTReportNqlObject 
        {
            public Object Requestamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                }
            }

            public Object Acceptedamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCEPTEDAMOUNT"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public GetTotalAmountByYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalAmountByYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalAmountByYear_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSectionRequirementForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Requestamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetSectionRequirementForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSectionRequirementForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSectionRequirementForMaterialRequestReportQuery_Class() : base() { }
        }

        public static BindingList<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class> GetSectionByStoreIDForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetSectionByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class> GetSectionByStoreIDForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetSectionByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirementMaterial.GetTotalAmountByYear_Class> GetTotalAmountByYear(string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetTotalAmountByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetTotalAmountByYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirementMaterial.GetTotalAmountByYear_Class> GetTotalAmountByYear(TTObjectContext objectContext, string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetTotalAmountByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetTotalAmountByYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class> GetSectionRequirementForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetSectionRequirementForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class> GetSectionRequirementForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENTMATERIAL"].QueryDefs["GetSectionRequirementForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? AcceptedAmount
        {
            get { return (Currency?)this["ACCEPTEDAMOUNT"]; }
            set { this["ACCEPTEDAMOUNT"] = value; }
        }

        protected SectionRequirementMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SectionRequirementMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SectionRequirementMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SectionRequirementMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SectionRequirementMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SECTIONREQUIREMENTMATERIAL", dataRow) { }
        protected SectionRequirementMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SECTIONREQUIREMENTMATERIAL", dataRow, isImported) { }
        public SectionRequirementMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SectionRequirementMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SectionRequirementMaterial() : base() { }

    }
}