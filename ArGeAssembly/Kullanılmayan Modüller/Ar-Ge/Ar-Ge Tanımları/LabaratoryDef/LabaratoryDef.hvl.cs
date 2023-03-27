
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabaratoryDef")] 

    public  partial class LabaratoryDef : BaseResDevDef
    {
        public class LabaratoryDefList : TTObjectCollection<LabaratoryDef> { }
                    
        public class ChildLabaratoryDefCollection : TTObject.TTChildObjectCollection<LabaratoryDef>
        {
            public ChildLabaratoryDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabaratoryDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabaratoryDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetLabaratoryDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabaratoryDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabaratoryDef_Class() : base() { }
        }

        public static BindingList<LabaratoryDef.GetLabaratoryDef_Class> GetLabaratoryDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABARATORYDEF"].QueryDefs["GetLabaratoryDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LabaratoryDef.GetLabaratoryDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LabaratoryDef.GetLabaratoryDef_Class> GetLabaratoryDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABARATORYDEF"].QueryDefs["GetLabaratoryDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LabaratoryDef.GetLabaratoryDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreatePlanCollection()
        {
            _Plan = new LabaratoryPlaning.ChildLabaratoryPlaningCollection(this, new Guid("8ddbb9e0-8b82-48fe-a7fb-ce1d38c17c7a"));
            ((ITTChildObjectCollection)_Plan).GetChildren();
        }

        protected LabaratoryPlaning.ChildLabaratoryPlaningCollection _Plan = null;
        public LabaratoryPlaning.ChildLabaratoryPlaningCollection Plan
        {
            get
            {
                if (_Plan == null)
                    CreatePlanCollection();
                return _Plan;
            }
        }

        protected LabaratoryDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabaratoryDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabaratoryDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabaratoryDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabaratoryDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABARATORYDEF", dataRow) { }
        protected LabaratoryDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABARATORYDEF", dataRow, isImported) { }
        public LabaratoryDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabaratoryDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabaratoryDef() : base() { }

    }
}