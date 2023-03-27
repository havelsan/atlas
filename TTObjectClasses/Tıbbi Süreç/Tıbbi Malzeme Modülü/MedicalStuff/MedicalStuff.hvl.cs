
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuff")] 

    public  partial class MedicalStuff : TTObject
    {
        public class MedicalStuffList : TTObjectCollection<MedicalStuff> { }
                    
        public class ChildMedicalStuffCollection : TTObject.TTChildObjectCollection<MedicalStuff>
        {
            public ChildMedicalStuffCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string StuffDescription
        {
            get { return (string)this["STUFFDESCRIPTION"]; }
            set { this["STUFFDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? StuffAmount
        {
            get { return (int?)this["STUFFAMOUNT"]; }
            set { this["STUFFAMOUNT"] = value; }
        }

    /// <summary>
    /// Kullanım periyodu
    /// </summary>
        public string PeriodUnit
        {
            get { return (string)this["PERIODUNIT"]; }
            set { this["PERIODUNIT"] = value; }
        }

    /// <summary>
    /// Kullanım periyot birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// Odyometri Test Id
    /// </summary>
        public int? OdyometryTestId
        {
            get { return (int?)this["ODYOMETRYTESTID"]; }
            set { this["ODYOMETRYTESTID"] = value; }
        }

        public MedicalStuffPlaceOfUsage MedicalStuffPlaceOfUsage
        {
            get { return (MedicalStuffPlaceOfUsage)((ITTObject)this).GetParent("MEDICALSTUFFPLACEOFUSAGE"); }
            set { this["MEDICALSTUFFPLACEOFUSAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalStuffDefinition MedicalStuffDef
        {
            get { return (MedicalStuffDefinition)((ITTObject)this).GetParent("MEDICALSTUFFDEF"); }
            set { this["MEDICALSTUFFDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalStuffGroup MedicalStuffGroup
        {
            get { return (MedicalStuffGroup)((ITTObject)this).GetParent("MEDICALSTUFFGROUP"); }
            set { this["MEDICALSTUFFGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalStuffReport MedicalStuffReport
        {
            get { return (MedicalStuffReport)((ITTObject)this).GetParent("MEDICALSTUFFREPORT"); }
            set { this["MEDICALSTUFFREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalStuffPrescription MedicalStuffPrescription
        {
            get { return (MedicalStuffPrescription)((ITTObject)this).GetParent("MEDICALSTUFFPRESCRIPTION"); }
            set { this["MEDICALSTUFFPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalStuffUsageType MedicalStuffUsageType
        {
            get { return (MedicalStuffUsageType)((ITTObject)this).GetParent("MEDICALSTUFFUSAGETYPE"); }
            set { this["MEDICALSTUFFUSAGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalStuff(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuff(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuff(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuff(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuff(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFF", dataRow) { }
        protected MedicalStuff(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFF", dataRow, isImported) { }
        public MedicalStuff(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuff(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuff() : base() { }

    }
}