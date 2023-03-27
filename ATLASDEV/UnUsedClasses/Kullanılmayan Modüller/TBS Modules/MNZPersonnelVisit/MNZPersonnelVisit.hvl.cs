
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZPersonnelVisit")] 

    /// <summary>
    /// Firma Personeli İzin Tarihleri
    /// </summary>
    public  partial class MNZPersonnelVisit : TTObject
    {
        public class MNZPersonnelVisitList : TTObjectCollection<MNZPersonnelVisit> { }
                    
        public class ChildMNZPersonnelVisitCollection : TTObject.TTChildObjectCollection<MNZPersonnelVisit>
        {
            public ChildMNZPersonnelVisitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZPersonnelVisitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ziyaret Günü
    /// </summary>
        public DateTime? VisitDate
        {
            get { return (DateTime?)this["VISITDATE"]; }
            set { this["VISITDATE"] = value; }
        }

    /// <summary>
    /// Giriş Saati
    /// </summary>
        public DateTime? EntranceTime
        {
            get { return (DateTime?)this["ENTRANCETIME"]; }
            set { this["ENTRANCETIME"] = value; }
        }

    /// <summary>
    /// Çıkış Saati
    /// </summary>
        public DateTime? ExitTime
        {
            get { return (DateTime?)this["EXITTIME"]; }
            set { this["EXITTIME"] = value; }
        }

    /// <summary>
    /// Kayıt Türü
    /// </summary>
        public string RecordType
        {
            get { return (string)this["RECORDTYPE"]; }
            set { this["RECORDTYPE"] = value; }
        }

    /// <summary>
    /// Fima Personeli İzin Tarihleri
    /// </summary>
        public MNZFirmPersonnel FirmPersonnel
        {
            get { return (MNZFirmPersonnel)((ITTObject)this).GetParent("FIRMPERSONNEL"); }
            set { this["FIRMPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZPersonnelVisit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZPersonnelVisit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZPersonnelVisit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZPersonnelVisit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZPersonnelVisit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZPERSONNELVISIT", dataRow) { }
        protected MNZPersonnelVisit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZPERSONNELVISIT", dataRow, isImported) { }
        public MNZPersonnelVisit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZPersonnelVisit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZPersonnelVisit() : base() { }

    }
}