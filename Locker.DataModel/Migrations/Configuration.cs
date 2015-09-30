namespace Tz.Locker.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tz.Common.DataModel.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Tz.Locker.DataModel.LockerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new SkipReadonlyEntityCodeMigration();
        }

        protected override void Seed(Tz.Locker.DataModel.LockerDbContext context)
        {
            var lockerBankTzSydney1 = Guid.Parse("042E3E9B-74EE-4EF0-86DE-B59D7BA90474");
            var lockerBankTzSydney2 = Guid.Parse("F5C47FAA-BABD-4FF1-8100-00CD7780AAD3");

            var lockerBankPrometheusSydney1 = Guid.Parse("B3BD92CE-FE9F-4172-AFDE-04B146ACBA4F");
            var lockerBankPrometheusSydney2 = Guid.Parse("78C0C253-843D-48E3-B275-D2FCBC9C9D72");


            var propertyPromentusSydney = Guid.Parse("1D4B448B-4E69-4ECA-A06E-E7F85256C920");

            var propertyTzSydney = Guid.Parse("0ABAA1CF-C482-4E89-A0E9-BF232F7D97C3");


            var tzLocker1 = Guid.Parse("9EEE2627-24C9-461B-A362-E17FDFB4549C");

            var tzLocker2 = Guid.Parse("80C7B2FB-6CCC-42C2-B7E6-02F3A6E61D2E");


            var promethusLocker1 = Guid.Parse("0617BE94-4AC1-4DB3-8B95-6D6D2B97C50E");

            var promethusLocker2 = Guid.Parse("09A8C4BF-6F69-4E28-961D-0C5671228258");



            var tzLocker1Device = Guid.Parse("8E137415-F817-4886-830F-9B425B4DAC85");

            var tzLocker2Device = Guid.Parse("A012B138-917D-465B-8724-0196952056E4");


            var promethusLocker1Device = Guid.Parse("BD2A56E0-2061-40A2-8D71-6BE5E7F46080");

            var promethusLocker2Device = Guid.Parse("5D1CE7F3-D04D-4BAB-AFB3-0061B4955D71");

            context.LockerBanks.AddOrUpdate(lb => lb.LockerBankId, new LockerBank
            {
                LockerBankId=lockerBankTzSydney1,
                BuildingPropertyId=propertyTzSydney,
                IpAddress="127.0.0.1",
                IsEnabled=true,
                Description="Tz sydney locker 1",
                LockerBankCode="TzLocker1",
                Name="Tz locker 1"
            });

            context.LockerBanks.AddOrUpdate(lb => lb.LockerBankId, new LockerBank
            {
                LockerBankId = lockerBankTzSydney2,
                BuildingPropertyId = propertyTzSydney,
                IpAddress = "127.0.0.1",
                IsEnabled = true,
                Description = "Tz sydney locker 2",
                LockerBankCode = "TzLocker2",
                Name = "Tz locker 2"
            });

            context.LockerBanks.AddOrUpdate(lb => lb.LockerBankId, new LockerBank
            {
                LockerBankId = lockerBankPrometheusSydney1,
                BuildingPropertyId = propertyPromentusSydney,
                IpAddress = "127.0.0.1",
                IsEnabled = true,
                Description = "Prometheus sydney locker 1",
                LockerBankCode = "PrometheusLocker1",
                Name = "Prometheus locker 2"
            });

            context.LockerBanks.AddOrUpdate(lb => lb.LockerBankId, new LockerBank
            {
                LockerBankId = lockerBankPrometheusSydney2,
                BuildingPropertyId = propertyPromentusSydney,
                IpAddress = "127.0.0.1",
                IsEnabled = true,
                Description = "Prometheus sydney locker 2",
                LockerBankCode = "PrometheusLocker2",
                Name = "Prometheus locker 2"
            });



            #region TzLockers
            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = tzLocker1,
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L1",
                Column = 1


            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = tzLocker2,
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L2",
                Column = 1

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L3",
                Column = 1

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L4",
                Column = 2

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L5",
                Column = 2

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L6",
                Column = 2

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L7",
                Column = 3

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L8",
                Column = 3

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankTzSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L9",
                Column = 3

            });

            #endregion


            #region PromethusLockers
            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = promethusLocker1,
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L1",
                Column = 1

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = promethusLocker2,
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L2",
                Column = 1

            });


            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L3",
                Column = 1

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L4",
                Column = 2

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L5",
                Column = 2

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L6",
                Column = 2

            });


            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L7",
                Column = 3

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L8",
                Column = 3

            });

            context.Lockers.AddOrUpdate(lo => lo.LockerId, new Locker
            {
                LockerId = Guid.NewGuid(),
                LockerBankId = lockerBankPrometheusSydney1,
                Size = Tz.Common.Values.Enums.Size.Medium,
                State = Tz.Common.Values.Enums.LockerState.Available,
                LockerNumber = "L9",
                Column = 3

            }); 
            #endregion

            context.Devices.AddOrUpdate(de => de.DeviceId, new Device
            {
                DeviceId=tzLocker1Device,
                IsEnabled=true,
                LockerBankId=lockerBankTzSydney1,
                DeviceType=Tz.Common.Values.Enums.DeviceType.Radials,
                SerialNumber="00000088BB"
            });

            context.Devices.AddOrUpdate(de => de.DeviceId, new Device
            {
                DeviceId = tzLocker2Device,
                IsEnabled = true,
                LockerBankId = lockerBankTzSydney1,
                DeviceType = Tz.Common.Values.Enums.DeviceType.Radials,
                SerialNumber = "0000005EBC"
            });

            context.Devices.AddOrUpdate(de => de.DeviceId, new Device
            {
                DeviceId = promethusLocker1Device,
                IsEnabled = true,
                LockerBankId = lockerBankPrometheusSydney1,
                DeviceType = Tz.Common.Values.Enums.DeviceType.Radials,
                SerialNumber = "00000023C7"
            });

            context.Devices.AddOrUpdate(de => de.DeviceId, new Device
            {
                DeviceId = promethusLocker2Device,
                IsEnabled = true,
                LockerBankId = lockerBankPrometheusSydney1,
                DeviceType = Tz.Common.Values.Enums.DeviceType.Radials,
                SerialNumber = "00000023C7"
            });


            context.LockerToDevices.AddOrUpdate(ltod => ltod.LockerToDeviceId, new Entity.LockerToDevice
            {
                LockerId=tzLocker1,
                DeviceId=tzLocker1Device
            });

            context.LockerToDevices.AddOrUpdate(ltod => ltod.LockerToDeviceId, new Entity.LockerToDevice
            {
                LockerId = tzLocker2,
                DeviceId = tzLocker2Device
            });

            context.LockerToDevices.AddOrUpdate(ltod => ltod.LockerToDeviceId, new Entity.LockerToDevice
            {
                LockerId = promethusLocker1,
                DeviceId = promethusLocker1Device
            });

            context.LockerToDevices.AddOrUpdate(ltod => ltod.LockerToDeviceId, new Entity.LockerToDevice
            {
                LockerId = promethusLocker2,
                DeviceId = promethusLocker2Device
            });

            context.SaveChanges();
        }
    }
}
