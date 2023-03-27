
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaRaporCevap")] 

    public  abstract  partial class BaseMedulaRaporCevap : BaseMedulaObject
    {
        public class BaseMedulaRaporCevapList : TTObjectCollection<BaseMedulaRaporCevap> { }
                    
        public class ChildBaseMedulaRaporCevapCollection : TTObject.TTChildObjectCollection<BaseMedulaRaporCevap>
        {
            public ChildBaseMedulaRaporCevapCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaRaporCevapCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public int? sonucKodu
        {
            get { return (int?)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string sonucAciklamasi
        {
            get { return (string)this["SONUCACIKLAMASI"]; }
            set { this["SONUCACIKLAMASI"] = value; }
        }

        protected BaseMedulaRaporCevap(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaRaporCevap(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaRaporCevap(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaRaporCevap(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaRaporCevap(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULARAPORCEVAP", dataRow) { }
        protected BaseMedulaRaporCevap(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULARAPORCEVAP", dataRow, isImported) { }
        public BaseMedulaRaporCevap(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaRaporCevap(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaRaporCevap() : base() { }

    }
}