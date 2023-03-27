
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
    public partial class FollowingPatientsForm : TTForm
    {
        protected TTObjectClasses.FollowingPatients _FollowingPatients
        {
            get { return (TTObjectClasses.FollowingPatients)_ttObject; }
        }

        protected ITTLabel labelFollower;
        protected ITTTextBox Follower;
        override protected void InitializeControls()
        {
            labelFollower = (ITTLabel)AddControl(new Guid("6b188791-eedd-4cea-8ea5-73f5d10e0b28"));
            Follower = (ITTTextBox)AddControl(new Guid("108394bf-ff09-4c7b-984c-23e67ef1fd8d"));
            base.InitializeControls();
        }

        public FollowingPatientsForm() : base("FOLLOWINGPATIENTS", "FollowingPatientsForm")
        {
        }

        protected FollowingPatientsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}