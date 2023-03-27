
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
    public partial class FollowUpExaminationCokluOzelDurum : TTForm
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

        protected ITTGrid ttgridcokluOzelDurum;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgridcokluOzelDurum = (ITTGrid)AddControl(new Guid("efc6872e-c737-48c4-9d58-ad37ddb57702"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("11a3d895-42f0-40f8-ab30-24b7002c47f0"));
            base.InitializeControls();
        }

        public FollowUpExaminationCokluOzelDurum() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationCokluOzelDurum")
        {
        }

        protected FollowUpExaminationCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}