
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingWoundedAssesment")] 

    public  partial class NursingWoundedAssesment : BaseNursingDataEntry
    {
        public class NursingWoundedAssesmentList : TTObjectCollection<NursingWoundedAssesment> { }
                    
        public class ChildNursingWoundedAssesmentCollection : TTObject.TTChildObjectCollection<NursingWoundedAssesment>
        {
            public ChildNursingWoundedAssesmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingWoundedAssesmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// En
    /// </summary>
        public double? Width
        {
            get { return (double?)this["WIDTH"]; }
            set { this["WIDTH"] = value; }
        }

    /// <summary>
    /// Yara Türü
    /// </summary>
        public WoundTypeEnum? WoundedType
        {
            get { return (WoundTypeEnum?)(int?)this["WOUNDEDTYPE"]; }
            set { this["WOUNDEDTYPE"] = value; }
        }

        public DateTime? OperationDate
        {
            get { return (DateTime?)this["OPERATIONDATE"]; }
            set { this["OPERATIONDATE"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Derinlik
    /// </summary>
        public double? Depth
        {
            get { return (double?)this["DEPTH"]; }
            set { this["DEPTH"] = value; }
        }

    /// <summary>
    /// Bası Yarası Oluşma Zamanı
    /// </summary>
        public PressureWoundTimeEnum? NursingWoundTime
        {
            get { return (PressureWoundTimeEnum?)(int?)this["NURSINGWOUNDTIME"]; }
            set { this["NURSINGWOUNDTIME"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public WoundStageDef WoundStage
        {
            get { return (WoundStageDef)((ITTObject)this).GetParent("WOUNDSTAGE"); }
            set { this["WOUNDSTAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public WoundLocalizationDef WoundLocalization
        {
            get { return (WoundLocalizationDef)((ITTObject)this).GetParent("WOUNDLOCALIZATION"); }
            set { this["WOUNDLOCALIZATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public WoundSideInfo WoundSide
        {
            get { return (WoundSideInfo)((ITTObject)this).GetParent("WOUNDSIDE"); }
            set { this["WOUNDSIDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWoundPhotosCollection()
        {
            _WoundPhotos = new WoundPhoto.ChildWoundPhotoCollection(this, new Guid("e1222f2d-0dc3-4f0f-ad78-bf18ea62a518"));
            ((ITTChildObjectCollection)_WoundPhotos).GetChildren();
        }

        protected WoundPhoto.ChildWoundPhotoCollection _WoundPhotos = null;
        public WoundPhoto.ChildWoundPhotoCollection WoundPhotos
        {
            get
            {
                if (_WoundPhotos == null)
                    CreateWoundPhotosCollection();
                return _WoundPhotos;
            }
        }

        protected NursingWoundedAssesment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingWoundedAssesment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingWoundedAssesment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingWoundedAssesment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingWoundedAssesment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGWOUNDEDASSESMENT", dataRow) { }
        protected NursingWoundedAssesment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGWOUNDEDASSESMENT", dataRow, isImported) { }
        public NursingWoundedAssesment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingWoundedAssesment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingWoundedAssesment() : base() { }

    }
}