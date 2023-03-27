
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetDetayDVO")] 

    public  partial class HizmetDetayDVO : BaseMedulaObject
    {
        public class HizmetDetayDVOList : TTObjectCollection<HizmetDetayDVO> { }
                    
        public class ChildHizmetDetayDVOCollection : TTObject.TTChildObjectCollection<HizmetDetayDVO>
        {
            public ChildHizmetDetayDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetDetayDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        public string taburcuKodu
        {
            get { return (string)this["TABURCUKODU"]; }
            set { this["TABURCUKODU"] = value; }
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
    /// Açıklama
    /// </summary>
        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Protokol Numarası
    /// </summary>
        public string protokolNo
        {
            get { return (string)this["PROTOKOLNO"]; }
            set { this["PROTOKOLNO"] = value; }
        }

    /// <summary>
    /// Fatura Giriş-Hizmet Detayları
    /// </summary>
        public FaturaGirisDVO FaturaGirisDVO
        {
            get { return (FaturaGirisDVO)((ITTObject)this).GetParent("FATURAGIRISDVO"); }
            set { this["FATURAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetDetayDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETDETAYDVO", dataRow) { }
        protected HizmetDetayDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETDETAYDVO", dataRow, isImported) { }
        public HizmetDetayDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetDetayDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetDetayDVO() : base() { }

    }
}