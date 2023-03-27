
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AcademicCommClaim")] 

    public  partial class AcademicCommClaim : TTObject
    {
        public class AcademicCommClaimList : TTObjectCollection<AcademicCommClaim> { }
                    
        public class ChildAcademicCommClaimCollection : TTObject.TTChildObjectCollection<AcademicCommClaim>
        {
            public ChildAcademicCommClaimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAcademicCommClaimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? AcademicCommAddDate
        {
            get { return (DateTime?)this["ACADEMICCOMMADDDATE"]; }
            set { this["ACADEMICCOMMADDDATE"] = value; }
        }

        public string AcademicCommAddInfo
        {
            get { return (string)this["ACADEMICCOMMADDINFO"]; }
            set { this["ACADEMICCOMMADDINFO"] = value; }
        }

        virtual protected void CreateProjectAcademicCommClaimCollection()
        {
            _ProjectAcademicCommClaim = new ArgeProject.ChildArgeProjectCollection(this, new Guid("e8686cfd-cdf2-4581-8762-47a3d0faf5bf"));
            ((ITTChildObjectCollection)_ProjectAcademicCommClaim).GetChildren();
        }

        protected ArgeProject.ChildArgeProjectCollection _ProjectAcademicCommClaim = null;
        public ArgeProject.ChildArgeProjectCollection ProjectAcademicCommClaim
        {
            get
            {
                if (_ProjectAcademicCommClaim == null)
                    CreateProjectAcademicCommClaimCollection();
                return _ProjectAcademicCommClaim;
            }
        }

        protected AcademicCommClaim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AcademicCommClaim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AcademicCommClaim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AcademicCommClaim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AcademicCommClaim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACADEMICCOMMCLAIM", dataRow) { }
        protected AcademicCommClaim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACADEMICCOMMCLAIM", dataRow, isImported) { }
        public AcademicCommClaim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AcademicCommClaim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AcademicCommClaim() : base() { }

    }
}