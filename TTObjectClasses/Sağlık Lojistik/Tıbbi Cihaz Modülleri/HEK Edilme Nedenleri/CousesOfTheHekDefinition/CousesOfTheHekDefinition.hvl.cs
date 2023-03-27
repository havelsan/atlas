
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CousesOfTheHekDefinition")] 

    public  partial class CousesOfTheHekDefinition : TerminologyManagerDef
    {
        public class CousesOfTheHekDefinitionList : TTObjectCollection<CousesOfTheHekDefinition> { }
                    
        public class ChildCousesOfTheHekDefinitionCollection : TTObject.TTChildObjectCollection<CousesOfTheHekDefinition>
        {
            public ChildCousesOfTheHekDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCousesOfTheHekDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCousesOfTheHekDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public int? Counter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUSESOFTHEHEKDEFINITION"].AllPropertyDefs["COUNTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUSESOFTHEHEKDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCousesOfTheHekDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCousesOfTheHekDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCousesOfTheHekDefinition_Class() : base() { }
        }

        public static BindingList<CousesOfTheHekDefinition.GetCousesOfTheHekDefinition_Class> GetCousesOfTheHekDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUSESOFTHEHEKDEFINITION"].QueryDefs["GetCousesOfTheHekDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CousesOfTheHekDefinition.GetCousesOfTheHekDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CousesOfTheHekDefinition.GetCousesOfTheHekDefinition_Class> GetCousesOfTheHekDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUSESOFTHEHEKDEFINITION"].QueryDefs["GetCousesOfTheHekDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CousesOfTheHekDefinition.GetCousesOfTheHekDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Counter
    /// </summary>
        public int? Counter
        {
            get { return (int?)this["COUNTER"]; }
            set { this["COUNTER"] = value; }
        }

    /// <summary>
    /// Description
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected CousesOfTheHekDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CousesOfTheHekDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CousesOfTheHekDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CousesOfTheHekDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CousesOfTheHekDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COUSESOFTHEHEKDEFINITION", dataRow) { }
        protected CousesOfTheHekDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COUSESOFTHEHEKDEFINITION", dataRow, isImported) { }
        public CousesOfTheHekDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CousesOfTheHekDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CousesOfTheHekDefinition() : base() { }

    }
}