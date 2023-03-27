
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteRecordDocAnimalDetail")] 

    public  partial class DeleteRecordDocAnimalDetail : BaseDeleteRecordDocumentDetail
    {
        public class DeleteRecordDocAnimalDetailList : TTObjectCollection<DeleteRecordDocAnimalDetail> { }
                    
        public class ChildDeleteRecordDocAnimalDetailCollection : TTObject.TTChildObjectCollection<DeleteRecordDocAnimalDetail>
        {
            public ChildDeleteRecordDocAnimalDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteRecordDocAnimalDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Türü
    /// </summary>
        public string Kind
        {
            get { return (string)this["KIND"]; }
            set { this["KIND"] = value; }
        }

    /// <summary>
    /// Irkı
    /// </summary>
        public string Specie
        {
            get { return (string)this["SPECIE"]; }
            set { this["SPECIE"] = value; }
        }

    /// <summary>
    /// Cinsiyeti
    /// </summary>
        public AnimalMaleFemaleEnum? Sex
        {
            get { return (AnimalMaleFemaleEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Taşınır Mal Nu.
    /// </summary>
        public string No
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Duty
        {
            get { return (string)this["DUTY"]; }
            set { this["DUTY"] = value; }
        }

    /// <summary>
    /// Eşkali
    /// </summary>
        public string View
        {
            get { return (string)this["VIEW"]; }
            set { this["VIEW"] = value; }
        }

        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETERECORDDOCANIMALDETAIL", dataRow) { }
        protected DeleteRecordDocAnimalDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETERECORDDOCANIMALDETAIL", dataRow, isImported) { }
        public DeleteRecordDocAnimalDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteRecordDocAnimalDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteRecordDocAnimalDetail() : base() { }

    }
}