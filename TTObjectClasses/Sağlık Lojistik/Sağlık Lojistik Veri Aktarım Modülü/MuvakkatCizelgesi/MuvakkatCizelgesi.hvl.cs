
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuvakkatCizelgesi")] 

    public  partial class MuvakkatCizelgesi : TTObject
    {
        public class MuvakkatCizelgesiList : TTObjectCollection<MuvakkatCizelgesi> { }
                    
        public class ChildMuvakkatCizelgesiCollection : TTObject.TTChildObjectCollection<MuvakkatCizelgesi>
        {
            public ChildMuvakkatCizelgesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuvakkatCizelgesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string MalzemeNu
        {
            get { return (string)this["MALZEMENU"]; }
            set { this["MALZEMENU"] = value; }
        }

        public string DepoKodu
        {
            get { return (string)this["DEPOKODU"]; }
            set { this["DEPOKODU"] = value; }
        }

        public Guid? StoreObjectID
        {
            get { return (Guid?)this["STOREOBJECTID"]; }
            set { this["STOREOBJECTID"] = value; }
        }

        public string Depo
        {
            get { return (string)this["DEPO"]; }
            set { this["DEPO"] = value; }
        }

        public double? MuvakkatenVerilen
        {
            get { return (double?)this["MUVAKKATENVERILEN"]; }
            set { this["MUVAKKATENVERILEN"] = value; }
        }

        public string NATOStokNu
        {
            get { return (string)this["NATOSTOKNU"]; }
            set { this["NATOSTOKNU"] = value; }
        }

        public int? SiraNu
        {
            get { return (int?)this["SIRANU"]; }
            set { this["SIRANU"] = value; }
        }

        public SayimTartiCizelgesi SayimTartiCizelgesi
        {
            get { return (SayimTartiCizelgesi)((ITTObject)this).GetParent("SAYIMTARTICIZELGESI"); }
            set { this["SAYIMTARTICIZELGESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MuvakkatCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuvakkatCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuvakkatCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuvakkatCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuvakkatCizelgesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUVAKKATCIZELGESI", dataRow) { }
        protected MuvakkatCizelgesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUVAKKATCIZELGESI", dataRow, isImported) { }
        public MuvakkatCizelgesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuvakkatCizelgesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuvakkatCizelgesi() : base() { }

    }
}