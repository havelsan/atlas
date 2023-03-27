using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTWebMethodDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTWebMethodDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTWebMethodDef> builder)
        {
            builder.HasKey(t => t.WebMethodDefId);
            builder.Property(t => t.WebMethodDefId).HasColumnName("WEBMETHODDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.ReturnType).HasColumnName("RETURNTYPE").HasMaxLength(100);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.CallMode).HasColumnName("CALLMODE");
            builder.Property(t => t.Priority).HasColumnName("PRIORITY");
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.DisplayText).HasColumnName("DISPLAYTEXT").HasMaxLength(150);
            builder.Property(t => t.AuthenticationType).HasColumnName("AUTHENTICATIONTYPE");
            builder.Property(t => t.UserNameParameterName).HasColumnName("USERNAMEPARAMETERNAME").HasMaxLength(150);
            builder.Property(t => t.PasswordParameterName).HasColumnName("PASSWORDPARAMETERNAME").HasMaxLength(150);
            builder.Property(t => t.ResourceParameterType).HasColumnName("RESOURCEPARAMETERTYPE");
            builder.Property(t => t.GenerateProcedureParameter).HasColumnName("GENERATEPROCEDUREPARAMETER");
            builder.Property(t => t.MethodName).HasColumnName("METHODNAME").HasMaxLength(100);
            builder.Property(t => t.FirmUserNameParameterName).HasColumnName("FIRMUSERNAMEPARAMETERNAME").HasMaxLength(150);
            builder.Property(t => t.FirmPasswordParameterName).HasColumnName("FIRMPASSWORDPARAMETERNAME").HasMaxLength(150);
            builder.Property(t => t.CallTimeout).HasColumnName("CALLTIMEOUT");
            builder.Property(t => t.HttpVerb).HasColumnName("HTTPVERB");
            builder.Property(t => t.ApplicationCodeParameterName).HasColumnName("APPLICATIONCODEPARAMETERNAME").HasMaxLength(150);
            builder.Property(t => t.OrganizationCodeParameterName).HasColumnName("ORGANIZATIONCODEPARAMETERNAME").HasMaxLength(150);
        }
    }
}