
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Phototherapy")] 

    public  partial class Phototherapy : BaseMultipleDataEntry
    {
        public class PhototherapyList : TTObjectCollection<Phototherapy> { }
                    
        public class ChildPhototherapyCollection : TTObject.TTChildObjectCollection<Phototherapy>
        {
            public ChildPhototherapyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhototherapyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fototerapinin Uygulandığı Tarih
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Fototerapi Uygulamasının Başladığı Saat
    /// </summary>
        public DateTime? ProcessStartTime
        {
            get { return (DateTime?)this["PROCESSSTARTTIME"]; }
            set { this["PROCESSSTARTTIME"] = value; }
        }

    /// <summary>
    /// Fototerapi Uygulamasının Bittiği Saat
    /// </summary>
        public DateTime? ProcessEndTime
        {
            get { return (DateTime?)this["PROCESSENDTIME"]; }
            set { this["PROCESSENDTIME"] = value; }
        }

    /// <summary>
    /// Komplikasyon Mevcut 
    /// </summary>
        public bool? Complication
        {
            get { return (bool?)this["COMPLICATION"]; }
            set { this["COMPLICATION"] = value; }
        }

        public PhototherapyDefinition PhototherapyDefinition
        {
            get { return (PhototherapyDefinition)((ITTObject)this).GetParent("PHOTOTHERAPYDEFINITION"); }
            set { this["PHOTOTHERAPYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser RequesterPerson
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERPERSON"); }
            set { this["REQUESTERPERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysicianApplication PhysicianApplication
        {
            get 
            {   
                if (EpisodeAction is PhysicianApplication)
                    return (PhysicianApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected Phototherapy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Phototherapy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Phototherapy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Phototherapy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Phototherapy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHOTOTHERAPY", dataRow) { }
        protected Phototherapy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHOTOTHERAPY", dataRow, isImported) { }
        public Phototherapy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Phototherapy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Phototherapy() : base() { }

    }
}