
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzProfilaksiUygProfilak")] 

    /// <summary>
    /// Kuduz Veri Paketi Uygulanan Kuduz Profilaksisi
    /// </summary>
    public  partial class KuduzProfilaksiUygProfilak : TTObject
    {
        public class KuduzProfilaksiUygProfilakList : TTObjectCollection<KuduzProfilaksiUygProfilak> { }
                    
        public class ChildKuduzProfilaksiUygProfilakCollection : TTObject.TTChildObjectCollection<KuduzProfilaksiUygProfilak>
        {
            public ChildKuduzProfilaksiUygProfilakCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzProfilaksiUygProfilakCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public KuduzProfilaksiVeriSeti KuduzProfilaksiVeriSeti
        {
            get { return (KuduzProfilaksiVeriSeti)((ITTObject)this).GetParent("KUDUZPROFILAKSIVERISETI"); }
            set { this["KUDUZPROFILAKSIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSUygulananKuduzProfilaksisi SKRSUygulananKuduzProfilaksi
        {
            get { return (SKRSUygulananKuduzProfilaksisi)((ITTObject)this).GetParent("SKRSUYGULANANKUDUZPROFILAKSI"); }
            set { this["SKRSUYGULANANKUDUZPROFILAKSI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZPROFILAKSIUYGPROFILAK", dataRow) { }
        protected KuduzProfilaksiUygProfilak(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZPROFILAKSIUYGPROFILAK", dataRow, isImported) { }
        public KuduzProfilaksiUygProfilak(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzProfilaksiUygProfilak(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzProfilaksiUygProfilak() : base() { }

    }
}