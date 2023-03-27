
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GILDefinition")] 

    /// <summary>
    /// Girişimsel İşlem Listesi
    /// </summary>
    public  partial class GILDefinition : TerminologyManagerDef
    {
        public class GILDefinitionList : TTObjectCollection<GILDefinition> { }
                    
        public class ChildGILDefinitionCollection : TTObject.TTChildObjectCollection<GILDefinition>
        {
            public ChildGILDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGILDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGILDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Point
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["POINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SurgeryGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["SURGERYGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetGILDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGILDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGILDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetGILDefinitionWithMasterCount_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Point
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["POINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SurgeryGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["SURGERYGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dpmastercount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DPMASTERCOUNT"]);
                }
            }

            public GetGILDefinitionWithMasterCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGILDefinitionWithMasterCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGILDefinitionWithMasterCount_Class() : base() { }
        }

        public static BindingList<GILDefinition> GetGILDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].QueryDefs["GetGILDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<GILDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<GILDefinition.GetGILDefinitions_Class> GetGILDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].QueryDefs["GetGILDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GILDefinition.GetGILDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GILDefinition.GetGILDefinitions_Class> GetGILDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].QueryDefs["GetGILDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GILDefinition.GetGILDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GILDefinition.GetGILDefinitionWithMasterCount_Class> GetGILDefinitionWithMasterCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].QueryDefs["GetGILDefinitionWithMasterCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GILDefinition.GetGILDefinitionWithMasterCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GILDefinition.GetGILDefinitionWithMasterCount_Class> GetGILDefinitionWithMasterCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].QueryDefs["GetGILDefinitionWithMasterCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GILDefinition.GetGILDefinitionWithMasterCount_Class>(objectContext, queryDef, paramList, pi);
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

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Puan
    /// </summary>
        public int? Point
        {
            get { return (int?)this["POINT"]; }
            set { this["POINT"] = value; }
        }

    /// <summary>
    /// Ameliyat Grubu
    /// </summary>
        public string SurgeryGroup
        {
            get { return (string)this["SURGERYGROUP"]; }
            set { this["SURGERYGROUP"] = value; }
        }

        virtual protected void CreateProcedureDefinitionsCollection()
        {
            _ProcedureDefinitions = new ProcedureDefinition.ChildProcedureDefinitionCollection(this, new Guid("c62ec9bb-92f7-46d1-b06e-19fdc3cebfac"));
            ((ITTChildObjectCollection)_ProcedureDefinitions).GetChildren();
        }

        protected ProcedureDefinition.ChildProcedureDefinitionCollection _ProcedureDefinitions = null;
        public ProcedureDefinition.ChildProcedureDefinitionCollection ProcedureDefinitions
        {
            get
            {
                if (_ProcedureDefinitions == null)
                    CreateProcedureDefinitionsCollection();
                return _ProcedureDefinitions;
            }
        }

        virtual protected void CreateDPRuleMastersCollection()
        {
            _DPRuleMasters = new DPRuleMaster.ChildDPRuleMasterCollection(this, new Guid("3ed480d9-f3f8-4c77-bb82-e0b17060d2e2"));
            ((ITTChildObjectCollection)_DPRuleMasters).GetChildren();
        }

        protected DPRuleMaster.ChildDPRuleMasterCollection _DPRuleMasters = null;
        public DPRuleMaster.ChildDPRuleMasterCollection DPRuleMasters
        {
            get
            {
                if (_DPRuleMasters == null)
                    CreateDPRuleMastersCollection();
                return _DPRuleMasters;
            }
        }

        protected GILDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GILDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GILDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GILDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GILDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GILDEFINITION", dataRow) { }
        protected GILDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GILDEFINITION", dataRow, isImported) { }
        public GILDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GILDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GILDefinition() : base() { }

    }
}