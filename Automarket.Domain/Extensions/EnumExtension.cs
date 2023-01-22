using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this System.Enum enumName)
        {
            return enumName.GetType().GetMember(enumName.ToString()).First().GetCustomAttribute<DisplayAttribute>()
        ?.GetName() ?? "Неопределённый";
        }

    }
}
