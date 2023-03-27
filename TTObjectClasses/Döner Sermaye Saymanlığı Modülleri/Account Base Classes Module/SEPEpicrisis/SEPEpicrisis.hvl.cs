
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SEPEpicrisis")] 

    public  partial class SEPEpicrisis : TTObject
    {
        public class SEPEpicrisisList : TTObjectCollection<SEPEpicrisis> { }
                    
        public class ChildSEPEpicrisisCollection : TTObject.TTChildObjectCollection<SEPEpicrisis>
        {
            public ChildSEPEpicrisisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSEPEpicrisisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

    /// <summary>
    /// Kayıt Edilmiş Epikriz
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kullanıcı Bağlantısı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSEPCollection()
        {
            _SEP = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("8c0d183e-2874-4204-b4bc-256ae4963e52"));
            ((ITTChildObjectCollection)_SEP).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SEP = null;
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SEP
        {
            get
            {
                if (_SEP == null)
                    CreateSEPCollection();
                return _SEP;
            }
        }

        protected SEPEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SEPEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SEPEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SEPEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SEPEpicrisis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEPEPICRISIS", dataRow) { }
        protected SEPEpicrisis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEPEPICRISIS", dataRow, isImported) { }
        public SEPEpicrisis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SEPEpicrisis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SEPEpicrisis() : base() { }

    }
}