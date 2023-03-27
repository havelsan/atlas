
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaTeslimNoDVO")] 

    public  partial class FaturaTeslimNoDVO : BaseMedulaObject
    {
        public class FaturaTeslimNoDVOList : TTObjectCollection<FaturaTeslimNoDVO> { }
                    
        public class ChildFaturaTeslimNoDVOCollection : TTObject.TTChildObjectCollection<FaturaTeslimNoDVO>
        {
            public ChildFaturaTeslimNoDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaTeslimNoDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fatura Teslim Numarası
    /// </summary>
        public string faturaTeslimNo
        {
            get { return (string)this["FATURATESLIMNO"]; }
            set { this["FATURATESLIMNO"] = value; }
        }

    /// <summary>
    /// Fatura İptal Giriş-Fatura Teslim Numaraları
    /// </summary>
        public FaturaIptalGirisDVO FaturaIptalGirisDVO
        {
            get { return (FaturaIptalGirisDVO)((ITTObject)this).GetParent("FATURAIPTALGIRISDVO"); }
            set { this["FATURAIPTALGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaTeslimNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaTeslimNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaTeslimNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaTeslimNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaTeslimNoDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURATESLIMNODVO", dataRow) { }
        protected FaturaTeslimNoDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURATESLIMNODVO", dataRow, isImported) { }
        public FaturaTeslimNoDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaTeslimNoDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaTeslimNoDVO() : base() { }

    }
}