
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
    /// Medula Branş Doktor Eşleştirme Tanımı
    /// </summary>
    public partial class MedulaBranchDoctorMatchForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Medula Branş Doktor Eşleştirme Tanımı
    /// </summary>
        protected TTObjectClasses.MedulaBranchDoctorMatchDef _MedulaBranchDoctorMatchDef
        {
            get { return (TTObjectClasses.MedulaBranchDoctorMatchDef)_ttObject; }
        }

        protected ITTLabel lblDoctor;
        protected ITTLabel lblBranch;
        protected ITTObjectListBox Branch;
        protected ITTObjectListBox Doctor;
        override protected void InitializeControls()
        {
            lblDoctor = (ITTLabel)AddControl(new Guid("cb2b0311-3d08-44fd-a0ff-6ff4b193093a"));
            lblBranch = (ITTLabel)AddControl(new Guid("8a5774c8-0f1f-4344-9480-fdc0573b6e54"));
            Branch = (ITTObjectListBox)AddControl(new Guid("df49a70b-33a4-4953-a11f-bd9958b03263"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("f842dcc2-08ff-450e-822d-6b5fe670f116"));
            base.InitializeControls();
        }

        public MedulaBranchDoctorMatchForm() : base("MEDULABRANCHDOCTORMATCHDEF", "MedulaBranchDoctorMatchForm")
        {
        }

        protected MedulaBranchDoctorMatchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}