
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaGirisDVO")] 

    public  partial class FaturaGirisDVO : BaseMedulaObject
    {
        public class FaturaGirisDVOList : TTObjectCollection<FaturaGirisDVO> { }
                    
        public class ChildFaturaGirisDVOCollection : TTObject.TTChildObjectCollection<FaturaGirisDVO>
        {
            public ChildFaturaGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Faturanın Referans No
    /// </summary>
        public string faturaRefNo
        {
            get { return (string)this["FATURAREFNO"]; }
            set { this["FATURAREFNO"] = value; }
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
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public string faturaTarihi
        {
            get { return (string)this["FATURATARIHI"]; }
            set { this["FATURATARIHI"] = value; }
        }

    /// <summary>
    /// Fatura Cevap
    /// </summary>
        public FaturaCevapDVO faturaCevapDVO
        {
            get { return (FaturaCevapDVO)((ITTObject)this).GetParent("FATURACEVAPDVO"); }
            set { this["FATURACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatehizmetDetaylariCollection()
        {
            _hizmetDetaylari = new HizmetDetayDVO.ChildHizmetDetayDVOCollection(this, new Guid("52b1a99e-6d0a-4182-aa9f-89e2dbec0f3d"));
            ((ITTChildObjectCollection)_hizmetDetaylari).GetChildren();
        }

        protected HizmetDetayDVO.ChildHizmetDetayDVOCollection _hizmetDetaylari = null;
    /// <summary>
    /// Child collection for Fatura Giriş-Hizmet Detayları
    /// </summary>
        public HizmetDetayDVO.ChildHizmetDetayDVOCollection hizmetDetaylari
        {
            get
            {
                if (_hizmetDetaylari == null)
                    CreatehizmetDetaylariCollection();
                return _hizmetDetaylari;
            }
        }

        protected FaturaGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAGIRISDVO", dataRow) { }
        protected FaturaGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAGIRISDVO", dataRow, isImported) { }
        public FaturaGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaGirisDVO() : base() { }

    }
}