
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZPersonnel")] 

    /// <summary>
    /// DE_Personel
    /// </summary>
    public  partial class MNZPersonnel : Personnel
    {
        public class MNZPersonnelList : TTObjectCollection<MNZPersonnel> { }
                    
        public class ChildMNZPersonnelCollection : TTObject.TTChildObjectCollection<MNZPersonnel>
        {
            public ChildMNZPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateExpectedVisitorCollection()
        {
            _ExpectedVisitor = new MNZExpectedVisitor.ChildMNZExpectedVisitorCollection(this, new Guid("2cfc07c1-1ad4-437d-a464-2b82c7f3f572"));
            ((ITTChildObjectCollection)_ExpectedVisitor).GetChildren();
        }

        protected MNZExpectedVisitor.ChildMNZExpectedVisitorCollection _ExpectedVisitor = null;
    /// <summary>
    /// Child collection for Personel Beklenen Ziyaretçi
    /// </summary>
        public MNZExpectedVisitor.ChildMNZExpectedVisitorCollection ExpectedVisitor
        {
            get
            {
                if (_ExpectedVisitor == null)
                    CreateExpectedVisitorCollection();
                return _ExpectedVisitor;
            }
        }

        protected MNZPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZPERSONNEL", dataRow) { }
        protected MNZPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZPERSONNEL", dataRow, isImported) { }
        public MNZPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZPersonnel() : base() { }

    }
}