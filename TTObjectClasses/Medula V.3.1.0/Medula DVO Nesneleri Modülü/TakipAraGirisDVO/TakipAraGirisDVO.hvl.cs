
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipAraGirisDVO")] 

    public  partial class TakipAraGirisDVO : BaseMedulaObject
    {
        public class TakipAraGirisDVOList : TTObjectCollection<TakipAraGirisDVO> { }
                    
        public class ChildTakipAraGirisDVOCollection : TTObject.TTChildObjectCollection<TakipAraGirisDVO>
        {
            public ChildTakipAraGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipAraGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Takip Numarasının Aranacağı Başlangıç Tarihi
    /// </summary>
        public string baslangicTarihi
        {
            get { return (string)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Hastanın TC Kimlik Numarası
    /// </summary>
        public string hastaTCK
        {
            get { return (string)this["HASTATCK"]; }
            set { this["HASTATCK"] = value; }
        }

    /// <summary>
    /// Takip Numarasının Aranacağı Bitiş Tarihi
    /// </summary>
        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// Sevk Bildirimi Yapılmış yada Yapılmamış
    /// </summary>
        public string sevkDurumu
        {
            get { return (string)this["SEVKDURUMU"]; }
            set { this["SEVKDURUMU"] = value; }
        }

    /// <summary>
    /// Takip Ara Cevap
    /// </summary>
        public TakipAraCevapDVO takipAraCevapDVO
        {
            get { return (TakipAraCevapDVO)((ITTObject)this).GetParent("TAKIPARACEVAPDVO"); }
            set { this["TAKIPARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipAraGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPARAGIRISDVO", dataRow) { }
        protected TakipAraGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPARAGIRISDVO", dataRow, isImported) { }
        public TakipAraGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipAraGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipAraGirisDVO() : base() { }

    }
}