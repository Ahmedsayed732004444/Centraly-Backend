using System;
using System.IO;
using System.Text.RegularExpressions;

var batchFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Entities\Inventory\ProductBatch.cs";
var batchContent = File.ReadAllText(batchFile);
batchContent = batchContent.Replace("public decimal RetailPrice { get; set; }", "public decimal RetailPrice { get; set; }\n    public decimal MaintenancePrice { get; set; }");
File.WriteAllText(batchFile, batchContent);

var reqFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Contracts\Suppliers\CreatePurchaseInvoiceItemRequest.cs";
var reqContent = File.ReadAllText(reqFile);
reqContent = reqContent.Replace("decimal RetailPrice     // New Batch Retail Price", "decimal RetailPrice,     // New Batch Retail Price\n    decimal? MaintenancePrice // Maintenance Price");
File.WriteAllText(reqFile, reqContent);

var batchResFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Contracts\Inventory\Products\ProductResponse.cs";
var batchResContent = File.ReadAllText(batchResFile);
batchResContent = batchResContent.Replace("decimal RetailPrice,", "decimal RetailPrice,\n    decimal MaintenancePrice,");
File.WriteAllText(batchResFile, batchResContent);

var invoiceSvcFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\PurchaseInvoiceService.cs";
var invoiceSvcContent = File.ReadAllText(invoiceSvcFile);
invoiceSvcContent = invoiceSvcContent.Replace("RetailPrice = itemReq.RetailPrice,", "RetailPrice = itemReq.RetailPrice,\n                    MaintenancePrice = itemReq.MaintenancePrice ?? 0,");
File.WriteAllText(invoiceSvcFile, invoiceSvcContent);

var prodSvcFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\ProductService.cs";
var prodSvcContent = File.ReadAllText(prodSvcFile);
prodSvcContent = prodSvcContent.Replace("b.RetailPrice,", "b.RetailPrice,\n                  b.MaintenancePrice,");
prodSvcContent = prodSvcContent.Replace("b.RetailPrice,\n                  b.DateReceived", "b.RetailPrice,\n                  b.MaintenancePrice,\n                  b.DateReceived");
File.WriteAllText(prodSvcFile, prodSvcContent);
