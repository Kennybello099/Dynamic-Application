using Dynamic_Application.Common;

namespace Dynamic_Application.model
{
    public class DataBaseLog : BaseEntity
    {
        public string? EntityClass { get; set; }

        public string? LogType { get; set; }

        public string? Value { get; set; }

    }
}
