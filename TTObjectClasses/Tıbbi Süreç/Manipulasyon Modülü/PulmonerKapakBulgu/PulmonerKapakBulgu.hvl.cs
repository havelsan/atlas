
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PulmonerKapakBulgu")] 

    public  partial class PulmonerKapakBulgu : TTObject
    {
        public class PulmonerKapakBulguList : TTObjectCollection<PulmonerKapakBulgu> { }
                    
        public class ChildPulmonerKapakBulguCollection : TTObject.TTChildObjectCollection<PulmonerKapakBulgu>
        {
            public ChildPulmonerKapakBulguCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPulmonerKapakBulguCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Pulmoner Kapak
    /// </summary>
        public PulmonerKapakEnum? PulmonerKapakTest
        {
            get { return (PulmonerKapakEnum?)(int?)this["PULMONERKAPAKTEST"]; }
            set { this["PULMONERKAPAKTEST"] = value; }
        }

    /// <summary>
    /// Bulgu
    /// </summary>
        public string PulmonerKapakTestBulgu
        {
            get { return (string)this["PULMONERKAPAKTESTBULGU"]; }
            set { this["PULMONERKAPAKTESTBULGU"] = value; }
        }

        public EkokardiografiFormObject EkokardiografiFormObject
        {
            get { return (EkokardiografiFormObject)((ITTObject)this).GetParent("EKOKARDIOGRAFIFORMOBJECT"); }
            set { this["EKOKARDIOGRAFIFORMOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PulmonerKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PulmonerKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PulmonerKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PulmonerKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PulmonerKapakBulgu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PULMONERKAPAKBULGU", dataRow) { }
        protected PulmonerKapakBulgu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PULMONERKAPAKBULGU", dataRow, isImported) { }
        public PulmonerKapakBulgu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PulmonerKapakBulgu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PulmonerKapakBulgu() : base() { }

    }
}