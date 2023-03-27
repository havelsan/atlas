
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSPermanentTurkishMilitaryPersonnel")] 

    /// <summary>
    /// Sürekli Türk XXXXXX Personel
    /// </summary>
    public  partial class MPBSPermanentTurkishMilitaryPersonnel : MPBSPermanentTurkishPersonnel
    {
        public class MPBSPermanentTurkishMilitaryPersonnelList : TTObjectCollection<MPBSPermanentTurkishMilitaryPersonnel> { }
                    
        public class ChildMPBSPermanentTurkishMilitaryPersonnelCollection : TTObject.TTChildObjectCollection<MPBSPermanentTurkishMilitaryPersonnel>
        {
            public ChildMPBSPermanentTurkishMilitaryPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSPermanentTurkishMilitaryPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Göz Renk
    /// </summary>
        public ColorEnum? EyeColor
        {
            get { return (ColorEnum?)(int?)this["EYECOLOR"]; }
            set { this["EYECOLOR"] = value; }
        }

    /// <summary>
    /// Nasıb
    /// </summary>
        public string Nasib
        {
            get { return (string)this["NASIB"]; }
            set { this["NASIB"] = value; }
        }

    /// <summary>
    /// Ten Renk
    /// </summary>
        public ColorEnum? SkinColor
        {
            get { return (ColorEnum?)(int?)this["SKINCOLOR"]; }
            set { this["SKINCOLOR"] = value; }
        }

    /// <summary>
    /// Kıdem Sıra No
    /// </summary>
        public string SeniorityOrdinalNo
        {
            get { return (string)this["SENIORITYORDINALNO"]; }
            set { this["SENIORITYORDINALNO"] = value; }
        }

    /// <summary>
    /// Tayin No
    /// </summary>
        public string AppoinmentNo
        {
            get { return (string)this["APPOINMENTNO"]; }
            set { this["APPOINMENTNO"] = value; }
        }

    /// <summary>
    /// Saç Renk
    /// </summary>
        public ColorEnum? HairColor
        {
            get { return (ColorEnum?)(int?)this["HAIRCOLOR"]; }
            set { this["HAIRCOLOR"] = value; }
        }

    /// <summary>
    /// Dühul
    /// </summary>
        public string Penetration
        {
            get { return (string)this["PENETRATION"]; }
            set { this["PENETRATION"] = value; }
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public MPBSHonorificDefinition Honorific
        {
            get { return (MPBSHonorificDefinition)((ITTObject)this).GetParent("HONORIFIC"); }
            set { this["HONORIFIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public MPBSArmedForceDefinition ArmedForce
        {
            get { return (MPBSArmedForceDefinition)((ITTObject)this).GetParent("ARMEDFORCE"); }
            set { this["ARMEDFORCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branş
    /// </summary>
        public MPBSBranchDefinition Branch
        {
            get { return (MPBSBranchDefinition)((ITTObject)this).GetParent("BRANCH"); }
            set { this["BRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MPBSClassDefinition Class
        {
            get { return (MPBSClassDefinition)((ITTObject)this).GetParent("CLASS"); }
            set { this["CLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public MPBSRankDefinition Rank
        {
            get { return (MPBSRankDefinition)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPERMANENTTURKISHMILITARYPERSONNEL", dataRow) { }
        protected MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPERMANENTTURKISHMILITARYPERSONNEL", dataRow, isImported) { }
        public MPBSPermanentTurkishMilitaryPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSPermanentTurkishMilitaryPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSPermanentTurkishMilitaryPersonnel() : base() { }

    }
}