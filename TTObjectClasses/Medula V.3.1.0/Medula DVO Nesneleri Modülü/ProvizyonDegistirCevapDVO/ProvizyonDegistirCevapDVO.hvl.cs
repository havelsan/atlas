
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvizyonDegistirCevapDVO")] 

    public  partial class ProvizyonDegistirCevapDVO : BaseMedulaCevap
    {
        public class ProvizyonDegistirCevapDVOList : TTObjectCollection<ProvizyonDegistirCevapDVO> { }
                    
        public class ChildProvizyonDegistirCevapDVOCollection : TTObject.TTChildObjectCollection<ProvizyonDegistirCevapDVO>
        {
            public ChildProvizyonDegistirCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvizyonDegistirCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Provizyonun Tipi
    /// </summary>
        public string yeniProvizyonTipi
        {
            get { return (string)this["YENIPROVIZYONTIPI"]; }
            set { this["YENIPROVIZYONTIPI"] = value; }
        }

        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVIZYONDEGISTIRCEVAPDVO", dataRow) { }
        protected ProvizyonDegistirCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVIZYONDEGISTIRCEVAPDVO", dataRow, isImported) { }
        public ProvizyonDegistirCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvizyonDegistirCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvizyonDegistirCevapDVO() : base() { }

    }
}