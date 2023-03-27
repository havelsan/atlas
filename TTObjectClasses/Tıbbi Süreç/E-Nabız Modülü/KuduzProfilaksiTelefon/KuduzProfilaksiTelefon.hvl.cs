
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzProfilaksiTelefon")] 

    public  partial class KuduzProfilaksiTelefon : TTObject
    {
        public class KuduzProfilaksiTelefonList : TTObjectCollection<KuduzProfilaksiTelefon> { }
                    
        public class ChildKuduzProfilaksiTelefonCollection : TTObject.TTChildObjectCollection<KuduzProfilaksiTelefon>
        {
            public ChildKuduzProfilaksiTelefonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzProfilaksiTelefonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string TelefonNumarasi
        {
            get { return (string)this["TELEFONNUMARASI"]; }
            set { this["TELEFONNUMARASI"] = value; }
        }

        public SKRSTelefonTipi SKRSTelefonTipi
        {
            get { return (SKRSTelefonTipi)((ITTObject)this).GetParent("SKRSTELEFONTIPI"); }
            set { this["SKRSTELEFONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KuduzProfilaksiVeriSeti KuduzProfilaksiVeriSeti
        {
            get { return (KuduzProfilaksiVeriSeti)((ITTObject)this).GetParent("KUDUZPROFILAKSIVERISETI"); }
            set { this["KUDUZPROFILAKSIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZPROFILAKSITELEFON", dataRow) { }
        protected KuduzProfilaksiTelefon(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZPROFILAKSITELEFON", dataRow, isImported) { }
        public KuduzProfilaksiTelefon(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzProfilaksiTelefon(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzProfilaksiTelefon() : base() { }

    }
}