
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResDivision")] 

    /// <summary>
    /// Bölüm Tanımı
    /// </summary>
    public  partial class ResDivision : ResSection
    {
        public class ResDivisionList : TTObjectCollection<ResDivision> { }
                    
        public class ChildResDivisionCollection : TTObject.TTChildObjectCollection<ResDivision>
        {
            public ChildResDivisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResDivisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Müdürlük-Bölüm
    /// </summary>
        public ResHeaderShip HeaderShip
        {
            get { return (ResHeaderShip)((ITTObject)this).GetParent("HEADERSHIP"); }
            set { this["HEADERSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDivisionSectionsCollection()
        {
            _DivisionSections = new ResDivisionSection.ChildResDivisionSectionCollection(this, new Guid("5cb50924-9323-4516-b889-8d8bead479f2"));
            ((ITTChildObjectCollection)_DivisionSections).GetChildren();
        }

        protected ResDivisionSection.ChildResDivisionSectionCollection _DivisionSections = null;
    /// <summary>
    /// Child collection for Bölüm-Kısım
    /// </summary>
        public ResDivisionSection.ChildResDivisionSectionCollection DivisionSections
        {
            get
            {
                if (_DivisionSections == null)
                    CreateDivisionSectionsCollection();
                return _DivisionSections;
            }
        }

        protected ResDivision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResDivision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResDivision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResDivision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResDivision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESDIVISION", dataRow) { }
        protected ResDivision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESDIVISION", dataRow, isImported) { }
        public ResDivision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResDivision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResDivision() : base() { }

    }
}