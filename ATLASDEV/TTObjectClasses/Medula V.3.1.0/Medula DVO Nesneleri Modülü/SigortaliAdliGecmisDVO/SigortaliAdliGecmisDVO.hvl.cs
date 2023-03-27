
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SigortaliAdliGecmisDVO")] 

    public  partial class SigortaliAdliGecmisDVO : BaseMedulaObject
    {
        public class SigortaliAdliGecmisDVOList : TTObjectCollection<SigortaliAdliGecmisDVO> { }
                    
        public class ChildSigortaliAdliGecmisDVOCollection : TTObject.TTChildObjectCollection<SigortaliAdliGecmisDVO>
        {
            public ChildSigortaliAdliGecmisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSigortaliAdliGecmisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Provizyon Tarihi
    /// </summary>
        public string provTarihi
        {
            get { return (string)this["PROVTARIHI"]; }
            set { this["PROVTARIHI"] = value; }
        }

    /// <summary>
    /// Provizyon Tipi
    /// </summary>
        public string provTipi
        {
            get { return (string)this["PROVTIPI"]; }
            set { this["PROVTIPI"] = value; }
        }

    /// <summary>
    /// Hasta TC Kimlik No
    /// </summary>
        public string tckNo
        {
            get { return (string)this["TCKNO"]; }
            set { this["TCKNO"] = value; }
        }

        public ProvizyonCevapDVO ProvizyonCevapDVO
        {
            get { return (ProvizyonCevapDVO)((ITTObject)this).GetParent("PROVIZYONCEVAPDVO"); }
            set { this["PROVIZYONCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SIGORTALIADLIGECMISDVO", dataRow) { }
        protected SigortaliAdliGecmisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SIGORTALIADLIGECMISDVO", dataRow, isImported) { }
        public SigortaliAdliGecmisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SigortaliAdliGecmisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SigortaliAdliGecmisDVO() : base() { }

    }
}