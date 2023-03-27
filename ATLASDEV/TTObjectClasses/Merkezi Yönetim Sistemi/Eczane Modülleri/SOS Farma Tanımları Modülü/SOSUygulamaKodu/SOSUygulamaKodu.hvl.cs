
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSUygulamaKodu")] 

    public  partial class SOSUygulamaKodu : TerminologyManagerDef
    {
        public class SOSUygulamaKoduList : TTObjectCollection<SOSUygulamaKodu> { }
                    
        public class ChildSOSUygulamaKoduCollection : TTObject.TTChildObjectCollection<SOSUygulamaKodu>
        {
            public ChildSOSUygulamaKoduCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSUygulamaKoduCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// Uygulama Yolu Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Uygulama Yolu Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public RouteOfAdmin XXXXXXRouteOfAdmin
        {
            get { return (RouteOfAdmin)((ITTObject)this).GetParent("XXXXXXROUTEOFADMIN"); }
            set { this["XXXXXXROUTEOFADMIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSUygulamaKodu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSUygulamaKodu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSUygulamaKodu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSUygulamaKodu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSUygulamaKodu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSUYGULAMAKODU", dataRow) { }
        protected SOSUygulamaKodu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSUYGULAMAKODU", dataRow, isImported) { }
        public SOSUygulamaKodu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSUygulamaKodu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSUygulamaKodu() : base() { }

    }
}