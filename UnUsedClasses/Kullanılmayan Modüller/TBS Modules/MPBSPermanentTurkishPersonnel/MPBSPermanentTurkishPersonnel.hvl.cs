
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSPermanentTurkishPersonnel")] 

    public  partial class MPBSPermanentTurkishPersonnel : MPBSTurkishPersonnel
    {
        public class MPBSPermanentTurkishPersonnelList : TTObjectCollection<MPBSPermanentTurkishPersonnel> { }
                    
        public class ChildMPBSPermanentTurkishPersonnelCollection : TTObject.TTChildObjectCollection<MPBSPermanentTurkishPersonnel>
        {
            public ChildMPBSPermanentTurkishPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSPermanentTurkishPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string RetirementFundRegistryNo
        {
            get { return (string)this["RETIREMENTFUNDREGISTRYNO"]; }
            set { this["RETIREMENTFUNDREGISTRYNO"] = value; }
        }

    /// <summary>
    /// Sicil No
    /// </summary>
        public string RegistryNumber
        {
            get { return (string)this["REGISTRYNUMBER"]; }
            set { this["REGISTRYNUMBER"] = value; }
        }

    /// <summary>
    /// Künye Defter No
    /// </summary>
        public string PersonalRecordNo
        {
            get { return (string)this["PERSONALRECORDNO"]; }
            set { this["PERSONALRECORDNO"] = value; }
        }

    /// <summary>
    /// Oyak No
    /// </summary>
        public string OyakNo
        {
            get { return (string)this["OYAKNO"]; }
            set { this["OYAKNO"] = value; }
        }

    /// <summary>
    /// Ayrılış Lojman Puanı
    /// </summary>
        public int? DepartureApartmentServPoint
        {
            get { return (int?)this["DEPARTUREAPARTMENTSERVPOINT"]; }
            set { this["DEPARTUREAPARTMENTSERVPOINT"] = value; }
        }

    /// <summary>
    /// Kızlık Soyadı
    /// </summary>
        public string MaidenSurname
        {
            get { return (string)this["MAIDENSURNAME"]; }
            set { this["MAIDENSURNAME"] = value; }
        }

    /// <summary>
    /// Toplam Lojman Puanı
    /// </summary>
        public int? TotalApartmentServPoint
        {
            get { return (int?)this["TOTALAPARTMENTSERVPOINT"]; }
            set { this["TOTALAPARTMENTSERVPOINT"] = value; }
        }

    /// <summary>
    /// Kişisel Kayıt Tarihi
    /// </summary>
        public DateTime? PersonalRecordDate
        {
            get { return (DateTime?)this["PERSONALRECORDDATE"]; }
            set { this["PERSONALRECORDDATE"] = value; }
        }

    /// <summary>
    /// Atama No
    /// </summary>
        public string AppointmentNo
        {
            get { return (string)this["APPOINTMENTNO"]; }
            set { this["APPOINTMENTNO"] = value; }
        }

        virtual protected void CreateMilitaryPersonnelRanksCollection()
        {
            _MilitaryPersonnelRanks = new MPBSMilitaryPersonnelRank.ChildMPBSMilitaryPersonnelRankCollection(this, new Guid("32af95c3-d33f-44ed-8b67-0516d96e4876"));
            ((ITTChildObjectCollection)_MilitaryPersonnelRanks).GetChildren();
        }

        protected MPBSMilitaryPersonnelRank.ChildMPBSMilitaryPersonnelRankCollection _MilitaryPersonnelRanks = null;
    /// <summary>
    /// Child collection for Alınan Rütbeler
    /// </summary>
        public MPBSMilitaryPersonnelRank.ChildMPBSMilitaryPersonnelRankCollection MilitaryPersonnelRanks
        {
            get
            {
                if (_MilitaryPersonnelRanks == null)
                    CreateMilitaryPersonnelRanksCollection();
                return _MilitaryPersonnelRanks;
            }
        }

        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPERMANENTTURKISHPERSONNEL", dataRow) { }
        protected MPBSPermanentTurkishPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPERMANENTTURKISHPERSONNEL", dataRow, isImported) { }
        public MPBSPermanentTurkishPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSPermanentTurkishPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSPermanentTurkishPersonnel() : base() { }

    }
}