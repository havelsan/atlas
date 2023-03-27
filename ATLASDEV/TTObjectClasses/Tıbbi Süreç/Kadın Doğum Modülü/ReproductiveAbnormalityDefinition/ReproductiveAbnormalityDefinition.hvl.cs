
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReproductiveAbnormalityDefinition")] 

    public  partial class ReproductiveAbnormalityDefinition : TerminologyManagerDef
    {
        public class ReproductiveAbnormalityDefinitionList : TTObjectCollection<ReproductiveAbnormalityDefinition> { }
                    
        public class ChildReproductiveAbnormalityDefinitionCollection : TTObject.TTChildObjectCollection<ReproductiveAbnormalityDefinition>
        {
            public ChildReproductiveAbnormalityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReproductiveAbnormalityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ReproductiveAbnormalityDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPRODUCTIVEABNORMALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReproductiveAbnormalityDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReproductiveAbnormalityDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReproductiveAbnormalityDefinitionNQL_Class() : base() { }
        }

        public static BindingList<ReproductiveAbnormalityDefinition.ReproductiveAbnormalityDefinitionNQL_Class> ReproductiveAbnormalityDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPRODUCTIVEABNORMALITYDEFINITION"].QueryDefs["ReproductiveAbnormalityDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReproductiveAbnormalityDefinition.ReproductiveAbnormalityDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReproductiveAbnormalityDefinition.ReproductiveAbnormalityDefinitionNQL_Class> ReproductiveAbnormalityDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPRODUCTIVEABNORMALITYDEFINITION"].QueryDefs["ReproductiveAbnormalityDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReproductiveAbnormalityDefinition.ReproductiveAbnormalityDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Üreme Organı Anomalisi Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public ReproductiveAbnormalityDefinition ParentGroup
        {
            get { return (ReproductiveAbnormalityDefinition)((ITTObject)this).GetParent("PARENTGROUP"); }
            set { this["PARENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReproductiveAbnormalityDefinitionsCollection()
        {
            _ReproductiveAbnormalityDefinitions = new ReproductiveAbnormalityDefinition.ChildReproductiveAbnormalityDefinitionCollection(this, new Guid("13cd587a-a3ed-470a-b96a-56de50617c3a"));
            ((ITTChildObjectCollection)_ReproductiveAbnormalityDefinitions).GetChildren();
        }

        protected ReproductiveAbnormalityDefinition.ChildReproductiveAbnormalityDefinitionCollection _ReproductiveAbnormalityDefinitions = null;
        public ReproductiveAbnormalityDefinition.ChildReproductiveAbnormalityDefinitionCollection ReproductiveAbnormalityDefinitions
        {
            get
            {
                if (_ReproductiveAbnormalityDefinitions == null)
                    CreateReproductiveAbnormalityDefinitionsCollection();
                return _ReproductiveAbnormalityDefinitions;
            }
        }

        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPRODUCTIVEABNORMALITYDEFINITION", dataRow) { }
        protected ReproductiveAbnormalityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPRODUCTIVEABNORMALITYDEFINITION", dataRow, isImported) { }
        public ReproductiveAbnormalityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReproductiveAbnormalityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReproductiveAbnormalityDefinition() : base() { }

    }
}