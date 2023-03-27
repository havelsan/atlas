
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaYatisOkuCevapDVO")] 

    public  partial class HastaYatisOkuCevapDVO : BaseMedulaCevap
    {
        public class HastaYatisOkuCevapDVOList : TTObjectCollection<HastaYatisOkuCevapDVO> { }
                    
        public class ChildHastaYatisOkuCevapDVOCollection : TTObject.TTChildObjectCollection<HastaYatisOkuCevapDVO>
        {
            public ChildHastaYatisOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaYatisOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Yeni Doğan Çocuk Sıra
    /// </summary>
        public string yeniDoganCocukSiraNo
        {
            get { return (string)this["YENIDOGANCOCUKSIRANO"]; }
            set { this["YENIDOGANCOCUKSIRANO"] = value; }
        }

    /// <summary>
    /// Donör TC Kimlik No
    /// </summary>
        public string donorTck
        {
            get { return (string)this["DONORTCK"]; }
            set { this["DONORTCK"] = value; }
        }

    /// <summary>
    /// Yeni Doğan Doğum Tar.
    /// </summary>
        public string yeniDoganDogumTarihi
        {
            get { return (string)this["YENIDOGANDOGUMTARIHI"]; }
            set { this["YENIDOGANDOGUMTARIHI"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisiKodu
        {
            get { return (int?)this["SAGLIKTESISIKODU"]; }
            set { this["SAGLIKTESISIKODU"] = value; }
        }

        virtual protected void CreatebasvuruYatisBilgileriCollection()
        {
            _basvuruYatisBilgileri = new BasvuruYatisBilgileriDVO.ChildBasvuruYatisBilgileriDVOCollection(this, new Guid("2fb3ca18-ff55-473c-baa2-133393c17fbf"));
            ((ITTChildObjectCollection)_basvuruYatisBilgileri).GetChildren();
        }

        protected BasvuruYatisBilgileriDVO.ChildBasvuruYatisBilgileriDVOCollection _basvuruYatisBilgileri = null;
        public BasvuruYatisBilgileriDVO.ChildBasvuruYatisBilgileriDVOCollection basvuruYatisBilgileri
        {
            get
            {
                if (_basvuruYatisBilgileri == null)
                    CreatebasvuruYatisBilgileriCollection();
                return _basvuruYatisBilgileri;
            }
        }

        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAYATISOKUCEVAPDVO", dataRow) { }
        protected HastaYatisOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAYATISOKUCEVAPDVO", dataRow, isImported) { }
        public HastaYatisOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaYatisOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaYatisOkuCevapDVO() : base() { }

    }
}