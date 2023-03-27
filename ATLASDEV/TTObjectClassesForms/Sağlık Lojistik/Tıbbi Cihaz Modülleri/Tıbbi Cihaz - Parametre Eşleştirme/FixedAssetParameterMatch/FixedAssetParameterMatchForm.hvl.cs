
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
    /// Tıbbi Cihaz - Parametre Eşleştirme
    /// </summary>
    public partial class FixedAssetParameterMatchForm : TTForm
    {
    /// <summary>
    /// Tıbbi Cihaz - Parametre Eşleştirme
    /// </summary>
        protected TTObjectClasses.FixedAssetParameterMatch _FixedAssetParameterMatch
        {
            get { return (TTObjectClasses.FixedAssetParameterMatch)_ttObject; }
        }

        protected ITTGrid MatchUserParameters;
        protected ITTListBoxColumn UserParameterMatchUserParameter;
        protected ITTGrid MatchUnitParameters;
        protected ITTListBoxColumn UnitParameterMatchUnitParameter;
        protected ITTGrid MatchFixedAssets;
        protected ITTListBoxColumn FixedAssetDefinitionMatchFixedAsset;
        protected ITTLabel labelWorkListDate;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        override protected void InitializeControls()
        {
            MatchUserParameters = (ITTGrid)AddControl(new Guid("aca8be28-9d62-471d-9e4e-76cb99727ba0"));
            UserParameterMatchUserParameter = (ITTListBoxColumn)AddControl(new Guid("4ffb0661-78a4-47e9-9cf7-fa9bd6cb65e6"));
            MatchUnitParameters = (ITTGrid)AddControl(new Guid("9a9d03d9-0c2d-4e59-838d-19c3c8daccf5"));
            UnitParameterMatchUnitParameter = (ITTListBoxColumn)AddControl(new Guid("17a60612-7674-46dd-b554-005744c84371"));
            MatchFixedAssets = (ITTGrid)AddControl(new Guid("c2fc7b07-d599-4fa8-aec2-7db55ab92609"));
            FixedAssetDefinitionMatchFixedAsset = (ITTListBoxColumn)AddControl(new Guid("aa8606ef-56da-4076-a884-8e7bf042462a"));
            labelWorkListDate = (ITTLabel)AddControl(new Guid("609c2cff-af4a-4265-b43b-6de44cc1ba4b"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("84575ad6-c467-44d5-8400-f801e69af104"));
            labelID = (ITTLabel)AddControl(new Guid("783ac30e-4c77-46e5-9279-877a0c9831ae"));
            ID = (ITTTextBox)AddControl(new Guid("56056d04-c693-473c-a47e-d851fabd1b82"));
            base.InitializeControls();
        }

        public FixedAssetParameterMatchForm() : base("FIXEDASSETPARAMETERMATCH", "FixedAssetParameterMatchForm")
        {
        }

        protected FixedAssetParameterMatchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}