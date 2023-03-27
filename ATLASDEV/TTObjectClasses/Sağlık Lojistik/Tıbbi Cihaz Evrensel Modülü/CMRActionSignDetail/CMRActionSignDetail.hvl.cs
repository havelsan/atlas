
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRActionSignDetail")] 

    public  partial class CMRActionSignDetail : TTObject
    {
        public class CMRActionSignDetailList : TTObjectCollection<CMRActionSignDetail> { }
                    
        public class ChildCMRActionSignDetailCollection : TTObject.TTChildObjectCollection<CMRActionSignDetail>
        {
            public ChildCMRActionSignDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionSignDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İmza Tipi
    /// </summary>
        public SignUserTypeEnum? SignUserType
        {
            get { return (SignUserTypeEnum?)(int?)this["SIGNUSERTYPE"]; }
            set { this["SIGNUSERTYPE"] = value; }
        }

    /// <summary>
    /// Vekil
    /// </summary>
        public bool? IsDeputy
        {
            get { return (bool?)this["ISDEPUTY"]; }
            set { this["ISDEPUTY"] = value; }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser SignUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SIGNUSER"); }
            set { this["SIGNUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrder MaintenanceOrder_Sign
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER_SIGN"); }
            set { this["MAINTENANCEORDER_SIGN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CMRActionSignDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRActionSignDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRActionSignDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRActionSignDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRActionSignDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTIONSIGNDETAIL", dataRow) { }
        protected CMRActionSignDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTIONSIGNDETAIL", dataRow, isImported) { }
        public CMRActionSignDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRActionSignDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRActionSignDetail() : base() { }

    }
}