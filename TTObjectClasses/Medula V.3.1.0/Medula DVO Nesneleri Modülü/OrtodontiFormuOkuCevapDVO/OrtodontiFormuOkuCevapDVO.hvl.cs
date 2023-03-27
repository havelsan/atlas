
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiFormuOkuCevapDVO")] 

    public  partial class OrtodontiFormuOkuCevapDVO : BaseMedulaCevap
    {
        public class OrtodontiFormuOkuCevapDVOList : TTObjectCollection<OrtodontiFormuOkuCevapDVO> { }
                    
        public class ChildOrtodontiFormuOkuCevapDVOCollection : TTObject.TTChildObjectCollection<OrtodontiFormuOkuCevapDVO>
        {
            public ChildOrtodontiFormuOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiFormuOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string formNo
        {
            get { return (string)this["FORMNO"]; }
            set { this["FORMNO"] = value; }
        }

        public string islemTuru
        {
            get { return (string)this["ISLEMTURU"]; }
            set { this["ISLEMTURU"] = value; }
        }

        public string tesis_kodu_1
        {
            get { return (string)this["TESIS_KODU_1"]; }
            set { this["TESIS_KODU_1"] = value; }
        }

        public string tesis_kodu_2
        {
            get { return (string)this["TESIS_KODU_2"]; }
            set { this["TESIS_KODU_2"] = value; }
        }

        public string tesis_kodu_3
        {
            get { return (string)this["TESIS_KODU_3"]; }
            set { this["TESIS_KODU_3"] = value; }
        }

        public string islem_tarihi_1
        {
            get { return (string)this["ISLEM_TARIHI_1"]; }
            set { this["ISLEM_TARIHI_1"] = value; }
        }

        public string islem_tarihi_2
        {
            get { return (string)this["ISLEM_TARIHI_2"]; }
            set { this["ISLEM_TARIHI_2"] = value; }
        }

        public string islem_tarihi_3
        {
            get { return (string)this["ISLEM_TARIHI_3"]; }
            set { this["ISLEM_TARIHI_3"] = value; }
        }

        public string provizyonNo1
        {
            get { return (string)this["PROVIZYONNO1"]; }
            set { this["PROVIZYONNO1"] = value; }
        }

        public string provizyonNo2
        {
            get { return (string)this["PROVIZYONNO2"]; }
            set { this["PROVIZYONNO2"] = value; }
        }

        public string provizyonNo3
        {
            get { return (string)this["PROVIZYONNO3"]; }
            set { this["PROVIZYONNO3"] = value; }
        }

        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIFORMUOKUCEVAPDVO", dataRow) { }
        protected OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIFORMUOKUCEVAPDVO", dataRow, isImported) { }
        public OrtodontiFormuOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiFormuOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiFormuOkuCevapDVO() : base() { }

    }
}