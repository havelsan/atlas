
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ShellingProcedureMaterialOut")] 

    /// <summary>
    /// Ayıklama işleminde artan malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ShellingProcedureMaterialOut : StockActionDetailOut
    {
        public class ShellingProcedureMaterialOutList : TTObjectCollection<ShellingProcedureMaterialOut> { }
                    
        public class ChildShellingProcedureMaterialOutCollection : TTObject.TTChildObjectCollection<ShellingProcedureMaterialOut>
        {
            public ChildShellingProcedureMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildShellingProcedureMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetShellingProcedureOutMaterials_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SHELLINGPROCEDUREMATERIALOUT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? Inmaterialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INMATERIALID"]);
                }
            }

            public string Inmaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inmaterialamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INMATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SHELLINGPROCEDUREMATERIALIN"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetShellingProcedureOutMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetShellingProcedureOutMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetShellingProcedureOutMaterials_Class() : base() { }
        }

        public static BindingList<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class> GetShellingProcedureOutMaterials(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHELLINGPROCEDUREMATERIALOUT"].QueryDefs["GetShellingProcedureOutMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class> GetShellingProcedureOutMaterials(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SHELLINGPROCEDUREMATERIALOUT"].QueryDefs["GetShellingProcedureOutMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ShellingProcedure ShellingProcedure
        {
            get 
            {   
                if (StockAction is ShellingProcedure)
                    return (ShellingProcedure)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        virtual protected void CreateInMaterialsCollection()
        {
            _InMaterials = new ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection(this, new Guid("a71d5e17-5d40-4b51-8bee-862944574511"));
            ((ITTChildObjectCollection)_InMaterials).GetChildren();
        }

        protected ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection _InMaterials = null;
        public ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection InMaterials
        {
            get
            {
                if (_InMaterials == null)
                    CreateInMaterialsCollection();
                return _InMaterials;
            }
        }

        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SHELLINGPROCEDUREMATERIALOUT", dataRow) { }
        protected ShellingProcedureMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SHELLINGPROCEDUREMATERIALOUT", dataRow, isImported) { }
        public ShellingProcedureMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ShellingProcedureMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ShellingProcedureMaterialOut() : base() { }

    }
}