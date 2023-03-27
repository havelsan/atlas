
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedicalStuffDef")] 

    public  abstract  partial class BaseMedicalStuffDef : TerminologyManagerDef
    {
        public class BaseMedicalStuffDefList : TTObjectCollection<BaseMedicalStuffDef> { }
                    
        public class ChildBaseMedicalStuffDefCollection : TTObject.TTChildObjectCollection<BaseMedicalStuffDef>
        {
            public ChildBaseMedicalStuffDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedicalStuffDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffDef_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEMEDICALSTUFFDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEMEDICALSTUFFDEF"].AllPropertyDefs["NAME"].DataType;
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

            public GetMedicalStuffDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffDef_Class() : base() { }
        }

        public static BindingList<BaseMedicalStuffDef.GetMedicalStuffDef_Class> GetMedicalStuffDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDICALSTUFFDEF"].QueryDefs["GetMedicalStuffDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseMedicalStuffDef.GetMedicalStuffDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseMedicalStuffDef.GetMedicalStuffDef_Class> GetMedicalStuffDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDICALSTUFFDEF"].QueryDefs["GetMedicalStuffDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseMedicalStuffDef.GetMedicalStuffDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        protected BaseMedicalStuffDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedicalStuffDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedicalStuffDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedicalStuffDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedicalStuffDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDICALSTUFFDEF", dataRow) { }
        protected BaseMedicalStuffDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDICALSTUFFDEF", dataRow, isImported) { }
        public BaseMedicalStuffDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedicalStuffDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedicalStuffDef() : base() { }

    }
}