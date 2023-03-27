
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseSurgeryAndManipulationProcedure")] 

    /// <summary>
    /// Ana Ameliyat ve Maniplasyon
    /// </summary>
    public  partial class BaseSurgeryAndManipulationProcedure : SubActionProcedure
    {
        public class BaseSurgeryAndManipulationProcedureList : TTObjectCollection<BaseSurgeryAndManipulationProcedure> { }
                    
        public class ChildBaseSurgeryAndManipulationProcedureCollection : TTObject.TTChildObjectCollection<BaseSurgeryAndManipulationProcedure>
        {
            public ChildBaseSurgeryAndManipulationProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseSurgeryAndManipulationProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Sut Puanı
    /// </summary>
        public double? SutPoint
        {
            get { return (double?)this["SUTPOINT"]; }
            set { this["SUTPOINT"] = value; }
        }

        public ResUser AnesteziDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTEZIDOKTOR"); }
            set { this["ANESTEZIDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan 2. Doktor
    /// </summary>
        public ResUser ProcedureDoctor2
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR2"); }
            set { this["PROCEDUREDOCTOR2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EuroScoreOfProcedure EuroScoreOfProcedure
        {
            get { return (EuroScoreOfProcedure)((ITTObject)this).GetParent("EUROSCOREOFPROCEDURE"); }
            set { this["EUROSCOREOFPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("afc962d2-9841-436f-a0d0-aad9a96bca71"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASESURGERYANDMANIPULATIONPROCEDURE", dataRow) { }
        protected BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASESURGERYANDMANIPULATIONPROCEDURE", dataRow, isImported) { }
        public BaseSurgeryAndManipulationProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseSurgeryAndManipulationProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseSurgeryAndManipulationProcedure() : base() { }

    }
}