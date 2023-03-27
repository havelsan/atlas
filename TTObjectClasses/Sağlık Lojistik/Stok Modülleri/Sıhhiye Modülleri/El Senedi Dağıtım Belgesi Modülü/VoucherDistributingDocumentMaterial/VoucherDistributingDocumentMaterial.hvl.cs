
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VoucherDistributingDocumentMaterial")] 

    /// <summary>
    /// El Senedi Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class VoucherDistributingDocumentMaterial : StockActionDetailOut, IVoucherDistributingDocumentMaterial
    {
        public class VoucherDistributingDocumentMaterialList : TTObjectCollection<VoucherDistributingDocumentMaterial> { }
                    
        public class ChildVoucherDistributingDocumentMaterialCollection : TTObject.TTChildObjectCollection<VoucherDistributingDocumentMaterial>
        {
            public ChildVoucherDistributingDocumentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVoucherDistributingDocumentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVoucherByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
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

            public GetVoucherByStoreIDForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVoucherByStoreIDForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVoucherByStoreIDForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVoucherDistributeForMaterialRequestReportQuery_Class : TTReportNqlObject 
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

            public GetVoucherDistributeForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVoucherDistributeForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVoucherDistributeForMaterialRequestReportQuery_Class() : base() { }
        }

        public static BindingList<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class> GetVoucherByStoreIDForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENTMATERIAL"].QueryDefs["GetVoucherByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class> GetVoucherByStoreIDForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENTMATERIAL"].QueryDefs["GetVoucherByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class> GetVoucherDistributeForMaterialRequestReportQuery(DateTime ENDDATE, DateTime STARTDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENTMATERIAL"].QueryDefs["GetVoucherDistributeForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class> GetVoucherDistributeForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENTMATERIAL"].QueryDefs["GetVoucherDistributeForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Inheld
        {
            get { return (Currency?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? RequireMaterial
        {
            get { return (Currency?)this["REQUIREMATERIAL"]; }
            set { this["REQUIREMATERIAL"] = value; }
        }

        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VOUCHERDISTRIBUTINGDOCUMENTMATERIAL", dataRow) { }
        protected VoucherDistributingDocumentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VOUCHERDISTRIBUTINGDOCUMENTMATERIAL", dataRow, isImported) { }
        public VoucherDistributingDocumentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VoucherDistributingDocumentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VoucherDistributingDocumentMaterial() : base() { }

    }
}