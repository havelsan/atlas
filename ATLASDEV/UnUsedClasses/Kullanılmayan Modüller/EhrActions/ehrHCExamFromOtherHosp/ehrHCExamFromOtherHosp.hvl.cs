
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHCExamFromOtherHosp")] 

    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class ehrHCExamFromOtherHosp : ehrEpisodeAction
    {
        public class ehrHCExamFromOtherHospList : TTObjectCollection<ehrHCExamFromOtherHosp> { }
                    
        public class ChildehrHCExamFromOtherHospCollection : TTObject.TTChildObjectCollection<ehrHCExamFromOtherHosp>
        {
            public ChildehrHCExamFromOtherHospCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHCExamFromOtherHospCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public string Department
        {
            get { return (string)this["DEPARTMENT"]; }
            set { this["DEPARTMENT"] = value; }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHCEXAMFROMOTHERHOSP", dataRow) { }
        protected ehrHCExamFromOtherHosp(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHCEXAMFROMOTHERHOSP", dataRow, isImported) { }
        public ehrHCExamFromOtherHosp(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHCExamFromOtherHosp(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHCExamFromOtherHosp() : base() { }

    }
}