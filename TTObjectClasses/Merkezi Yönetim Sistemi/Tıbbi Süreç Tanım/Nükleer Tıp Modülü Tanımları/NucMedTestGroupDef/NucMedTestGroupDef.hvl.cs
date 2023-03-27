
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NucMedTestGroupDef")] 

    /// <summary>
    /// Nükleer Tıp Test Grup Tanımı
    /// </summary>
    public  partial class NucMedTestGroupDef : TTDefinitionSet
    {
        public class NucMedTestGroupDefList : TTObjectCollection<NucMedTestGroupDef> { }
                    
        public class ChildNucMedTestGroupDefCollection : TTObject.TTChildObjectCollection<NucMedTestGroupDef>
        {
            public ChildNucMedTestGroupDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNucMedTestGroupDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNucMedTestGrupDefsNQL_Class : TTReportNqlObject 
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

            public string TabOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].AllPropertyDefs["TABORDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNucMedTestGrupDefsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNucMedTestGrupDefsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNucMedTestGrupDefsNQL_Class() : base() { }
        }

        public static BindingList<NucMedTestGroupDef> GetTestGroups(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].QueryDefs["GetTestGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<NucMedTestGroupDef>(queryDef, paramList);
        }

        public static BindingList<NucMedTestGroupDef.GetNucMedTestGrupDefsNQL_Class> GetNucMedTestGrupDefsNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].QueryDefs["GetNucMedTestGrupDefsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NucMedTestGroupDef.GetNucMedTestGrupDefsNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NucMedTestGroupDef.GetNucMedTestGrupDefsNQL_Class> GetNucMedTestGrupDefsNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTESTGROUPDEF"].QueryDefs["GetNucMedTestGrupDefsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NucMedTestGroupDef.GetNucMedTestGrupDefsNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tab Order
    /// </summary>
        public string TabOrder
        {
            get { return (string)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Group Name
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateTabNamesCollection()
        {
            _TabNames = new NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection(this, new Guid("e0a3b475-493c-4808-98b4-fd5557cf180e"));
            ((ITTChildObjectCollection)_TabNames).GetChildren();
        }

        protected NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection _TabNames = null;
        public NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection TabNames
        {
            get
            {
                if (_TabNames == null)
                    CreateTabNamesCollection();
                return _TabNames;
            }
        }

        protected NucMedTestGroupDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NucMedTestGroupDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NucMedTestGroupDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NucMedTestGroupDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NucMedTestGroupDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCMEDTESTGROUPDEF", dataRow) { }
        protected NucMedTestGroupDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCMEDTESTGROUPDEF", dataRow, isImported) { }
        public NucMedTestGroupDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NucMedTestGroupDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NucMedTestGroupDef() : base() { }

    }
}