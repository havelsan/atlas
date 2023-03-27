
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaniBilgisiDVO")] 

    public  partial class TaniBilgisiDVO : BaseHizmetKayitDVO
    {
        public class TaniBilgisiDVOList : TTObjectCollection<TaniBilgisiDVO> { }
                    
        public class ChildTaniBilgisiDVOCollection : TTObject.TTChildObjectCollection<TaniBilgisiDVO>
        {
            public ChildTaniBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaniBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Kodu
    /// </summary>
        public string taniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public string taniTipi
        {
            get { return (string)this["TANITIPI"]; }
            set { this["TANITIPI"] = value; }
        }

    /// <summary>
    /// Birincil Tanı
    /// </summary>
        public string birincilTani
        {
            get { return (string)this["BIRINCILTANI"]; }
            set { this["BIRINCILTANI"] = value; }
        }

    /// <summary>
    /// Hizmet-Tanılar
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Tanılar
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaniBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaniBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaniBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaniBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaniBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TANIBILGISIDVO", dataRow) { }
        protected TaniBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TANIBILGISIDVO", dataRow, isImported) { }
        public TaniBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaniBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaniBilgisiDVO() : base() { }

    }
}