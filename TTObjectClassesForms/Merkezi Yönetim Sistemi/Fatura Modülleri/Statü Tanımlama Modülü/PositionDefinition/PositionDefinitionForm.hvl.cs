
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
    /// Statü Tanımlama Formu
    /// </summary>
    public partial class PositionDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Statü Tanımlama
    /// </summary>
        protected TTObjectClasses.PositionDefinition _PositionDefinition
        {
            get { return (TTObjectClasses.PositionDefinition)_ttObject; }
        }

        protected ITTLabel labelShortName;
        protected ITTTextBox ShortName;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelExtrenalCode;
        protected ITTTextBox ExtrenalCode;
        override protected void InitializeControls()
        {
            labelShortName = (ITTLabel)AddControl(new Guid("41c22791-08ff-43ce-943d-909ed682f174"));
            ShortName = (ITTTextBox)AddControl(new Guid("c9b0d14b-106f-493a-b883-bb17852a26ac"));
            labelName = (ITTLabel)AddControl(new Guid("a462fc80-38c8-44ac-b7f1-e2ca008d9cb5"));
            Name = (ITTTextBox)AddControl(new Guid("f93dbe25-efaf-4fde-9997-0ec12b3394e9"));
            labelExtrenalCode = (ITTLabel)AddControl(new Guid("8a5aae30-b3c3-4433-b8ba-5558d955939f"));
            ExtrenalCode = (ITTTextBox)AddControl(new Guid("0f38d542-1827-451f-b43a-4c0da43f730b"));
            base.InitializeControls();
        }

        public PositionDefinitionForm() : base("POSITIONDEFINITION", "PositionDefinitionForm")
        {
        }

        protected PositionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}