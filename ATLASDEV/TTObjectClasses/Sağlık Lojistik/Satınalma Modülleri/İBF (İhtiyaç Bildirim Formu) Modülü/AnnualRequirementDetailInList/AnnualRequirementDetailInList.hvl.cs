
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirementDetailInList")] 

    public  abstract  partial class AnnualRequirementDetailInList : AnnualRequirementDetail
    {
        public class AnnualRequirementDetailInListList : TTObjectCollection<AnnualRequirementDetailInList> { }
                    
        public class ChildAnnualRequirementDetailInListCollection : TTObject.TTChildObjectCollection<AnnualRequirementDetailInList>
        {
            public ChildAnnualRequirementDetailInListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementDetailInListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnnualRequirementDetailInListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NSN
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["NSN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? AccountancyStock
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYSTOCK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["ACCOUNTANCYSTOCK"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ClinicStocks
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICSTOCKS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["CLINICSTOCKS"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ConsumptionAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSUMPTIONAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["CONSUMPTIONAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? LastIBFRequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTIBFREQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["LASTIBFREQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAnnualRequirementDetailInListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnnualRequirementDetailInListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnnualRequirementDetailInListQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d9fc1811-1f02-4d91-905e-96cb589bd920"); } }
            public static Guid New { get { return new Guid("b598888e-7eef-48fb-9f95-495cae2a77ca"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("81b0c9a7-849c-4b52-b4b8-acd19a2615c8"); } }
        }

        public static BindingList<AnnualRequirementDetailInList> GetAvailableInListDets(TTObjectContext objectContext, int IBFTYPE, int IBFYEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].QueryDefs["GetAvailableInListDets"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IBFTYPE", IBFTYPE);
            paramList.Add("IBFYEAR", IBFYEAR);

            return ((ITTQuery)objectContext).QueryObjects<AnnualRequirementDetailInList>(queryDef, paramList);
        }

        public static BindingList<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class> GetAnnualRequirementDetailInListQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].QueryDefs["GetAnnualRequirementDetailInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class> GetAnnualRequirementDetailInListQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILINLIST"].QueryDefs["GetAnnualRequirementDetailInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public LBPurchaseProjectDetailInList LBPurchaseProjectDetailInList
        {
            get { return (LBPurchaseProjectDetailInList)((ITTObject)this).GetParent("LBPURCHASEPROJECTDETAILINLIST"); }
            set { this["LBPURCHASEPROJECTDETAILINLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAnnualRequirement_StoreStocksCollection()
        {
            _AnnualRequirement_StoreStocks = new AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection(this, new Guid("e195c94e-5f37-493f-a19e-36c1ede54309"));
            ((ITTChildObjectCollection)_AnnualRequirement_StoreStocks).GetChildren();
        }

        protected AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection _AnnualRequirement_StoreStocks = null;
        public AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection AnnualRequirement_StoreStocks
        {
            get
            {
                if (_AnnualRequirement_StoreStocks == null)
                    CreateAnnualRequirement_StoreStocksCollection();
                return _AnnualRequirement_StoreStocks;
            }
        }

        virtual protected void CreateDemandDetailsCollection()
        {
            _DemandDetails = new DemandDetail.ChildDemandDetailCollection(this, new Guid("df3d8b41-484f-4ada-a65e-8fa6451f19d8"));
            ((ITTChildObjectCollection)_DemandDetails).GetChildren();
        }

        protected DemandDetail.ChildDemandDetailCollection _DemandDetails = null;
        public DemandDetail.ChildDemandDetailCollection DemandDetails
        {
            get
            {
                if (_DemandDetails == null)
                    CreateDemandDetailsCollection();
                return _DemandDetails;
            }
        }

        protected AnnualRequirementDetailInList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirementDetailInList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirementDetailInList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirementDetailInList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirementDetailInList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENTDETAILINLIST", dataRow) { }
        protected AnnualRequirementDetailInList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENTDETAILINLIST", dataRow, isImported) { }
        public AnnualRequirementDetailInList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirementDetailInList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirementDetailInList() : base() { }

    }
}