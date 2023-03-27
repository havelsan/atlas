
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_VisitorNoncommissionedOfficerFamily")] 

    /// <summary>
    /// Misafir Astsubay Ailesi Kabulü
    /// </summary>
    public  partial class PA_VisitorNoncommissionedOfficerFamily : PA_VisitorMilitaryFamiliy
    {
        public class PA_VisitorNoncommissionedOfficerFamilyList : TTObjectCollection<PA_VisitorNoncommissionedOfficerFamily> { }
                    
        public class ChildPA_VisitorNoncommissionedOfficerFamilyCollection : TTObject.TTChildObjectCollection<PA_VisitorNoncommissionedOfficerFamily>
        {
            public ChildPA_VisitorNoncommissionedOfficerFamilyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_VisitorNoncommissionedOfficerFamilyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions HOFMilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("HOFMILITARYCLASS"); }
            set { this["HOFMILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions HOFRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("HOFRANK"); }
            set { this["HOFRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_VISITORNONCOMMISSIONEDOFFICERFAMILY", dataRow) { }
        protected PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_VISITORNONCOMMISSIONEDOFFICERFAMILY", dataRow, isImported) { }
        public PA_VisitorNoncommissionedOfficerFamily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_VisitorNoncommissionedOfficerFamily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_VisitorNoncommissionedOfficerFamily() : base() { }

    }
}