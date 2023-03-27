
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResReusablePackage")] 

    /// <summary>
    /// Sterile Edilebilir  Paket
    /// </summary>
    public  partial class ResReusablePackage : ResReusableMaterial
    {
        public class ResReusablePackageList : TTObjectCollection<ResReusablePackage> { }
                    
        public class ChildResReusablePackageCollection : TTObject.TTChildObjectCollection<ResReusablePackage>
        {
            public ChildResReusablePackageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResReusablePackageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResReusablePackage_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEPACKAGE"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEPACKAGE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Packetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEPACKAGE"].AllPropertyDefs["NAME"].DataType;
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

            public GetResReusablePackage_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResReusablePackage_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResReusablePackage_Class() : base() { }
        }

        public static BindingList<ResReusablePackage.GetResReusablePackage_Class> GetResReusablePackage(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEPACKAGE"].QueryDefs["GetResReusablePackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResReusablePackage.GetResReusablePackage_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResReusablePackage.GetResReusablePackage_Class> GetResReusablePackage(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESREUSABLEPACKAGE"].QueryDefs["GetResReusablePackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResReusablePackage.GetResReusablePackage_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateReusableMaterialDetailsCollection()
        {
            _ReusableMaterialDetails = new ResReusableMaterial.ChildResReusableMaterialCollection(this, new Guid("ba462901-110f-4f20-880d-ef06c13edc4f"));
            ((ITTChildObjectCollection)_ReusableMaterialDetails).GetChildren();
        }

        protected ResReusableMaterial.ChildResReusableMaterialCollection _ReusableMaterialDetails = null;
        public ResReusableMaterial.ChildResReusableMaterialCollection ReusableMaterialDetails
        {
            get
            {
                if (_ReusableMaterialDetails == null)
                    CreateReusableMaterialDetailsCollection();
                return _ReusableMaterialDetails;
            }
        }

        protected ResReusablePackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResReusablePackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResReusablePackage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResReusablePackage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResReusablePackage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESREUSABLEPACKAGE", dataRow) { }
        protected ResReusablePackage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESREUSABLEPACKAGE", dataRow, isImported) { }
        public ResReusablePackage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResReusablePackage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResReusablePackage() : base() { }

    }
}