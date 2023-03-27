
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirementDetailOutOfList")] 

    public  abstract  partial class AnnualRequirementDetailOutOfList : AnnualRequirementDetail
    {
        public class AnnualRequirementDetailOutOfListList : TTObjectCollection<AnnualRequirementDetailOutOfList> { }
                    
        public class ChildAnnualRequirementDetailOutOfListCollection : TTObject.TTChildObjectCollection<AnnualRequirementDetailOutOfList>
        {
            public ChildAnnualRequirementDetailOutOfListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementDetailOutOfListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnnualRequirementDetailOutOfListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILOUTOFLIST"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILOUTOFLIST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAnnualRequirementDetailOutOfListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnnualRequirementDetailOutOfListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnnualRequirementDetailOutOfListQuery_Class() : base() { }
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

        public static BindingList<AnnualRequirementDetailOutOfList> GetAvailableOutOfListDets(TTObjectContext objectContext, int IBFTYPE, int IBFYEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILOUTOFLIST"].QueryDefs["GetAvailableOutOfListDets"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IBFTYPE", IBFTYPE);
            paramList.Add("IBFYEAR", IBFYEAR);

            return ((ITTQuery)objectContext).QueryObjects<AnnualRequirementDetailOutOfList>(queryDef, paramList);
        }

        public static BindingList<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class> GetAnnualRequirementDetailOutOfListQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILOUTOFLIST"].QueryDefs["GetAnnualRequirementDetailOutOfListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class> GetAnnualRequirementDetailOutOfListQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTDETAILOUTOFLIST"].QueryDefs["GetAnnualRequirementDetailOutOfListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public LBPurchaseProjectDetailOutOfList LBPurchaseProjectDetOutOfList
        {
            get { return (LBPurchaseProjectDetailOutOfList)((ITTObject)this).GetParent("LBPURCHASEPROJECTDETOUTOFLIST"); }
            set { this["LBPURCHASEPROJECTDETOUTOFLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDemandDetailsCollection()
        {
            _DemandDetails = new DemandDetail.ChildDemandDetailCollection(this, new Guid("be0bd1af-56c0-4e41-bd86-119ba58b2f60"));
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

        virtual protected void CreateAnnualRequirement_StoreStocksCollection()
        {
            _AnnualRequirement_StoreStocks = new AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection(this, new Guid("c36de640-1330-4aca-8422-f2aff8583312"));
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

        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENTDETAILOUTOFLIST", dataRow) { }
        protected AnnualRequirementDetailOutOfList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENTDETAILOUTOFLIST", dataRow, isImported) { }
        public AnnualRequirementDetailOutOfList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirementDetailOutOfList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirementDetailOutOfList() : base() { }

    }
}