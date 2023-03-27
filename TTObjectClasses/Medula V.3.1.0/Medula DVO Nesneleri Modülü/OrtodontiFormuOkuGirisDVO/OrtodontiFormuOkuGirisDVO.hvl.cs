
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiFormuOkuGirisDVO")] 

    public  partial class OrtodontiFormuOkuGirisDVO : BaseMedulaObject
    {
        public class OrtodontiFormuOkuGirisDVOList : TTObjectCollection<OrtodontiFormuOkuGirisDVO> { }
                    
        public class ChildOrtodontiFormuOkuGirisDVOCollection : TTObject.TTChildObjectCollection<OrtodontiFormuOkuGirisDVO>
        {
            public ChildOrtodontiFormuOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiFormuOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
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

        public long? tcKimlikNo
        {
            get { return (long?)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        public OrtodontiFormuOkuCevapDVO ortodontiFormuOkuCevapDVO
        {
            get { return (OrtodontiFormuOkuCevapDVO)((ITTObject)this).GetParent("ORTODONTIFORMUOKUCEVAPDVO"); }
            set { this["ORTODONTIFORMUOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIFORMUOKUGIRISDVO", dataRow) { }
        protected OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIFORMUOKUGIRISDVO", dataRow, isImported) { }
        public OrtodontiFormuOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiFormuOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiFormuOkuGirisDVO() : base() { }

    }
}