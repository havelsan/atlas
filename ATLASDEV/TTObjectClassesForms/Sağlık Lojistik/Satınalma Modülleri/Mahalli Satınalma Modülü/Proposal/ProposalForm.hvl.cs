
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
    /// Teklifler
    /// </summary>
    public partial class ProposalForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalmada Firmaların Verdiği Her Teklif İçin Kullanılan Sınıf. Her Firma İçin Bir Adet Instance Yaratılır
    /// </summary>
        protected TTObjectClasses.Proposal _Proposal
        {
            get { return (TTObjectClasses.Proposal)_ttObject; }
        }

        protected ITTGrid PurchaseItemProposalsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTListBoxColumn MaterialName;
        protected ITTTextBoxColumn ProposalPrice;
        protected ITTTextBoxColumn FDUDA;
        protected ITTTextBoxColumn YILFA;
        protected ITTTextBoxColumn Description;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            PurchaseItemProposalsGrid = (ITTGrid)AddControl(new Guid("85337f62-e8fb-4639-9edc-7544c13ff8af"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("e2b86e66-7a20-46c6-a756-45392eaf3c80"));
            MaterialName = (ITTListBoxColumn)AddControl(new Guid("251d6cbe-b83c-45f1-9180-60eb95c700f2"));
            ProposalPrice = (ITTTextBoxColumn)AddControl(new Guid("8bbea3d9-1413-4a06-88c7-da63a649cce1"));
            FDUDA = (ITTTextBoxColumn)AddControl(new Guid("3b3fdfb8-2db9-4364-b132-d71708d9cec5"));
            YILFA = (ITTTextBoxColumn)AddControl(new Guid("4567f08f-ba9e-4c41-a595-bb3661b36551"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("6a88bae6-3e59-4325-aea8-95ad13629ea6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a8817785-66f1-4a69-ad3f-76088f52ba1d"));
            base.InitializeControls();
        }

        public ProposalForm() : base("PROPOSAL", "ProposalForm")
        {
        }

        protected ProposalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}