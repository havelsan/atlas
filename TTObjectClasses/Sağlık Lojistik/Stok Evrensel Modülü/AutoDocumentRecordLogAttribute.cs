
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


namespace TTObjectClasses
{
    public partial class AutoDocumentRecordLogAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            StockAction stockAction = (StockAction)ObjectContext.GetObject(Interface.GetObjectID(), typeof(StockAction).Name);
            if (stockAction == null)
                throw new TTException(SystemMessage.GetMessage(526));

            if (stockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
            {
                if (Interface.GetDocumentRecordLogContents() == null || Interface.GetDocumentRecordLogContents().Count == 0)
                    throw new TTException(SystemMessage.GetMessage(527));

                foreach (DocumentRecordLogContent documentRecordLogContent in Interface.GetDocumentRecordLogContents())
                {
                    string filterexp = " CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed) + " AND DOCUMENTTRANSACTIONTYPE = " + (int)documentRecordLogContent.TransactionType + " AND BUDGETYPE = " + (int)documentRecordLogContent.ButceTur + " AND DESCRIPTIONS = '" + documentRecordLogContent.Descriptions + "'";
                    IList documentRecordLogs = stockAction.DocumentRecordLogs.Select(filterexp);
                    if (documentRecordLogs.Count > 0)
                        UpdateDocumentRecordLog(documentRecordLogContent);
                    else
                        CreateNewDocumentRecordLog(documentRecordLogContent);
                }
            }

            if (stockAction.CurrentStateDef.Status == StateStatusEnum.Cancelled)
            {
                stockAction.CancelDocumentRecordLogs();
            }
            #endregion Body
        }

        #region Methods
        public class DocumentRecordLogContent
        {
            private DocumentTransactionTypeEnum _transactionType;
            public DocumentTransactionTypeEnum TransactionType
            {
                get { return _transactionType; }
            }

            private StockAction _stockAction;
            public StockAction StockAction
            {
                get { return _stockAction; }
            }

            private int _numberOfRows;
            public int NumberOfRows
            {
                get { return _numberOfRows; }
            }

            private string _takenGivenPlace;
            public string TakenGivenPlace
            {
                get { return _takenGivenPlace; }
            }

            private string _description;
            public string Descriptions
            {
                get { return _description; }
            }


            private MKYS_EButceTurEnum _butceTur;
            public MKYS_EButceTurEnum ButceTur
            {
                get { return _butceTur; }
            }

            public DocumentRecordLogContent(DocumentTransactionTypeEnum transactionType, StockAction stockAction, int numberOfRows, string takenGivenPlace, MKYS_EButceTurEnum butceTur)
            {
                _transactionType = transactionType;
                _stockAction = stockAction;
                _numberOfRows = numberOfRows;
                _takenGivenPlace = takenGivenPlace;
                _butceTur = butceTur;

            }
            public DocumentRecordLogContent(DocumentTransactionTypeEnum transactionType, StockAction stockAction, int numberOfRows, string takenGivenPlace, MKYS_EButceTurEnum butceTur, string description)
            {
                _transactionType = transactionType;
                _stockAction = stockAction;
                _numberOfRows = numberOfRows;
                _takenGivenPlace = takenGivenPlace;
                _butceTur = butceTur;
                _description = description;
            }
        }

        private void UpdateDocumentRecordLog(DocumentRecordLogContent documentRecordLogContent)
        {
            IList documentRecordLogs = documentRecordLogContent.StockAction.DocumentRecordLogs.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed) + " AND DOCUMENTTRANSACTIONTYPE = " + (int)documentRecordLogContent.TransactionType);
            foreach (DocumentRecordLog documentRecordLog in documentRecordLogs)
            {
                ((ITTObject)documentRecordLog).UndoLastTransition(TTUtils.CultureService.GetText("M25750", "Güncelleme nedeniyle."));
                documentRecordLog.Update();
                documentRecordLog.NumberOfRows = documentRecordLog.NumberOfRows;
                documentRecordLog.TakenGivenPlace = documentRecordLog.TakenGivenPlace;
                documentRecordLog.BudgeType = documentRecordLog.BudgeType;
                documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.Completed;
            }
        }

        private void CreateNewDocumentRecordLog(DocumentRecordLogContent documentRecordLogContent)
        {
            DocumentRecordLog documentRecordLog = new DocumentRecordLog(ObjectContext);
            documentRecordLog.StockAction = documentRecordLogContent.StockAction;

            Guid documentRecordLogSequenceID = new Guid("38b068a4-81c5-4a47-b8d3-efd350ef3ee5");
            string filterTXT = documentRecordLogContent.StockAction.AccountingTerm.Accountancy.ObjectID.ToString() + "_" + ((MKYS_EButceTurEnum)documentRecordLogContent.ButceTur).ToString();
            if (documentRecordLogContent.StockAction.ClonedObjectID != null)
            {
                StockAction cloneedStockAction = (StockAction)ObjectContext.GetObject(documentRecordLogContent.StockAction.ClonedObjectID.Value, typeof(StockAction));
                if (documentRecordLogContent.StockAction.AccountingTerm == cloneedStockAction.AccountingTerm)
                {
                    DocumentRecordLog findDocument = cloneedStockAction.DocumentRecordLogs.Where(x => x.BudgeType == documentRecordLogContent.ButceTur).FirstOrDefault();
                    if (findDocument != null)
                    {
                        documentRecordLog.DocumentRecordLogNumber = findDocument.DocumentRecordLogNumber;
                    }
                    else
                    {
                        documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, documentRecordLogContent.StockAction.AccountingTerm.TermYear.Value);
                    }
                }
                else
                {
                    documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, documentRecordLogContent.StockAction.AccountingTerm.TermYear.Value);
                }

            }
            else
            {
                documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, documentRecordLogContent.StockAction.AccountingTerm.TermYear.Value);
                //documentRecordLog.DocumentRecordLogNumber.GetNextValue(documentRecordLogContent.StockAction.AccountingTerm.Accountancy.ObjectID.ToString() + "_" + ((MKYS_EButceTurEnum)documentRecordLogContent.ButceTur).ToString(), documentRecordLogContent.StockAction.AccountingTerm.TermYear.Value);
            }

            documentRecordLog.DocumentTransactionType = documentRecordLogContent.TransactionType;
            documentRecordLog.DocumentDateTime = documentRecordLogContent.StockAction.TransactionDate;
            documentRecordLog.NumberOfRows = documentRecordLogContent.NumberOfRows;
            documentRecordLog.Subject = documentRecordLogContent.StockAction.ObjectDef.ApplicationName;
            documentRecordLog.TakenGivenPlace = documentRecordLogContent.TakenGivenPlace;
            documentRecordLog.BudgeType = documentRecordLogContent.ButceTur;
            documentRecordLog.MKYSStatus = MKYSControlEnum.Completed;
            if (documentRecordLogContent.StockAction is ProductionConsumptionDocument)
                documentRecordLog.Descriptions = documentRecordLogContent.StockAction.Description;
            if (documentRecordLogContent.StockAction is ReviewAction)
                documentRecordLog.Descriptions = documentRecordLogContent.Descriptions;
            documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.New;
            documentRecordLog.Update();
            documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.Completed;

        }
        #endregion Methods

        public override void Check(TTAttribute attribute)
        {
            #region CheckBody

            #endregion CheckBody
        }
    }
}