
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationCommisionMember")] 

    public  partial class ExaminationCommisionMember : CommisionMember
    {
        public class ExaminationCommisionMemberList : TTObjectCollection<ExaminationCommisionMember> { }
                    
        public class ChildExaminationCommisionMemberCollection : TTObject.TTChildObjectCollection<ExaminationCommisionMember>
        {
            public ChildExaminationCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PurchaseExamination PurchaseExamination
        {
            get { return (PurchaseExamination)((ITTObject)this).GetParent("PURCHASEEXAMINATION"); }
            set { this["PURCHASEEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONCOMMISIONMEMBER", dataRow) { }
        protected ExaminationCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONCOMMISIONMEMBER", dataRow, isImported) { }
        public ExaminationCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationCommisionMember() : base() { }

    }
}