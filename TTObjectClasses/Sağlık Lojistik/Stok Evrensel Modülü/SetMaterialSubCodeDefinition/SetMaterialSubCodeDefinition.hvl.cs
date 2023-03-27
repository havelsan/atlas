
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetMaterialSubCodeDefinition")] 

    /// <summary>
    /// Set Malzeme Alt Kodları
    /// </summary>
    public  partial class SetMaterialSubCodeDefinition : TerminologyManagerDef
    {
        public class SetMaterialSubCodeDefinitionList : TTObjectCollection<SetMaterialSubCodeDefinition> { }
                    
        public class ChildSetMaterialSubCodeDefinitionCollection : TTObject.TTChildObjectCollection<SetMaterialSubCodeDefinition>
        {
            public ChildSetMaterialSubCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetMaterialSubCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSetMaterialByMaterialCode_Class : TTReportNqlObject 
        {
            public Guid? SetMaterialPricingDetail
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SETMATERIALPRICINGDETAIL"]);
                }
            }

            public GetSetMaterialByMaterialCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSetMaterialByMaterialCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSetMaterialByMaterialCode_Class() : base() { }
        }

        public static BindingList<SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class> GetSetMaterialByMaterialCode(string MATERIALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETMATERIALSUBCODEDEFINITION"].QueryDefs["GetSetMaterialByMaterialCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALCODE", MATERIALCODE);

            return TTReportNqlObject.QueryObjects<SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class> GetSetMaterialByMaterialCode(TTObjectContext objectContext, string MATERIALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETMATERIALSUBCODEDEFINITION"].QueryDefs["GetSetMaterialByMaterialCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALCODE", MATERIALCODE);

            return TTReportNqlObject.QueryObjects<SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public string MaterialCode
        {
            get { return (string)this["MATERIALCODE"]; }
            set { this["MATERIALCODE"] = value; }
        }

    /// <summary>
    /// Malzeme Kodları
    /// </summary>
        public SetMaterialDefinition SetMaterial
        {
            get { return (SetMaterialDefinition)((ITTObject)this).GetParent("SETMATERIAL"); }
            set { this["SETMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETMATERIALSUBCODEDEFINITION", dataRow) { }
        protected SetMaterialSubCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETMATERIALSUBCODEDEFINITION", dataRow, isImported) { }
        public SetMaterialSubCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetMaterialSubCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetMaterialSubCodeDefinition() : base() { }

    }
}