
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuffGroup")] 

    /// <summary>
    /// Tıbbi Malzeme Grup Tanımlama
    /// </summary>
    public  partial class MedicalStuffGroup : BaseMedicalStuffDef
    {
        public class MedicalStuffGroupList : TTObjectCollection<MedicalStuffGroup> { }
                    
        public class ChildMedicalStuffGroupCollection : TTObject.TTChildObjectCollection<MedicalStuffGroup>
        {
            public ChildMedicalStuffGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffGroup_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFGROUP"].AllPropertyDefs["CODE"].DataType;
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

            public GetMedicalStuffGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffGroup_Class() : base() { }
        }

        public static BindingList<MedicalStuffGroup.GetMedicalStuffGroup_Class> GetMedicalStuffGroup(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFGROUP"].QueryDefs["GetMedicalStuffGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffGroup.GetMedicalStuffGroup_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalStuffGroup.GetMedicalStuffGroup_Class> GetMedicalStuffGroup(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFGROUP"].QueryDefs["GetMedicalStuffGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffGroup.GetMedicalStuffGroup_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalStuffGroup> GetMedicalStuffGroupByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFGROUP"].QueryDefs["GetMedicalStuffGroupByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<MedicalStuffGroup>(queryDef, paramList);
        }

        protected MedicalStuffGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuffGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuffGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuffGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuffGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFFGROUP", dataRow) { }
        protected MedicalStuffGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFFGROUP", dataRow, isImported) { }
        public MedicalStuffGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuffGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuffGroup() : base() { }

    }
}