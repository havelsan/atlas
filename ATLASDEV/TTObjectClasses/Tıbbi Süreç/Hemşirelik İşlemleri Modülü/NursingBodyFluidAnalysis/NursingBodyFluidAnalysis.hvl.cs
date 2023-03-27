
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingBodyFluidAnalysis")] 

    /// <summary>
    /// Sıvı Giriş Çıkış Takibi
    /// </summary>
    public  partial class NursingBodyFluidAnalysis : BaseNursingDataEntry
    {
        public class NursingBodyFluidAnalysisList : TTObjectCollection<NursingBodyFluidAnalysis> { }
                    
        public class ChildNursingBodyFluidAnalysisCollection : TTObject.TTChildObjectCollection<NursingBodyFluidAnalysis>
        {
            public ChildNursingBodyFluidAnalysisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingBodyFluidAnalysisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Toplam Oral
    /// </summary>
        public double? TotalOralIntake
        {
            get { return (double?)this["TOTALORALINTAKE"]; }
            set { this["TOTALORALINTAKE"] = value; }
        }

    /// <summary>
    /// Toplam NGC
    /// </summary>
        public double? TotalNGC
        {
            get { return (double?)this["TOTALNGC"]; }
            set { this["TOTALNGC"] = value; }
        }

    /// <summary>
    /// Toplam Damar İçi Sıvılar
    /// </summary>
        public double? TotalVenousFluid
        {
            get { return (double?)this["TOTALVENOUSFLUID"]; }
            set { this["TOTALVENOUSFLUID"] = value; }
        }

    /// <summary>
    /// Toplam İlaçlar
    /// </summary>
        public double? TotalMed
        {
            get { return (double?)this["TOTALMED"]; }
            set { this["TOTALMED"] = value; }
        }

    /// <summary>
    /// Toplam Verilen Kan
    /// </summary>
        public double? TotalSuppliedBlood
        {
            get { return (double?)this["TOTALSUPPLIEDBLOOD"]; }
            set { this["TOTALSUPPLIEDBLOOD"] = value; }
        }

    /// <summary>
    /// Toplam İrigasyon
    /// </summary>
        public double? TotalIrrigation
        {
            get { return (double?)this["TOTALIRRIGATION"]; }
            set { this["TOTALIRRIGATION"] = value; }
        }

    /// <summary>
    /// Toplam Süt Miktarı
    /// </summary>
        public double? TotalMilkAmount
        {
            get { return (double?)this["TOTALMILKAMOUNT"]; }
            set { this["TOTALMILKAMOUNT"] = value; }
        }

    /// <summary>
    /// Tortu
    /// </summary>
        public double? TotalSludge
        {
            get { return (double?)this["TOTALSLUDGE"]; }
            set { this["TOTALSLUDGE"] = value; }
        }

    /// <summary>
    /// Toplam PAC
    /// </summary>
        public double? Total_PAC
        {
            get { return (double?)this["TOTAL PAC"]; }
            set { this["TOTAL PAC"] = value; }
        }

    /// <summary>
    /// Toplam Alınan Diğer Sıvılar
    /// </summary>
        public double? TotalOtherBodilyFluidsTaken
        {
            get { return (double?)this["TOTALOTHERBODILYFLUIDSTAKEN"]; }
            set { this["TOTALOTHERBODILYFLUIDSTAKEN"] = value; }
        }

    /// <summary>
    /// Toplam İdrar
    /// </summary>
        public double? TotalUrine
        {
            get { return (double?)this["TOTALURINE"]; }
            set { this["TOTALURINE"] = value; }
        }

    /// <summary>
    /// Toplam Aspirasyon
    /// </summary>
        public double? TotalAspiration
        {
            get { return (double?)this["TOTALASPIRATION"]; }
            set { this["TOTALASPIRATION"] = value; }
        }

    /// <summary>
    /// Toplam Kusma
    /// </summary>
        public double? TotalVomit
        {
            get { return (double?)this["TOTALVOMIT"]; }
            set { this["TOTALVOMIT"] = value; }
        }

    /// <summary>
    /// Toplam Drenaj
    /// </summary>
        public double? TotalDrainage
        {
            get { return (double?)this["TOTALDRAINAGE"]; }
            set { this["TOTALDRAINAGE"] = value; }
        }

    /// <summary>
    /// Toplam Dışkı
    /// </summary>
        public double? TotalStool
        {
            get { return (double?)this["TOTALSTOOL"]; }
            set { this["TOTALSTOOL"] = value; }
        }

    /// <summary>
    /// Toplam Kaybedilen Kan
    /// </summary>
        public double? TotalBloodLoss
        {
            get { return (double?)this["TOTALBLOODLOSS"]; }
            set { this["TOTALBLOODLOSS"] = value; }
        }

    /// <summary>
    /// Toplam Diğer Kaybedilen Sıvılar
    /// </summary>
        public double? TotalOtherBodilyFluidLoss
        {
            get { return (double?)this["TOTALOTHERBODILYFLUIDLOSS"]; }
            set { this["TOTALOTHERBODILYFLUIDLOSS"] = value; }
        }

        virtual protected void CreateFluidIntakeOutputGridsCollection()
        {
            _FluidIntakeOutputGrids = new NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection(this, new Guid("ed5c15aa-9924-47ee-a520-80de368c90e6"));
            ((ITTChildObjectCollection)_FluidIntakeOutputGrids).GetChildren();
        }

        protected NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection _FluidIntakeOutputGrids = null;
        public NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection FluidIntakeOutputGrids
        {
            get
            {
                if (_FluidIntakeOutputGrids == null)
                    CreateFluidIntakeOutputGridsCollection();
                return _FluidIntakeOutputGrids;
            }
        }

        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGBODYFLUIDANALYSIS", dataRow) { }
        protected NursingBodyFluidAnalysis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGBODYFLUIDANALYSIS", dataRow, isImported) { }
        public NursingBodyFluidAnalysis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingBodyFluidAnalysis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingBodyFluidAnalysis() : base() { }

    }
}