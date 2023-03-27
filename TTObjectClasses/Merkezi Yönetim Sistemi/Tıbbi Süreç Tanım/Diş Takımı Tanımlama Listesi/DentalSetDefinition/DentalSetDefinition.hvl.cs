
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalSetDefinition")] 

    /// <summary>
    /// Diş Takım Tanımları
    /// </summary>
    public  partial class DentalSetDefinition : TTDefinitionSet
    {
        public class DentalSetDefinitionList : TTObjectCollection<DentalSetDefinition> { }
                    
        public class ChildDentalSetDefinitionCollection : TTObject.TTChildObjectCollection<DentalSetDefinition>
        {
            public ChildDentalSetDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalSetDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDentalSets_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALSETDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALSETDEFINITION"].AllPropertyDefs["INHELD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDentalSets_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalSets_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalSets_Class() : base() { }
        }

        public static BindingList<DentalSetDefinition.GetDentalSets_Class> GetDentalSets(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALSETDEFINITION"].QueryDefs["GetDentalSets"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalSetDefinition.GetDentalSets_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalSetDefinition.GetDentalSets_Class> GetDentalSets(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALSETDEFINITION"].QueryDefs["GetDentalSets"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalSetDefinition.GetDentalSets_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Inheld
    /// </summary>
        public double? Inheld
        {
            get { return (double?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

    /// <summary>
    /// Name
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected DentalSetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalSetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalSetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalSetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalSetDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALSETDEFINITION", dataRow) { }
        protected DentalSetDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALSETDEFINITION", dataRow, isImported) { }
        protected DentalSetDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalSetDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalSetDefinition() : base() { }

    }
}