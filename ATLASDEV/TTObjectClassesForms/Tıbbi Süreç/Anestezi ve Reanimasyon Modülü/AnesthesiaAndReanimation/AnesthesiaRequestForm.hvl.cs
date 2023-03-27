
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PlannedAnesthsiaDate;
        protected ITTGrid RequestedProcedure;
        protected ITTListBoxColumn Procedure;
        protected ITTLabel LabelRequest;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox RequestNote;
        protected ITTLabel labelRequestNote;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("76af8d10-96cc-43f0-bf92-34c2ed0ae38f"));
            PlannedAnesthsiaDate = (ITTDateTimePicker)AddControl(new Guid("bcec448c-93c0-47af-ab50-719db83b718b"));
            RequestedProcedure = (ITTGrid)AddControl(new Guid("ff07fecb-f8da-4a00-baad-7a7a28960195"));
            Procedure = (ITTListBoxColumn)AddControl(new Guid("dfc12455-4f1c-463b-a4ef-6da334f71ca4"));
            LabelRequest = (ITTLabel)AddControl(new Guid("02adc8b7-d435-48f3-a948-82427e2c1e00"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cbca16dc-6e5e-4ba9-8404-e5a9c63edb9e"));
            RequestNote = (ITTTextBox)AddControl(new Guid("6051b13d-d876-4d5c-aaec-3454b9f7c4b9"));
            labelRequestNote = (ITTLabel)AddControl(new Guid("08fdefa0-6a17-498c-86ff-7c4101a3daae"));
            base.InitializeControls();
        }

        public AnesthesiaRequestForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaRequestForm")
        {
        }

        protected AnesthesiaRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}