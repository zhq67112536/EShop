﻿using EasyAbp.EShop.Orders.Orders;
using EasyAbp.EShop.Stores;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Orders
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(EShopOrdersDomainSharedModule),
        typeof(EShopStoresDomainSharedModule)
        )]
    public class EShopOrdersDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<EShopOrdersDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<OrdersDomainAutoMapperProfile>(validate: true);
            });

            Configure<AbpDistributedEventBusOptions>(options =>
            {
                options.EtoMappings.Add<Order, OrderEto>(typeof(EShopOrdersDomainModule));
            });
        }
    }
}
