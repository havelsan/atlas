
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NumberOfCopiesGrid")] 

    /// <summary>
    /// Ayaktan Kopya Sayıları
    /// </summary>
    public  partial class NumberOfCopiesGrid : TerminologyManagerDef
    {
        public class NumberOfCopiesGridList : TTObjectCollection<NumberOfCopiesGrid> { }
                    
        public class ChildNumberOfCopiesGridCollection : TTObject.TTChildObjectCollection<NumberOfCopiesGrid>
        {
            public ChildNumberOfCopiesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNumberOfCopiesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Saymanlık
    /// </summary>
        public int? ToAccountingOffice
        {
            get { return (int?)this["TOACCOUNTINGOFFICE"]; }
            set { this["TOACCOUNTINGOFFICE"] = value; }
        }

    /// <summary>
    /// XXXXXXlik Şubesi
    /// </summary>
        public int? ToMilitaryOffice
        {
            get { return (int?)this["TOMILITARYOFFICE"]; }
            set { this["TOMILITARYOFFICE"] = value; }
        }

    /// <summary>
    /// XXXXXX varsa diğerlerini dökme
    /// </summary>
        public bool? NotPrintOthersIfHospExists
        {
            get { return (bool?)this["NOTPRINTOTHERSIFHOSPEXISTS"]; }
            set { this["NOTPRINTOTHERSIFHOSPEXISTS"] = value; }
        }

    /// <summary>
    /// Birlik ile makam aynı ise dökme
    /// </summary>
        public bool? NotPrintIfMilUnitEqualSendCh
        {
            get { return (bool?)this["NOTPRINTIFMILUNITEQUALSENDCH"]; }
            set { this["NOTPRINTIFMILUNITEQUALSENDCH"] = value; }
        }

    /// <summary>
    /// Hasta Dosyası
    /// </summary>
        public int? ToPatientFolder
        {
            get { return (int?)this["TOPATIENTFOLDER"]; }
            set { this["TOPATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Otomatik Döküm
    /// </summary>
        public bool? AutoPrint
        {
            get { return (bool?)this["AUTOPRINT"]; }
            set { this["AUTOPRINT"] = value; }
        }

    /// <summary>
    /// Gidecek XXXXXX
    /// </summary>
        public int? ToHospitalSendingTo
        {
            get { return (int?)this["TOHOSPITALSENDINGTO"]; }
            set { this["TOHOSPITALSENDINGTO"] = value; }
        }

    /// <summary>
    /// Levazım Şube Müdürlüğü
    /// </summary>
        public int? ToSupplierUnit
        {
            get { return (int?)this["TOSUPPLIERUNIT"]; }
            set { this["TOSUPPLIERUNIT"] = value; }
        }

    /// <summary>
    /// Muayeneye Gönderen Makam
    /// </summary>
        public int? ToExaminationSenderUnit
        {
            get { return (int?)this["TOEXAMINATIONSENDERUNIT"]; }
            set { this["TOEXAMINATIONSENDERUNIT"] = value; }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public int? ToMilitaryUnit
        {
            get { return (int?)this["TOMILITARYUNIT"]; }
            set { this["TOMILITARYUNIT"] = value; }
        }

    /// <summary>
    /// XXXXXX Varsa Dosya Dök
    /// </summary>
        public bool? PrintFileIfHospitalExists
        {
            get { return (bool?)this["PRINTFILEIFHOSPITALEXISTS"]; }
            set { this["PRINTFILEIFHOSPITALEXISTS"] = value; }
        }

    /// <summary>
    /// TreatmentDischargeNumberOfCopiesOutpatientNumberOfCopies
    /// </summary>
        public TreatmentDischargeByPatientGroupDefinition TreatmentDisNumberOfCopiesDef
        {
            get { return (TreatmentDischargeByPatientGroupDefinition)((ITTObject)this).GetParent("TREATMENTDISNUMBEROFCOPIESDEF"); }
            set { this["TREATMENTDISNUMBEROFCOPIESDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUMBEROFCOPIESGRID", dataRow) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUMBEROFCOPIESGRID", dataRow, isImported) { }
        protected NumberOfCopiesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NumberOfCopiesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NumberOfCopiesGrid() : base() { }

    }
}