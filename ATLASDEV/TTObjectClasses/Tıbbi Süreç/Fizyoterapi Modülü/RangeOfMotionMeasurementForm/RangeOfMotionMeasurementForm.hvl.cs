
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RangeOfMotionMeasurementForm")] 

    /// <summary>
    /// Eklem Hareket Açıklığı Ölçümü
    /// </summary>
    public  partial class RangeOfMotionMeasurementForm : BaseAdditionalInfo
    {
        public class RangeOfMotionMeasurementFormList : TTObjectCollection<RangeOfMotionMeasurementForm> { }
                    
        public class ChildRangeOfMotionMeasurementFormCollection : TTObject.TTChildObjectCollection<RangeOfMotionMeasurementForm>
        {
            public ChildRangeOfMotionMeasurementFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRangeOfMotionMeasurementFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ekstensiyon ? EHA
    /// </summary>
        public string ExtensionEHA
        {
            get { return (string)this["EXTENSIONEHA"]; }
            set { this["EXTENSIONEHA"] = value; }
        }

    /// <summary>
    /// Ekstensiyon ? Hareket Arkı Başında Kısıtlı
    /// </summary>
        public string ExtensionHABK
        {
            get { return (string)this["EXTENSIONHABK"]; }
            set { this["EXTENSIONHABK"] = value; }
        }

    /// <summary>
    /// Ekstensiyon ? Hareket Arkı Sonunda Kısıtlı
    /// </summary>
        public string ExtensionHASK
        {
            get { return (string)this["EXTENSIONHASK"]; }
            set { this["EXTENSIONHASK"] = value; }
        }

    /// <summary>
    /// Ekstensiyon ? Hareket Arkı Ortasında Kısıtlı
    /// </summary>
        public string ExtensionHAOK
        {
            get { return (string)this["EXTENSIONHAOK"]; }
            set { this["EXTENSIONHAOK"] = value; }
        }

    /// <summary>
    /// Fleksiyon ? EHA
    /// </summary>
        public string FlexionEHA
        {
            get { return (string)this["FLEXIONEHA"]; }
            set { this["FLEXIONEHA"] = value; }
        }

    /// <summary>
    /// Fleksiyon ? Hareket Arkı Başında Kısıtlı
    /// </summary>
        public string FlexionHABK
        {
            get { return (string)this["FLEXIONHABK"]; }
            set { this["FLEXIONHABK"] = value; }
        }

    /// <summary>
    /// Fleksiyon ? Hareket Arkı Ortasında Kısıtlı
    /// </summary>
        public string FlexionHAOK
        {
            get { return (string)this["FLEXIONHAOK"]; }
            set { this["FLEXIONHAOK"] = value; }
        }

    /// <summary>
    /// Fleksiyon ? Hareket Arkı Sonunda Kısıtlı
    /// </summary>
        public string FlexionHASK
        {
            get { return (string)this["FLEXIONHASK"]; }
            set { this["FLEXIONHASK"] = value; }
        }

    /// <summary>
    /// Abduksiyon - EHA
    /// </summary>
        public string AbductionEHA
        {
            get { return (string)this["ABDUCTIONEHA"]; }
            set { this["ABDUCTIONEHA"] = value; }
        }

    /// <summary>
    /// Abduksiyon ? Hareket Arkı Başında Kısıtlı
    /// </summary>
        public string AbductionHABK
        {
            get { return (string)this["ABDUCTIONHABK"]; }
            set { this["ABDUCTIONHABK"] = value; }
        }

    /// <summary>
    /// Abduksiyon ? Hareket Arkı Ortasında Kısıtlı
    /// </summary>
        public string AbductionHAOK
        {
            get { return (string)this["ABDUCTIONHAOK"]; }
            set { this["ABDUCTIONHAOK"] = value; }
        }

    /// <summary>
    /// Abduksiyon ? Hareket Arkı Sonunda Kısıtlı
    /// </summary>
        public string AbductionHASK
        {
            get { return (string)this["ABDUCTIONHASK"]; }
            set { this["ABDUCTIONHASK"] = value; }
        }

    /// <summary>
    /// Rotasyon ? EHA
    /// </summary>
        public string RotationEHA
        {
            get { return (string)this["ROTATIONEHA"]; }
            set { this["ROTATIONEHA"] = value; }
        }

    /// <summary>
    /// Rotasyon ? Hareket Arkı Başında Kısıtlı
    /// </summary>
        public string RotationHABK
        {
            get { return (string)this["ROTATIONHABK"]; }
            set { this["ROTATIONHABK"] = value; }
        }

    /// <summary>
    /// Rotasyon ? Hareket Arkı Ortasında Kısıtlı
    /// </summary>
        public string RotationHAOK
        {
            get { return (string)this["ROTATIONHAOK"]; }
            set { this["ROTATIONHAOK"] = value; }
        }

    /// <summary>
    /// Rotasyon ? Hareket Arkı Sonunda Kısıtlı
    /// </summary>
        public string RotationHASK
        {
            get { return (string)this["ROTATIONHASK"]; }
            set { this["ROTATIONHASK"] = value; }
        }

        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RANGEOFMOTIONMEASUREMENTFORM", dataRow) { }
        protected RangeOfMotionMeasurementForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RANGEOFMOTIONMEASUREMENTFORM", dataRow, isImported) { }
        public RangeOfMotionMeasurementForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RangeOfMotionMeasurementForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RangeOfMotionMeasurementForm() : base() { }

    }
}