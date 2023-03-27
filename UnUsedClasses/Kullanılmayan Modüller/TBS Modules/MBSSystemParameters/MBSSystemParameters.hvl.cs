
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSSystemParameters")] 

    public  partial class MBSSystemParameters : TTObject
    {
        public class MBSSystemParametersList : TTObjectCollection<MBSSystemParameters> { }
                    
        public class ChildMBSSystemParametersCollection : TTObject.TTChildObjectCollection<MBSSystemParameters>
        {
            public ChildMBSSystemParametersCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSSystemParametersCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tür
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Grup Kodu
    /// </summary>
        public string GroupCode
        {
            get { return (string)this["GROUPCODE"]; }
            set { this["GROUPCODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSSystemParameters(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSSystemParameters(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSSystemParameters(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSSystemParameters(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSSystemParameters(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSSYSTEMPARAMETERS", dataRow) { }
        protected MBSSystemParameters(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSSYSTEMPARAMETERS", dataRow, isImported) { }
        public MBSSystemParameters(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSSystemParameters(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSSystemParameters() : base() { }

    }
}