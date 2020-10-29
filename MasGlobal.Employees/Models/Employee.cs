using MasGlobal.Employees.Enums;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace MasGlobal.Employees.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Employee : IEquatable<Employee>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ContractTypeName
        /// </summary>
        [DataMember(Name = "contractTypeName")]        
        public string ContractTypeName { get; set; }

        /// <summary>
        /// Gets or Sets RoleId
        /// </summary>
        [DataMember(Name = "roleId")]
        public int? RoleId { get; set; }

        /// <summary>
        /// Gets or Sets RoleName
        /// </summary>
        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or Sets RoleDescription
        /// </summary>
        [DataMember(Name = "roleDescription")]
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or Sets HourlySalary
        /// </summary>
        [DataMember(Name = "hourlySalary")]
        public double? HourlySalary { get; set; }

        /// <summary>
        /// Gets or Sets MonthlySalary
        /// </summary>
        [DataMember(Name = "monthlySalary")]
        public double? MonthlySalary { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Employee {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ContractTypeName: ").Append(ContractTypeName).Append("\n");
            sb.Append("  RoleId: ").Append(RoleId).Append("\n");
            sb.Append("  RoleName: ").Append(RoleName).Append("\n");
            sb.Append("  RoleDescription: ").Append(RoleDescription).Append("\n");
            sb.Append("  HourlySalary: ").Append(HourlySalary).Append("\n");
            sb.Append("  MonthlySalary: ").Append(MonthlySalary).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Employee)obj);
        }

        /// <summary>
        /// Returns true if Employee instances are equal
        /// </summary>
        /// <param name="other">Instance of Employee to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Employee other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    ContractTypeName == other.ContractTypeName ||
                    ContractTypeName != null &&
                    ContractTypeName.Equals(other.ContractTypeName)
                ) &&
                (
                    RoleId == other.RoleId ||
                    RoleId != null &&
                    RoleId.Equals(other.RoleId)
                ) &&
                (
                    RoleName == other.RoleName ||
                    RoleName != null &&
                    RoleName.Equals(other.RoleName)
                ) &&
                (
                    RoleDescription == other.RoleDescription ||
                    RoleDescription != null &&
                    RoleDescription.Equals(other.RoleDescription)
                ) &&
                (
                    HourlySalary == other.HourlySalary ||
                    HourlySalary != null &&
                    HourlySalary.Equals(other.HourlySalary)
                ) &&
                (
                    MonthlySalary == other.MonthlySalary ||
                    MonthlySalary != null &&
                    MonthlySalary.Equals(other.MonthlySalary)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (ContractTypeName != null)
                    hashCode = hashCode * 59 + ContractTypeName.GetHashCode();
                if (RoleId != null)
                    hashCode = hashCode * 59 + RoleId.GetHashCode();
                if (RoleName != null)
                    hashCode = hashCode * 59 + RoleName.GetHashCode();
                if (RoleDescription != null)
                    hashCode = hashCode * 59 + RoleDescription.GetHashCode();
                if (HourlySalary != null)
                    hashCode = hashCode * 59 + HourlySalary.GetHashCode();
                if (MonthlySalary != null)
                    hashCode = hashCode * 59 + MonthlySalary.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
