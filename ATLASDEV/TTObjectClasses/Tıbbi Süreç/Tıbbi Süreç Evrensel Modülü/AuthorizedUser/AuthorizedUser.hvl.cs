
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AuthorizedUser")] 

    /// <summary>
    /// İşlemden Sorumlu Kullanıcıyı Taşıyan Nesne
    /// </summary>
    public  partial class AuthorizedUser : TTObject
    {
        public class AuthorizedUserList : TTObjectCollection<AuthorizedUser> { }
                    
        public class ChildAuthorizedUserCollection : TTObject.TTChildObjectCollection<AuthorizedUser>
        {
            public ChildAuthorizedUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAuthorizedUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<AuthorizedUser> GetAuthorizedUsersByEpisodeActions(TTObjectContext objectContext, IList<Guid> ACTIONOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AUTHORIZEDUSER"].QueryDefs["GetAuthorizedUsersByEpisodeActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONOBJECTID", ACTIONOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<AuthorizedUser>(queryDef, paramList);
        }

        public BaseAction Action
        {
            get { return (BaseAction)((ITTObject)this).GetParent("ACTION"); }
            set { this["ACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubactionProcedureFlowable SubactionProcedure
        {
            get { return (SubactionProcedureFlowable)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AuthorizedUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AuthorizedUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AuthorizedUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AuthorizedUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AuthorizedUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AUTHORIZEDUSER", dataRow) { }
        protected AuthorizedUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AUTHORIZEDUSER", dataRow, isImported) { }
        public AuthorizedUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AuthorizedUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AuthorizedUser() : base() { }

    }
}