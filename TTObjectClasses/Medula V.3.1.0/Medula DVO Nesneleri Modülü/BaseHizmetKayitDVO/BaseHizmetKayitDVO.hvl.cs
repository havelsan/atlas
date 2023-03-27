
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHizmetKayitDVO")] 

    public  abstract  partial class BaseHizmetKayitDVO : BaseMedulaObject
    {
        public class BaseHizmetKayitDVOList : TTObjectCollection<BaseHizmetKayitDVO> { }
                    
        public class ChildBaseHizmetKayitDVOCollection : TTObject.TTChildObjectCollection<BaseHizmetKayitDVO>
        {
            public ChildBaseHizmetKayitDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHizmetKayitDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Özel Durum
    /// </summary>
        public string ozelDurum
        {
            get { return (string)this["OZELDURUM"]; }
            set { this["OZELDURUM"] = value; }
        }

    /// <summary>
    /// İşlem Sıra Numarası
    /// </summary>
        public string islemSiraNo
        {
            get { return (string)this["ISLEMSIRANO"]; }
            set { this["ISLEMSIRANO"] = value; }
        }

    /// <summary>
    /// Hizmet Sunucu Referans Numarası
    /// </summary>
        public string hizmetSunucuRefNo
        {
            get { return (string)this["HIZMETSUNUCUREFNO"]; }
            set { this["HIZMETSUNUCUREFNO"] = value; }
        }

        protected BaseHizmetKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHizmetKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHizmetKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHizmetKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHizmetKayitDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHIZMETKAYITDVO", dataRow) { }
        protected BaseHizmetKayitDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHIZMETKAYITDVO", dataRow, isImported) { }
        public BaseHizmetKayitDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHizmetKayitDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHizmetKayitDVO() : base() { }

    }
}