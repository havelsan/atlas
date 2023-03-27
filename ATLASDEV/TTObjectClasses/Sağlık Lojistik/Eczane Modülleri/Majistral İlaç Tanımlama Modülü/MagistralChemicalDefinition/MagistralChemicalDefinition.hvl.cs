
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralChemicalDefinition")] 

    public  partial class MagistralChemicalDefinition : TerminologyManagerDef
    {
        public class MagistralChemicalDefinitionList : TTObjectCollection<MagistralChemicalDefinition> { }
                    
        public class ChildMagistralChemicalDefinitionCollection : TTObject.TTChildObjectCollection<MagistralChemicalDefinition>
        {
            public ChildMagistralChemicalDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralChemicalDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMagistralChemicalDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALCHEMICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MagistralChemicalPropertyEnum? ChemicalProperty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHEMICALPROPERTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALCHEMICALDEFINITION"].AllPropertyDefs["CHEMICALPROPERTY"].DataType;
                    return (MagistralChemicalPropertyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetMagistralChemicalDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMagistralChemicalDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMagistralChemicalDefinitions_Class() : base() { }
        }

        public static BindingList<MagistralChemicalDefinition.GetMagistralChemicalDefinitions_Class> GetMagistralChemicalDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALCHEMICALDEFINITION"].QueryDefs["GetMagistralChemicalDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralChemicalDefinition.GetMagistralChemicalDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MagistralChemicalDefinition.GetMagistralChemicalDefinitions_Class> GetMagistralChemicalDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALCHEMICALDEFINITION"].QueryDefs["GetMagistralChemicalDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralChemicalDefinition.GetMagistralChemicalDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kimyasal Özellik
    /// </summary>
        public MagistralChemicalPropertyEnum? ChemicalProperty
        {
            get { return (MagistralChemicalPropertyEnum?)(int?)this["CHEMICALPROPERTY"]; }
            set { this["CHEMICALPROPERTY"] = value; }
        }

    /// <summary>
    /// SPTS Material ID
    /// </summary>
        public long? SPTSMaterialID
        {
            get { return (long?)this["SPTSMATERIALID"]; }
            set { this["SPTSMATERIALID"] = value; }
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
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public ConsumableMaterialDefinition Material
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralChemicalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralChemicalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralChemicalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralChemicalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralChemicalDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALCHEMICALDEFINITION", dataRow) { }
        protected MagistralChemicalDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALCHEMICALDEFINITION", dataRow, isImported) { }
        public MagistralChemicalDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralChemicalDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralChemicalDefinition() : base() { }

    }
}