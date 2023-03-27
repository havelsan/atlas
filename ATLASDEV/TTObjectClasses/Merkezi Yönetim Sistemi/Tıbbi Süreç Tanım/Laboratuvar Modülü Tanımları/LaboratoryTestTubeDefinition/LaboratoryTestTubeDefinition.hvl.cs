
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTestTubeDefinition")] 

    public  partial class LaboratoryTestTubeDefinition : TTDefinitionSet
    {
        public class LaboratoryTestTubeDefinitionList : TTObjectCollection<LaboratoryTestTubeDefinition> { }
                    
        public class ChildLaboratoryTestTubeDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryTestTubeDefinition>
        {
            public ChildLaboratoryTestTubeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTestTubeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLaboratoryTestTubesNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTUBEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTUBEDEFINITION"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryTestTubesNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryTestTubesNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryTestTubesNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5104934c-a897-4cbf-9333-4368394ce6cb"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("f71aa241-762d-4087-9107-6e0935e22d84"); } }
        }

        public static BindingList<LaboratoryTestTubeDefinition.GetLaboratoryTestTubesNQL_Class> GetLaboratoryTestTubesNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTUBEDEFINITION"].QueryDefs["GetLaboratoryTestTubesNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestTubeDefinition.GetLaboratoryTestTubesNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryTestTubeDefinition.GetLaboratoryTestTubesNQL_Class> GetLaboratoryTestTubesNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTUBEDEFINITION"].QueryDefs["GetLaboratoryTestTubesNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTestTubeDefinition.GetLaboratoryTestTubesNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// TupTanimi
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// KisaTanim
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string ShortName_Shadow
        {
            get { return (string)this["SHORTNAME_SHADOW"]; }
        }

        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTESTTUBEDEFINITION", dataRow) { }
        protected LaboratoryTestTubeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTESTTUBEDEFINITION", dataRow, isImported) { }
        public LaboratoryTestTubeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTestTubeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTestTubeDefinition() : base() { }

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