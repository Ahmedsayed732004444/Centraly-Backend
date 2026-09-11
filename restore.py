import os

path = r'C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Dependencies.cs'
with open(path, 'r', encoding='utf-8') as f:
    c = f.read()

services_add = '''
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.IProductService, Centraly.Api.Services.Implementation.ProductService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISupplierService, Centraly.Api.Services.Implementation.SupplierService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISupplierTransactionService, Centraly.Api.Services.Implementation.SupplierTransactionService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.IPurchaseInvoiceService, Centraly.Api.Services.Implementation.PurchaseInvoiceService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISalesInvoiceService, Centraly.Api.Services.Implementation.SalesInvoiceService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ICustomerTransactionService, Centraly.Api.Services.Implementation.CustomerTransactionService>();
'''
c = c.replace('services.AddScoped<IAuthService, AuthService>();', services_add)

with open(path, 'w', encoding='utf-8') as f:
    f.write(c)
