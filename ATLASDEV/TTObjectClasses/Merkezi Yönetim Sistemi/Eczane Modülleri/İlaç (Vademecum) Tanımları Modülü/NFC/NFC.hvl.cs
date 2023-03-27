
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NFC")] 

    /// <summary>
    /// NFC
    /// </summary>
    public  partial class NFC : TerminologyManagerDef
    {
        public class NFCList : TTObjectCollection<NFC> { }
                    
        public class ChildNFCCollection : TTObject.TTChildObjectCollection<NFC>
        {
            public ChildNFCCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNFCCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<NFC> GetNFCBySPTSNFCIDs(TTObjectContext objectContext, long SPTSNFCID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NFC"].QueryDefs["GetNFCBySPTSNFCIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPTSNFCID", SPTSNFCID);

            return ((ITTQuery)objectContext).QueryObjects<NFC>(queryDef, paramList);
        }

        public static BindingList<NFC> GetNFCbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NFC"].QueryDefs["GetNFCbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NFC>(queryDef, paramList);
        }

    /// <summary>
    /// NFC Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? SPTSNFCID
        {
            get { return (long?)this["SPTSNFCID"]; }
            set { this["SPTSNFCID"] = value; }
        }

    /// <summary>
    /// Grup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

    /// <summary>
    /// NFC Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

    /// <summary>
    /// Aciklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public NFC ParentCode
        {
            get { return (NFC)((ITTObject)this).GetParent("PARENTCODE"); }
            set { this["PARENTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NFC(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NFC(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NFC(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NFC(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NFC(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NFC", dataRow) { }
        protected NFC(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NFC", dataRow, isImported) { }
        public NFC(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NFC(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NFC() : base() { }

    }
}