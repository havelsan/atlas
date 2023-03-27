
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDetDetailIn")] 

    /// <summary>
    /// İBF Detayları ana sınıfı (İBF Listesi Dahili)
    /// </summary>
    public  abstract  partial class IBFDetDetailIn : IBFBaseDemandDetail
    {
        public class IBFDetDetailInList : TTObjectCollection<IBFDetDetailIn> { }
                    
        public class ChildIBFDetDetailInCollection : TTObject.TTChildObjectCollection<IBFDetDetailIn>
        {
            public ChildIBFDetDetailInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDetDetailInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIBFDetailInQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["NSN"].DataType;
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

            public Currency? StoreStocks
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORESTOCKS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["STORESTOCKS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["CONSUMPTIONAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["LASTIBFREQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetIBFDetailInQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIBFDetailInQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIBFDetailInQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
        }

        public static BindingList<IBFDetDetailIn.GetIBFDetailInQuery_Class> GetIBFDetailInQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].QueryDefs["GetIBFDetailInQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<IBFDetDetailIn.GetIBFDetailInQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<IBFDetDetailIn.GetIBFDetailInQuery_Class> GetIBFDetailInQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILIN"].QueryDefs["GetIBFDetailInQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<IBFDetDetailIn.GetIBFDetailInQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        protected IBFDetDetailIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDetDetailIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDetDetailIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDetDetailIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDetDetailIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDETDETAILIN", dataRow) { }
        protected IBFDetDetailIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDETDETAILIN", dataRow, isImported) { }
        public IBFDetDetailIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDetDetailIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDetDetailIn() : base() { }

    }
}