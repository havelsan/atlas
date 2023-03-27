
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
    public partial class DoctorPerformance : TTUnboundForm
    {
        protected ITTTabControl tabPerformance;
        protected ITTTabPage tpApproval;
        protected ITTLabel POCommitteeTotalPoint;
        protected ITTLabel lblPOCommitteeTotalPoint;
        protected ITTLabel POTotalPoint;
        protected ITTLabel lblPOTotalPoint;
        protected ITTButton btnPOUnCheckAll;
        protected ITTButton btnPOReject;
        protected ITTButton btnPOApprove;
        protected ITTButton btnPOCheckAll;
        protected ITTGrid grdPerformanceApprove;
        protected ITTTextBoxColumn gcPOObjectID;
        protected ITTCheckBoxColumn gcPOCheck;
        protected ITTDateTimePickerColumn gcPODate;
        protected ITTTextBoxColumn gcPOUniqueRefNo;
        protected ITTTextBoxColumn gcPONameSurname;
        protected ITTTextBoxColumn gcPOProtocolNo;
        protected ITTTextBoxColumn gcPOActionID;
        protected ITTTextBoxColumn gcPOProcedureCode;
        protected ITTTextBoxColumn gcPOProcedureName;
        protected ITTTextBoxColumn gcPOAmount;
        protected ITTTextBoxColumn gcPOPoint;
        protected ITTTextBoxColumn gcPODescription;
        protected ITTMaskedTextBoxColumn gcPOCommitteePoint;
        protected ITTTextBoxColumn gcPOCommitteeDescription;
        protected ITTButton btnPOList;
        protected ITTLabel lblPODoctor;
        protected ITTValueListBox PODoctor;
        protected ITTTabPage tpList;
        protected ITTObjectListBox PLDoctor;
        protected ITTGrid grdPerformanceList;
        protected ITTTextBoxColumn gcPLObjectID;
        protected ITTDateTimePickerColumn gcPLDate;
        protected ITTTextBoxColumn gcPLUniqueRefNo;
        protected ITTTextBoxColumn gcPLNameSurname;
        protected ITTTextBoxColumn gcPLProtocolNo;
        protected ITTTextBoxColumn gcPLActionID;
        protected ITTTextBoxColumn gcPLProcedureCode;
        protected ITTTextBoxColumn gcPLProcedureName;
        protected ITTTextBoxColumn gcPLAmount;
        protected ITTTextBoxColumn gcPLPoint;
        protected ITTTextBoxColumn gcPLDescription;
        protected ITTLabel PLTotalPoint;
        protected ITTLabel lblPLTotalPoint;
        protected ITTLabel lblPLDoctor;
        protected ITTCheckBox chkPLDetailedList;
        protected ITTButton btnPLList;
        protected ITTTabPage tpProcedureEntry;
        protected ITTButton SendDP;
        override protected void InitializeControls()
        {
            tabPerformance = (ITTTabControl)AddControl(new Guid("61478b9f-1f14-4fed-939f-43908281380a"));
            tpApproval = (ITTTabPage)AddControl(new Guid("41f647b0-8c64-4865-8904-b97f1d3bffdc"));
            POCommitteeTotalPoint = (ITTLabel)AddControl(new Guid("94210c0e-296d-4833-99ff-38b30df73878"));
            lblPOCommitteeTotalPoint = (ITTLabel)AddControl(new Guid("8372b725-2724-47ff-9466-4f01339f6842"));
            POTotalPoint = (ITTLabel)AddControl(new Guid("8e74fe05-e0a5-4bde-a799-f0adbf700a12"));
            lblPOTotalPoint = (ITTLabel)AddControl(new Guid("5178642a-e844-4281-8730-74be47f232c3"));
            btnPOUnCheckAll = (ITTButton)AddControl(new Guid("901877a4-ae31-433f-a45d-2230ba0e9753"));
            btnPOReject = (ITTButton)AddControl(new Guid("1d900bcf-6728-4918-9c8e-0cdb29311152"));
            btnPOApprove = (ITTButton)AddControl(new Guid("d7f06aa0-18e3-4f90-89fc-559c65c5807a"));
            btnPOCheckAll = (ITTButton)AddControl(new Guid("643d41ff-aef3-438e-8c23-9dc968dec860"));
            grdPerformanceApprove = (ITTGrid)AddControl(new Guid("3894721f-484b-4021-8005-db8eb220498b"));
            gcPOObjectID = (ITTTextBoxColumn)AddControl(new Guid("66279853-3289-482c-8203-4c87af75731e"));
            gcPOCheck = (ITTCheckBoxColumn)AddControl(new Guid("86624d56-28ff-43b2-8f5c-90283396a93a"));
            gcPODate = (ITTDateTimePickerColumn)AddControl(new Guid("b05a7104-23d9-41be-a0cc-6c854f6c691f"));
            gcPOUniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("12ae8667-a934-4790-9950-7855721e815b"));
            gcPONameSurname = (ITTTextBoxColumn)AddControl(new Guid("b1f13168-21e8-40d3-b13f-9c6af1f596d4"));
            gcPOProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("5173dfe0-5890-44ab-88db-6dc53c284610"));
            gcPOActionID = (ITTTextBoxColumn)AddControl(new Guid("438e7ba9-25d2-44ce-a80b-0088a8da022a"));
            gcPOProcedureCode = (ITTTextBoxColumn)AddControl(new Guid("9a3ce7e6-da0b-4ba5-8fa7-bde2f70f42f1"));
            gcPOProcedureName = (ITTTextBoxColumn)AddControl(new Guid("959e2aee-cdb3-41a3-94a5-9830cc915ac1"));
            gcPOAmount = (ITTTextBoxColumn)AddControl(new Guid("d5be0430-e2f8-4dca-bad8-78d215711a52"));
            gcPOPoint = (ITTTextBoxColumn)AddControl(new Guid("ee8e3dca-1437-43f4-aceb-1f067ae02c84"));
            gcPODescription = (ITTTextBoxColumn)AddControl(new Guid("5c2dd1f0-794a-43d9-9b5f-f70d4183be9e"));
            gcPOCommitteePoint = (ITTMaskedTextBoxColumn)AddControl(new Guid("ac3129dc-a044-4a26-8791-76ac03fd4628"));
            gcPOCommitteeDescription = (ITTTextBoxColumn)AddControl(new Guid("0f8a9132-7025-477f-a548-efce24bf67c3"));
            btnPOList = (ITTButton)AddControl(new Guid("e80ad38c-82e7-459c-9e16-fe79b7561dca"));
            lblPODoctor = (ITTLabel)AddControl(new Guid("46d1718a-07e6-438f-821d-0a5713d0705b"));
            PODoctor = (ITTValueListBox)AddControl(new Guid("0b51dffd-442b-4e96-909a-e89eb878258a"));
            tpList = (ITTTabPage)AddControl(new Guid("db1de3b0-43a7-4f96-93b8-75d04fafb112"));
            PLDoctor = (ITTObjectListBox)AddControl(new Guid("af1e485b-fcdb-46ad-ba5d-7b04b4e2882b"));
            grdPerformanceList = (ITTGrid)AddControl(new Guid("b4c5e924-4168-4f38-bd93-bea088bf598a"));
            gcPLObjectID = (ITTTextBoxColumn)AddControl(new Guid("645ee5d8-1020-472c-b8a2-f9ac662d9037"));
            gcPLDate = (ITTDateTimePickerColumn)AddControl(new Guid("816e06c5-8afd-4e11-9a60-cb45e19a9493"));
            gcPLUniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("a231c9f7-4534-427f-acfe-2dc8ae358c6e"));
            gcPLNameSurname = (ITTTextBoxColumn)AddControl(new Guid("cd7a7647-9126-47b9-b00e-29d65bf6d87e"));
            gcPLProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("668269ea-7f08-4b92-b639-79f67902899f"));
            gcPLActionID = (ITTTextBoxColumn)AddControl(new Guid("9b8ca77e-77fa-4e0f-a69d-423bdb09d101"));
            gcPLProcedureCode = (ITTTextBoxColumn)AddControl(new Guid("27e5c3cd-87ff-4d28-a219-6102dad6264c"));
            gcPLProcedureName = (ITTTextBoxColumn)AddControl(new Guid("f7131a50-20f0-42f5-867b-a8de5ec2c80e"));
            gcPLAmount = (ITTTextBoxColumn)AddControl(new Guid("0c2bc435-0dc3-4475-abd2-03929fce13a8"));
            gcPLPoint = (ITTTextBoxColumn)AddControl(new Guid("893907ac-255d-412b-b63c-d36aad153fa7"));
            gcPLDescription = (ITTTextBoxColumn)AddControl(new Guid("7b45efd1-1334-4251-87e9-cb5dd34f1e16"));
            PLTotalPoint = (ITTLabel)AddControl(new Guid("37794008-1ce8-4528-8a83-20f230354132"));
            lblPLTotalPoint = (ITTLabel)AddControl(new Guid("7778b2d0-ea99-4fec-8b3d-eb3b8e422793"));
            lblPLDoctor = (ITTLabel)AddControl(new Guid("ae99f1c6-6348-4d9b-892e-04622aaf8bd9"));
            chkPLDetailedList = (ITTCheckBox)AddControl(new Guid("d04fd3d0-b105-416b-8b87-6a691f56c9c1"));
            btnPLList = (ITTButton)AddControl(new Guid("da2e6ce8-d435-44b6-9e1e-ba7e38681390"));
            tpProcedureEntry = (ITTTabPage)AddControl(new Guid("2bd3a4ad-4307-4450-a10b-d28ab4165129"));
            SendDP = (ITTButton)AddControl(new Guid("77c54d0f-c54f-44e0-ab27-695811279539"));
            base.InitializeControls();
        }

        public DoctorPerformance() : base("DoctorPerformance")
        {
        }

        protected DoctorPerformance(string formDefName) : base(formDefName)
        {
        }
    }
}