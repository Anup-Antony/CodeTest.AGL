using System.Runtime.Serialization;

namespace CodeTest.Agl.Api.Constants
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male,
        [EnumMember(Value = "Female")]
        Female
    }
}
