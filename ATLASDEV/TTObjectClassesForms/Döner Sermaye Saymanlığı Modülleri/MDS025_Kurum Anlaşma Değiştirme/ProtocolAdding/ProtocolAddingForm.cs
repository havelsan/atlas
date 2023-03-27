
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// Hasta Kurum Bilgisi Değiştirme
//    /// </summary>
//    public partial class ProtocolAddingForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            NEWPAYER.SelectedObjectChanged += new TTControlEventDelegate(NEWPAYER_SelectedObjectChanged);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            NEWPAYER.SelectedObjectChanged -= new TTControlEventDelegate(NEWPAYER_SelectedObjectChanged);
//            base.UnBindControlEvents();
//        }

//        private void NEWPAYER_SelectedObjectChanged()
//        {
//            #region ProtocolAddingForm_NEWPAYER_SelectedObjectChanged
//            _ProtocolAdding.Protocol = null;

//            if (_ProtocolAdding.Payer != null)
//            {
//                ProtocolDefinition oneValidProtocol = null;
//                bool protocolFound = false;

//                this.NEWPROTOCOL.ListFilterExpression = _ProtocolAdding.Payer.GetListFilterExpressionForValidProtocols(null, ref protocolFound, ref oneValidProtocol);
//                _ProtocolAdding.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için
//            }
//            #endregion ProtocolAddingForm_NEWPAYER_SelectedObjectChanged
//        }

//        protected override void PreScript()
//        {
//            #region ProtocolAddingForm_PreScript
//            Episode myEpisode = _ProtocolAdding.Episode;
//            //IList EPList = EpisodeProtocol.GetByEpisode(_ProtocolAdding.ObjectContext, myEpisode.ObjectID.ToString());
//            IList sepList = SubEpisodeProtocol.GetSEPByEpisode(_ProtocolAdding.ObjectContext, myEpisode.ObjectID);
//            this.cmdOK.Visible = false;
//            if (_ProtocolAdding.CurrentStateDefID == ProtocolAdding.States.New)
//            {
//                _ProtocolAdding.ProtocolAddingDetails.Clear();
//                foreach (SubEpisodeProtocol sep in sepList)
//                {
//                    ProtocolAddingDetail prtAddingDetail = new ProtocolAddingDetail(_ProtocolAdding.ObjectContext);
//                    prtAddingDetail.PAYERNAME = sep.Payer.Name.ToString();
//                    prtAddingDetail.PROTOCOLNAME = sep.Protocol.Name.ToString();
//                    prtAddingDetail.PROTOCOLSTATUS = sep.CurrentStateDef.DisplayText;
//                    prtAddingDetail.SEPOBJECTID = sep.ObjectID;
//                    prtAddingDetail.CREATIONDATE = sep.CreationDate;
//                    prtAddingDetail.SUBEPISODENAME = sep.SubEpisode.ProtocolNo + " " + sep.SubEpisode.ResSection.Name;
//                    prtAddingDetail.SUBEPISODEOBJECTID = sep.SubEpisode.ObjectID;
//                    prtAddingDetail.INVOICESTATUS = sep.InvoiceStatus;
//                    _ProtocolAdding.ProtocolAddingDetails.Add(prtAddingDetail);
//                }
//                foreach (SubEpisode se in myEpisode.SubEpisodes)
//                {
//                    ProtocolAddingSubEpisode prtAddingSE = new ProtocolAddingSubEpisode(_ProtocolAdding.ObjectContext);
//                    prtAddingSE.SubEpisode = se;
//                    _ProtocolAdding.ProtocolAddingSubEpisodes.Add(prtAddingSE);
//                }
//            }
//            #endregion ProtocolAddingForm_PreScript

//        }
//    }
//}