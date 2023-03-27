
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResReusableMaterial")] 

    /// <summary>
    /// Sterile Edilebilir Malzeme
    /// </summary>
    public  partial class ResReusableMaterial : ResSection
    {
        public class ResReusableMaterialList : TTObjectCollection<ResReusableMaterial> { }
                    
        public class ChildResReusableMaterialCollection : TTObject.TTChildObjectCollection<ResReusableMaterial>
        {
            public ChildResReusableMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResReusableMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResReusableMaterials_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ownerresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResReusableMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResReusableMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResReusableMaterials_Class() : base() { }
        }

        public static BindingList<ResReusableMaterial> silgonul(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].QueryDefs["silgonul"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResReusableMaterial>(queryDef, paramList);
        }

        public static BindingList<ResReusableMaterial> GetWithoutPackage(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].QueryDefs["GetWithoutPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResReusableMaterial>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResReusableMaterial> GetClearAndWithoutPacket(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].QueryDefs["GetClearAndWithoutPacket"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResReusableMaterial>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResReusableMaterial.GetResReusableMaterials_Class> GetResReusableMaterials(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].QueryDefs["GetResReusableMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResReusableMaterial.GetResReusableMaterials_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResReusableMaterial.GetResReusableMaterials_Class> GetResReusableMaterials(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEMATERIAL"].QueryDefs["GetResReusableMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResReusableMaterial.GetResReusableMaterials_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public ResReusablePackage ResReusablePackage
        {
            get { return (ResReusablePackage)((ITTObject)this).GetParent("RESREUSABLEPACKAGE"); }
            set { this["RESREUSABLEPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection OwnerResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("OWNERRESOURCE"); }
            set { this["OWNERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SterilizationHistory ActiveSterilization
        {
            get { return (SterilizationHistory)((ITTObject)this).GetParent("ACTIVESTERILIZATION"); }
            set { this["ACTIVESTERILIZATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSterilizationHistoriesCollection()
        {
            _SterilizationHistories = new SterilizationHistory.ChildSterilizationHistoryCollection(this, new Guid("9a933923-da41-4a49-bc02-76a1102a5742"));
            ((ITTChildObjectCollection)_SterilizationHistories).GetChildren();
        }

        protected SterilizationHistory.ChildSterilizationHistoryCollection _SterilizationHistories = null;
        public SterilizationHistory.ChildSterilizationHistoryCollection SterilizationHistories
        {
            get
            {
                if (_SterilizationHistories == null)
                    CreateSterilizationHistoriesCollection();
                return _SterilizationHistories;
            }
        }

        protected ResReusableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResReusableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResReusableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResReusableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResReusableMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESREUSABLEMATERIAL", dataRow) { }
        protected ResReusableMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESREUSABLEMATERIAL", dataRow, isImported) { }
        public ResReusableMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResReusableMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResReusableMaterial() : base() { }

    }
}