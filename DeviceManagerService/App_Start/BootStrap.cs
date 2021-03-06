﻿using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using TZ.ServiceModel;
using Tz.LockerBank.Common.Interface.CardReaderConversion;

namespace Tz.DeviceManagerService.App_Start
{
    public static class Bootstrapper
    {
        public static readonly IContainer Container;

        static Bootstrapper()
        {
            var builder = new ContainerBuilder();

            Register(builder);

            var container = builder.Build();

            var device = container.Resolve<IDeviceManager>();

            Container = container;

        }

        private static void Register(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterType<LogService>().As<ILogger>().SingleInstance();// .Register<ILogger, LogService>(Lifestyle.Singleton);

            containerBuilder.RegisterType<ComPortProvider>().As<IComPortProvider>().SingleInstance();
            containerBuilder.RegisterType<DeviceManager>().As<IDeviceManager>().SingleInstance();

            containerBuilder.RegisterType<DeviceManagerServiceHost>().As<IDeviceManagerService>();
            containerBuilder.RegisterType<LockerBankIdentifier>().As<ILockerBankIdentifier>();
            containerBuilder.RegisterType<CardReaderListner>().As<ICardReaderService>().SingleInstance();
            containerBuilder.RegisterType<CardReaderService>().As<ICardReaderEventsSubscribe>().SingleInstance();
            containerBuilder.RegisterType<CardReaderService>().As<IWebCardReaderEventsSubscribe>().SingleInstance();
            containerBuilder.RegisterType<HidStandard35BitConversion>().As<ICardReaderConversionService>().SingleInstance();

            //var deviceManager =container.GetInstance<IDeviceManager>();
        }
    }
}
