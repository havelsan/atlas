
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuffPlaceOfUsage")] 

    /// <summary>
    /// Tıbbi malzeme Kullanım Yeri Tanımlama
    /// </summary>
    public  partial class MedicalStuffPlaceOfUsage : BaseMedicalStuffDef
    {
        public class MedicalStuffPlaceOfUsageList : TTObjectCollection<MedicalStuffPlaceOfUsage> { }
                    
        public class ChildMedicalStuffPlaceOfUsageCollection : TTObject.TTChildObjectCollection<MedicalStuffPlaceOfUsage>
        {
            public ChildMedicalStuffPlaceOfUsageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffPlaceOfUsageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffPlaceOfUsage_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPLACEOFUSAGE"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPLACEOFUSAGE"].AllPropertyDefs["NAME"].DataType;
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

            public GetMedicalStuffPlaceOfUsage_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffPlaceOfUsage_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffPlaceOfUsage_Class() : base() { }
        }

        public static BindingList<MedicalStuffPlaceOfUsage.GetMedicalStuffPlaceOfUsage_Class> GetMedicalStuffPlaceOfUsage(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPLACEOFUSAGE"].QueryDefs["GetMedicalStuffPlaceOfUsage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffPlaceOfUsage.GetMedicalStuffPlaceOfUsage_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalStuffPlaceOfUsage.GetMedicalStuffPlaceOfUsage_Class> GetMedicalStuffPlaceOfUsage(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPLACEOFUSAGE"].QueryDefs["GetMedicalStuffPlaceOfUsage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffPlaceOfUsage.GetMedicalStuffPlaceOfUsage_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFFPLACEOFUSAGE", dataRow) { }
        protected MedicalStuffPlaceOfUsage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFFPLACEOFUSAGE", dataRow, isImported) { }
        public MedicalStuffPlaceOfUsage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuffPlaceOfUsage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuffPlaceOfUsage() : base() { }

    }
}