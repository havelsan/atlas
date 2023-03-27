
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingAppProgresses")] 

    /// <summary>
    /// Hemşire Notları Devir Teslim
    /// </summary>
    public  partial class NursingAppProgresses : TTObject
    {
        public class NursingAppProgressesList : TTObjectCollection<NursingAppProgresses> { }
                    
        public class ChildNursingAppProgressesCollection : TTObject.TTChildObjectCollection<NursingAppProgresses>
        {
            public ChildNursingAppProgressesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingAppProgressesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ProgressDate
        {
            get { return (DateTime?)this["PROGRESSDATE"]; }
            set { this["PROGRESSDATE"] = value; }
        }

        protected NursingAppProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingAppProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingAppProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingAppProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingAppProgresses(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPPROGRESSES", dataRow) { }
        protected NursingAppProgresses(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPPROGRESSES", dataRow, isImported) { }
        public NursingAppProgresses(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingAppProgresses(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingAppProgresses() : base() { }

    }
}