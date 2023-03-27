
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseCulture")] 

    public  abstract  partial class BaseCulture : TerminologyManagerDef
    {
        public class BaseCultureList : TTObjectCollection<BaseCulture> { }
                    
        public class ChildBaseCultureCollection : TTObject.TTChildObjectCollection<BaseCulture>
        {
            public ChildBaseCultureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseCultureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseCulture> GetCulture(TTObjectContext objectContext, string ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECULTURE"].QueryDefs["GetCulture"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<BaseCulture>(queryDef, paramList);
        }

        public int? LCID
        {
            get { return (int?)this["LCID"]; }
            set { this["LCID"] = value; }
        }

        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected BaseCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseCulture(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseCulture(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseCulture(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASECULTURE", dataRow) { }
        protected BaseCulture(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASECULTURE", dataRow, isImported) { }
        public BaseCulture(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseCulture(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseCulture() : base() { }

    }
}