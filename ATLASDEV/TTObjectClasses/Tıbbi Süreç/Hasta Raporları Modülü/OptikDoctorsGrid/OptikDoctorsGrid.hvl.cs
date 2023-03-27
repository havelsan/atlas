
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OptikDoctorsGrid")] 

    public  partial class OptikDoctorsGrid : DoctorGrid
    {
        public class OptikDoctorsGridList : TTObjectCollection<OptikDoctorsGrid> { }
                    
        public class ChildOptikDoctorsGridCollection : TTObject.TTChildObjectCollection<OptikDoctorsGrid>
        {
            public ChildOptikDoctorsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOptikDoctorsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Medula Optik Doktor Onay Sonuç Kodu
    /// </summary>
        public string SonucKodu
        {
            get { return (string)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

    /// <summary>
    /// Medula Optik Doktor Onay Sonuç Mesajı
    /// </summary>
        public string SonucMesaji
        {
            get { return (string)this["SONUCMESAJI"]; }
            set { this["SONUCMESAJI"] = value; }
        }

    /// <summary>
    /// Medula Optik Doktor Onay Uyarı Mesajı
    /// </summary>
        public string UyariMesaji
        {
            get { return (string)this["UYARIMESAJI"]; }
            set { this["UYARIMESAJI"] = value; }
        }

    /// <summary>
    /// Onay Durumu
    /// </summary>
        public bool? IsApproved
        {
            get { return (bool?)this["ISAPPROVED"]; }
            set { this["ISAPPROVED"] = value; }
        }

        public MedulaOptikReport MedulaOptikReport
        {
            get { return (MedulaOptikReport)((ITTObject)this).GetParent("MEDULAOPTIKREPORT"); }
            set { this["MEDULAOPTIKREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OptikDoctorsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OptikDoctorsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OptikDoctorsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OptikDoctorsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OptikDoctorsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OPTIKDOCTORSGRID", dataRow) { }
        protected OptikDoctorsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OPTIKDOCTORSGRID", dataRow, isImported) { }
        public OptikDoctorsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OptikDoctorsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OptikDoctorsGrid() : base() { }

    }
}