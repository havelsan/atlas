
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyPanicAlert")] 

    public  partial class PathologyPanicAlert : TTObject
    {
        public class PathologyPanicAlertList : TTObjectCollection<PathologyPanicAlert> { }
                    
        public class ChildPathologyPanicAlertCollection : TTObject.TTChildObjectCollection<PathologyPanicAlert>
        {
            public ChildPathologyPanicAlertCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyPanicAlertCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Panik Bildirim Tarihi
    /// </summary>
        public DateTime? PanicAlertDate
        {
            get { return (DateTime?)this["PANICALERTDATE"]; }
            set { this["PANICALERTDATE"] = value; }
        }

    /// <summary>
    /// Panik Bildirim Yapan Kullanıcı
    /// </summary>
        public string User
        {
            get { return (string)this["USER"]; }
            set { this["USER"] = value; }
        }

        public PathologyPanicReasonDef PathologyPanicReason
        {
            get { return (PathologyPanicReasonDef)((ITTObject)this).GetParent("PATHOLOGYPANICREASON"); }
            set { this["PATHOLOGYPANICREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePathologyCollection()
        {
            _Pathology = new Pathology.ChildPathologyCollection(this, new Guid("e8a802c1-8dd6-4c1c-ae53-8109dbbc2ecc"));
            ((ITTChildObjectCollection)_Pathology).GetChildren();
        }

        protected Pathology.ChildPathologyCollection _Pathology = null;
        public Pathology.ChildPathologyCollection Pathology
        {
            get
            {
                if (_Pathology == null)
                    CreatePathologyCollection();
                return _Pathology;
            }
        }

        protected PathologyPanicAlert(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyPanicAlert(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyPanicAlert(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyPanicAlert(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyPanicAlert(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYPANICALERT", dataRow) { }
        protected PathologyPanicAlert(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYPANICALERT", dataRow, isImported) { }
        public PathologyPanicAlert(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyPanicAlert(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyPanicAlert() : base() { }

    }
}