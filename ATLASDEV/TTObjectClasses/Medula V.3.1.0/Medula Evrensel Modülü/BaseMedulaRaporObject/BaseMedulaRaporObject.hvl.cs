
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaRaporObject")] 

    public  abstract  partial class BaseMedulaRaporObject : BaseMedulaObject
    {
        public class BaseMedulaRaporObjectList : TTObjectCollection<BaseMedulaRaporObject> { }
                    
        public class ChildBaseMedulaRaporObjectCollection : TTObject.TTChildObjectCollection<BaseMedulaRaporObject>
        {
            public ChildBaseMedulaRaporObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaRaporObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullanıcı Tesis Kodu
    /// </summary>
        public int? kullaniciTesisKodu
        {
            get { return (int?)this["KULLANICITESISKODU"]; }
            set { this["KULLANICITESISKODU"] = value; }
        }

        protected BaseMedulaRaporObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaRaporObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaRaporObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaRaporObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaRaporObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULARAPOROBJECT", dataRow) { }
        protected BaseMedulaRaporObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULARAPOROBJECT", dataRow, isImported) { }
        public BaseMedulaRaporObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaRaporObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaRaporObject() : base() { }

    }
}