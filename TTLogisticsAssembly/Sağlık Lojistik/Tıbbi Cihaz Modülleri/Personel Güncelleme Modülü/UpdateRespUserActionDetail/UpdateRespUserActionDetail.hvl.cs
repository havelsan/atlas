
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdateRespUserActionDetail")] 

    public  partial class UpdateRespUserActionDetail : TTObject
    {
        public class UpdateRespUserActionDetailList : TTObjectCollection<UpdateRespUserActionDetail> { }
                    
        public class ChildUpdateRespUserActionDetailCollection : TTObject.TTChildObjectCollection<UpdateRespUserActionDetail>
        {
            public ChildUpdateRespUserActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdateRespUserActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CMRAction CMRAction
        {
            get { return (CMRAction)((ITTObject)this).GetParent("CMRACTION"); }
            set { this["CMRACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UpdateRespUserAction UpdateRespUserAction
        {
            get { return (UpdateRespUserAction)((ITTObject)this).GetParent("UPDATERESPUSERACTION"); }
            set { this["UPDATERESPUSERACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser UpdateResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("UPDATERESUSER"); }
            set { this["UPDATERESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UpdateRespUserActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdateRespUserActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdateRespUserActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdateRespUserActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdateRespUserActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATERESPUSERACTIONDETAIL", dataRow) { }
        protected UpdateRespUserActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATERESPUSERACTIONDETAIL", dataRow, isImported) { }
        public UpdateRespUserActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdateRespUserActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdateRespUserActionDetail() : base() { }

    }
}