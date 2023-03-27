
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExchangeTypeDef")] 

    public  partial class ExchangeTypeDef : BaseResDevDef
    {
        public class ExchangeTypeDefList : TTObjectCollection<ExchangeTypeDef> { }
                    
        public class ChildExchangeTypeDefCollection : TTObject.TTChildObjectCollection<ExchangeTypeDef>
        {
            public ChildExchangeTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExchangeTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExchangeTypeDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXCHANGETYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXCHANGETYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetExchangeTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExchangeTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExchangeTypeDef_Class() : base() { }
        }

        public static BindingList<ExchangeTypeDef.GetExchangeTypeDef_Class> GetExchangeTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXCHANGETYPEDEF"].QueryDefs["GetExchangeTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExchangeTypeDef.GetExchangeTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExchangeTypeDef.GetExchangeTypeDef_Class> GetExchangeTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXCHANGETYPEDEF"].QueryDefs["GetExchangeTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExchangeTypeDef.GetExchangeTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateOtherCostCollection()
        {
            _OtherCost = new OtherCostDetail.ChildOtherCostDetailCollection(this, new Guid("5339f9ca-6372-4954-bbb1-0f68d521b0f3"));
            ((ITTChildObjectCollection)_OtherCost).GetChildren();
        }

        protected OtherCostDetail.ChildOtherCostDetailCollection _OtherCost = null;
        public OtherCostDetail.ChildOtherCostDetailCollection OtherCost
        {
            get
            {
                if (_OtherCost == null)
                    CreateOtherCostCollection();
                return _OtherCost;
            }
        }

        virtual protected void CreateDutyCostCollection()
        {
            _DutyCost = new DutiesDetail.ChildDutiesDetailCollection(this, new Guid("4651c841-864f-4767-8fcd-36920d9d36b2"));
            ((ITTChildObjectCollection)_DutyCost).GetChildren();
        }

        protected DutiesDetail.ChildDutiesDetailCollection _DutyCost = null;
        public DutiesDetail.ChildDutiesDetailCollection DutyCost
        {
            get
            {
                if (_DutyCost == null)
                    CreateDutyCostCollection();
                return _DutyCost;
            }
        }

        virtual protected void CreateReagentCostCollection()
        {
            _ReagentCost = new ReagentDetail.ChildReagentDetailCollection(this, new Guid("8f49fe7b-2d81-48e4-8e67-d7a3e3ff2566"));
            ((ITTChildObjectCollection)_ReagentCost).GetChildren();
        }

        protected ReagentDetail.ChildReagentDetailCollection _ReagentCost = null;
        public ReagentDetail.ChildReagentDetailCollection ReagentCost
        {
            get
            {
                if (_ReagentCost == null)
                    CreateReagentCostCollection();
                return _ReagentCost;
            }
        }

        virtual protected void CreateConsumableMaterialCollection()
        {
            _ConsumableMaterial = new ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection(this, new Guid("6d6217a2-7c54-44f5-aa04-d84fcb27bb17"));
            ((ITTChildObjectCollection)_ConsumableMaterial).GetChildren();
        }

        protected ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection _ConsumableMaterial = null;
        public ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection ConsumableMaterial
        {
            get
            {
                if (_ConsumableMaterial == null)
                    CreateConsumableMaterialCollection();
                return _ConsumableMaterial;
            }
        }

        protected ExchangeTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExchangeTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExchangeTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExchangeTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExchangeTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXCHANGETYPEDEF", dataRow) { }
        protected ExchangeTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXCHANGETYPEDEF", dataRow, isImported) { }
        public ExchangeTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExchangeTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExchangeTypeDef() : base() { }

    }
}