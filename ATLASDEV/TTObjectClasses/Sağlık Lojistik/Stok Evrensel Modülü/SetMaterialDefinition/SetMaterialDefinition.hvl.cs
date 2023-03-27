
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetMaterialDefinition")] 

    /// <summary>
    /// Set Malzeme Tanımı
    /// </summary>
    public  partial class SetMaterialDefinition : TerminologyManagerDef
    {
        public class SetMaterialDefinitionList : TTObjectCollection<SetMaterialDefinition> { }
                    
        public class ChildSetMaterialDefinitionCollection : TTObject.TTChildObjectCollection<SetMaterialDefinition>
        {
            public ChildSetMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSetMaterialDefListDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Pricinglistname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGLISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSetMaterialDefListDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSetMaterialDefListDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSetMaterialDefListDef_Class() : base() { }
        }

        public static BindingList<SetMaterialDefinition.GetSetMaterialDefListDef_Class> GetSetMaterialDefListDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETMATERIALDEFINITION"].QueryDefs["GetSetMaterialDefListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SetMaterialDefinition.GetSetMaterialDefListDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SetMaterialDefinition.GetSetMaterialDefListDef_Class> GetSetMaterialDefListDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETMATERIALDEFINITION"].QueryDefs["GetSetMaterialDefListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SetMaterialDefinition.GetSetMaterialDefListDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public PricingDetailDefinition SetMaterialPricingDetail
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("SETMATERIALPRICINGDETAIL"); }
            set { this["SETMATERIALPRICINGDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubCodesCollection()
        {
            _SubCodes = new SetMaterialSubCodeDefinition.ChildSetMaterialSubCodeDefinitionCollection(this, new Guid("57502154-ceb0-40a5-9338-c462ae09cc4e"));
            ((ITTChildObjectCollection)_SubCodes).GetChildren();
        }

        protected SetMaterialSubCodeDefinition.ChildSetMaterialSubCodeDefinitionCollection _SubCodes = null;
    /// <summary>
    /// Child collection for Malzeme Kodları
    /// </summary>
        public SetMaterialSubCodeDefinition.ChildSetMaterialSubCodeDefinitionCollection SubCodes
        {
            get
            {
                if (_SubCodes == null)
                    CreateSubCodesCollection();
                return _SubCodes;
            }
        }

        protected SetMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETMATERIALDEFINITION", dataRow) { }
        protected SetMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETMATERIALDEFINITION", dataRow, isImported) { }
        protected SetMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetMaterialDefinition() : base() { }

    }
}