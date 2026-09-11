using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Sales;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class SalesMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Customers
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<CustomerResponse> ProjectToResponse(this IQueryable<Customer> query)
    {
        return query
            .Where(c => !c.IsDeleted)
            .AsNoTracking()
            .Select(c => new CustomerResponse(
                c.Id,
                c.Name,
                c.Phone,
                c.DebtBalance,
                c.Invoices.Count(i => !i.IsDeleted),
                c.CreatedAt));
    }

    public static IQueryable<CustomerInvoiceSummary> ProjectToSummary(this IQueryable<Invoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new CustomerInvoiceSummary(
                i.Id,
                i.InvoiceNumber,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.CreatedAt));
    }

    public static IQueryable<CustomerDebtPaymentResponse> ProjectToResponse(this IQueryable<CustomerDebtPayment> query)
    {
        return query
            .AsNoTracking()
            .Select(p => new CustomerDebtPaymentResponse(
                p.Id,
                new CustomerSummary(p.Customer!.Id, p.Customer.Name, p.Customer.Phone),
                p.Amount,
                p.PaymentDate,
                p.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Sales Invoices
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SalesInvoiceResponse> ProjectToResponse(this IQueryable<Invoice> query, ApplicationDbContext dbContext)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new SalesInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                i.Customer != null ? new CustomerSummary(i.Customer.Id, i.Customer.Name, i.Customer.Phone) : null,
                (SaleTypeDto)i.SaleType,
                (PaymentMethodDto)i.PaymentMethod,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.Notes,
                i.CreatedAt,
                i.Returns.Any(r => !r.IsDeleted),
                i.Items.Select(item => new SalesInvoiceItemResponse(
                    item.Id,
                    item.ProductId,
                    item.Product != null ? item.Product.Name ?? "Unknown" : "Unknown",
                    item.BatchId,
                    item.Quantity,
                    dbContext.ReturnItems
                        .Where(ri => ri.ReturnRecord.InvoiceId == i.Id && ri.ProductId == item.ProductId && ri.BatchId == item.BatchId)
                        .Sum(ri => (int?)ri.Quantity) ?? 0,
                    item.UnitPrice,
                    item.UnitCost,
                    item.Quantity * item.UnitPrice))
                    .ToList()));
    }

    public static IQueryable<SalesInvoiceResponse> ProjectToSummaryResponse(this IQueryable<Invoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new SalesInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                i.Customer != null ? new CustomerSummary(i.Customer.Id, i.Customer.Name, i.Customer.Phone) : null,
                (SaleTypeDto)i.SaleType,
                (PaymentMethodDto)i.PaymentMethod,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.Notes,
                i.CreatedAt,
                i.Returns.Any(r => !r.IsDeleted),
                new List<SalesInvoiceItemResponse>()));
    }
    // ─────────────────────────────────────────────────────────────────
    //  Sales Returns
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<ReturnRecordResponse> ProjectToResponse(this IQueryable<ReturnRecord> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new ReturnRecordResponse(
                r.Id,
                r.InvoiceId,
                r.Invoice != null ? r.Invoice.InvoiceNumber : "",
                r.IsFullInvoiceReturn,
                (ReturnReasonDto)r.Reason,
                r.Notes,
                false, // IsCashRefund
                r.TotalReturnedAmount,
                r.ReturnDate,
                r.Items.Select(item => new ReturnItemResponse(
                    item.Id, item.ProductId, item.BatchId, item.Quantity, item.UnitPrice))
                    .ToList()));
    }

    public static IQueryable<ReturnRecordResponse> ProjectToSummaryResponse(this IQueryable<ReturnRecord> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new ReturnRecordResponse(
                r.Id,
                r.InvoiceId,
                r.Invoice != null ? r.Invoice.InvoiceNumber : "",
                r.IsFullInvoiceReturn,
                (ReturnReasonDto)r.Reason,
                r.Notes,
                false,
                r.TotalReturnedAmount,
                r.ReturnDate,
                new List<ReturnItemResponse>()));
    }
}
