namespace BlazorFront.Mutations
{
    public class Mutations
    {
        public const string CREATE_CONTRACT = "mutation CreateContract{{createContract(newContract:{{ name: \"{0}\", contractType: \"{1}\"}}){{id name contractType }}}}";
        public const string CREATE_CONTRACT_OPERATION_NAME = "CreateContract";
    }
}
