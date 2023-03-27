
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SnomedDiagnosisGrid")] 

    /// <summary>
    /// Snomed Tanı Girişi
    /// </summary>
    public  partial class SnomedDiagnosisGrid : TTDefinitionSet
    {
        public class SnomedDiagnosisGridList : TTObjectCollection<SnomedDiagnosisGrid> { }
                    
        public class ChildSnomedDiagnosisGridCollection : TTObject.TTChildObjectCollection<SnomedDiagnosisGrid>
        {
            public ChildSnomedDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSnomedDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Panik Tanı Bildirim
    /// </summary>
        public bool? PanicDiagnosisNotification
        {
            get { return (bool?)this["PANICDIAGNOSISNOTIFICATION"]; }
            set { this["PANICDIAGNOSISNOTIFICATION"] = value; }
        }

        public SnomedDiagnosisDefinition SnomedDiagnose
        {
            get { return (SnomedDiagnosisDefinition)((ITTObject)this).GetParent("SNOMEDDIAGNOSE"); }
            set { this["SNOMEDDIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pathology PathologyTest
        {
            get { return (Pathology)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Panik Bidirim Mesajı İlişkisi
    /// </summary>
        public UserMessage UserMessage
        {
            get { return (UserMessage)((ITTObject)this).GetParent("USERMESSAGE"); }
            set { this["USERMESSAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SnomedDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SnomedDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SnomedDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SnomedDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SnomedDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SNOMEDDIAGNOSISGRID", dataRow) { }
        protected SnomedDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SNOMEDDIAGNOSISGRID", dataRow, isImported) { }
        public SnomedDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SnomedDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SnomedDiagnosisGrid() : base() { }

    }
}