
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikTesisiListDVO")] 

    public  partial class SaglikTesisiListDVO : BaseMedulaObject
    {
        public class SaglikTesisiListDVOList : TTObjectCollection<SaglikTesisiListDVO> { }
                    
        public class ChildSaglikTesisiListDVOCollection : TTObject.TTChildObjectCollection<SaglikTesisiListDVO>
        {
            public ChildSaglikTesisiListDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikTesisiListDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesisin Türü
    /// </summary>
        public string tesisTuru
        {
            get { return (string)this["TESISTURU"]; }
            set { this["TESISTURU"] = value; }
        }

    /// <summary>
    /// Tesisin Kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

    /// <summary>
    /// Tesis Sınıf Kodu
    /// </summary>
        public string tesisSinifKodu
        {
            get { return (string)this["TESISSINIFKODU"]; }
            set { this["TESISSINIFKODU"] = value; }
        }

    /// <summary>
    /// Tesisin İl Kodu
    /// </summary>
        public string tesisIl
        {
            get { return (string)this["TESISIL"]; }
            set { this["TESISIL"] = value; }
        }

    /// <summary>
    /// SaglikTesisiAraCevapDVO-tesisler
    /// </summary>
        public SaglikTesisiAraCevapDVO SaglikTesisiAraCevapDVO
        {
            get { return (SaglikTesisiAraCevapDVO)((ITTObject)this).GetParent("SAGLIKTESISIARACEVAPDVO"); }
            set { this["SAGLIKTESISIARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SaglikTesisiListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikTesisiListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikTesisiListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikTesisiListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikTesisiListDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKTESISILISTDVO", dataRow) { }
        protected SaglikTesisiListDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKTESISILISTDVO", dataRow, isImported) { }
        public SaglikTesisiListDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikTesisiListDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikTesisiListDVO() : base() { }

    }
}