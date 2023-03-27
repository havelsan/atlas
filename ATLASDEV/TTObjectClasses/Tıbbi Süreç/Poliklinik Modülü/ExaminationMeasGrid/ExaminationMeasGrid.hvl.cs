
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationMeasGrid")] 

    /// <summary>
    /// Muayene Ölçümleri
    /// </summary>
    public  partial class ExaminationMeasGrid : TTObject
    {
        public class ExaminationMeasGridList : TTObjectCollection<ExaminationMeasGrid> { }
                    
        public class ChildExaminationMeasGridCollection : TTObject.TTChildObjectCollection<ExaminationMeasGrid>
        {
            public ChildExaminationMeasGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationMeasGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Baş Çevresi
    /// </summary>
        public double? HeadCircumference
        {
            get { return (double?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Göğüs Çevresi
    /// </summary>
        public double? ChestCircumference
        {
            get { return (double?)this["CHESTCIRCUMFERENCE"]; }
            set { this["CHESTCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Heigth
        {
            get { return (double?)this["HEIGTH"]; }
            set { this["HEIGTH"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Ölçüm Tarihi
    /// </summary>
        public DateTime? MeasDate
        {
            get { return (DateTime?)this["MEASDATE"]; }
            set { this["MEASDATE"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubactionProcedureFlowable SubactionProcedure
        {
            get { return (SubactionProcedureFlowable)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationMeasGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationMeasGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationMeasGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationMeasGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationMeasGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONMEASGRID", dataRow) { }
        protected ExaminationMeasGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONMEASGRID", dataRow, isImported) { }
        public ExaminationMeasGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationMeasGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationMeasGrid() : base() { }

    }
}