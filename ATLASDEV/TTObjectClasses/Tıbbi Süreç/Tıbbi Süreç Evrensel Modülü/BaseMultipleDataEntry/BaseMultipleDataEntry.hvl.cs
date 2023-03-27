
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMultipleDataEntry")] 

    public  partial class BaseMultipleDataEntry : TTObject
    {
        public class BaseMultipleDataEntryList : TTObjectCollection<BaseMultipleDataEntry> { }
                    
        public class ChildBaseMultipleDataEntryCollection : TTObject.TTChildObjectCollection<BaseMultipleDataEntry>
        {
            public ChildBaseMultipleDataEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMultipleDataEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseMultipleDataEntry> GetBaseMultipleDataByType(TTObjectContext objectContext, Guid EPISODEACTION, string OBJECTDEFNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMULTIPLEDATAENTRY"].QueryDefs["GetBaseMultipleDataByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);

            return ((ITTQuery)objectContext).QueryObjects<BaseMultipleDataEntry>(queryDef, paramList);
        }

    /// <summary>
    /// Giriş Yapılan Zaman
    /// </summary>
        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

        public ResUser EntryUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ENTRYUSER"); }
            set { this["ENTRYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseMultipleDataEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMultipleDataEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMultipleDataEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMultipleDataEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMultipleDataEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMULTIPLEDATAENTRY", dataRow) { }
        protected BaseMultipleDataEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMULTIPLEDATAENTRY", dataRow, isImported) { }
        public BaseMultipleDataEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMultipleDataEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMultipleDataEntry() : base() { }

    }
}