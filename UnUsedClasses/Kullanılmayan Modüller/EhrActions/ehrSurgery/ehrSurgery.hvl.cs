
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrSurgery")] 

    /// <summary>
    /// Ameliyat
    /// </summary>
    public  partial class ehrSurgery : ehrEpisodeAction
    {
        public class ehrSurgeryList : TTObjectCollection<ehrSurgery> { }
                    
        public class ChildehrSurgeryCollection : TTObject.TTChildObjectCollection<ehrSurgery>
        {
            public ChildehrSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Ameliyat Raporu
    /// </summary>
        public object SurgeryReport
        {
            get { return (object)this["SURGERYREPORT"]; }
            set { this["SURGERYREPORT"] = value; }
        }

        public DateTime? SurgeryStartTime
        {
            get { return (DateTime?)this["SURGERYSTARTTIME"]; }
            set { this["SURGERYSTARTTIME"] = value; }
        }

    /// <summary>
    /// Ameliyat Bitiş Tarihi
    /// </summary>
        public DateTime? SurgeryEndTime
        {
            get { return (DateTime?)this["SURGERYENDTIME"]; }
            set { this["SURGERYENDTIME"] = value; }
        }

    /// <summary>
    /// Anestezi ve Reanimasyon İşlemi
    /// </summary>
        public ehrAnesthesiaAndReanimation ehrAnesthesiaAndReanimation
        {
            get { return (ehrAnesthesiaAndReanimation)((ITTObject)this).GetParent("EHRANESTHESIAANDREANIMATION"); }
            set { this["EHRANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yapılacak Ameliyat
    /// </summary>
        public SurgeryCategoryDefinition PlannedSurgery
        {
            get { return (SurgeryCategoryDefinition)((ITTObject)this).GetParent("PLANNEDSURGERY"); }
            set { this["PLANNEDSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrSurgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRSURGERY", dataRow) { }
        protected ehrSurgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRSURGERY", dataRow, isImported) { }
        public ehrSurgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrSurgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrSurgery() : base() { }

    }
}