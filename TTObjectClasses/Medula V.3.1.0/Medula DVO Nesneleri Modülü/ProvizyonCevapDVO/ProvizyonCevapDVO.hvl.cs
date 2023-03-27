
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvizyonCevapDVO")] 

    public  partial class ProvizyonCevapDVO : BaseMedulaCevap
    {
        public class ProvizyonCevapDVOList : TTObjectCollection<ProvizyonCevapDVO> { }
                    
        public class ChildProvizyonCevapDVOCollection : TTObject.TTChildObjectCollection<ProvizyonCevapDVO>
        {
            public ChildProvizyonCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvizyonCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
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
    /// Hastanın GSS Sisteminde Kayıtlı Bilgileri
    /// </summary>
        public HastaBilgileriDVO hastaBilgileri
        {
            get { return (HastaBilgileriDVO)((ITTObject)this).GetParent("HASTABILGILERI"); }
            set { this["HASTABILGILERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatesigortaliAdliGecmisiCollection()
        {
            _sigortaliAdliGecmisi = new SigortaliAdliGecmisDVO.ChildSigortaliAdliGecmisDVOCollection(this, new Guid("b8512d3b-f2e4-406f-9f43-99b9a076a429"));
            ((ITTChildObjectCollection)_sigortaliAdliGecmisi).GetChildren();
        }

        protected SigortaliAdliGecmisDVO.ChildSigortaliAdliGecmisDVOCollection _sigortaliAdliGecmisi = null;
        public SigortaliAdliGecmisDVO.ChildSigortaliAdliGecmisDVOCollection sigortaliAdliGecmisi
        {
            get
            {
                if (_sigortaliAdliGecmisi == null)
                    CreatesigortaliAdliGecmisiCollection();
                return _sigortaliAdliGecmisi;
            }
        }

        protected ProvizyonCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvizyonCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvizyonCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvizyonCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvizyonCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVIZYONCEVAPDVO", dataRow) { }
        protected ProvizyonCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVIZYONCEVAPDVO", dataRow, isImported) { }
        public ProvizyonCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvizyonCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvizyonCevapDVO() : base() { }

    }
}