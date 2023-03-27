
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionDocumentMaterial")] 

    /// <summary>
    /// Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class DistributionDocumentMaterial : StockActionDetailOut
    {
        public class DistributionDocumentMaterialList : TTObjectCollection<DistributionDocumentMaterial> { }
                    
        public class ChildDistributionDocumentMaterialCollection : TTObject.TTChildObjectCollection<DistributionDocumentMaterial>
        {
            public ChildDistributionDocumentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionDocumentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDistByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
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

            public GetDistByStoreIDForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistByStoreIDForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistByStoreIDForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistributionForMaterialRequestReportQuery_Class : TTReportNqlObject 
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

            public GetDistributionForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributionForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributionForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExistAutoDistributionDoc_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetExistAutoDistributionDoc_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExistAutoDistributionDoc_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExistAutoDistributionDoc_Class() : base() { }
        }

        [Serializable] 

        public partial class PrescriptionTypeDistQuery_Class : TTReportNqlObject 
        {
            public Guid? DestinationStore
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DESTINATIONSTORE"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public PrescriptionTypeDistQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PrescriptionTypeDistQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PrescriptionTypeDistQuery_Class() : base() { }
        }

        public static BindingList<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class> GetDistByStoreIDForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetDistByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class> GetDistByStoreIDForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetDistByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class> GetDistributionForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetDistributionForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class> GetDistributionForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetDistributionForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class> GetExistAutoDistributionDoc(Guid STOREGUID, IList<Guid> MATERIALS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetExistAutoDistributionDoc"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREGUID", STOREGUID);
            paramList.Add("MATERIALS", MATERIALS);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class> GetExistAutoDistributionDoc(TTObjectContext objectContext, Guid STOREGUID, IList<Guid> MATERIALS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["GetExistAutoDistributionDoc"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREGUID", STOREGUID);
            paramList.Add("MATERIALS", MATERIALS);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class> PrescriptionTypeDistQuery(DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, bool ALLMATERIALS, IList<string> MATERIALS, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["PrescriptionTypeDistQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);
            paramList.Add("ALLMATERIALS", ALLMATERIALS);
            paramList.Add("MATERIALS", MATERIALS);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class> PrescriptionTypeDistQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, bool ALLMATERIALS, IList<string> MATERIALS, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENTMATERIAL"].QueryDefs["PrescriptionTypeDistQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);
            paramList.Add("ALLMATERIALS", ALLMATERIALS);
            paramList.Add("MATERIALS", MATERIALS);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? AcceptedAmount
        {
            get { return (Currency?)this["ACCEPTEDAMOUNT"]; }
            set { this["ACCEPTEDAMOUNT"] = value; }
        }

        public Guid? DistributionDepStoreMatID
        {
            get { return (Guid?)this["DISTRIBUTIONDEPSTOREMATID"]; }
            set { this["DISTRIBUTIONDEPSTOREMATID"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public DistributionDocument DistributionDocument
        {
            get 
            {   
                if (StockAction is DistributionDocument)
                    return (DistributionDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get 
            {   
                if (Material is DrugDefinition)
                    return (DrugDefinition)Material; 
                return null;
            }            
            set { Material = value; }
        }

        protected DistributionDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionDocumentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONDOCUMENTMATERIAL", dataRow) { }
        protected DistributionDocumentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONDOCUMENTMATERIAL", dataRow, isImported) { }
        public DistributionDocumentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionDocumentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionDocumentMaterial() : base() { }

    }
}