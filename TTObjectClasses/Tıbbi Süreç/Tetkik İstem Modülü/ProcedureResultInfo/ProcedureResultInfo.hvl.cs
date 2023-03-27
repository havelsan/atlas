
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureResultInfo")] 

    /// <summary>
    /// İşlem Sonucu
    /// </summary>
    public  partial class ProcedureResultInfo : BaseAdditionalInfo
    {
        public class ProcedureResultInfoList : TTObjectCollection<ProcedureResultInfo> { }
                    
        public class ChildProcedureResultInfoCollection : TTObject.TTChildObjectCollection<ProcedureResultInfo>
        {
            public ChildProcedureResultInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureResultInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç Değeri
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        protected ProcedureResultInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureResultInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureResultInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureResultInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureResultInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDURERESULTINFO", dataRow) { }
        protected ProcedureResultInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDURERESULTINFO", dataRow, isImported) { }
        public ProcedureResultInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureResultInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureResultInfo() : base() { }

    }
}