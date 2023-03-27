
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DutyTypeDef")] 

    public  partial class DutyTypeDef : BaseResDevDef
    {
        public class DutyTypeDefList : TTObjectCollection<DutyTypeDef> { }
                    
        public class ChildDutyTypeDefCollection : TTObject.TTChildObjectCollection<DutyTypeDef>
        {
            public ChildDutyTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDutyTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDutyTypeDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DUTYTYPEDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DUTYTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetDutyTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDutyTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDutyTypeDef_Class() : base() { }
        }

        public static BindingList<DutyTypeDef.GetDutyTypeDef_Class> GetDutyTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DUTYTYPEDEF"].QueryDefs["GetDutyTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DutyTypeDef.GetDutyTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DutyTypeDef.GetDutyTypeDef_Class> GetDutyTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DUTYTYPEDEF"].QueryDefs["GetDutyTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DutyTypeDef.GetDutyTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateDutyCostCollection()
        {
            _DutyCost = new DutiesDetail.ChildDutiesDetailCollection(this, new Guid("35933b6e-db55-4ab8-8d48-36703f1f57f6"));
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

        protected DutyTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DutyTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DutyTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DutyTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DutyTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DUTYTYPEDEF", dataRow) { }
        protected DutyTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DUTYTYPEDEF", dataRow, isImported) { }
        public DutyTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DutyTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DutyTypeDef() : base() { }

    }
}