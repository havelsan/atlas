
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PostpartumFollowUp")] 

    /// <summary>
    /// Lohusa İzlem
    /// </summary>
    public  partial class PostpartumFollowUp : TTObject
    {
        public class PostpartumFollowUpList : TTObjectCollection<PostpartumFollowUp> { }
                    
        public class ChildPostpartumFollowUpCollection : TTObject.TTChildObjectCollection<PostpartumFollowUp>
        {
            public ChildPostpartumFollowUpCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPostpartumFollowUpCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public double? Hemoglobin
        {
            get { return (double?)this["HEMOGLOBIN"]; }
            set { this["HEMOGLOBIN"] = value; }
        }

    /// <summary>
    /// Gebelik Sonlanma Tarihi
    /// </summary>
        public DateTime? PregnancyDueDate
        {
            get { return (DateTime?)this["PREGNANCYDUEDATE"]; }
            set { this["PREGNANCYDUEDATE"] = value; }
        }

    /// <summary>
    /// Bilgi Alınan Kişi
    /// </summary>
        public string InformerName
        {
            get { return (string)this["INFORMERNAME"]; }
            set { this["INFORMERNAME"] = value; }
        }

    /// <summary>
    /// Bilgi Alınan Kişi Telefon No
    /// </summary>
        public string InformerPhone
        {
            get { return (string)this["INFORMERPHONE"]; }
            set { this["INFORMERPHONE"] = value; }
        }

    /// <summary>
    /// Konjenital Anomali Varlığı
    /// </summary>
        public SKRSKonjenitalAnomaliliDogumVarligi CongenitalAnomalies
        {
            get { return (SKRSKonjenitalAnomaliliDogumVarligi)((ITTObject)this).GetParent("CONGENITALANOMALIES"); }
            set { this["CONGENITALANOMALIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaçıncı Lohusa Izlem
    /// </summary>
        public SKRSKacinciLohusaIzlem WhichPostpartumFollowUp
        {
            get { return (SKRSKacinciLohusaIzlem)((ITTObject)this).GetParent("WHICHPOSTPARTUMFOLLOWUP"); }
            set { this["WHICHPOSTPARTUMFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Demir Lojistiği ve Desteği
    /// </summary>
        public SKRSDemirLojistigiveDestegi IronLogisticsAndSupplement
        {
            get { return (SKRSDemirLojistigiveDestegi)((ITTObject)this).GetParent("IRONLOGISTICSANDSUPPLEMENT"); }
            set { this["IRONLOGISTICSANDSUPPLEMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// D Vitamini Lojistiği ve Desteği
    /// </summary>
        public SKRSDVitaminiLojistigiveDestegi VitaminDSupplements
        {
            get { return (SKRSDVitaminiLojistigiveDestegi)((ITTObject)this).GetParent("VITAMINDSUPPLEMENTS"); }
            set { this["VITAMINDSUPPLEMENTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum Sonrası Depresyonu
    /// </summary>
        public SKRSPostpartumDepresyon PostpartumDepression
        {
            get { return (SKRSPostpartumDepresyon)((ITTObject)this).GetParent("POSTPARTUMDEPRESSION"); }
            set { this["POSTPARTUMDEPRESSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Uterus Involusyonu
    /// </summary>
        public SKRSUterusInvolusyon UterusInvolution
        {
            get { return (SKRSUterusInvolusyon)((ITTObject)this).GetParent("UTERUSINVOLUTION"); }
            set { this["UTERUSINVOLUTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateComplicationDiagnosisCollection()
        {
            _ComplicationDiagnosis = new ComplicationDiagnosis.ChildComplicationDiagnosisCollection(this, new Guid("3a8062b4-30b6-499d-8db1-9d7aec50b356"));
            ((ITTChildObjectCollection)_ComplicationDiagnosis).GetChildren();
        }

        protected ComplicationDiagnosis.ChildComplicationDiagnosisCollection _ComplicationDiagnosis = null;
        public ComplicationDiagnosis.ChildComplicationDiagnosisCollection ComplicationDiagnosis
        {
            get
            {
                if (_ComplicationDiagnosis == null)
                    CreateComplicationDiagnosisCollection();
                return _ComplicationDiagnosis;
            }
        }

        virtual protected void CreateDangerSignsCollection()
        {
            _DangerSigns = new PostpartumDangerSigns.ChildPostpartumDangerSignsCollection(this, new Guid("98f6072b-d4d6-41a9-b9af-99bb5cc093ec"));
            ((ITTChildObjectCollection)_DangerSigns).GetChildren();
        }

        protected PostpartumDangerSigns.ChildPostpartumDangerSignsCollection _DangerSigns = null;
        public PostpartumDangerSigns.ChildPostpartumDangerSignsCollection DangerSigns
        {
            get
            {
                if (_DangerSigns == null)
                    CreateDangerSignsCollection();
                return _DangerSigns;
            }
        }

        virtual protected void CreateWomanHealthOperationsCollection()
        {
            _WomanHealthOperations = new WomanHealthOperations.ChildWomanHealthOperationsCollection(this, new Guid("4e6c589d-11e2-441e-ae2a-a2d560545e35"));
            ((ITTChildObjectCollection)_WomanHealthOperations).GetChildren();
        }

        protected WomanHealthOperations.ChildWomanHealthOperationsCollection _WomanHealthOperations = null;
        public WomanHealthOperations.ChildWomanHealthOperationsCollection WomanHealthOperations
        {
            get
            {
                if (_WomanHealthOperations == null)
                    CreateWomanHealthOperationsCollection();
                return _WomanHealthOperations;
            }
        }

        virtual protected void CreateWomanSpecialityObjectCollection()
        {
            _WomanSpecialityObject = new WomanSpecialityObject.ChildWomanSpecialityObjectCollection(this, new Guid("68b15df0-2e50-4800-8397-f0412c1a8362"));
            ((ITTChildObjectCollection)_WomanSpecialityObject).GetChildren();
        }

        protected WomanSpecialityObject.ChildWomanSpecialityObjectCollection _WomanSpecialityObject = null;
        public WomanSpecialityObject.ChildWomanSpecialityObjectCollection WomanSpecialityObject
        {
            get
            {
                if (_WomanSpecialityObject == null)
                    CreateWomanSpecialityObjectCollection();
                return _WomanSpecialityObject;
            }
        }

        protected PostpartumFollowUp(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PostpartumFollowUp(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PostpartumFollowUp(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PostpartumFollowUp(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PostpartumFollowUp(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "POSTPARTUMFOLLOWUP", dataRow) { }
        protected PostpartumFollowUp(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "POSTPARTUMFOLLOWUP", dataRow, isImported) { }
        public PostpartumFollowUp(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PostpartumFollowUp(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PostpartumFollowUp() : base() { }

    }
}