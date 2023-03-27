using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceLog
    {
        public Guid ObjectId { get; set; }
        public InvoiceOperationTypeEnum? OperationType { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public InvoiceLogTypeEnum? MessageType { get; set; }
        public Guid? ObjectPrimaryKey { get; set; }
        public InvoiceLogObjectTypeEnum? ObjectType { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}