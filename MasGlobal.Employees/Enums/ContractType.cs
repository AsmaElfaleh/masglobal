using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MasGlobal.Employees.Enums
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ContractType
    {
        [EnumMember(Value = "HourlySalaryEmployee")]
        HourlySalaryEmployee,
        [EnumMember(Value = "MonthlySalaryEmployee")]
        MonthlySalaryEmployee

    }
}
