
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeSUTKuraliDVO")] 

    public  partial class EtkinMaddeSUTKuraliDVO : BaseMedulaObject
    {
        public class EtkinMaddeSUTKuraliDVOList : TTObjectCollection<EtkinMaddeSUTKuraliDVO> { }
                    
        public class ChildEtkinMaddeSUTKuraliDVOCollection : TTObject.TTChildObjectCollection<EtkinMaddeSUTKuraliDVO>
        {
            public ChildEtkinMaddeSUTKuraliDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeSUTKuraliDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string bransKuralUygulama
        {
            get { return (string)this["BRANSKURALUYGULAMA"]; }
            set { this["BRANSKURALUYGULAMA"] = value; }
        }

        public string duzenlemeTuru
        {
            get { return (string)this["DUZENLEMETURU"]; }
            set { this["DUZENLEMETURU"] = value; }
        }

        public int? kuralID
        {
            get { return (int?)this["KURALID"]; }
            set { this["KURALID"] = value; }
        }

        public EtkinMaddeSUTCevapDVO EtkinMaddeSUTCevapDVO
        {
            get { return (EtkinMaddeSUTCevapDVO)((ITTObject)this).GetParent("ETKINMADDESUTCEVAPDVO"); }
            set { this["ETKINMADDESUTCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatebranslarCollection()
        {
            _branslar = new BransListDVO.ChildBransListDVOCollection(this, new Guid("7690a5bd-7af3-4953-a21a-cb21c2fa7f98"));
            ((ITTChildObjectCollection)_branslar).GetChildren();
        }

        protected BransListDVO.ChildBransListDVOCollection _branslar = null;
        public BransListDVO.ChildBransListDVOCollection branslar
        {
            get
            {
                if (_branslar == null)
                    CreatebranslarCollection();
                return _branslar;
            }
        }

        virtual protected void CreatesertifikalarCollection()
        {
            _sertifikalar = new SertifikaStringDVO.ChildSertifikaStringDVOCollection(this, new Guid("6a9571b9-5a68-4052-bdc6-2f078f321a0d"));
            ((ITTChildObjectCollection)_sertifikalar).GetChildren();
        }

        protected SertifikaStringDVO.ChildSertifikaStringDVOCollection _sertifikalar = null;
        public SertifikaStringDVO.ChildSertifikaStringDVOCollection sertifikalar
        {
            get
            {
                if (_sertifikalar == null)
                    CreatesertifikalarCollection();
                return _sertifikalar;
            }
        }

        virtual protected void CreateteshislerCollection()
        {
            _teshisler = new TeshisDVO.ChildTeshisDVOCollection(this, new Guid("2e6a09df-d96d-4573-9292-c576060904d9"));
            ((ITTChildObjectCollection)_teshisler).GetChildren();
        }

        protected TeshisDVO.ChildTeshisDVOCollection _teshisler = null;
        public TeshisDVO.ChildTeshisDVOCollection teshisler
        {
            get
            {
                if (_teshisler == null)
                    CreateteshislerCollection();
                return _teshisler;
            }
        }

        virtual protected void CreatetesislerCollection()
        {
            _tesisler = new TesisStringDVO.ChildTesisStringDVOCollection(this, new Guid("86b1a2fd-5dbc-4ecf-ab05-499f53eb091e"));
            ((ITTChildObjectCollection)_tesisler).GetChildren();
        }

        protected TesisStringDVO.ChildTesisStringDVOCollection _tesisler = null;
        public TesisStringDVO.ChildTesisStringDVOCollection tesisler
        {
            get
            {
                if (_tesisler == null)
                    CreatetesislerCollection();
                return _tesisler;
            }
        }

        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDESUTKURALIDVO", dataRow) { }
        protected EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDESUTKURALIDVO", dataRow, isImported) { }
        public EtkinMaddeSUTKuraliDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeSUTKuraliDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeSUTKuraliDVO() : base() { }

    }
}