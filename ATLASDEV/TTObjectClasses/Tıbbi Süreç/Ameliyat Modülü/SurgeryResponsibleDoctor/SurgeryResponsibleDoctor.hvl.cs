
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryResponsibleDoctor")] 

    public  partial class SurgeryResponsibleDoctor : TTObject
    {
        public class SurgeryResponsibleDoctorList : TTObjectCollection<SurgeryResponsibleDoctor> { }
                    
        public class ChildSurgeryResponsibleDoctorCollection : TTObject.TTChildObjectCollection<SurgeryResponsibleDoctor>
        {
            public ChildSurgeryResponsibleDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryResponsibleDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıralama Numarası
    /// </summary>
        public string RankingNumber
        {
            get { return (string)this["RANKINGNUMBER"]; }
            set { this["RANKINGNUMBER"] = value; }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryProcedure SurgeryProcedure
        {
            get { return (SurgeryProcedure)((ITTObject)this).GetParent("SURGERYPROCEDURE"); }
            set { this["SURGERYPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYRESPONSIBLEDOCTOR", dataRow) { }
        protected SurgeryResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYRESPONSIBLEDOCTOR", dataRow, isImported) { }
        public SurgeryResponsibleDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryResponsibleDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryResponsibleDoctor() : base() { }

    }
}