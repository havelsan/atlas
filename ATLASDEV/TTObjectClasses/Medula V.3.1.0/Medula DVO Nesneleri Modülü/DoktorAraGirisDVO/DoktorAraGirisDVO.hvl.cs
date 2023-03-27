
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoktorAraGirisDVO")] 

    public  partial class DoktorAraGirisDVO : BaseMedulaObject
    {
        public class DoktorAraGirisDVOList : TTObjectCollection<DoktorAraGirisDVO> { }
                    
        public class ChildDoktorAraGirisDVOCollection : TTObject.TTChildObjectCollection<DoktorAraGirisDVO>
        {
            public ChildDoktorAraGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorAraGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

    /// <summary>
    /// Doktor Soyadı
    /// </summary>
        public string drSoyadi
        {
            get { return (string)this["DRSOYADI"]; }
            set { this["DRSOYADI"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisiKodu
        {
            get { return (int?)this["SAGLIKTESISIKODU"]; }
            set { this["SAGLIKTESISIKODU"] = value; }
        }

    /// <summary>
    /// Doktor Uzmanlık Kodu
    /// </summary>
        public string drBransKodu
        {
            get { return (string)this["DRBRANSKODU"]; }
            set { this["DRBRANSKODU"] = value; }
        }

    /// <summary>
    /// Doktor Diploma No
    /// </summary>
        public string drDiplomaNo
        {
            get { return (string)this["DRDIPLOMANO"]; }
            set { this["DRDIPLOMANO"] = value; }
        }

    /// <summary>
    /// Doktor Adı
    /// </summary>
        public string drAdi
        {
            get { return (string)this["DRADI"]; }
            set { this["DRADI"] = value; }
        }

    /// <summary>
    /// Doktor Ara Cevap
    /// </summary>
        public DoktorAraCevapDVO doktorAraCevapDVO
        {
            get { return (DoktorAraCevapDVO)((ITTObject)this).GetParent("DOKTORARACEVAPDVO"); }
            set { this["DOKTORARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoktorAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoktorAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoktorAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoktorAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoktorAraGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTORARAGIRISDVO", dataRow) { }
        protected DoktorAraGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTORARAGIRISDVO", dataRow, isImported) { }
        public DoktorAraGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoktorAraGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoktorAraGirisDVO() : base() { }

    }
}