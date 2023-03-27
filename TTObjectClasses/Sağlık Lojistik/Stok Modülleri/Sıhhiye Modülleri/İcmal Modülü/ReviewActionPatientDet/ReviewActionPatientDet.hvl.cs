
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReviewActionPatientDet")] 

    public  partial class ReviewActionPatientDet : TTObject
    {
        public class ReviewActionPatientDetList : TTObjectCollection<ReviewActionPatientDet> { }
                    
        public class ChildReviewActionPatientDetCollection : TTObject.TTChildObjectCollection<ReviewActionPatientDet>
        {
            public ChildReviewActionPatientDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReviewActionPatientDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bölüm
    /// </summary>
        public string Clinic
        {
            get { return (string)this["CLINIC"]; }
            set { this["CLINIC"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string Patient
        {
            get { return (string)this["PATIENT"]; }
            set { this["PATIENT"] = value; }
        }

    /// <summary>
    /// T.C. Kimlik No
    /// </summary>
        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public string MaterialName
        {
            get { return (string)this["MATERIALNAME"]; }
            set { this["MATERIALNAME"] = value; }
        }

    /// <summary>
    /// PatientObjID
    /// </summary>
        public Guid? PatientObjID
        {
            get { return (Guid?)this["PATIENTOBJID"]; }
            set { this["PATIENTOBJID"] = value; }
        }

    /// <summary>
    /// MaterialObjID
    /// </summary>
        public Guid? MaterialObjID
        {
            get { return (Guid?)this["MATERIALOBJID"]; }
            set { this["MATERIALOBJID"] = value; }
        }

        public ReviewAction ReviewAction
        {
            get { return (ReviewAction)((ITTObject)this).GetParent("REVIEWACTION"); }
            set { this["REVIEWACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReviewActionPatientDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReviewActionPatientDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReviewActionPatientDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReviewActionPatientDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReviewActionPatientDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REVIEWACTIONPATIENTDET", dataRow) { }
        protected ReviewActionPatientDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REVIEWACTIONPATIENTDET", dataRow, isImported) { }
        public ReviewActionPatientDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReviewActionPatientDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReviewActionPatientDet() : base() { }

    }
}