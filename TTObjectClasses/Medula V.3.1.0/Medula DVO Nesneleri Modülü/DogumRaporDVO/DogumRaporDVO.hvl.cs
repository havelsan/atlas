
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DogumRaporDVO")] 

    public  partial class DogumRaporDVO : BaseMedulaObject
    {
        public class DogumRaporDVOList : TTObjectCollection<DogumRaporDVO> { }
                    
        public class ChildDogumRaporDVOCollection : TTObject.TTChildObjectCollection<DogumRaporDVO>
        {
            public ChildDogumRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDogumRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bebeğin tahmini doğum tarihi (dd.mm.yyyy)
    /// </summary>
        public string bebekDogumTarihi
        {
            get { return (string)this["BEBEKDOGUMTARIHI"]; }
            set { this["BEBEKDOGUMTARIHI"] = value; }
        }

        public int? cocukSayisi
        {
            get { return (int?)this["COCUKSAYISI"]; }
            set { this["COCUKSAYISI"] = value; }
        }

        public int? canliCocukSayisi
        {
            get { return (int?)this["CANLICOCUKSAYISI"]; }
            set { this["CANLICOCUKSAYISI"] = value; }
        }

        public string dogumTipi
        {
            get { return (string)this["DOGUMTIPI"]; }
            set { this["DOGUMTIPI"] = value; }
        }

        public string epizyotemi
        {
            get { return (string)this["EPIZYOTEMI"]; }
            set { this["EPIZYOTEMI"] = value; }
        }

        public string anesteziTipi
        {
            get { return (string)this["ANESTEZITIPI"]; }
            set { this["ANESTEZITIPI"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatecocuklarCollection()
        {
            _cocuklar = new CocukBilgisiDVO.ChildCocukBilgisiDVOCollection(this, new Guid("3d7f67e4-209b-4c48-a1ac-9ce0077124f5"));
            ((ITTChildObjectCollection)_cocuklar).GetChildren();
        }

        protected CocukBilgisiDVO.ChildCocukBilgisiDVOCollection _cocuklar = null;
        public CocukBilgisiDVO.ChildCocukBilgisiDVOCollection cocuklar
        {
            get
            {
                if (_cocuklar == null)
                    CreatecocuklarCollection();
                return _cocuklar;
            }
        }

        protected DogumRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DogumRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DogumRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DogumRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DogumRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOGUMRAPORDVO", dataRow) { }
        protected DogumRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOGUMRAPORDVO", dataRow, isImported) { }
        public DogumRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DogumRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DogumRaporDVO() : base() { }

    }
}