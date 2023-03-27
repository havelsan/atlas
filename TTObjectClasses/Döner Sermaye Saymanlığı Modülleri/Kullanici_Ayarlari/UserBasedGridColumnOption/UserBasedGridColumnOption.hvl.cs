
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserBasedGridColumnOption")] 

    public  partial class UserBasedGridColumnOption : TTObject
    {
        public class UserBasedGridColumnOptionList : TTObjectCollection<UserBasedGridColumnOption> { }
                    
        public class ChildUserBasedGridColumnOptionCollection : TTObject.TTChildObjectCollection<UserBasedGridColumnOption>
        {
            public ChildUserBasedGridColumnOptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserBasedGridColumnOptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UserBasedGridColumnOption> GetGridColumnOption(TTObjectContext objectContext, Guid USER, string GRIDNAME, string PAGENAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERBASEDGRIDCOLUMNOPTION"].QueryDefs["GetGridColumnOption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("GRIDNAME", GRIDNAME);
            paramList.Add("PAGENAME", PAGENAME);

            return ((ITTQuery)objectContext).QueryObjects<UserBasedGridColumnOption>(queryDef, paramList);
        }

        public string GridName
        {
            get { return (string)this["GRIDNAME"]; }
            set { this["GRIDNAME"] = value; }
        }

        public string ColumnList
        {
            get { return (string)this["COLUMNLIST"]; }
            set { this["COLUMNLIST"] = value; }
        }

        public string PageName
        {
            get { return (string)this["PAGENAME"]; }
            set { this["PAGENAME"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserBasedGridColumnOption(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserBasedGridColumnOption(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserBasedGridColumnOption(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserBasedGridColumnOption(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserBasedGridColumnOption(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERBASEDGRIDCOLUMNOPTION", dataRow) { }
        protected UserBasedGridColumnOption(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERBASEDGRIDCOLUMNOPTION", dataRow, isImported) { }
        public UserBasedGridColumnOption(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserBasedGridColumnOption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserBasedGridColumnOption() : base() { }

    }
}