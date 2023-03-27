
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadioPharmaceuticalUnitDefinition")] 

    /// <summary>
    /// Radyofarmasötik Birim Tanımları
    /// </summary>
    public  partial class RadioPharmaceuticalUnitDefinition : TTDefinitionSet
    {
        public class RadioPharmaceuticalUnitDefinitionList : TTObjectCollection<RadioPharmaceuticalUnitDefinition> { }
                    
        public class ChildRadioPharmaceuticalUnitDefinitionCollection : TTObject.TTChildObjectCollection<RadioPharmaceuticalUnitDefinition>
        {
            public ChildRadioPharmaceuticalUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadioPharmaceuticalUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadioPharmaceuticalUnitsNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALUNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALUNITDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadioPharmaceuticalUnitsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadioPharmaceuticalUnitsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadioPharmaceuticalUnitsNQL_Class() : base() { }
        }

        public static BindingList<RadioPharmaceuticalUnitDefinition.GetRadioPharmaceuticalUnitsNQL_Class> GetRadioPharmaceuticalUnitsNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALUNITDEFINITION"].QueryDefs["GetRadioPharmaceuticalUnitsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadioPharmaceuticalUnitDefinition.GetRadioPharmaceuticalUnitsNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadioPharmaceuticalUnitDefinition.GetRadioPharmaceuticalUnitsNQL_Class> GetRadioPharmaceuticalUnitsNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALUNITDEFINITION"].QueryDefs["GetRadioPharmaceuticalUnitsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadioPharmaceuticalUnitDefinition.GetRadioPharmaceuticalUnitsNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOPHARMACEUTICALUNITDEFINITION", dataRow) { }
        protected RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOPHARMACEUTICALUNITDEFINITION", dataRow, isImported) { }
        public RadioPharmaceuticalUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadioPharmaceuticalUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadioPharmaceuticalUnitDefinition() : base() { }

    }
}