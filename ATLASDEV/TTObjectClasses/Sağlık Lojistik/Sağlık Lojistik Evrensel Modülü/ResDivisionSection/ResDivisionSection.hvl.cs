
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResDivisionSection")] 

    /// <summary>
    /// Kısım Tanımı
    /// </summary>
    public  partial class ResDivisionSection : ResSection
    {
        public class ResDivisionSectionList : TTObjectCollection<ResDivisionSection> { }
                    
        public class ChildResDivisionSectionCollection : TTObject.TTChildObjectCollection<ResDivisionSection>
        {
            public ChildResDivisionSectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResDivisionSectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StageDefinition Stage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("STAGE"); }
            set { this["STAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bölüm-Kısım
    /// </summary>
        public ResDivision Division
        {
            get { return (ResDivision)((ITTObject)this).GetParent("DIVISION"); }
            set { this["DIVISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDivisionSubSectionsCollection()
        {
            _DivisionSubSections = new ResDivisionSubSection.ChildResDivisionSubSectionCollection(this, new Guid("be7f4777-2146-428d-af59-704e9dd03523"));
            ((ITTChildObjectCollection)_DivisionSubSections).GetChildren();
        }

        protected ResDivisionSubSection.ChildResDivisionSubSectionCollection _DivisionSubSections = null;
    /// <summary>
    /// Child collection for Kısım-Alt Kısım
    /// </summary>
        public ResDivisionSubSection.ChildResDivisionSubSectionCollection DivisionSubSections
        {
            get
            {
                if (_DivisionSubSections == null)
                    CreateDivisionSubSectionsCollection();
                return _DivisionSubSections;
            }
        }

        protected ResDivisionSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResDivisionSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResDivisionSection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResDivisionSection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResDivisionSection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESDIVISIONSECTION", dataRow) { }
        protected ResDivisionSection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESDIVISIONSECTION", dataRow, isImported) { }
        public ResDivisionSection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResDivisionSection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResDivisionSection() : base() { }

    }
}