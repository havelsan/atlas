
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCENewForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExamination _HealthCommitteeExamination
        {
            get { return (TTObjectClasses.HealthCommitteeExamination)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTTextBox ReportNo;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("eea5dc78-d6f1-41d3-b74d-0c9c56462d1a"));
            ReportNo = (ITTTextBox)AddControl(new Guid("3d9b2690-84eb-46e2-a478-669248b022fe"));
            base.InitializeControls();
        }

        public HCENewForm() : base("HEALTHCOMMITTEEEXAMINATION", "HCENewForm")
        {
        }

        protected HCENewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}