
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaCikisIptalDVO")] 

    public  partial class HastaCikisIptalDVO : BaseMedulaObject
    {
        public class HastaCikisIptalDVOList : TTObjectCollection<HastaCikisIptalDVO> { }
                    
        public class ChildHastaCikisIptalDVOCollection : TTObject.TTChildObjectCollection<HastaCikisIptalDVO>
        {
            public ChildHastaCikisIptalDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaCikisIptalDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yeni Hasta Çıkış Tarihi
    /// </summary>
        public string yeniHastaCikisTarihi
        {
            get { return (string)this["YENIHASTACIKISTARIHI"]; }
            set { this["YENIHASTACIKISTARIHI"] = value; }
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
    /// Hasta Çıkış Tarihi
    /// </summary>
        public string hastaCikisTarihi
        {
            get { return (string)this["HASTACIKISTARIHI"]; }
            set { this["HASTACIKISTARIHI"] = value; }
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
    /// Hasta Cıkış Cevap
    /// </summary>
        public HastaCikisCevapDVO hastaCikisCevapDVO
        {
            get { return (HastaCikisCevapDVO)((ITTObject)this).GetParent("HASTACIKISCEVAPDVO"); }
            set { this["HASTACIKISCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaCikisIptalDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaCikisIptalDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaCikisIptalDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaCikisIptalDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaCikisIptalDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTACIKISIPTALDVO", dataRow) { }
        protected HastaCikisIptalDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTACIKISIPTALDVO", dataRow, isImported) { }
        public HastaCikisIptalDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaCikisIptalDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaCikisIptalDVO() : base() { }

    }
}