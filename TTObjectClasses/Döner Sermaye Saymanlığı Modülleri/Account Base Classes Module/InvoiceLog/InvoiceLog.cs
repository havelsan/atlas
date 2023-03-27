
using System;
using TTInstanceManagement;


namespace TTObjectClasses
{
    /// <summary>
    /// Fatura Ekranı Logları
    /// </summary>
    public partial class InvoiceLog : TTObject
    {
        public partial class GetMedulaInvoiceLogs_Class : TTReportNqlObject
        {
        }

        public static void CopyLog(InvoiceLog oldLog, Guid ObjectPrimaryKey, TTObjectContext context)
        {
            InvoiceLog log = new InvoiceLog(context);
            log.OperationType = oldLog.OperationType;
            log.Date = oldLog.Date;
            log.ObjectPrimaryKey = ObjectPrimaryKey;
            log.ObjectType = oldLog.ObjectType;
            log.MessageType = oldLog.MessageType;
            log.Message = oldLog.Message;
            log.ResUser = oldLog.ResUser;
            log.SubEpisodeProtocol = context.GetObject<SubEpisodeProtocol>(ObjectPrimaryKey, false);
            log.OldValue = oldLog.OldValue;
            log.NewValue = oldLog.NewValue;
        }

        private static void AddLog(string message, Guid ObjectPrimaryKey, InvoiceLogTypeEnum logType, InvoiceOperationTypeEnum operationType, InvoiceLogObjectTypeEnum objectType, TTObjectContext context = null, string oldValue = null, string newValue = null)
        {
            TTObjectContext _context = null;
            if (context == null)
                _context = new TTObjectContext(false);
            else
                _context = context;

            InvoiceLog log = new InvoiceLog(_context);
            log.OperationType = operationType;
            log.Date = DateTime.Now;
            log.ObjectPrimaryKey = ObjectPrimaryKey;
            log.ObjectType = objectType;
            log.MessageType = logType;
            log.Message = message;
            log.ResUser = Common.CurrentResource;
            log.OldValue = oldValue;
            log.NewValue = newValue;

            if (objectType == InvoiceLogObjectTypeEnum.AccountTransaction)
                log.AccountTransaction = _context.GetObject<AccountTransaction>(ObjectPrimaryKey, false);
            else if (objectType == InvoiceLogObjectTypeEnum.SubEpisodeProtocol)
                log.SubEpisodeProtocol = _context.GetObject<SubEpisodeProtocol>(ObjectPrimaryKey, false);
            else if (objectType == InvoiceLogObjectTypeEnum.SEPDiagnosis)
                log.SEPDiagnosis = _context.GetObject<SEPDiagnosis>(ObjectPrimaryKey, false);

            if (context == null)
            {
                _context.Save();
                _context.Dispose();
            }
        }

        public static void AddInfo(string message, Guid ObjectPrimaryKey, InvoiceOperationTypeEnum operationType, InvoiceLogObjectTypeEnum objectType, TTObjectContext context = null, string oldValue = null, string newValue = null)
        {
            AddLog(message, ObjectPrimaryKey, InvoiceLogTypeEnum.Info, operationType, objectType, context, oldValue, newValue);
        }

        public static void AddErr(string message, Guid ObjectPrimaryKey, InvoiceOperationTypeEnum operationType, InvoiceLogObjectTypeEnum objectType, TTObjectContext context = null)
        {
            AddLog(message, ObjectPrimaryKey, InvoiceLogTypeEnum.Err, operationType, objectType, context);
        }

        public static void AddException(string message, Guid ObjectPrimaryKey, InvoiceOperationTypeEnum operationType, InvoiceLogObjectTypeEnum objectType)
        {//Exception kendi context i ile kayıt etsin.
            AddLog(message, ObjectPrimaryKey, InvoiceLogTypeEnum.Exception, operationType, objectType);
        }

    }
}