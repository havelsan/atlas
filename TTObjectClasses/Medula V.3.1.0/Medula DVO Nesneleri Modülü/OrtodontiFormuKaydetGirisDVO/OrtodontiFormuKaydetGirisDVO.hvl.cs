
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiFormuKaydetGirisDVO")] 

    public  partial class OrtodontiFormuKaydetGirisDVO : BaseMedulaObject
    {
        public class OrtodontiFormuKaydetGirisDVOList : TTObjectCollection<OrtodontiFormuKaydetGirisDVO> { }
                    
        public class ChildOrtodontiFormuKaydetGirisDVOCollection : TTObject.TTChildObjectCollection<OrtodontiFormuKaydetGirisDVO>
        {
            public ChildOrtodontiFormuKaydetGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiFormuKaydetGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public string provizyonNo
        {
            get { return (string)this["PROVIZYONNO"]; }
            set { this["PROVIZYONNO"] = value; }
        }

        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public int? formNo
        {
            get { return (int?)this["FORMNO"]; }
            set { this["FORMNO"] = value; }
        }

        public string islemTarihi
        {
            get { return (string)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

        public long? tcKimlikNo
        {
            get { return (long?)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        public OrtodontiFormuKaydetCevapDVO ortodontiFormuKaydetCevapDVO
        {
            get { return (OrtodontiFormuKaydetCevapDVO)((ITTObject)this).GetParent("ORTODONTIFORMUKAYDETCEVAPDVO"); }
            set { this["ORTODONTIFORMUKAYDETCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIFORMUKAYDETGIRISDVO", dataRow) { }
        protected OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIFORMUKAYDETGIRISDVO", dataRow, isImported) { }
        public OrtodontiFormuKaydetGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiFormuKaydetGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiFormuKaydetGirisDVO() : base() { }

    }
}