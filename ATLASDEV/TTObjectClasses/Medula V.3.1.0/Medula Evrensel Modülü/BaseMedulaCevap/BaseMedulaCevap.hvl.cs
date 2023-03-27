
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaCevap")] 

    public  abstract  partial class BaseMedulaCevap : BaseMedulaObject
    {
        public class BaseMedulaCevapList : TTObjectCollection<BaseMedulaCevap> { }
                    
        public class ChildBaseMedulaCevapCollection : TTObject.TTChildObjectCollection<BaseMedulaCevap>
        {
            public ChildBaseMedulaCevapCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaCevapCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string sonucMesaji
        {
            get { return (string)this["SONUCMESAJI"]; }
            set { this["SONUCMESAJI"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string sonucKodu
        {
            get { return (string)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

        protected BaseMedulaCevap(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaCevap(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaCevap(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaCevap(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaCevap(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULACEVAP", dataRow) { }
        protected BaseMedulaCevap(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULACEVAP", dataRow, isImported) { }
        public BaseMedulaCevap(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaCevap(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaCevap() : base() { }

    }
}