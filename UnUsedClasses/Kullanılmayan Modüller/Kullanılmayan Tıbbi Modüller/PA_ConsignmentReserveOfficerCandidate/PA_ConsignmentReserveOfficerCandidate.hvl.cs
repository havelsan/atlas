
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_ConsignmentReserveOfficerCandidate")] 

    /// <summary>
    /// Sevke Tabi Yedek Subay Aday  Adayı Kabul 
    /// </summary>
    public  partial class PA_ConsignmentReserveOfficerCandidate : PatientAdmission
    {
        public class PA_ConsignmentReserveOfficerCandidateList : TTObjectCollection<PA_ConsignmentReserveOfficerCandidate> { }
                    
        public class ChildPA_ConsignmentReserveOfficerCandidateCollection : TTObject.TTChildObjectCollection<PA_ConsignmentReserveOfficerCandidate>
        {
            public ChildPA_ConsignmentReserveOfficerCandidateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_ConsignmentReserveOfficerCandidateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// XXXXXXlik Şubesi
    /// </summary>
        public MilitaryOffice MilitaryOffice
        {
            get { return (MilitaryOffice)((ITTObject)this).GetParent("MILITARYOFFICE"); }
            set { this["MILITARYOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayeneye Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_CONSIGNMENTRESERVEOFFICERCANDIDATE", dataRow) { }
        protected PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_CONSIGNMENTRESERVEOFFICERCANDIDATE", dataRow, isImported) { }
        public PA_ConsignmentReserveOfficerCandidate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_ConsignmentReserveOfficerCandidate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_ConsignmentReserveOfficerCandidate() : base() { }

    }
}