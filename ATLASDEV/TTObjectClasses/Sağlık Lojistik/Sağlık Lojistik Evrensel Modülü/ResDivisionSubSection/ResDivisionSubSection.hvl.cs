
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResDivisionSubSection")] 

    /// <summary>
    /// Alt Kısım Tanımı
    /// </summary>
    public  partial class ResDivisionSubSection : ResSection
    {
        public class ResDivisionSubSectionList : TTObjectCollection<ResDivisionSubSection> { }
                    
        public class ChildResDivisionSubSectionCollection : TTObject.TTChildObjectCollection<ResDivisionSubSection>
        {
            public ChildResDivisionSubSectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResDivisionSubSectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StageDefinition Stage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("STAGE"); }
            set { this["STAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kısım-Alt Kısım
    /// </summary>
        public ResDivisionSection DivisionSection
        {
            get { return (ResDivisionSection)((ITTObject)this).GetParent("DIVISIONSECTION"); }
            set { this["DIVISIONSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWorkShopUsersCollection()
        {
            _WorkShopUsers = new WorkShopUserDefinition.ChildWorkShopUserDefinitionCollection(this, new Guid("3ebae22c-85b8-4e8a-a9eb-5ca6967d403f"));
            ((ITTChildObjectCollection)_WorkShopUsers).GetChildren();
        }

        protected WorkShopUserDefinition.ChildWorkShopUserDefinitionCollection _WorkShopUsers = null;
        public WorkShopUserDefinition.ChildWorkShopUserDefinitionCollection WorkShopUsers
        {
            get
            {
                if (_WorkShopUsers == null)
                    CreateWorkShopUsersCollection();
                return _WorkShopUsers;
            }
        }

        protected ResDivisionSubSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResDivisionSubSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResDivisionSubSection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResDivisionSubSection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResDivisionSubSection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESDIVISIONSUBSECTION", dataRow) { }
        protected ResDivisionSubSection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESDIVISIONSUBSECTION", dataRow, isImported) { }
        public ResDivisionSubSection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResDivisionSubSection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResDivisionSubSection() : base() { }

    }
}