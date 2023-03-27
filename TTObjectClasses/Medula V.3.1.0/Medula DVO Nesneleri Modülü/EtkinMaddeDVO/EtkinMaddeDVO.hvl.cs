
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeDVO")] 

    public  partial class EtkinMaddeDVO : BaseMedulaObject
    {
        public class EtkinMaddeDVOList : TTObjectCollection<EtkinMaddeDVO> { }
                    
        public class ChildEtkinMaddeDVOCollection : TTObject.TTChildObjectCollection<EtkinMaddeDVO>
        {
            public ChildEtkinMaddeDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string adetMiktar
        {
            get { return (string)this["ADETMIKTAR"]; }
            set { this["ADETMIKTAR"] = value; }
        }

        public string etkinMaddeAdi
        {
            get { return (string)this["ETKINMADDEADI"]; }
            set { this["ETKINMADDEADI"] = value; }
        }

        public string etkinMaddeKodu
        {
            get { return (string)this["ETKINMADDEKODU"]; }
            set { this["ETKINMADDEKODU"] = value; }
        }

        public string form
        {
            get { return (string)this["FORM"]; }
            set { this["FORM"] = value; }
        }

        public string icerikMiktari
        {
            get { return (string)this["ICERIKMIKTARI"]; }
            set { this["ICERIKMIKTARI"] = value; }
        }

        public EtkinMaddeOkuCevapDVO EtkinMaddeOkuCevapDVO
        {
            get { return (EtkinMaddeOkuCevapDVO)((ITTObject)this).GetParent("ETKINMADDEOKUCEVAPDVO"); }
            set { this["ETKINMADDEOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDEDVO", dataRow) { }
        protected EtkinMaddeDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDEDVO", dataRow, isImported) { }
        public EtkinMaddeDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeDVO() : base() { }

    }
}