using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface ILookupService
    {
        IList<EnumLookupItem> EnumList(string enumName);
        IList<LookupItem> ListDefList(string listDefName, string listFilterExpression, string linkFilterExpression);
    }
}
