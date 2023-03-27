
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="APRTrxType")] 

    public  partial class APRTrxType : TTDefinitionSet
    {
        public class APRTrxTypeList : TTObjectCollection<APRTrxType> { }
                    
        public class ChildAPRTrxTypeCollection : TTObject.TTChildObjectCollection<APRTrxType>
        {
            public ChildAPRTrxTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAPRTrxTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<APRTrxType> GetByType(TTObjectContext objectContext, int PARAMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APRTRXTYPE"].QueryDefs["GetByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMID", PARAMID);

            return ((ITTQuery)objectContext).QueryObjects<APRTrxType>(queryDef, paramList);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public int? ID
        {
            get { return (int?)this["ID"]; }
            set { this["ID"] = value; }
        }

        virtual protected void CreateAPRTrxCollection()
        {
            _APRTrx = new APRTrx.ChildAPRTrxCollection(this, new Guid("cb303351-c5ab-4c2a-8551-95b95c0cfbc9"));
            ((ITTChildObjectCollection)_APRTrx).GetChildren();
        }

        protected APRTrx.ChildAPRTrxCollection _APRTrx = null;
    /// <summary>
    /// Child collection for APRTrxType a relation
    /// </summary>
        public APRTrx.ChildAPRTrxCollection APRTrx
        {
            get
            {
                if (_APRTrx == null)
                    CreateAPRTrxCollection();
                return _APRTrx;
            }
        }

        protected APRTrxType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected APRTrxType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected APRTrxType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected APRTrxType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected APRTrxType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APRTRXTYPE", dataRow) { }
        protected APRTrxType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APRTRXTYPE", dataRow, isImported) { }
        public APRTrxType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public APRTrxType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public APRTrxType() : base() { }

    }
}