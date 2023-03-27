
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondClosedSeps")] 

    /// <summary>
    /// Anlaşmaları kapat
    /// </summary>
    public  partial class BondClosedSeps : TTObject
    {
        public class BondClosedSepsList : TTObjectCollection<BondClosedSeps> { }
                    
        public class ChildBondClosedSepsCollection : TTObject.TTChildObjectCollection<BondClosedSeps>
        {
            public ChildBondClosedSepsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondClosedSepsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BondClosedSeps> GetBySEP(TTObjectContext objectContext, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BONDCLOSEDSEPS"].QueryDefs["GetBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<BondClosedSeps>(queryDef, paramList);
        }

    /// <summary>
    /// Kapatılan SubEpisodeProtocol
    /// </summary>
        public SubEpisodeProtocol SEP
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SEP"); }
            set { this["SEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Bond Bond
        {
            get { return (Bond)((ITTObject)this).GetParent("BOND"); }
            set { this["BOND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BondClosedSeps(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondClosedSeps(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondClosedSeps(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondClosedSeps(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondClosedSeps(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDCLOSEDSEPS", dataRow) { }
        protected BondClosedSeps(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDCLOSEDSEPS", dataRow, isImported) { }
        public BondClosedSeps(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondClosedSeps(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondClosedSeps() : base() { }

    }
}