
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaHataDVO")] 

    public  partial class FaturaHataDVO : BaseMedulaObject
    {
        public class FaturaHataDVOList : TTObjectCollection<FaturaHataDVO> { }
                    
        public class ChildFaturaHataDVOCollection : TTObject.TTChildObjectCollection<FaturaHataDVO>
        {
            public ChildFaturaHataDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaHataDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hata Kodu
    /// </summary>
        public string hataKodu
        {
            get { return (string)this["HATAKODU"]; }
            set { this["HATAKODU"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string hataMesaji
        {
            get { return (string)this["HATAMESAJI"]; }
            set { this["HATAMESAJI"] = value; }
        }

    /// <summary>
    /// Fatura Cevap-Hatalı Kayıtlar
    /// </summary>
        public FaturaCevapDVO FaturaCevapDVO
        {
            get { return (FaturaCevapDVO)((ITTObject)this).GetParent("FATURACEVAPDVO"); }
            set { this["FATURACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaHataDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaHataDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaHataDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaHataDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaHataDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAHATADVO", dataRow) { }
        protected FaturaHataDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAHATADVO", dataRow, isImported) { }
        public FaturaHataDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaHataDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaHataDVO() : base() { }

    }
}