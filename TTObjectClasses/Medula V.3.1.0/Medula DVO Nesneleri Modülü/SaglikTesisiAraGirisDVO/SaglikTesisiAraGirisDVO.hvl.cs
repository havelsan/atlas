
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikTesisiAraGirisDVO")] 

    public  partial class SaglikTesisiAraGirisDVO : BaseMedulaObject
    {
        public class SaglikTesisiAraGirisDVOList : TTObjectCollection<SaglikTesisiAraGirisDVO> { }
                    
        public class ChildSaglikTesisiAraGirisDVOCollection : TTObject.TTChildObjectCollection<SaglikTesisiAraGirisDVO>
        {
            public ChildSaglikTesisiAraGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikTesisiAraGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesis Adı
    /// </summary>
        public string tesisAdi
        {
            get { return (string)this["TESISADI"]; }
            set { this["TESISADI"] = value; }
        }

    /// <summary>
    /// Tesisin İl Kodu
    /// </summary>
        public string tesisIlKodu
        {
            get { return (string)this["TESISILKODU"]; }
            set { this["TESISILKODU"] = value; }
        }

    /// <summary>
    /// Tesisin Türü
    /// </summary>
        public string tesisTuru
        {
            get { return (string)this["TESISTURU"]; }
            set { this["TESISTURU"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public string tesisKodu
        {
            get { return (string)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

    /// <summary>
    /// Sağlık Tesisi Ara Cevap
    /// </summary>
        public SaglikTesisiAraCevapDVO saglikTesisiAraCevapDVO
        {
            get { return (SaglikTesisiAraCevapDVO)((ITTObject)this).GetParent("SAGLIKTESISIARACEVAPDVO"); }
            set { this["SAGLIKTESISIARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKTESISIARAGIRISDVO", dataRow) { }
        protected SaglikTesisiAraGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKTESISIARAGIRISDVO", dataRow, isImported) { }
        public SaglikTesisiAraGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikTesisiAraGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikTesisiAraGirisDVO() : base() { }

    }
}