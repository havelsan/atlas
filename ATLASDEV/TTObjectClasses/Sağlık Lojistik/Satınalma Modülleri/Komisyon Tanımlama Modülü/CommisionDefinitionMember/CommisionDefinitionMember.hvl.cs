
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommisionDefinitionMember")] 

    /// <summary>
    /// Satınalma projelerinde önceden tanımlı komisyon şablonları yaratmak için kullanılır
    /// </summary>
    public  partial class CommisionDefinitionMember : TTObject
    {
        public class CommisionDefinitionMemberList : TTObjectCollection<CommisionDefinitionMember> { }
                    
        public class ChildCommisionDefinitionMemberCollection : TTObject.TTChildObjectCollection<CommisionDefinitionMember>
        {
            public ChildCommisionDefinitionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommisionDefinitionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İmza Tipi
    /// </summary>
        public SignUserTypeEnum? SignUserType
        {
            get { return (SignUserTypeEnum?)(int?)this["SIGNUSERTYPE"]; }
            set { this["SIGNUSERTYPE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CommisionDefinition CommisionDefinition
        {
            get { return (CommisionDefinition)((ITTObject)this).GetParent("COMMISIONDEFINITION"); }
            set { this["COMMISIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CommisionDefinitionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommisionDefinitionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommisionDefinitionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommisionDefinitionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommisionDefinitionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMISIONDEFINITIONMEMBER", dataRow) { }
        protected CommisionDefinitionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMISIONDEFINITIONMEMBER", dataRow, isImported) { }
        public CommisionDefinitionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommisionDefinitionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommisionDefinitionMember() : base() { }

    }
}