
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentCarrier")] 

    public  partial class AppointmentCarrier : TTObject
    {
        public class AppointmentCarrierList : TTObjectCollection<AppointmentCarrier> { }
                    
        public class ChildAppointmentCarrierCollection : TTObject.TTChildObjectCollection<AppointmentCarrier>
        {
            public ChildAppointmentCarrierCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentCarrierCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Alt Kaynak Başlığı
    /// </summary>
        public string SubResourceCaption
        {
            get { return (string)this["SUBRESOURCECAPTION"]; }
            set { this["SUBRESOURCECAPTION"] = value; }
        }

    /// <summary>
    /// Alt Kaynak Tipi
    /// </summary>
        public string SubResource
        {
            get { return (string)this["SUBRESOURCE"]; }
            set { this["SUBRESOURCE"] = value; }
        }

    /// <summary>
    /// Randevu Tipi
    /// </summary>
        public AppointmentTypeEnum? AppointmentType
        {
            get { return (AppointmentTypeEnum?)(int?)this["APPOINTMENTTYPE"]; }
            set { this["APPOINTMENTTYPE"] = value; }
        }

    /// <summary>
    /// İlişki Adı (Parent)
    /// </summary>
        public string RelationParentName
        {
            get { return (string)this["RELATIONPARENTNAME"]; }
            set { this["RELATIONPARENTNAME"] = value; }
        }

    /// <summary>
    /// Default
    /// </summary>
        public bool? IsDefault
        {
            get { return (bool?)this["ISDEFAULT"]; }
            set { this["ISDEFAULT"] = value; }
        }

    /// <summary>
    /// Randevu Sayısı
    /// </summary>
        public int? AppointmentCount
        {
            get { return (int?)this["APPOINTMENTCOUNT"]; }
            set { this["APPOINTMENTCOUNT"] = value; }
        }

    /// <summary>
    /// Ana Kaynak Başlığı
    /// </summary>
        public string MasterResourceCaption
        {
            get { return (string)this["MASTERRESOURCECAPTION"]; }
            set { this["MASTERRESOURCECAPTION"] = value; }
        }

    /// <summary>
    /// Alt Randevu Adı
    /// </summary>
        public string CarrierName
        {
            get { return (string)this["CARRIERNAME"]; }
            set { this["CARRIERNAME"] = value; }
        }

    /// <summary>
    /// Randevu Süresi
    /// </summary>
        public int? AppointmentDuration
        {
            get { return (int?)this["APPOINTMENTDURATION"]; }
            set { this["APPOINTMENTDURATION"] = value; }
        }

    /// <summary>
    /// Ana Kaynak Tipi
    /// </summary>
        public string MasterResource
        {
            get { return (string)this["MASTERRESOURCE"]; }
            set { this["MASTERRESOURCE"] = value; }
        }

    /// <summary>
    /// Ana Kaynak Filtresi
    /// </summary>
        public string MasterResourceFilter
        {
            get { return (string)this["MASTERRESOURCEFILTER"]; }
            set { this["MASTERRESOURCEFILTER"] = value; }
        }

        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAppointmentTypesCollection()
        {
            _AppointmentTypes = new AppointmentType.ChildAppointmentTypeCollection(this, new Guid("b82ddf67-a9a4-4770-a2c5-140e466bad9f"));
            ((ITTChildObjectCollection)_AppointmentTypes).GetChildren();
        }

        protected AppointmentType.ChildAppointmentTypeCollection _AppointmentTypes = null;
    /// <summary>
    /// Child collection for Randevu Türü
    /// </summary>
        public AppointmentType.ChildAppointmentTypeCollection AppointmentTypes
        {
            get
            {
                if (_AppointmentTypes == null)
                    CreateAppointmentTypesCollection();
                return _AppointmentTypes;
            }
        }

        virtual protected void CreateAppointmentCarrierUserTypesCollection()
        {
            _AppointmentCarrierUserTypes = new AppointmentCarrierUserTypes.ChildAppointmentCarrierUserTypesCollection(this, new Guid("7ca668f5-277d-4c24-83e1-c3bf34711888"));
            ((ITTChildObjectCollection)_AppointmentCarrierUserTypes).GetChildren();
        }

        protected AppointmentCarrierUserTypes.ChildAppointmentCarrierUserTypesCollection _AppointmentCarrierUserTypes = null;
        public AppointmentCarrierUserTypes.ChildAppointmentCarrierUserTypesCollection AppointmentCarrierUserTypes
        {
            get
            {
                if (_AppointmentCarrierUserTypes == null)
                    CreateAppointmentCarrierUserTypesCollection();
                return _AppointmentCarrierUserTypes;
            }
        }

        protected AppointmentCarrier(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentCarrier(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentCarrier(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentCarrier(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentCarrier(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTCARRIER", dataRow) { }
        protected AppointmentCarrier(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTCARRIER", dataRow, isImported) { }
        public AppointmentCarrier(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentCarrier(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentCarrier() : base() { }

    }
}