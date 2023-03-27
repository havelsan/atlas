
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuffUsageType")] 

    /// <summary>
    /// İşitme Cihazları Kullanım Şekli
    /// </summary>
    public  partial class MedicalStuffUsageType : BaseMedicalStuffDef
    {
        public class MedicalStuffUsageTypeList : TTObjectCollection<MedicalStuffUsageType> { }
                    
        public class ChildMedicalStuffUsageTypeCollection : TTObject.TTChildObjectCollection<MedicalStuffUsageType>
        {
            public ChildMedicalStuffUsageTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffUsageTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffUsageTypes_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFUSAGETYPE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFUSAGETYPE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMedicalStuffUsageTypes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffUsageTypes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffUsageTypes_Class() : base() { }
        }

        public static BindingList<MedicalStuffUsageType.GetMedicalStuffUsageTypes_Class> GetMedicalStuffUsageTypes(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFUSAGETYPE"].QueryDefs["GetMedicalStuffUsageTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffUsageType.GetMedicalStuffUsageTypes_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalStuffUsageType.GetMedicalStuffUsageTypes_Class> GetMedicalStuffUsageTypes(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFUSAGETYPE"].QueryDefs["GetMedicalStuffUsageTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffUsageType.GetMedicalStuffUsageTypes_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected MedicalStuffUsageType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuffUsageType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuffUsageType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuffUsageType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuffUsageType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFFUSAGETYPE", dataRow) { }
        protected MedicalStuffUsageType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFFUSAGETYPE", dataRow, isImported) { }
        public MedicalStuffUsageType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuffUsageType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuffUsageType() : base() { }

    }
}