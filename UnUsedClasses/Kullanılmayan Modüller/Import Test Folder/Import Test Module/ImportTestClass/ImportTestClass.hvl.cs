
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportTestClass")] 

    public  partial class ImportTestClass : ImportTestClassBase, ImportTestInterface
    {
        public class ImportTestClassList : TTObjectCollection<ImportTestClass> { }
                    
        public class ChildImportTestClassCollection : TTObject.TTChildObjectCollection<ImportTestClass>
        {
            public ChildImportTestClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportTestClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ImportTestReportQuery_Class : TTReportNqlObject 
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

            public string Ulke
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ULKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].AllPropertyDefs["ULKE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sehir2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEHIR2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].AllPropertyDefs["SEHIR2"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImportTestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ImportTestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ImportTestReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("38e3ad63-fd21-4dae-b5fc-53998caf3189"); } }
            public static Guid New { get { return new Guid("12c3f542-aef2-4c7f-bd2f-94d405529664"); } }
        }

        public static BindingList<ImportTestClass> ImportTestQuery(TTObjectContext objectContext, string PARAMULKE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].QueryDefs["ImportTestQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMULKE", PARAMULKE);

            return ((ITTQuery)objectContext).QueryObjects<ImportTestClass>(queryDef, paramList);
        }

        public static BindingList<ImportTestClass.ImportTestReportQuery_Class> ImportTestReportQuery(string PARAMSEHIR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].QueryDefs["ImportTestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSEHIR", PARAMSEHIR);

            return TTReportNqlObject.QueryObjects<ImportTestClass.ImportTestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ImportTestClass.ImportTestReportQuery_Class> ImportTestReportQuery(TTObjectContext objectContext, string PARAMSEHIR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTCLASS"].QueryDefs["ImportTestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSEHIR", PARAMSEHIR);

            return TTReportNqlObject.QueryObjects<ImportTestClass.ImportTestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Ulke
        {
            get { return (string)this["ULKE"]; }
            set { this["ULKE"] = value; }
        }

        public string Sehir2
        {
            get { return (string)this["SEHIR2"]; }
            set { this["SEHIR2"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public ImportTestParent ImportTestParent
        {
            get { return (ImportTestParent)((ITTObject)this).GetParent("IMPORTTESTPARENT"); }
            set { this["IMPORTTESTPARENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateImportTestChildClassesCollection()
        {
            _ImportTestChildClasses = new ImportTestChildClass.ChildImportTestChildClassCollection(this, new Guid("d370c0de-5eee-4b78-a902-a7d0f0c99dee"));
            ((ITTChildObjectCollection)_ImportTestChildClasses).GetChildren();
        }

        protected ImportTestChildClass.ChildImportTestChildClassCollection _ImportTestChildClasses = null;
        public ImportTestChildClass.ChildImportTestChildClassCollection ImportTestChildClasses
        {
            get
            {
                if (_ImportTestChildClasses == null)
                    CreateImportTestChildClassesCollection();
                return _ImportTestChildClasses;
            }
        }

        protected ImportTestClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportTestClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportTestClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportTestClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportTestClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTTESTCLASS", dataRow) { }
        protected ImportTestClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTTESTCLASS", dataRow, isImported) { }
        public ImportTestClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportTestClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportTestClass() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}