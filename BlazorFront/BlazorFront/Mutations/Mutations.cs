namespace BlazorFront.Mutations
{
    public class Mutations
    {
        public const string CREATE_CONTRACT = "mutation CreateContract{{createContract(newContract:{{ name: \"{0}\", contractType: \"{1}\"}}){{id name contractType }}}}";
        public const string CREATE_CONTRACT_OPERATION_NAME = "CreateContract";

        public const string UPDATE_CONTRACT = "mutation UpdateContract{{updateContract(updateContract:{{ id: \"{0}\", name: \"{1}\", contractType: \"{2}\"}}){{id name contractType }}}}";
        public const string UPDATE_CONTRACT_OPERATION_NAME = "UpdateContract";

        public const string DELETE_CONTRACT = "mutation DeleteContract{{deleteContract(deleteContract:{{ id: \"{0}\"}}){{id}}}}";
        public const string DELETE_CONTRACT_OPERATION_NAME = "DeleteContract";
    }
}
