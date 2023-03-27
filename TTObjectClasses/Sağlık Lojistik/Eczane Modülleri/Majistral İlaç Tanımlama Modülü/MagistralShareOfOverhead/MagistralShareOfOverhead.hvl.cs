
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralShareOfOverhead")] 

    public  partial class MagistralShareOfOverhead : TerminologyManagerDef
    {
        public class MagistralShareOfOverheadList : TTObjectCollection<MagistralShareOfOverhead> { }
                    
        public class ChildMagistralShareOfOverheadCollection : TTObject.TTChildObjectCollection<MagistralShareOfOverhead>
        {
            public ChildMagistralShareOfOverheadCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralShareOfOverheadCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MagistralShareOfOverhead> GetMagistralShareOfOverheadbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALSHAREOFOVERHEAD"].QueryDefs["GetMagistralShareOfOverheadbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MagistralShareOfOverhead>(queryDef, paramList);
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
    /// Tutar
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

        protected MagistralShareOfOverhead(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralShareOfOverhead(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralShareOfOverhead(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralShareOfOverhead(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralShareOfOverhead(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALSHAREOFOVERHEAD", dataRow) { }
        protected MagistralShareOfOverhead(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALSHAREOFOVERHEAD", dataRow, isImported) { }
        public MagistralShareOfOverhead(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralShareOfOverhead(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralShareOfOverhead() : base() { }

    }
}