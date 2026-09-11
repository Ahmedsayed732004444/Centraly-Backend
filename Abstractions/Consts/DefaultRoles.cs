namespace Centraly.Api.Abstractions.Consts;

public static class DefaultRoles
{
    public partial class Admin
    {
        public const string Name = nameof(Admin);
        public const string Id = "0191a4b6-c4fc-752e-9d95-40b5e4e68054";
        public const string ConcurrencyStamp = "0191a4b6-c4fc-752e-9d95-40b631d1866d";
    }
    public partial class Manager
    {
        public const string Name = nameof(Manager);
        public const string Id = "6340d7c9-5aba-483f-90ad-29979e56999b";
        public const string ConcurrencyStamp = "fb6de3d0-ca0a-44d4-97d4-03caa996184a";
    }

    public partial class Salesperson
    {
        public const string Name = nameof(Salesperson);
        public const string Id = "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0";
        public const string ConcurrencyStamp = "0191a4b6-c4fc-752e-9d95-40b85cf3fd22";
    }

    public partial class Technician
    {
        public const string Name = nameof(Technician);
        public const string Id = "4ec432f6-c564-4291-b079-98636f8b8b1d";
        public const string ConcurrencyStamp = "19a49e8c-9372-4b21-937b-9304b99a4d01";
    }
}