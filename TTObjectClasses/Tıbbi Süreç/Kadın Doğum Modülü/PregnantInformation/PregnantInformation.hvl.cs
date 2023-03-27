
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnantInformation")] 

    /// <summary>
    /// Önceki gebelikler ile ilgili sayısal verileri tutmak için oluşturuldu.
    /// </summary>
    public  partial class PregnantInformation : TTObject
    {
        public class PregnantInformationList : TTObjectCollection<PregnantInformation> { }
                    
        public class ChildPregnantInformationCollection : TTObject.TTChildObjectCollection<PregnantInformation>
        {
            public ChildPregnantInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnantInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kaçıncı gebelik
    /// </summary>
        public int? PregnancyNumber
        {
            get { return (int?)this["PREGNANCYNUMBER"]; }
            set { this["PREGNANCYNUMBER"] = value; }
        }

    /// <summary>
    /// Daha önceki doğum sayısı
    /// </summary>
        public int? Parity
        {
            get { return (int?)this["PARITY"]; }
            set { this["PARITY"] = value; }
        }

    /// <summary>
    /// Düşük Sayısı
    /// </summary>
        public int? Abortions
        {
            get { return (int?)this["ABORTIONS"]; }
            set { this["ABORTIONS"] = value; }
        }

        public int? DC
        {
            get { return (int?)this["DC"]; }
            set { this["DC"] = value; }
        }

        public int? UIEX
        {
            get { return (int?)this["UIEX"]; }
            set { this["UIEX"] = value; }
        }

    /// <summary>
    /// Yaşayan Çocuk Sayısı
    /// </summary>
        public int? NumberOfLivingChildren
        {
            get { return (int?)this["NUMBEROFLIVINGCHILDREN"]; }
            set { this["NUMBEROFLIVINGCHILDREN"] = value; }
        }

        virtual protected void CreateRegularObstetricCollection()
        {
            _RegularObstetric = new RegularObstetric.ChildRegularObstetricCollection(this, new Guid("95ff1a77-18ce-4028-b037-20f44305e127"));
            ((ITTChildObjectCollection)_RegularObstetric).GetChildren();
        }

        protected RegularObstetric.ChildRegularObstetricCollection _RegularObstetric = null;
    /// <summary>
    /// Child collection for Sayısal verileri tutar
    /// </summary>
        public RegularObstetric.ChildRegularObstetricCollection RegularObstetric
        {
            get
            {
                if (_RegularObstetric == null)
                    CreateRegularObstetricCollection();
                return _RegularObstetric;
            }
        }

        virtual protected void CreateWomanSpecialityObjectCollection()
        {
            _WomanSpecialityObject = new WomanSpecialityObject.ChildWomanSpecialityObjectCollection(this, new Guid("62a134a8-1a20-4b9c-9d60-983bf378a605"));
            ((ITTChildObjectCollection)_WomanSpecialityObject).GetChildren();
        }

        protected WomanSpecialityObject.ChildWomanSpecialityObjectCollection _WomanSpecialityObject = null;
    /// <summary>
    /// Child collection for Sayısal verileri tutar
    /// </summary>
        public WomanSpecialityObject.ChildWomanSpecialityObjectCollection WomanSpecialityObject
        {
            get
            {
                if (_WomanSpecialityObject == null)
                    CreateWomanSpecialityObjectCollection();
                return _WomanSpecialityObject;
            }
        }

        protected PregnantInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnantInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnantInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnantInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnantInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANTINFORMATION", dataRow) { }
        protected PregnantInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANTINFORMATION", dataRow, isImported) { }
        public PregnantInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnantInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnantInformation() : base() { }

    }
}