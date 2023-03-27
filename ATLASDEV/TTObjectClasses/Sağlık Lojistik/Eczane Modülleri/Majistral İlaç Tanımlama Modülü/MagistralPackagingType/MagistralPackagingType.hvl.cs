
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPackagingType")] 

    public  partial class MagistralPackagingType : TerminologyManagerDef
    {
        public class MagistralPackagingTypeList : TTObjectCollection<MagistralPackagingType> { }
                    
        public class ChildMagistralPackagingTypeCollection : TTObject.TTChildObjectCollection<MagistralPackagingType>
        {
            public ChildMagistralPackagingTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPackagingTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MagistralPackagingType> GetMagistralPackTypebyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPACKAGINGTYPE"].QueryDefs["GetMagistralPackTypebyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MagistralPackagingType>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// SPTS Packaging Type ID
    /// </summary>
        public long? SPTSPackagingTypeID
        {
            get { return (long?)this["SPTSPACKAGINGTYPEID"]; }
            set { this["SPTSPACKAGINGTYPEID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected MagistralPackagingType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPackagingType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPackagingType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPackagingType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPackagingType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPACKAGINGTYPE", dataRow) { }
        protected MagistralPackagingType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPACKAGINGTYPE", dataRow, isImported) { }
        public MagistralPackagingType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPackagingType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPackagingType() : base() { }

    }
}