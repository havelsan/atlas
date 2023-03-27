
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectPreAssement")] 

    public  partial class ProjectPreAssement : TTObject
    {
        public class ProjectPreAssementList : TTObjectCollection<ProjectPreAssement> { }
                    
        public class ChildProjectPreAssementCollection : TTObject.TTChildObjectCollection<ProjectPreAssement>
        {
            public ChildProjectPreAssementCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectPreAssementCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string PreWorkAim
        {
            get { return (string)this["PREWORKAIM"]; }
            set { this["PREWORKAIM"] = value; }
        }

        public int? ControllerReagentCount
        {
            get { return (int?)this["CONTROLLERREAGENTCOUNT"]; }
            set { this["CONTROLLERREAGENTCOUNT"] = value; }
        }

        public int? ControllerRepeatCount
        {
            get { return (int?)this["CONTROLLERREPEATCOUNT"]; }
            set { this["CONTROLLERREPEATCOUNT"] = value; }
        }

        public int? ControllerTotalReagentCount
        {
            get { return (int?)this["CONTROLLERTOTALREAGENTCOUNT"]; }
            set { this["CONTROLLERTOTALREAGENTCOUNT"] = value; }
        }

        public int? ExperimantalReagentCount
        {
            get { return (int?)this["EXPERIMANTALREAGENTCOUNT"]; }
            set { this["EXPERIMANTALREAGENTCOUNT"] = value; }
        }

        public int? ExperimentalRepeatCount
        {
            get { return (int?)this["EXPERIMENTALREPEATCOUNT"]; }
            set { this["EXPERIMENTALREPEATCOUNT"] = value; }
        }

        public int? ExperimentalTotalReagentCount
        {
            get { return (int?)this["EXPERIMENTALTOTALREAGENTCOUNT"]; }
            set { this["EXPERIMENTALTOTALREAGENTCOUNT"] = value; }
        }

        public string PreAssementResult
        {
            get { return (string)this["PREASSEMENTRESULT"]; }
            set { this["PREASSEMENTRESULT"] = value; }
        }

        public string ProjectImportance
        {
            get { return (string)this["PROJECTIMPORTANCE"]; }
            set { this["PROJECTIMPORTANCE"] = value; }
        }

        public string ReagentSectionDemand
        {
            get { return (string)this["REAGENTSECTIONDEMAND"]; }
            set { this["REAGENTSECTIONDEMAND"] = value; }
        }

        public string ResearcCenterDemand
        {
            get { return (string)this["RESEARCCENTERDEMAND"]; }
            set { this["RESEARCCENTERDEMAND"] = value; }
        }

        public string SurgeryResearchCenterDemand
        {
            get { return (string)this["SURGERYRESEARCHCENTERDEMAND"]; }
            set { this["SURGERYRESEARCHCENTERDEMAND"] = value; }
        }

        public DateTime? PreAssesmentDate
        {
            get { return (DateTime?)this["PREASSESMENTDATE"]; }
            set { this["PREASSESMENTDATE"] = value; }
        }

        public string MaterialMethod
        {
            get { return (string)this["MATERIALMETHOD"]; }
            set { this["MATERIALMETHOD"] = value; }
        }

        public string ProjectAim
        {
            get { return (string)this["PROJECTAIM"]; }
            set { this["PROJECTAIM"] = value; }
        }

        virtual protected void CreateProjectAssementCollection()
        {
            _ProjectAssement = new ArgeProject.ChildArgeProjectCollection(this, new Guid("5608e08e-a2e5-45c5-9c4c-6805ef7c4053"));
            ((ITTChildObjectCollection)_ProjectAssement).GetChildren();
        }

        protected ArgeProject.ChildArgeProjectCollection _ProjectAssement = null;
        public ArgeProject.ChildArgeProjectCollection ProjectAssement
        {
            get
            {
                if (_ProjectAssement == null)
                    CreateProjectAssementCollection();
                return _ProjectAssement;
            }
        }

        protected ProjectPreAssement(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectPreAssement(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectPreAssement(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectPreAssement(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectPreAssement(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTPREASSEMENT", dataRow) { }
        protected ProjectPreAssement(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTPREASSEMENT", dataRow, isImported) { }
        public ProjectPreAssement(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectPreAssement(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectPreAssement() : base() { }

    }
}